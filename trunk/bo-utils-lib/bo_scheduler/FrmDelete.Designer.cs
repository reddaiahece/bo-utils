namespace BusinessObjectsUtils.bo_scheduler
{
    partial class FrmDelete
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
        /// 
        private void InitializeComponent()
        {
            ctrlReports = new System.Windows.Forms.TextBox();
            pictureBox5 = new System.Windows.Forms.PictureBox();
            label9 = new System.Windows.Forms.Label();
            pictureBox4 = new System.Windows.Forms.PictureBox();
            ctrlCancel = new System.Windows.Forms.Button();
            ctrlDelete = new System.Windows.Forms.Button();
            label1 = new System.Windows.Forms.Label();
            pictureBox3 = new System.Windows.Forms.PictureBox();
            ctrlDelSpecified = new System.Windows.Forms.RadioButton();
            ctrlDelSucceed = new System.Windows.Forms.RadioButton();
            ctrlDelAllState = new System.Windows.Forms.RadioButton();
            ctrlDelFailed = new System.Windows.Forms.RadioButton();
            paneConfig = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(pictureBox3)).BeginInit();
            paneConfig.SuspendLayout();
            SuspendLayout();
            // 
            // ctrlReports
            // 
            ctrlReports.Location = new System.Drawing.Point(5, 101);
            ctrlReports.Multiline = true;
            ctrlReports.Name = "ctrlReports";
            ctrlReports.ReadOnly = true;
            ctrlReports.RightToLeft = System.Windows.Forms.RightToLeft.No;
            ctrlReports.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            ctrlReports.Size = new System.Drawing.Size(315, 96);
            ctrlReports.TabIndex = 68;
            ctrlReports.WordWrap = false;
            // 
            // pictureBox5
            // 
            pictureBox5.BackColor = System.Drawing.Color.Silver;
            pictureBox5.Location = new System.Drawing.Point(0, 203);
            pictureBox5.Name = "pictureBox5";
            pictureBox5.Size = new System.Drawing.Size(321, 1);
            pictureBox5.TabIndex = 67;
            pictureBox5.TabStop = false;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.ForeColor = System.Drawing.Color.Blue;
            label9.Location = new System.Drawing.Point(-3, 84);
            label9.Name = "label9";
            label9.Size = new System.Drawing.Size(44, 13);
            label9.TabIndex = 65;
            label9.Text = "Reports";
            // 
            // pictureBox4
            // 
            pictureBox4.BackColor = System.Drawing.Color.Silver;
            pictureBox4.Location = new System.Drawing.Point(38, 92);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new System.Drawing.Size(282, 1);
            pictureBox4.TabIndex = 66;
            pictureBox4.TabStop = false;
            // 
            // ctrlCancel
            // 
            ctrlCancel.Location = new System.Drawing.Point(169, 209);
            ctrlCancel.Name = "ctrlCancel";
            ctrlCancel.Size = new System.Drawing.Size(90, 24);
            ctrlCancel.TabIndex = 64;
            ctrlCancel.Text = "Close";
            ctrlCancel.UseVisualStyleBackColor = true;
            ctrlCancel.Click += new System.EventHandler(btCancel_Click);
            // 
            // ctrlDelete
            // 
            ctrlDelete.FlatAppearance.BorderSize = 2;
            ctrlDelete.Location = new System.Drawing.Point(63, 209);
            ctrlDelete.Name = "ctrlDelete";
            ctrlDelete.Size = new System.Drawing.Size(90, 24);
            ctrlDelete.TabIndex = 63;
            ctrlDelete.Text = "Delete";
            ctrlDelete.UseVisualStyleBackColor = true;
            ctrlDelete.Click += new System.EventHandler(btDelete_Click);
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = System.Drawing.Color.Blue;
            label1.Location = new System.Drawing.Point(-3, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(43, 13);
            label1.TabIndex = 69;
            label1.Text = "Options";
            // 
            // pictureBox3
            // 
            pictureBox3.BackColor = System.Drawing.Color.Silver;
            pictureBox3.Location = new System.Drawing.Point(37, 8);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new System.Drawing.Size(282, 1);
            pictureBox3.TabIndex = 70;
            pictureBox3.TabStop = false;
            // 
            // ctrlDelSpecified
            // 
            ctrlDelSpecified.AutoSize = true;
            ctrlDelSpecified.Checked = true;
            ctrlDelSpecified.Location = new System.Drawing.Point(5, 14);
            ctrlDelSpecified.Name = "ctrlDelSpecified";
            ctrlDelSpecified.Size = new System.Drawing.Size(217, 17);
            ctrlDelSpecified.TabIndex = 72;
            ctrlDelSpecified.TabStop = true;
            ctrlDelSpecified.Text = "Delete attached instance (Column InstId)";
            ctrlDelSpecified.UseVisualStyleBackColor = true;
            // 
            // ctrlDelSucceed
            // 
            ctrlDelSucceed.AutoSize = true;
            ctrlDelSucceed.Location = new System.Drawing.Point(5, 31);
            ctrlDelSucceed.Name = "ctrlDelSucceed";
            ctrlDelSucceed.Size = new System.Drawing.Size(236, 17);
            ctrlDelSucceed.TabIndex = 72;
            ctrlDelSucceed.Text = "Delete successful instances scheduled once";
            ctrlDelSucceed.UseVisualStyleBackColor = true;
            // 
            // ctrlDelAllState
            // 
            ctrlDelAllState.AutoSize = true;
            ctrlDelAllState.Location = new System.Drawing.Point(5, 65);
            ctrlDelAllState.Name = "ctrlDelAllState";
            ctrlDelAllState.Size = new System.Drawing.Size(196, 17);
            ctrlDelAllState.TabIndex = 73;
            ctrlDelAllState.Text = "Delete all instances scheduled once";
            ctrlDelAllState.UseVisualStyleBackColor = true;
            // 
            // ctrlDelFailed
            // 
            ctrlDelFailed.AutoSize = true;
            ctrlDelFailed.Location = new System.Drawing.Point(5, 48);
            ctrlDelFailed.Name = "ctrlDelFailed";
            ctrlDelFailed.Size = new System.Drawing.Size(211, 17);
            ctrlDelFailed.TabIndex = 72;
            ctrlDelFailed.Text = "Delete failed instances scheduled once";
            ctrlDelFailed.UseVisualStyleBackColor = true;
            // 
            // paneConfig
            // 
            paneConfig.Controls.Add(ctrlDelSpecified);
            paneConfig.Controls.Add(label1);
            paneConfig.Controls.Add(pictureBox4);
            paneConfig.Controls.Add(ctrlDelAllState);
            paneConfig.Controls.Add(label9);
            paneConfig.Controls.Add(ctrlReports);
            paneConfig.Controls.Add(ctrlDelSucceed);
            paneConfig.Controls.Add(pictureBox3);
            paneConfig.Controls.Add(ctrlDelFailed);
            paneConfig.Location = new System.Drawing.Point(0, 1);
            paneConfig.Name = "paneConfig";
            paneConfig.Size = new System.Drawing.Size(324, 200);
            paneConfig.TabIndex = 74;
            // 
            // FrmDelete
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(326, 237);
            Controls.Add(paneConfig);
            Controls.Add(pictureBox5);
            Controls.Add(ctrlCancel);
            Controls.Add(ctrlDelete);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmDelete";
            ShowIcon = false;
            ShowInTaskbar = false;
            SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Delete Reports Instance";
            ((System.ComponentModel.ISupportInitialize)(pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(pictureBox3)).EndInit();
            paneConfig.ResumeLayout(false);
            paneConfig.PerformLayout();
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox ctrlReports;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Button ctrlCancel;
        private System.Windows.Forms.Button ctrlDelete;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.RadioButton ctrlDelSpecified;
        private System.Windows.Forms.RadioButton ctrlDelSucceed;
        private System.Windows.Forms.RadioButton ctrlDelAllState;
        private System.Windows.Forms.RadioButton ctrlDelFailed;
        private System.Windows.Forms.Panel paneConfig;
    }
}