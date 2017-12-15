using System;
using System.Windows.Forms;

namespace lab5
{
    public partial class Form1 : Form
    {
        private DeviceFinder deviceFinder;
        private int selectedIndex;

        public Form1()
        {
            InitializeComponent();

            deviceFinder = new DeviceFinder();
            deviceFinder.FindDevices();
            PaintUI();
        }

        private void PaintUI()
        {
            listView1.Scrollable = true;

            listView1.View = View.Details;
            listView1.HeaderStyle = ColumnHeaderStyle.None;

            listView2.HeaderStyle = ColumnHeaderStyle.None;

            button1.Enabled = false;

            label5.Text = "System name: " + deviceFinder.SystemName;

            foreach (var device in deviceFinder.devices)
            {
                addComponent(device);
            }
        }

        private void addComponent(Device device)
        {
            listView1.Items.Add(device.Name);
        }

        private void addDescription()
        {
            listView2.Clear();

            listView2.Items.Add("Name: " + deviceFinder.devices[selectedIndex].Name);
            listView2.Items.Add("DeviceID: " + deviceFinder.devices[selectedIndex].DeviceID);
            listView2.Items.Add("GUID: " + deviceFinder.devices[selectedIndex].GUID);
            listView2.Items.Add("Manufacturer: " + deviceFinder.devices[selectedIndex].Manufacturer);

            listView2.Items.Add("\nHardwareIDInfo: ");
            try
            {
                foreach (var hardwareID in deviceFinder.devices[selectedIndex].HardwareID)
                {
                    listView2.Items.Add(hardwareID);
                }
            }
            catch (NullReferenceException) { }

            if (deviceFinder.devices[selectedIndex].SysFiles.Count != 0)
            {
                listView2.Items.Add("Sys Files: ");
                foreach (var sysFile in deviceFinder.devices[selectedIndex].SysFiles)
                {
                    listView2.Items.Add("Path: " + sysFile.Path);
                    listView2.Items.Add("Description: " + sysFile.Description);
                }
            }

            listView2.Items.Add("Status: " + (deviceFinder.devices[selectedIndex].Status ? "on" : "off"));

            button1.Text = (deviceFinder.devices[selectedIndex].Status ? "Turn off" : "Turn on");
            button1.Enabled = true;
        }

   

        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                var selected = listView1.FocusedItem;

                if (selected != null && selected.Bounds.Contains(e.Location) == true)
                {
                    selectedIndex = selected.Index;
                    addDescription();
                }

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (deviceFinder.devices[listView1.FocusedItem.Index].Status)
            {
                if (deviceFinder.TurnOff(deviceFinder.devices[selectedIndex]))
                {
                    MessageBox.Show(@"Done!");
                }
                else
                {
                     MessageBox.Show(@"Try again!");
                }
            }
            else
            {
                if (deviceFinder.TurnOn(deviceFinder.devices[selectedIndex]))
                {
                    MessageBox.Show(@"Done!");
                }
                else
                {
                    MessageBox.Show(@"Try again!");
                }

            }

            addDescription();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

    }
}
