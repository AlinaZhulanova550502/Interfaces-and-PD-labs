﻿namespace lab8
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.emailTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.maxSizeTextBox = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.normalStartCheckBox = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.White;
            this.textBox1.Location = new System.Drawing.Point(6, 39);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(358, 22);
            this.textBox1.TabIndex = 0;
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.SystemColors.Window;
            this.textBox2.Location = new System.Drawing.Point(6, 67);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(358, 22);
            this.textBox2.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(161, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Shift+F2 to switch mode.";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 121);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(105, 17);
            this.label4.TabIndex = 5;
            this.label4.Text = "Send emails to:";
            // 
            // emailTextBox
            // 
            this.emailTextBox.Location = new System.Drawing.Point(134, 121);
            this.emailTextBox.Name = "emailTextBox";
            this.emailTextBox.Size = new System.Drawing.Size(230, 22);
            this.emailTextBox.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 147);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(125, 17);
            this.label5.TabIndex = 7;
            this.label5.Text = "LogFiles Max Size:";
            // 
            // maxSizeTextBox
            // 
            this.maxSizeTextBox.Location = new System.Drawing.Point(134, 147);
            this.maxSizeTextBox.Name = "maxSizeTextBox";
            this.maxSizeTextBox.Size = new System.Drawing.Size(230, 22);
            this.maxSizeTextBox.TabIndex = 9;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(109, 197);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(174, 27);
            this.button1.TabIndex = 11;
            this.button1.Text = "Save Settings";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.SaveSettingsButton_Click);
            // 
            // normalStartCheckBox
            // 
            this.normalStartCheckBox.AutoSize = true;
            this.normalStartCheckBox.Location = new System.Drawing.Point(134, 174);
            this.normalStartCheckBox.Name = "normalStartCheckBox";
            this.normalStartCheckBox.Size = new System.Drawing.Size(18, 17);
            this.normalStartCheckBox.TabIndex = 15;
            this.normalStartCheckBox.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 174);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 17);
            this.label1.TabIndex = 16;
            this.label1.Text = "Normal Start:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(374, 234);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.emailTextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.maxSizeTextBox);
            this.Controls.Add(this.normalStartCheckBox);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "Form1";
            this.Text = "lab8";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox emailTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox maxSizeTextBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox normalStartCheckBox;
        private System.Windows.Forms.Label label1;
    }
}

