namespace lab7
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.statusProgressBar = new System.Windows.Forms.ProgressBar();
            this.statusLabel = new System.Windows.Forms.Label();
            this.burnButton = new System.Windows.Forms.Button();
            this.detectButton = new System.Windows.Forms.Button();
            this.totalSizeLabel = new System.Windows.Forms.Label();
            this.progressBarCapacity = new System.Windows.Forms.ProgressBar();
            this.textBoxLabel = new System.Windows.Forms.TextBox();
            this.buttonRemoveFiles = new System.Windows.Forms.Button();
            this.buttonAddFiles = new System.Windows.Forms.Button();
            this.listBoxFiles = new System.Windows.Forms.ListBox();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(16, 15);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(182, 24);
            this.comboBox1.TabIndex = 1;
            this.comboBox1.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.devicesComboBox_Format);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "All Files (*.*)|*.*";
            // 
            // statusProgressBar
            // 
            this.statusProgressBar.Location = new System.Drawing.Point(285, 91);
            this.statusProgressBar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.statusProgressBar.Name = "statusProgressBar";
            this.statusProgressBar.Size = new System.Drawing.Size(166, 18);
            this.statusProgressBar.TabIndex = 8;
            // 
            // statusLabel
            // 
            this.statusLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.statusLabel.Location = new System.Drawing.Point(285, 64);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(166, 23);
            this.statusLabel.TabIndex = 7;
            this.statusLabel.Text = "State";
            this.statusLabel.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // burnButton
            // 
            this.burnButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.burnButton.Location = new System.Drawing.Point(300, 134);
            this.burnButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.burnButton.Name = "burnButton";
            this.burnButton.Size = new System.Drawing.Size(128, 33);
            this.burnButton.TabIndex = 6;
            this.burnButton.Text = "BURN!";
            this.burnButton.UseVisualStyleBackColor = true;
            this.burnButton.Click += new System.EventHandler(this.buttonBurn_Click);
            // 
            // detectButton
            // 
            this.detectButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.detectButton.Location = new System.Drawing.Point(204, 15);
            this.detectButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.detectButton.Name = "detectButton";
            this.detectButton.Size = new System.Drawing.Size(72, 24);
            this.detectButton.TabIndex = 9;
            this.detectButton.Text = "Detect";
            this.detectButton.UseVisualStyleBackColor = true;
            this.detectButton.Click += new System.EventHandler(this.detectButton_Click);
            // 
            // totalSizeLabel
            // 
            this.totalSizeLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.totalSizeLabel.AutoSize = true;
            this.totalSizeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.totalSizeLabel.Location = new System.Drawing.Point(366, 14);
            this.totalSizeLabel.Name = "totalSizeLabel";
            this.totalSizeLabel.Size = new System.Drawing.Size(62, 17);
            this.totalSizeLabel.TabIndex = 7;
            this.totalSizeLabel.Text = "totalSize";
            // 
            // progressBarCapacity
            // 
            this.progressBarCapacity.Location = new System.Drawing.Point(288, 35);
            this.progressBarCapacity.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.progressBarCapacity.Name = "progressBarCapacity";
            this.progressBarCapacity.Size = new System.Drawing.Size(163, 15);
            this.progressBarCapacity.Step = 1;
            this.progressBarCapacity.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBarCapacity.TabIndex = 8;
            // 
            // textBoxLabel
            // 
            this.textBoxLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxLabel.Location = new System.Drawing.Point(107, 142);
            this.textBoxLabel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBoxLabel.Name = "textBoxLabel";
            this.textBoxLabel.Size = new System.Drawing.Size(169, 23);
            this.textBoxLabel.TabIndex = 5;
            // 
            // buttonRemoveFiles
            // 
            this.buttonRemoveFiles.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonRemoveFiles.Location = new System.Drawing.Point(47, 139);
            this.buttonRemoveFiles.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonRemoveFiles.Name = "buttonRemoveFiles";
            this.buttonRemoveFiles.Size = new System.Drawing.Size(23, 23);
            this.buttonRemoveFiles.TabIndex = 3;
            this.buttonRemoveFiles.Text = "-";
            this.buttonRemoveFiles.UseVisualStyleBackColor = true;
            this.buttonRemoveFiles.Click += new System.EventHandler(this.buttonRemoveFiles_Click);
            // 
            // buttonAddFiles
            // 
            this.buttonAddFiles.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonAddFiles.Location = new System.Drawing.Point(16, 139);
            this.buttonAddFiles.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonAddFiles.Name = "buttonAddFiles";
            this.buttonAddFiles.Size = new System.Drawing.Size(25, 23);
            this.buttonAddFiles.TabIndex = 1;
            this.buttonAddFiles.Text = "+";
            this.buttonAddFiles.UseVisualStyleBackColor = true;
            this.buttonAddFiles.Click += new System.EventHandler(this.buttonAddFiles_Click);
            // 
            // listBoxFiles
            // 
            this.listBoxFiles.FormattingEnabled = true;
            this.listBoxFiles.ItemHeight = 16;
            this.listBoxFiles.Location = new System.Drawing.Point(16, 50);
            this.listBoxFiles.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.listBoxFiles.Name = "listBoxFiles";
            this.listBoxFiles.Size = new System.Drawing.Size(260, 84);
            this.listBoxFiles.TabIndex = 0;
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "CD Burn";
            this.notifyIcon1.Visible = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(285, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 17);
            this.label1.TabIndex = 10;
            this.label1.Text = "Total Size:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(468, 178);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.detectButton);
            this.Controls.Add(this.textBoxLabel);
            this.Controls.Add(this.burnButton);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.statusProgressBar);
            this.Controls.Add(this.listBoxFiles);
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.buttonRemoveFiles);
            this.Controls.Add(this.totalSizeLabel);
            this.Controls.Add(this.buttonAddFiles);
            this.Controls.Add(this.progressBarCapacity);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form1";
            this.Text = "lab7";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.ProgressBar statusProgressBar;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.Button burnButton;
        private System.Windows.Forms.Button detectButton;
        private System.Windows.Forms.Label totalSizeLabel;
        private System.Windows.Forms.ProgressBar progressBarCapacity;
        private System.Windows.Forms.TextBox textBoxLabel;
        private System.Windows.Forms.Button buttonRemoveFiles;
        private System.Windows.Forms.Button buttonAddFiles;
        private System.Windows.Forms.ListBox listBoxFiles;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.Label label1;
    }
}

