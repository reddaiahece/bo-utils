namespace BusinessObjectsUtils
{
    partial class FrmRunner
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
            progressBar1 = new System.Windows.Forms.ProgressBar();
            btCancel = new System.Windows.Forms.Button();
            txtInfo = new System.Windows.Forms.TextBox();
            btClose = new System.Windows.Forms.Button();
            SuspendLayout();
            // 
            // progressBar1
            // 
            progressBar1.ForeColor = System.Drawing.Color.Blue;
            progressBar1.Location = new System.Drawing.Point(7, 7);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new System.Drawing.Size(334, 20);
            progressBar1.Step = 1;
            progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            progressBar1.TabIndex = 0;
            // 
            // btCancel
            // 
            btCancel.Location = new System.Drawing.Point(81, 194);
            btCancel.Name = "btCancel";
            btCancel.Size = new System.Drawing.Size(90, 25);
            btCancel.TabIndex = 0;
            btCancel.Text = "Cancel";
            btCancel.UseVisualStyleBackColor = true;
            btCancel.Click += new System.EventHandler(btCancel_Click);
            // 
            // txtInfo
            // 
            txtInfo.AcceptsReturn = true;
            txtInfo.AcceptsTab = true;
            txtInfo.CausesValidation = false;
            txtInfo.Location = new System.Drawing.Point(7, 33);
            txtInfo.Multiline = true;
            txtInfo.Name = "txtInfo";
            txtInfo.ReadOnly = true;
            txtInfo.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            txtInfo.Size = new System.Drawing.Size(334, 155);
            txtInfo.TabIndex = 3;
            txtInfo.TabStop = false;
            txtInfo.WordWrap = false;
            // 
            // btClose
            // 
            btClose.Enabled = false;
            btClose.Location = new System.Drawing.Point(177, 194);
            btClose.Name = "btClose";
            btClose.Size = new System.Drawing.Size(90, 25);
            btClose.TabIndex = 1;
            btClose.Text = "Close";
            btClose.UseVisualStyleBackColor = true;
            btClose.Click += new System.EventHandler(btClose_Click);
            // 
            // FrmRunner
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(349, 224);
            Controls.Add(btClose);
            Controls.Add(txtInfo);
            Controls.Add(btCancel);
            Controls.Add(progressBar1);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmRunner";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Progress";
            FormClosing += new System.Windows.Forms.FormClosingEventHandler(FormProgress_FormClosing);
            Load += new System.EventHandler(FrmProgress_Load);
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBar1;
        public System.Windows.Forms.Button btCancel;
        public System.Windows.Forms.TextBox txtInfo;
        private System.Windows.Forms.Button btClose;
    }
}