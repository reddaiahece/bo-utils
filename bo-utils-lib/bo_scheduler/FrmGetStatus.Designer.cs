namespace BusinessObjectsUtils.bo_scheduler
{
    partial class FrmGetStatus
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
            pictureBox5 = new System.Windows.Forms.PictureBox();
            label9 = new System.Windows.Forms.Label();
            pictureBox4 = new System.Windows.Forms.PictureBox();
            ctrlCancel = new System.Windows.Forms.Button();
            ctrlGetStatus = new System.Windows.Forms.Button();
            ctrlReports = new System.Windows.Forms.TextBox();
            ctrlGetSpecified = new System.Windows.Forms.RadioButton();
            ctrlGetLastFailed = new System.Windows.Forms.RadioButton();
            ctrlGetLastSucceed = new System.Windows.Forms.RadioButton();
            ctrlGetLastCreated = new System.Windows.Forms.RadioButton();
            label7 = new System.Windows.Forms.Label();
            pictureBox2 = new System.Windows.Forms.PictureBox();
            panelConfig = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(pictureBox2)).BeginInit();
            panelConfig.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBox5
            // 
            pictureBox5.BackColor = System.Drawing.Color.Silver;
            pictureBox5.Location = new System.Drawing.Point(2, 155);
            pictureBox5.Name = "pictureBox5";
            pictureBox5.Size = new System.Drawing.Size(321, 1);
            pictureBox5.TabIndex = 61;
            pictureBox5.TabStop = false;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.ForeColor = System.Drawing.Color.Blue;
            label9.Location = new System.Drawing.Point(-3, 36);
            label9.Name = "label9";
            label9.Size = new System.Drawing.Size(44, 13);
            label9.TabIndex = 58;
            label9.Text = "Reports";
            // 
            // pictureBox4
            // 
            pictureBox4.BackColor = System.Drawing.Color.Silver;
            pictureBox4.Location = new System.Drawing.Point(38, 44);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new System.Drawing.Size(282, 1);
            pictureBox4.TabIndex = 59;
            pictureBox4.TabStop = false;
            // 
            // ctrlCancel
            // 
            ctrlCancel.Location = new System.Drawing.Point(170, 161);
            ctrlCancel.Name = "ctrlCancel";
            ctrlCancel.Size = new System.Drawing.Size(90, 24);
            ctrlCancel.TabIndex = 57;
            ctrlCancel.Text = "Close";
            ctrlCancel.UseVisualStyleBackColor = true;
            ctrlCancel.Click += new System.EventHandler(btCancel_Click);
            // 
            // ctrlGetStatus
            // 
            ctrlGetStatus.FlatAppearance.BorderSize = 2;
            ctrlGetStatus.Location = new System.Drawing.Point(64, 161);
            ctrlGetStatus.Name = "ctrlGetStatus";
            ctrlGetStatus.Size = new System.Drawing.Size(90, 24);
            ctrlGetStatus.TabIndex = 56;
            ctrlGetStatus.Text = "Get Status";
            ctrlGetStatus.UseVisualStyleBackColor = true;
            ctrlGetStatus.Click += new System.EventHandler(btGetStatus_Click);
            // 
            // ctrlReports
            // 
            ctrlReports.Location = new System.Drawing.Point(5, 53);
            ctrlReports.Multiline = true;
            ctrlReports.Name = "ctrlReports";
            ctrlReports.ReadOnly = true;
            ctrlReports.RightToLeft = System.Windows.Forms.RightToLeft.No;
            ctrlReports.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            ctrlReports.Size = new System.Drawing.Size(315, 96);
            ctrlReports.TabIndex = 62;
            ctrlReports.WordWrap = false;
            // 
            // ctrlGetSpecified
            // 
            ctrlGetSpecified.AutoSize = true;
            ctrlGetSpecified.Checked = true;
            ctrlGetSpecified.Location = new System.Drawing.Point(5, 15);
            ctrlGetSpecified.Name = "ctrlGetSpecified";
            ctrlGetSpecified.Size = new System.Drawing.Size(69, 17);
            ctrlGetSpecified.TabIndex = 82;
            ctrlGetSpecified.TabStop = true;
            ctrlGetSpecified.Text = "Specified";
            ctrlGetSpecified.UseVisualStyleBackColor = true;
            // 
            // ctrlGetLastFailed
            // 
            ctrlGetLastFailed.AutoSize = true;
            ctrlGetLastFailed.Location = new System.Drawing.Point(249, 15);
            ctrlGetLastFailed.Name = "ctrlGetLastFailed";
            ctrlGetLastFailed.Size = new System.Drawing.Size(73, 17);
            ctrlGetLastFailed.TabIndex = 80;
            ctrlGetLastFailed.Text = "Last failed";
            ctrlGetLastFailed.UseVisualStyleBackColor = true;
            // 
            // ctrlGetLastSucceed
            // 
            ctrlGetLastSucceed.AutoSize = true;
            ctrlGetLastSucceed.Location = new System.Drawing.Point(158, 15);
            ctrlGetLastSucceed.Name = "ctrlGetLastSucceed";
            ctrlGetLastSucceed.Size = new System.Drawing.Size(89, 17);
            ctrlGetLastSucceed.TabIndex = 81;
            ctrlGetLastSucceed.Text = "Last succeed";
            ctrlGetLastSucceed.UseVisualStyleBackColor = true;
            // 
            // ctrlGetLastCreated
            // 
            ctrlGetLastCreated.AutoSize = true;
            ctrlGetLastCreated.Location = new System.Drawing.Point(74, 15);
            ctrlGetLastCreated.Name = "ctrlGetLastCreated";
            ctrlGetLastCreated.Size = new System.Drawing.Size(84, 17);
            ctrlGetLastCreated.TabIndex = 79;
            ctrlGetLastCreated.Text = "Last created";
            ctrlGetLastCreated.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.ForeColor = System.Drawing.Color.Blue;
            label7.Location = new System.Drawing.Point(-3, 0);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(104, 13);
            label7.TabIndex = 77;
            label7.Text = "Instance association";
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = System.Drawing.Color.Silver;
            pictureBox2.Location = new System.Drawing.Point(37, 8);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new System.Drawing.Size(282, 1);
            pictureBox2.TabIndex = 78;
            pictureBox2.TabStop = false;
            // 
            // panelConfig
            // 
            panelConfig.Controls.Add(label7);
            panelConfig.Controls.Add(ctrlGetSpecified);
            panelConfig.Controls.Add(pictureBox4);
            panelConfig.Controls.Add(ctrlGetLastFailed);
            panelConfig.Controls.Add(label9);
            panelConfig.Controls.Add(ctrlGetLastSucceed);
            panelConfig.Controls.Add(ctrlReports);
            panelConfig.Controls.Add(ctrlGetLastCreated);
            panelConfig.Controls.Add(pictureBox2);
            panelConfig.Location = new System.Drawing.Point(2, 1);
            panelConfig.Name = "panelConfig";
            panelConfig.Size = new System.Drawing.Size(327, 154);
            panelConfig.TabIndex = 83;
            // 
            // FrmGetStatus
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(329, 190);
            Controls.Add(pictureBox5);
            Controls.Add(panelConfig);
            Controls.Add(ctrlCancel);
            Controls.Add(ctrlGetStatus);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmGetStatus";
            ShowIcon = false;
            ShowInTaskbar = false;
            SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Get Reports Status";
            ((System.ComponentModel.ISupportInitialize)(pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(pictureBox2)).EndInit();
            panelConfig.ResumeLayout(false);
            panelConfig.PerformLayout();
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Button ctrlCancel;
        private System.Windows.Forms.Button ctrlGetStatus;
        private System.Windows.Forms.TextBox ctrlReports;
        private System.Windows.Forms.RadioButton ctrlGetSpecified;
        private System.Windows.Forms.RadioButton ctrlGetLastFailed;
        private System.Windows.Forms.RadioButton ctrlGetLastSucceed;
        private System.Windows.Forms.RadioButton ctrlGetLastCreated;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Panel panelConfig;
    }
}