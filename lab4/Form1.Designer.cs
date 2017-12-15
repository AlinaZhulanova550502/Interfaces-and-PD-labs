namespace USBCheck
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
            this.USBList = new System.Windows.Forms.DataGridView();
            this.EjectButton = new System.Windows.Forms.Button();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.spaceTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.USBList)).BeginInit();
            this.SuspendLayout();
            // 
            // USBList
            // 
            this.USBList.BackgroundColor = System.Drawing.Color.White;
            this.USBList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.USBList.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.USBList.Location = new System.Drawing.Point(12, 12);
            this.USBList.Name = "USBList";
            this.USBList.Size = new System.Drawing.Size(145, 150);
            this.USBList.TabIndex = 0;
            this.USBList.SelectionChanged += new System.EventHandler(this.ChangeSelect);
            // 
            // EjectButton
            // 
            this.EjectButton.Font = new System.Drawing.Font("Candara", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.EjectButton.Location = new System.Drawing.Point(287, 168);
            this.EjectButton.Name = "EjectButton";
            this.EjectButton.Size = new System.Drawing.Size(77, 31);
            this.EjectButton.TabIndex = 1;
            this.EjectButton.Text = "Eject";
            this.EjectButton.UseVisualStyleBackColor = true;
            this.EjectButton.Click += new System.EventHandler(this.HitEjectButton);
            // 
            // timer
            // 
            this.timer.Interval = 8000;
            this.timer.Tick += new System.EventHandler(this.TickTimer);
            // 
            // spaceTextBox
            // 
            this.spaceTextBox.BackColor = System.Drawing.Color.White;
            this.spaceTextBox.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.spaceTextBox.Location = new System.Drawing.Point(175, 12);
            this.spaceTextBox.Multiline = true;
            this.spaceTextBox.Name = "spaceTextBox";
            this.spaceTextBox.Size = new System.Drawing.Size(189, 150);
            this.spaceTextBox.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 179);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(370, 204);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.spaceTextBox);
            this.Controls.Add(this.EjectButton);
            this.Controls.Add(this.USBList);
            this.Name = "Form1";
            this.Text = "USB Checker";
            this.Load += new System.EventHandler(this.LoadForm);
            ((System.ComponentModel.ISupportInitialize)(this.USBList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView USBList;
        private System.Windows.Forms.Button EjectButton;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.TextBox spaceTextBox;
        private System.Windows.Forms.Label label1;
    }
}

