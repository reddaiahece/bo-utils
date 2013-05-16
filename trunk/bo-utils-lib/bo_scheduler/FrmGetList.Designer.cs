using System.Windows.Forms;
namespace BusinessObjectsUtils.bo_scheduler
{
    partial class FrmGetList
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
            ctrlReportsPath = new System.Windows.Forms.TextBox();
            ctrlCancel = new System.Windows.Forms.Button();
            ctrlExtract = new System.Windows.Forms.Button();
            label8 = new System.Windows.Forms.Label();
            pictureBox3 = new System.Windows.Forms.PictureBox();
            pictureBox4 = new System.Windows.Forms.PictureBox();
            label6 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            ctrlPrompts = new System.Windows.Forms.CheckBox();
            label5 = new System.Windows.Forms.Label();
            pictureBox1 = new System.Windows.Forms.PictureBox();
            ctrlGetLastCreated = new System.Windows.Forms.RadioButton();
            ctrlGetLastSucceed = new System.Windows.Forms.RadioButton();
            pictureBox2 = new System.Windows.Forms.PictureBox();
            label7 = new System.Windows.Forms.Label();
            ctrlGetLastFailed = new System.Windows.Forms.RadioButton();
            ctrlGetLastNone = new System.Windows.Forms.RadioButton();
            panelConfig = new System.Windows.Forms.Panel();
            ctrlWizard = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(pictureBox2)).BeginInit();
            panelConfig.SuspendLayout();
            SuspendLayout();
            // 
            // ctrlReportsPath
            // 
            ctrlReportsPath.AcceptsReturn = true;
            ctrlReportsPath.Location = new System.Drawing.Point(5, 17);
            ctrlReportsPath.Multiline = true;
            ctrlReportsPath.Name = "ctrlReportsPath";
            ctrlReportsPath.Size = new System.Drawing.Size(312, 35);
            ctrlReportsPath.TabIndex = 28;
            // 
            // ctrlCancel
            // 
            ctrlCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            ctrlCancel.CausesValidation = false;
            ctrlCancel.Location = new System.Drawing.Point(169, 201);
            ctrlCancel.Name = "ctrlCancel";
            ctrlCancel.Size = new System.Drawing.Size(90, 24);
            ctrlCancel.TabIndex = 27;
            ctrlCancel.Text = "Close";
            ctrlCancel.UseVisualStyleBackColor = true;
            ctrlCancel.Click += new System.EventHandler(btCancel_Click);
            // 
            // ctrlExtract
            // 
            ctrlExtract.FlatAppearance.BorderSize = 2;
            ctrlExtract.Location = new System.Drawing.Point(63, 201);
            ctrlExtract.Name = "ctrlExtract";
            ctrlExtract.Size = new System.Drawing.Size(90, 24);
            ctrlExtract.TabIndex = 26;
            ctrlExtract.Text = "Get List";
            ctrlExtract.UseVisualStyleBackColor = true;
            ctrlExtract.Click += new System.EventHandler(btExtract_Click);
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.ForeColor = System.Drawing.Color.Blue;
            label8.Location = new System.Drawing.Point(-3, 0);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(68, 13);
            label8.TabIndex = 24;
            label8.Text = "Reports path";
            // 
            // pictureBox3
            // 
            pictureBox3.BackColor = System.Drawing.Color.Silver;
            pictureBox3.Location = new System.Drawing.Point(38, 8);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new System.Drawing.Size(282, 1);
            pictureBox3.TabIndex = 31;
            pictureBox3.TabStop = false;
            // 
            // pictureBox4
            // 
            pictureBox4.BackColor = System.Drawing.Color.Silver;
            pictureBox4.Location = new System.Drawing.Point(0, 195);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new System.Drawing.Size(320, 1);
            pictureBox4.TabIndex = 33;
            pictureBox4.TabStop = false;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = System.Drawing.Color.Transparent;
            label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label6.Location = new System.Drawing.Point(5, 67);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(250, 13);
            label6.TabIndex = 53;
            label6.Text = "A report in a folder : Folder A/Folder B/Report  Name";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label1.Location = new System.Drawing.Point(5, 80);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(162, 13);
            label1.TabIndex = 53;
            label1.Text = "All reports in a folders  : FolderA/*";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label2.Location = new System.Drawing.Point(5, 106);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(226, 13);
            label2.TabIndex = 53;
            label2.Text = "A report in all first level folders  : */Report Name";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label3.Location = new System.Drawing.Point(5, 93);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(138, 13);
            label3.TabIndex = 53;
            label3.Text = "All reports in all folders  : **/*";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = System.Drawing.Color.Transparent;
            label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label4.Location = new System.Drawing.Point(5, 54);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(173, 13);
            label4.TabIndex = 54;
            label4.Text = "Reports by id : 10020,10021,10023";
            // 
            // ctrlPrompts
            // 
            ctrlPrompts.AutoSize = true;
            ctrlPrompts.Checked = true;
            ctrlPrompts.CheckState = System.Windows.Forms.CheckState.Checked;
            ctrlPrompts.Location = new System.Drawing.Point(7, 172);
            ctrlPrompts.Name = "ctrlPrompts";
            ctrlPrompts.Size = new System.Drawing.Size(101, 17);
            ctrlPrompts.TabIndex = 74;
            ctrlPrompts.Text = "Include prompts";
            ctrlPrompts.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.ForeColor = System.Drawing.Color.Blue;
            label5.Location = new System.Drawing.Point(-3, 155);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(43, 13);
            label5.TabIndex = 72;
            label5.Text = "Options";
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = System.Drawing.Color.Silver;
            pictureBox1.Location = new System.Drawing.Point(37, 163);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new System.Drawing.Size(282, 1);
            pictureBox1.TabIndex = 73;
            pictureBox1.TabStop = false;
            // 
            // ctrlGetLastCreated
            // 
            ctrlGetLastCreated.AutoSize = true;
            ctrlGetLastCreated.Location = new System.Drawing.Point(61, 136);
            ctrlGetLastCreated.Name = "ctrlGetLastCreated";
            ctrlGetLastCreated.Size = new System.Drawing.Size(84, 17);
            ctrlGetLastCreated.TabIndex = 75;
            ctrlGetLastCreated.Text = "Last created";
            ctrlGetLastCreated.UseVisualStyleBackColor = true;
            // 
            // ctrlGetLastSucceed
            // 
            ctrlGetLastSucceed.AutoSize = true;
            ctrlGetLastSucceed.Location = new System.Drawing.Point(149, 136);
            ctrlGetLastSucceed.Name = "ctrlGetLastSucceed";
            ctrlGetLastSucceed.Size = new System.Drawing.Size(89, 17);
            ctrlGetLastSucceed.TabIndex = 75;
            ctrlGetLastSucceed.Text = "Last succeed";
            ctrlGetLastSucceed.UseVisualStyleBackColor = true;
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = System.Drawing.Color.Silver;
            pictureBox2.Location = new System.Drawing.Point(37, 129);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new System.Drawing.Size(282, 1);
            pictureBox2.TabIndex = 73;
            pictureBox2.TabStop = false;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.ForeColor = System.Drawing.Color.Blue;
            label7.Location = new System.Drawing.Point(-3, 121);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(104, 13);
            label7.TabIndex = 72;
            label7.Text = "Instance association";
            // 
            // ctrlGetLastFailed
            // 
            ctrlGetLastFailed.AutoSize = true;
            ctrlGetLastFailed.Location = new System.Drawing.Point(242, 136);
            ctrlGetLastFailed.Name = "ctrlGetLastFailed";
            ctrlGetLastFailed.Size = new System.Drawing.Size(73, 17);
            ctrlGetLastFailed.TabIndex = 75;
            ctrlGetLastFailed.Text = "Last failed";
            ctrlGetLastFailed.UseVisualStyleBackColor = true;
            // 
            // ctrlGetLastNone
            // 
            ctrlGetLastNone.AutoSize = true;
            ctrlGetLastNone.Checked = true;
            ctrlGetLastNone.Location = new System.Drawing.Point(7, 136);
            ctrlGetLastNone.Name = "ctrlGetLastNone";
            ctrlGetLastNone.Size = new System.Drawing.Size(51, 17);
            ctrlGetLastNone.TabIndex = 76;
            ctrlGetLastNone.TabStop = true;
            ctrlGetLastNone.Text = "None";
            ctrlGetLastNone.UseVisualStyleBackColor = true;
            // 
            // panelConfig
            // 
            panelConfig.Controls.Add(ctrlWizard);
            panelConfig.Controls.Add(label8);
            panelConfig.Controls.Add(ctrlGetLastNone);
            panelConfig.Controls.Add(pictureBox3);
            panelConfig.Controls.Add(ctrlGetLastFailed);
            panelConfig.Controls.Add(ctrlReportsPath);
            panelConfig.Controls.Add(ctrlGetLastSucceed);
            panelConfig.Controls.Add(label6);
            panelConfig.Controls.Add(ctrlGetLastCreated);
            panelConfig.Controls.Add(label1);
            panelConfig.Controls.Add(ctrlPrompts);
            panelConfig.Controls.Add(label3);
            panelConfig.Controls.Add(label7);
            panelConfig.Controls.Add(label2);
            panelConfig.Controls.Add(pictureBox2);
            panelConfig.Controls.Add(label4);
            panelConfig.Controls.Add(label5);
            panelConfig.Controls.Add(pictureBox1);
            panelConfig.Location = new System.Drawing.Point(2, 2);
            panelConfig.Name = "panelConfig";
            panelConfig.Size = new System.Drawing.Size(324, 193);
            panelConfig.TabIndex = 77;
            // 
            // ctrlWizard
            // 
            ctrlWizard.Location = new System.Drawing.Point(261, 67);
            ctrlWizard.Name = "ctrlWizard";
            ctrlWizard.Size = new System.Drawing.Size(55, 39);
            ctrlWizard.TabIndex = 77;
            ctrlWizard.Text = "Wizard";
            ctrlWizard.UseVisualStyleBackColor = true;
            ctrlWizard.Click += new System.EventHandler(ctrlWizard_Click);
            // 
            // FrmGetList
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(326, 230);
            Controls.Add(panelConfig);
            Controls.Add(pictureBox4);
            Controls.Add(ctrlCancel);
            Controls.Add(ctrlExtract);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmGetList";
            ShowIcon = false;
            ShowInTaskbar = false;
            SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Get Reports List";
            ((System.ComponentModel.ISupportInitialize)(pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(pictureBox2)).EndInit();
            panelConfig.ResumeLayout(false);
            panelConfig.PerformLayout();
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ctrlCancel;
        private System.Windows.Forms.Button ctrlExtract;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox ctrlPrompts;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.RadioButton ctrlGetLastCreated;
        private System.Windows.Forms.RadioButton ctrlGetLastSucceed;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RadioButton ctrlGetLastFailed;
        private System.Windows.Forms.RadioButton ctrlGetLastNone;
        private System.Windows.Forms.TextBox ctrlReportsPath;
        private System.Windows.Forms.Panel panelConfig;
        private Button ctrlWizard;
    }
}