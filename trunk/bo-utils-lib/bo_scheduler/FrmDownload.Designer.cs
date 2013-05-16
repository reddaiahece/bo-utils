namespace BusinessObjectsUtils.bo_scheduler
{
    partial class FrmDownload
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDownload));
            ctrlReportsPath = new System.Windows.Forms.TextBox();
            label8 = new System.Windows.Forms.Label();
            pictureBox3 = new System.Windows.Forms.PictureBox();
            pictureBox4 = new System.Windows.Forms.PictureBox();
            ctrlCancel = new System.Windows.Forms.Button();
            ctrlDownload = new System.Windows.Forms.Button();
            ctrlBrowse = new System.Windows.Forms.Button();
            ctrlReports = new System.Windows.Forms.TextBox();
            label9 = new System.Windows.Forms.Label();
            pictureBox1 = new System.Windows.Forms.PictureBox();
            ctrlDlSpecified = new System.Windows.Forms.RadioButton();
            ctrlDlLastSucceed = new System.Windows.Forms.RadioButton();
            label7 = new System.Windows.Forms.Label();
            pictureBox2 = new System.Windows.Forms.PictureBox();
            label1 = new System.Windows.Forms.Label();
            pictureBox5 = new System.Windows.Forms.PictureBox();
            ctrlFormatBinary = new System.Windows.Forms.RadioButton();
            ctrlFormatXml = new System.Windows.Forms.RadioButton();
            ctrlFormatHtml = new System.Windows.Forms.RadioButton();
            paneInstance = new System.Windows.Forms.Panel();
            ctrlDlNone = new System.Windows.Forms.RadioButton();
            paneFormat = new System.Windows.Forms.Panel();
            ctrlFormatExcel = new System.Windows.Forms.RadioButton();
            ctrlFormatPdf = new System.Windows.Forms.RadioButton();
            panelConfig = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(pictureBox5)).BeginInit();
            paneInstance.SuspendLayout();
            paneFormat.SuspendLayout();
            panelConfig.SuspendLayout();
            SuspendLayout();
            // 
            // ctrlReportsPath
            // 
            ctrlReportsPath.Location = new System.Drawing.Point(5, 18);
            ctrlReportsPath.Name = "ctrlReportsPath";
            ctrlReportsPath.ReadOnly = true;
            ctrlReportsPath.Size = new System.Drawing.Size(286, 20);
            ctrlReportsPath.TabIndex = 29;
            ctrlReportsPath.DoubleClick += new System.EventHandler(btBrowse_Click);
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.ForeColor = System.Drawing.Color.Blue;
            label8.Location = new System.Drawing.Point(-3, 0);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(89, 13);
            label8.TabIndex = 32;
            label8.Text = "Destination folder";
            // 
            // pictureBox3
            // 
            pictureBox3.BackColor = System.Drawing.Color.Silver;
            pictureBox3.Location = new System.Drawing.Point(38, 8);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new System.Drawing.Size(282, 1);
            pictureBox3.TabIndex = 33;
            pictureBox3.TabStop = false;
            // 
            // pictureBox4
            // 
            pictureBox4.BackColor = System.Drawing.Color.Silver;
            pictureBox4.Location = new System.Drawing.Point(3, 233);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new System.Drawing.Size(320, 1);
            pictureBox4.TabIndex = 36;
            pictureBox4.TabStop = false;
            // 
            // ctrlCancel
            // 
            ctrlCancel.Location = new System.Drawing.Point(171, 239);
            ctrlCancel.Name = "ctrlCancel";
            ctrlCancel.Size = new System.Drawing.Size(90, 24);
            ctrlCancel.TabIndex = 35;
            ctrlCancel.Text = "Close";
            ctrlCancel.UseVisualStyleBackColor = true;
            ctrlCancel.Click += new System.EventHandler(btCancel_Click);
            // 
            // ctrlDownload
            // 
            ctrlDownload.FlatAppearance.BorderSize = 2;
            ctrlDownload.Location = new System.Drawing.Point(65, 239);
            ctrlDownload.Name = "ctrlDownload";
            ctrlDownload.Size = new System.Drawing.Size(90, 24);
            ctrlDownload.TabIndex = 34;
            ctrlDownload.Text = "Download";
            ctrlDownload.UseVisualStyleBackColor = true;
            ctrlDownload.Click += new System.EventHandler(btDownload_Click);
            // 
            // ctrlBrowse
            // 
            ctrlBrowse.Image = ((System.Drawing.Image)(resources.GetObject("ctrlBrowse.Image")));
            ctrlBrowse.Location = new System.Drawing.Point(293, 16);
            ctrlBrowse.Margin = new System.Windows.Forms.Padding(0);
            ctrlBrowse.Name = "ctrlBrowse";
            ctrlBrowse.Size = new System.Drawing.Size(24, 24);
            ctrlBrowse.TabIndex = 37;
            ctrlBrowse.UseVisualStyleBackColor = true;
            ctrlBrowse.Click += new System.EventHandler(btBrowse_Click);
            // 
            // ctrlReports
            // 
            ctrlReports.Location = new System.Drawing.Point(5, 128);
            ctrlReports.Multiline = true;
            ctrlReports.Name = "ctrlReports";
            ctrlReports.ReadOnly = true;
            ctrlReports.RightToLeft = System.Windows.Forms.RightToLeft.No;
            ctrlReports.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            ctrlReports.Size = new System.Drawing.Size(312, 96);
            ctrlReports.TabIndex = 65;
            ctrlReports.WordWrap = false;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.ForeColor = System.Drawing.Color.Blue;
            label9.Location = new System.Drawing.Point(-3, 111);
            label9.Name = "label9";
            label9.Size = new System.Drawing.Size(44, 13);
            label9.TabIndex = 63;
            label9.Text = "Reports";
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = System.Drawing.Color.Silver;
            pictureBox1.Location = new System.Drawing.Point(39, 119);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new System.Drawing.Size(282, 1);
            pictureBox1.TabIndex = 64;
            pictureBox1.TabStop = false;
            // 
            // ctrlDlSpecified
            // 
            ctrlDlSpecified.AutoSize = true;
            ctrlDlSpecified.Location = new System.Drawing.Point(67, 3);
            ctrlDlSpecified.Name = "ctrlDlSpecified";
            ctrlDlSpecified.Size = new System.Drawing.Size(69, 17);
            ctrlDlSpecified.TabIndex = 88;
            ctrlDlSpecified.Text = "Specified";
            ctrlDlSpecified.UseVisualStyleBackColor = true;
            // 
            // ctrlDlLastSucceed
            // 
            ctrlDlLastSucceed.AutoSize = true;
            ctrlDlLastSucceed.Location = new System.Drawing.Point(153, 3);
            ctrlDlLastSucceed.Name = "ctrlDlLastSucceed";
            ctrlDlLastSucceed.Size = new System.Drawing.Size(89, 17);
            ctrlDlLastSucceed.TabIndex = 87;
            ctrlDlLastSucceed.Text = "Last succeed";
            ctrlDlLastSucceed.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.ForeColor = System.Drawing.Color.Blue;
            label7.Location = new System.Drawing.Point(-3, 43);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(104, 13);
            label7.TabIndex = 83;
            label7.Text = "Instance association";
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = System.Drawing.Color.Silver;
            pictureBox2.Location = new System.Drawing.Point(37, 51);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new System.Drawing.Size(282, 1);
            pictureBox2.TabIndex = 84;
            pictureBox2.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = System.Drawing.Color.Blue;
            label1.Location = new System.Drawing.Point(-3, 77);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(39, 13);
            label1.TabIndex = 89;
            label1.Text = "Format";
            // 
            // pictureBox5
            // 
            pictureBox5.BackColor = System.Drawing.Color.Silver;
            pictureBox5.Location = new System.Drawing.Point(37, 85);
            pictureBox5.Name = "pictureBox5";
            pictureBox5.Size = new System.Drawing.Size(282, 1);
            pictureBox5.TabIndex = 90;
            pictureBox5.TabStop = false;
            // 
            // ctrlFormatBinary
            // 
            ctrlFormatBinary.AutoSize = true;
            ctrlFormatBinary.Checked = true;
            ctrlFormatBinary.Location = new System.Drawing.Point(3, 3);
            ctrlFormatBinary.Name = "ctrlFormatBinary";
            ctrlFormatBinary.Size = new System.Drawing.Size(59, 17);
            ctrlFormatBinary.TabIndex = 91;
            ctrlFormatBinary.TabStop = true;
            ctrlFormatBinary.Text = "Default";
            ctrlFormatBinary.UseVisualStyleBackColor = true;
            // 
            // ctrlFormatXml
            // 
            ctrlFormatXml.AutoSize = true;
            ctrlFormatXml.Location = new System.Drawing.Point(171, 3);
            ctrlFormatXml.Name = "ctrlFormatXml";
            ctrlFormatXml.Size = new System.Drawing.Size(42, 17);
            ctrlFormatXml.TabIndex = 91;
            ctrlFormatXml.Text = "Xml";
            ctrlFormatXml.UseVisualStyleBackColor = true;
            // 
            // ctrlFormatHtml
            // 
            ctrlFormatHtml.AutoSize = true;
            ctrlFormatHtml.Location = new System.Drawing.Point(219, 3);
            ctrlFormatHtml.Name = "ctrlFormatHtml";
            ctrlFormatHtml.Size = new System.Drawing.Size(46, 17);
            ctrlFormatHtml.TabIndex = 91;
            ctrlFormatHtml.Text = "Html";
            ctrlFormatHtml.UseVisualStyleBackColor = true;
            // 
            // paneInstance
            // 
            paneInstance.Controls.Add(ctrlDlNone);
            paneInstance.Controls.Add(ctrlDlSpecified);
            paneInstance.Controls.Add(ctrlDlLastSucceed);
            paneInstance.Location = new System.Drawing.Point(5, 55);
            paneInstance.Name = "paneInstance";
            paneInstance.Size = new System.Drawing.Size(312, 22);
            paneInstance.TabIndex = 93;
            // 
            // ctrlDlNone
            // 
            ctrlDlNone.AutoSize = true;
            ctrlDlNone.Checked = true;
            ctrlDlNone.Location = new System.Drawing.Point(3, 3);
            ctrlDlNone.Name = "ctrlDlNone";
            ctrlDlNone.Size = new System.Drawing.Size(51, 17);
            ctrlDlNone.TabIndex = 88;
            ctrlDlNone.TabStop = true;
            ctrlDlNone.Text = "None";
            ctrlDlNone.UseVisualStyleBackColor = true;
            // 
            // paneFormat
            // 
            paneFormat.Controls.Add(ctrlFormatBinary);
            paneFormat.Controls.Add(ctrlFormatExcel);
            paneFormat.Controls.Add(ctrlFormatPdf);
            paneFormat.Controls.Add(ctrlFormatXml);
            paneFormat.Controls.Add(ctrlFormatHtml);
            paneFormat.Location = new System.Drawing.Point(5, 90);
            paneFormat.Name = "paneFormat";
            paneFormat.Size = new System.Drawing.Size(312, 22);
            paneFormat.TabIndex = 94;
            // 
            // ctrlFormatExcel
            // 
            ctrlFormatExcel.AutoSize = true;
            ctrlFormatExcel.Location = new System.Drawing.Point(114, 3);
            ctrlFormatExcel.Name = "ctrlFormatExcel";
            ctrlFormatExcel.Size = new System.Drawing.Size(51, 17);
            ctrlFormatExcel.TabIndex = 91;
            ctrlFormatExcel.Text = "Excel";
            ctrlFormatExcel.UseVisualStyleBackColor = true;
            // 
            // ctrlFormatPdf
            // 
            ctrlFormatPdf.AutoSize = true;
            ctrlFormatPdf.Location = new System.Drawing.Point(67, 3);
            ctrlFormatPdf.Name = "ctrlFormatPdf";
            ctrlFormatPdf.Size = new System.Drawing.Size(41, 17);
            ctrlFormatPdf.TabIndex = 91;
            ctrlFormatPdf.Text = "Pdf";
            ctrlFormatPdf.UseVisualStyleBackColor = true;
            // 
            // panelConfig
            // 
            panelConfig.Controls.Add(label8);
            panelConfig.Controls.Add(paneFormat);
            panelConfig.Controls.Add(ctrlReportsPath);
            panelConfig.Controls.Add(paneInstance);
            panelConfig.Controls.Add(pictureBox3);
            panelConfig.Controls.Add(label1);
            panelConfig.Controls.Add(ctrlBrowse);
            panelConfig.Controls.Add(pictureBox5);
            panelConfig.Controls.Add(pictureBox1);
            panelConfig.Controls.Add(label7);
            panelConfig.Controls.Add(label9);
            panelConfig.Controls.Add(pictureBox2);
            panelConfig.Controls.Add(ctrlReports);
            panelConfig.Location = new System.Drawing.Point(3, 3);
            panelConfig.Name = "panelConfig";
            panelConfig.Size = new System.Drawing.Size(324, 230);
            panelConfig.TabIndex = 95;
            // 
            // FrmDownload
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(327, 267);
            Controls.Add(panelConfig);
            Controls.Add(pictureBox4);
            Controls.Add(ctrlCancel);
            Controls.Add(ctrlDownload);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmDownload";
            ShowIcon = false;
            SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Download Reports";
            ((System.ComponentModel.ISupportInitialize)(pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(pictureBox5)).EndInit();
            paneInstance.ResumeLayout(false);
            paneInstance.PerformLayout();
            paneFormat.ResumeLayout(false);
            paneFormat.PerformLayout();
            panelConfig.ResumeLayout(false);
            panelConfig.PerformLayout();
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox ctrlReportsPath;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Button ctrlCancel;
        private System.Windows.Forms.Button ctrlDownload;
        private System.Windows.Forms.Button ctrlBrowse;
        private System.Windows.Forms.TextBox ctrlReports;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.RadioButton ctrlDlSpecified;
        private System.Windows.Forms.RadioButton ctrlDlLastSucceed;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.RadioButton ctrlFormatBinary;
        private System.Windows.Forms.RadioButton ctrlFormatXml;
        private System.Windows.Forms.RadioButton ctrlFormatHtml;
        private System.Windows.Forms.Panel paneInstance;
        private System.Windows.Forms.Panel paneFormat;
        private System.Windows.Forms.RadioButton ctrlDlNone;
        private System.Windows.Forms.RadioButton ctrlFormatPdf;
        private System.Windows.Forms.RadioButton ctrlFormatExcel;
        private System.Windows.Forms.Panel panelConfig;
    }
}