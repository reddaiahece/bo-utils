namespace BusinessObjectsUtils.bo_scheduler
{
    partial class FrmSchedule
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
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.ctrlFormat = new BusinessObjectsUtils.ComboBoxCust();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.ctrlDestination = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.ctrlCancel = new System.Windows.Forms.Button();
            this.ctrlSchedule = new System.Windows.Forms.Button();
            this.ctrlReports = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ctrlDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.ctrlWait = new System.Windows.Forms.CheckBox();
            this.ctrlCreateXml = new System.Windows.Forms.Button();
            this.ctrlClean = new System.Windows.Forms.CheckBox();
            this.ctrlPrompts = new System.Windows.Forms.CheckBox();
            this.ctrlEmail = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panelConfig = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.panelConfig.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox5
            // 
            this.pictureBox5.BackColor = System.Drawing.Color.Silver;
            this.pictureBox5.Location = new System.Drawing.Point(4, 242);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(322, 1);
            this.pictureBox5.TabIndex = 55;
            this.pictureBox5.TabStop = false;
            // 
            // ctrlFormat
            // 
            this.ctrlFormat.DisplayMember = "value";
            this.ctrlFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ctrlFormat.FormattingEnabled = true;
            this.ctrlFormat.Location = new System.Drawing.Point(70, 36);
            this.ctrlFormat.Name = "ctrlFormat";
            this.ctrlFormat.Size = new System.Drawing.Size(245, 21);
            this.ctrlFormat.TabIndex = 53;
            this.ctrlFormat.ValueMember = "key";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(3, 39);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(39, 13);
            this.label8.TabIndex = 52;
            this.label8.Text = "Format";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(3, 82);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 13);
            this.label6.TabIndex = 52;
            this.label6.Text = "Destination";
            // 
            // ctrlDestination
            // 
            this.ctrlDestination.Location = new System.Drawing.Point(70, 79);
            this.ctrlDestination.Name = "ctrlDestination";
            this.ctrlDestination.Size = new System.Drawing.Size(245, 20);
            this.ctrlDestination.TabIndex = 51;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.Blue;
            this.label9.Location = new System.Drawing.Point(-3, 120);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(44, 13);
            this.label9.TabIndex = 49;
            this.label9.Text = "Reports";
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.Color.Silver;
            this.pictureBox4.Location = new System.Drawing.Point(37, 128);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(282, 1);
            this.pictureBox4.TabIndex = 50;
            this.pictureBox4.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(-3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 49;
            this.label1.Text = "Options";
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Silver;
            this.pictureBox3.Location = new System.Drawing.Point(37, 8);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(282, 1);
            this.pictureBox3.TabIndex = 50;
            this.pictureBox3.TabStop = false;
            // 
            // ctrlCancel
            // 
            this.ctrlCancel.Location = new System.Drawing.Point(212, 248);
            this.ctrlCancel.Name = "ctrlCancel";
            this.ctrlCancel.Size = new System.Drawing.Size(90, 24);
            this.ctrlCancel.TabIndex = 48;
            this.ctrlCancel.Text = "Close";
            this.ctrlCancel.UseVisualStyleBackColor = true;
            this.ctrlCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // ctrlSchedule
            // 
            this.ctrlSchedule.FlatAppearance.BorderSize = 2;
            this.ctrlSchedule.Location = new System.Drawing.Point(116, 248);
            this.ctrlSchedule.Name = "ctrlSchedule";
            this.ctrlSchedule.Size = new System.Drawing.Size(90, 24);
            this.ctrlSchedule.TabIndex = 47;
            this.ctrlSchedule.Text = "Schedule";
            this.ctrlSchedule.UseVisualStyleBackColor = true;
            this.ctrlSchedule.Click += new System.EventHandler(this.btSchedule_Click);
            // 
            // ctrlReports
            // 
            this.ctrlReports.Location = new System.Drawing.Point(6, 137);
            this.ctrlReports.Multiline = true;
            this.ctrlReports.Name = "ctrlReports";
            this.ctrlReports.ReadOnly = true;
            this.ctrlReports.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ctrlReports.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ctrlReports.Size = new System.Drawing.Size(309, 96);
            this.ctrlReports.TabIndex = 57;
            this.ctrlReports.WordWrap = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 52;
            this.label2.Text = "Start Time";
            // 
            // ctrlDateTimePicker
            // 
            this.ctrlDateTimePicker.Location = new System.Drawing.Point(70, 58);
            this.ctrlDateTimePicker.Name = "ctrlDateTimePicker";
            this.ctrlDateTimePicker.ShowCheckBox = true;
            this.ctrlDateTimePicker.Size = new System.Drawing.Size(245, 20);
            this.ctrlDateTimePicker.TabIndex = 60;
            this.ctrlDateTimePicker.ValueChanged += new System.EventHandler(this.dtPicker_ValueChanged);
            // 
            // ctrlWait
            // 
            this.ctrlWait.AutoSize = true;
            this.ctrlWait.Location = new System.Drawing.Point(105, 17);
            this.ctrlWait.Name = "ctrlWait";
            this.ctrlWait.Size = new System.Drawing.Size(69, 17);
            this.ctrlWait.TabIndex = 62;
            this.ctrlWait.Text = "Wait end";
            this.ctrlWait.UseVisualStyleBackColor = true;
            // 
            // ctrlCreateXml
            // 
            this.ctrlCreateXml.FlatAppearance.BorderSize = 2;
            this.ctrlCreateXml.Location = new System.Drawing.Point(20, 248);
            this.ctrlCreateXml.Name = "ctrlCreateXml";
            this.ctrlCreateXml.Size = new System.Drawing.Size(90, 24);
            this.ctrlCreateXml.TabIndex = 70;
            this.ctrlCreateXml.Text = "Create Plan...";
            this.ctrlCreateXml.UseVisualStyleBackColor = true;
            this.ctrlCreateXml.Click += new System.EventHandler(this.btCreateXml_Click);
            // 
            // ctrlClean
            // 
            this.ctrlClean.AutoSize = true;
            this.ctrlClean.Location = new System.Drawing.Point(188, 17);
            this.ctrlClean.Name = "ctrlClean";
            this.ctrlClean.Size = new System.Drawing.Size(121, 17);
            this.ctrlClean.TabIndex = 62;
            this.ctrlClean.Text = "Clean when finished";
            this.ctrlClean.UseVisualStyleBackColor = true;
            // 
            // ctrlPrompts
            // 
            this.ctrlPrompts.AutoSize = true;
            this.ctrlPrompts.Checked = true;
            this.ctrlPrompts.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ctrlPrompts.Location = new System.Drawing.Point(6, 17);
            this.ctrlPrompts.Name = "ctrlPrompts";
            this.ctrlPrompts.Size = new System.Drawing.Size(88, 17);
            this.ctrlPrompts.TabIndex = 75;
            this.ctrlPrompts.Text = "With prompts";
            this.ctrlPrompts.UseVisualStyleBackColor = true;
            // 
            // ctrlEmail
            // 
            this.ctrlEmail.Location = new System.Drawing.Point(70, 100);
            this.ctrlEmail.Name = "ctrlEmail";
            this.ctrlEmail.Size = new System.Drawing.Size(245, 20);
            this.ctrlEmail.TabIndex = 76;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(4, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 52;
            this.label3.Text = "Notif. Email";
            // 
            // panelConfig
            // 
            this.panelConfig.Controls.Add(this.label1);
            this.panelConfig.Controls.Add(this.ctrlEmail);
            this.panelConfig.Controls.Add(this.pictureBox3);
            this.panelConfig.Controls.Add(this.ctrlPrompts);
            this.panelConfig.Controls.Add(this.pictureBox4);
            this.panelConfig.Controls.Add(this.label9);
            this.panelConfig.Controls.Add(this.ctrlClean);
            this.panelConfig.Controls.Add(this.label2);
            this.panelConfig.Controls.Add(this.ctrlWait);
            this.panelConfig.Controls.Add(this.ctrlDestination);
            this.panelConfig.Controls.Add(this.ctrlDateTimePicker);
            this.panelConfig.Controls.Add(this.label6);
            this.panelConfig.Controls.Add(this.ctrlReports);
            this.panelConfig.Controls.Add(this.label3);
            this.panelConfig.Controls.Add(this.label8);
            this.panelConfig.Controls.Add(this.ctrlFormat);
            this.panelConfig.Location = new System.Drawing.Point(3, 2);
            this.panelConfig.Name = "panelConfig";
            this.panelConfig.Size = new System.Drawing.Size(322, 237);
            this.panelConfig.TabIndex = 77;
            // 
            // FrmSchedule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(327, 276);
            this.Controls.Add(this.panelConfig);
            this.Controls.Add(this.ctrlCreateXml);
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.ctrlCancel);
            this.Controls.Add(this.ctrlSchedule);
            this.Name = "FrmSchedule";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Scedule Reports";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.panelConfig.ResumeLayout(false);
            this.panelConfig.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ctrlCancel;
        private System.Windows.Forms.Button ctrlSchedule;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.TextBox ctrlDestination;
        private System.Windows.Forms.Label label6;
        private ComboBoxCust ctrlFormat;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.TextBox ctrlReports;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker ctrlDateTimePicker;
        private System.Windows.Forms.CheckBox ctrlWait;
        private System.Windows.Forms.Button ctrlCreateXml;
        private System.Windows.Forms.CheckBox ctrlClean;
        private System.Windows.Forms.CheckBox ctrlPrompts;
        private System.Windows.Forms.TextBox ctrlEmail;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panelConfig;
    }
}