using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Windows.Forms;
using IMAPI2.Interop;
using IMAPI2.MediaItem;

namespace lab7
{
    public partial class Form1 : Form
    {
        private Int64 totalSize;
        private bool isBurning;
        private BurnData burnData = new BurnData();

        public Form1()
        {
            InitializeComponent();
            notifyIcon1.Visible = false;
            notifyIcon1.MouseDoubleClick += new MouseEventHandler(notifyIcon1_MouseDoubleClick);
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                ShowInTaskbar = false;
                notifyIcon1.Visible = true;
            }
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            notifyIcon1.Visible = false;
            ShowInTaskbar = true;
            WindowState = FormWindowState.Normal;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Determine the current recording devices
            MsftDiscMaster2 discMaster = null;
            try
            {
                discMaster = new MsftDiscMaster2();
                if (!discMaster.IsSupportedEnvironment)
                {
                    return;
                }

                foreach (string uniqueRecorderId in discMaster)
                {
                    var discRecorder2 = new MsftDiscRecorder2();
                    discRecorder2.InitializeDiscRecorder(uniqueRecorderId);
                    comboBox1.Items.Add(discRecorder2);
                }

                try
                {
                    comboBox1.SelectedIndex = 0;
                }
                catch (ArgumentOutOfRangeException)
                {

                }
            }
            catch (COMException)
            {
                return;
            }
            finally
            {
                if (discMaster != null)
                {
                    Marshal.ReleaseComObject(discMaster);
                }
            }

            textBoxLabel.Text = "Enter_Label";
            statusLabel.Text = string.Empty;
            UpdateStorageInfo();
        }

        private void devicesComboBox_Format(object sender, ListControlConvertEventArgs e)
        {
            IDiscRecorder2 discRecorder2 = (IDiscRecorder2)e.ListItem;
            string devicePaths = string.Empty;
            string volumePath = (string)discRecorder2.VolumePathNames.GetValue(0);
            foreach (string volPath in discRecorder2.VolumePathNames)
            {
                if (!string.IsNullOrEmpty(devicePaths))
                {
                    devicePaths += ",";
                }
                devicePaths += volumePath;
            }

            e.Value = string.Format("{0} [{1}]", devicePaths, discRecorder2.ProductId);
        }

        private void detectButton_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == -1)
            {
                return;
            }

            var discRecorder = (IDiscRecorder2)comboBox1.Items[comboBox1.SelectedIndex];
            MsftFileSystemImage fileSystemImage = null;
            MsftDiscFormat2Data discFormatData = null;

            statusLabel.Text = String.Empty;

            try
            {
                // Create and initialize the IDiscFormat2Data
                discFormatData = new MsftDiscFormat2Data();
                if (!discFormatData.IsCurrentMediaSupported(discRecorder))
                {
                    totalSizeLabel.Text = "Not supported!";
                    progressBarCapacity.Value = 0;
                    totalSize = 0;
                    return;
                }
                else
                {
                    // Get the media type in the recorder
                    discFormatData.Recorder = discRecorder;
                    IMAPI_MEDIA_PHYSICAL_TYPE mediaType = discFormatData.CurrentPhysicalMediaType;

                    // Create a file system and select the media type
                    fileSystemImage = new MsftFileSystemImage();
                    fileSystemImage.ChooseImageDefaultsForMediaType(mediaType);

                    totalSize = 2048 * fileSystemImage.FreeMediaBlocks;
                }
            }
            catch (COMException)
            {

            }
            finally
            {
                if (discFormatData != null)
                {
                    Marshal.ReleaseComObject(discFormatData);
                }

                if (fileSystemImage != null)
                {
                    Marshal.ReleaseComObject(fileSystemImage);
                }
            }
            UpdateStorageInfo();
        }

        private void buttonAddFiles_Click(object sender, EventArgs e)
        {
            if (!isBurning)
            {
                if (openFileDialog.ShowDialog(this) == DialogResult.OK)
                {
                    var fileItem = new FileItem(openFileDialog.FileName);
                    listBoxFiles.Items.Add(fileItem);

                    UpdateStorageInfo();
                }
            }
        }

        private void buttonRemoveFiles_Click(object sender, EventArgs e)
        {
            if (!isBurning)
            {
                var mediaItem = (IMediaItem)listBoxFiles.SelectedItem;
                if (mediaItem != null)
                {
                    listBoxFiles.Items.Remove(mediaItem);
                    UpdateStorageInfo();
                }
            }
        }

        private void buttonBurn_Click(object sender, EventArgs e)
        {
            if (!isBurning && comboBox1.SelectedIndex != -1 && UpdateStorageInfo())
            {
                isBurning = true;
                var discRecorder = (IDiscRecorder2)comboBox1.Items[comboBox1.SelectedIndex];
                burnData.uniqueRecorderId = discRecorder.ActiveDiscRecorder;
                backgroundWorker1.RunWorkerAsync(burnData);
            }
        }

        private bool UpdateStorageInfo()
        {
            totalSizeLabel.Text = string.Format("{0}MB", totalSize / 1000000);

            // Calculate the size of the files
            Int64 totalMediaSize = 0;
            foreach (IMediaItem mediaItem in listBoxFiles.Items)
            {
                totalMediaSize += mediaItem.SizeOnDisc;
            }

            try
            {
                var percent = (int)((totalMediaSize * 100) / totalSize);
                progressBarCapacity.Value = (percent > 100) ? 100 : percent;
                return (percent < 100 && totalMediaSize != 0);
            }
            catch (DivideByZeroException)
            {
                progressBarCapacity.Value = 0;
                return false;
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            MsftDiscRecorder2 discRecorder = null;
            MsftDiscFormat2Data discFormatData = null;

            try
            {
                // Create and initialize the IDiscRecorder2 object
                discRecorder = new MsftDiscRecorder2();
                var burnData = (BurnData)e.Argument;
                discRecorder.InitializeDiscRecorder(burnData.uniqueRecorderId);

                // Create and initialize the IDiscFormat2Data
                discFormatData = new MsftDiscFormat2Data
                {
                    Recorder = discRecorder,
                    ClientName = "burnMedia",
                    ForceMediaToBeClosed = true
                };

                // Set the verification level
                var burnVerification = (IBurnVerification)discFormatData;
                burnVerification.BurnVerificationLevel = IMAPI_BURN_VERIFICATION_LEVEL.IMAPI_BURN_VERIFICATION_NONE;

                // Create the file system
                IStream fileSystem;
                if (!CreateMediaFileSystemImage(discRecorder, out fileSystem))
                {
                    e.Result = -1;
                    return;
                }
                discFormatData.Update += discFormatData_Update;

                // Write the data here
                try
                {
                    discFormatData.Write(fileSystem);
                    e.Result = 0;
                }
                catch (COMException ex)
                {
                    e.Result = ex.ErrorCode;
                    MessageBox.Show(ex.Message, "IDiscFormat2Data.Write failed",
                        MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                finally
                {
                    if (fileSystem != null)
                    {
                        Marshal.FinalReleaseComObject(fileSystem);
                    }
                }

                discFormatData.Update -= discFormatData_Update;
            }
            catch (COMException exception)
            {
                // If anything happens during the format, show the message
                MessageBox.Show(exception.Message);
                e.Result = exception.ErrorCode;
            }
            finally
            {
                if (discRecorder != null)
                {
                    Marshal.ReleaseComObject(discRecorder);
                }

                if (discFormatData != null)
                {
                    Marshal.ReleaseComObject(discFormatData);
                }
            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            var burnData = (BurnData)e.UserState;

            if (burnData.task == BURN_MEDIA_TASK.BURN_MEDIA_TASK_FILE_SYSTEM)
            {
                statusLabel.Text = burnData.statusMessage;
            }
            else if (burnData.task == BURN_MEDIA_TASK.BURN_MEDIA_TASK_WRITING)
            {
                switch (burnData.currentAction)
                {
                    case IMAPI_FORMAT2_DATA_WRITE_ACTION.IMAPI_FORMAT2_DATA_WRITE_ACTION_VALIDATING_MEDIA:
                        statusLabel.Text = "Validating current media...";
                        break;

                    case IMAPI_FORMAT2_DATA_WRITE_ACTION.IMAPI_FORMAT2_DATA_WRITE_ACTION_FORMATTING_MEDIA:
                        statusLabel.Text = "Formatting media...";
                        break;

                    case IMAPI_FORMAT2_DATA_WRITE_ACTION.IMAPI_FORMAT2_DATA_WRITE_ACTION_INITIALIZING_HARDWARE:
                        statusLabel.Text = "Initializing hardware...";
                        break;

                    case IMAPI_FORMAT2_DATA_WRITE_ACTION.IMAPI_FORMAT2_DATA_WRITE_ACTION_CALIBRATING_POWER:
                        statusLabel.Text = "Optimizing laser intensity...";
                        break;

                    case IMAPI_FORMAT2_DATA_WRITE_ACTION.IMAPI_FORMAT2_DATA_WRITE_ACTION_WRITING_DATA:
                        long writtenSectors = burnData.lastWrittenLba - burnData.startLba;
                        if (writtenSectors > 0 && burnData.sectorCount > 0)
                        {
                            var percent = (int)((100 * writtenSectors) / burnData.sectorCount);
                            statusLabel.Text = string.Format("Progress: {0}%", percent);
                            statusProgressBar.Value = percent;
                        }
                        else
                        {
                            statusLabel.Text = "Progress 0%";
                            statusProgressBar.Value = 0;
                        }
                        break;

                    case IMAPI_FORMAT2_DATA_WRITE_ACTION.IMAPI_FORMAT2_DATA_WRITE_ACTION_FINALIZATION:
                        statusLabel.Text = "Finalizing writing...";
                        break;

                    case IMAPI_FORMAT2_DATA_WRITE_ACTION.IMAPI_FORMAT2_DATA_WRITE_ACTION_COMPLETED:
                        statusLabel.Text = "Completed!";
                        break;

                    case IMAPI_FORMAT2_DATA_WRITE_ACTION.IMAPI_FORMAT2_DATA_WRITE_ACTION_VERIFYING:
                        statusLabel.Text = "Verifying";
                        break;
                }
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            statusLabel.Text = ((int)e.Result == 0) ? "Finished!" : "Error!";
            statusProgressBar.Value = 0;
            isBurning = false;

            MessageBox.Show("Burning finished", statusLabel.Text, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
            notifyIcon1.Visible = false;
            ShowInTaskbar = true;
            WindowState = FormWindowState.Normal;
        }

        private bool CreateMediaFileSystemImage(IDiscRecorder2 discRecorder, out IStream dataStream)
        {
            MsftFileSystemImage fileSystemImage = null;
            try
            {
                fileSystemImage = new MsftFileSystemImage();
                fileSystemImage.ChooseImageDefaults(discRecorder);
                fileSystemImage.FileSystemsToCreate = FsiFileSystems.FsiFileSystemJoliet | FsiFileSystems.FsiFileSystemISO9660;
                fileSystemImage.VolumeName = textBoxLabel.Text;

                // Add Files to File System Image
                foreach (IMediaItem mediaItem in listBoxFiles.Items)
                {
                    mediaItem.AddToFileSystem(fileSystemImage.Root);
                }

                dataStream = fileSystemImage.CreateResultImage().ImageStream;
            }
            catch (COMException)
            {
                dataStream = null;
                return false;
            }
            finally
            {
                if (fileSystemImage != null)
                {
                    Marshal.ReleaseComObject(fileSystemImage);
                }
            }

            return true;
        }

        void discFormatData_Update([In, MarshalAs(UnmanagedType.IDispatch)] object sender, [In, MarshalAs(UnmanagedType.IDispatch)] object progress)
        {
            var eventArgs = (IDiscFormat2DataEventArgs)progress;

            burnData.task = BURN_MEDIA_TASK.BURN_MEDIA_TASK_WRITING;

            // IWriteEngine2EventArgs Interface
            burnData.currentAction = eventArgs.CurrentAction;
            burnData.startLba = eventArgs.StartLba;
            burnData.sectorCount = eventArgs.SectorCount;
            burnData.lastReadLba = eventArgs.LastReadLba;
            burnData.lastWrittenLba = eventArgs.LastWrittenLba;
            burnData.totalSystemBuffer = eventArgs.TotalSystemBuffer;
            burnData.usedSystemBuffer = eventArgs.UsedSystemBuffer;
            burnData.freeSystemBuffer = eventArgs.FreeSystemBuffer;

            backgroundWorker1.ReportProgress(0, burnData);
        }
    }
}

