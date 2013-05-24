using System.Windows.Forms;
namespace BusinessObjectsUtils.bo_session
{
    partial class FrmLogin
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
            this.ctrlDomain = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.ctrlAuth = new BusinessObjectsUtils.ComboBoxCust();
            this.label10 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ctrlPassword = new System.Windows.Forms.TextBox();
            this.ctrlLogin = new System.Windows.Forms.TextBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btCancel = new System.Windows.Forms.Button();
            this.btLogin = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.ctrlVersion = new BusinessObjectsUtils.ComboBoxCust();
            this.ctrlUrl = new BusinessObjectsUtils.ComboBoxCust();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.ctrlProxyPort = new System.Windows.Forms.TextBox();
            this.ctrlProxyUser = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.ctrlProxyHost = new System.Windows.Forms.TextBox();
            this.ctrlProxyPasword = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.SuspendLayout();
            // 
            // ctrlDomain
            // 
            this.ctrlDomain.Location = new System.Drawing.Point(65, 104);
            this.ctrlDomain.Name = "ctrlDomain";
            this.ctrlDomain.Size = new System.Drawing.Size(180, 20);
            this.ctrlDomain.TabIndex = 3;
            this.ctrlDomain.Tag = "System";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.Blue;
            this.label7.Location = new System.Drawing.Point(1, 3);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(94, 13);
            this.label7.TabIndex = 58;
            this.label7.Text = "Web Service URL";
            // 
            // ctrlAuth
            // 
            this.ctrlAuth.DisplayMember = "value";
            this.ctrlAuth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ctrlAuth.FormattingEnabled = true;
            this.ctrlAuth.Location = new System.Drawing.Point(65, 82);
            this.ctrlAuth.Name = "ctrlAuth";
            this.ctrlAuth.Size = new System.Drawing.Size(180, 21);
            this.ctrlAuth.TabIndex = 2;
            this.ctrlAuth.Tag = "Authentication";
            this.ctrlAuth.ValueMember = "key";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.Blue;
            this.label10.Location = new System.Drawing.Point(1, 45);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(61, 13);
            this.label10.TabIndex = 57;
            this.label10.Text = "Connection";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(7, 85);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 54;
            this.label5.Text = "Auth. :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 149);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 53;
            this.label3.Text = "Password :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 107);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 55;
            this.label4.Text = "System :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(7, 128);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 56;
            this.label2.Text = "Login :";
            // 
            // ctrlPassword
            // 
            this.ctrlPassword.Location = new System.Drawing.Point(65, 146);
            this.ctrlPassword.Name = "ctrlPassword";
            this.ctrlPassword.Size = new System.Drawing.Size(180, 20);
            this.ctrlPassword.TabIndex = 5;
            this.ctrlPassword.Tag = "Password";
            this.ctrlPassword.UseSystemPasswordChar = true;
            // 
            // ctrlLogin
            // 
            this.ctrlLogin.Location = new System.Drawing.Point(65, 125);
            this.ctrlLogin.Name = "ctrlLogin";
            this.ctrlLogin.Size = new System.Drawing.Size(180, 20);
            this.ctrlLogin.TabIndex = 4;
            this.ctrlLogin.Tag = "Login";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Silver;
            this.pictureBox2.Location = new System.Drawing.Point(33, 176);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(291, 1);
            this.pictureBox2.TabIndex = 59;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Silver;
            this.pictureBox1.Location = new System.Drawing.Point(42, 10);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(282, 1);
            this.pictureBox1.TabIndex = 60;
            this.pictureBox1.TabStop = false;
            // 
            // btCancel
            // 
            this.btCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.btCancel.CausesValidation = false;
            this.btCancel.Location = new System.Drawing.Point(171, 278);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(90, 24);
            this.btCancel.TabIndex = 11;
            this.btCancel.Text = "Cancel";
            this.btCancel.UseVisualStyleBackColor = true;
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // btLogin
            // 
            this.btLogin.FlatAppearance.BorderSize = 2;
            this.btLogin.Location = new System.Drawing.Point(70, 278);
            this.btLogin.Name = "btLogin";
            this.btLogin.Size = new System.Drawing.Size(90, 24);
            this.btLogin.TabIndex = 10;
            this.btLogin.Text = "Login";
            this.btLogin.UseVisualStyleBackColor = true;
            this.btLogin.Click += new System.EventHandler(this.btLogin_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 55;
            this.label1.Text = "Version :";
            // 
            // ctrlVersion
            // 
            this.ctrlVersion.DisplayMember = "value";
            this.ctrlVersion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ctrlVersion.FormattingEnabled = true;
            this.ctrlVersion.Location = new System.Drawing.Point(65, 60);
            this.ctrlVersion.Name = "ctrlVersion";
            this.ctrlVersion.Size = new System.Drawing.Size(99, 21);
            this.ctrlVersion.TabIndex = 1;
            this.ctrlVersion.Tag = "Version";
            this.ctrlVersion.ValueMember = "key";
            // 
            // ctrlUrl
            // 
            this.ctrlUrl.CausesValidation = false;
            this.ctrlUrl.DisplayMember = "value";
            this.ctrlUrl.FormattingEnabled = true;
            this.ctrlUrl.Location = new System.Drawing.Point(9, 19);
            this.ctrlUrl.Name = "ctrlUrl";
            this.ctrlUrl.Size = new System.Drawing.Size(315, 21);
            this.ctrlUrl.TabIndex = 0;
            this.ctrlUrl.Tag = "Web Service";
            this.ctrlUrl.ValueMember = "key";
            this.ctrlUrl.SelectedIndexChanged += new System.EventHandler(this.ctrlUrl_SelectedIndexChanged);
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Silver;
            this.pictureBox3.Location = new System.Drawing.Point(4, 271);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(320, 1);
            this.pictureBox3.TabIndex = 59;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.Color.Silver;
            this.pictureBox4.Location = new System.Drawing.Point(42, 53);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(282, 1);
            this.pictureBox4.TabIndex = 59;
            this.pictureBox4.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Blue;
            this.label6.Location = new System.Drawing.Point(1, 168);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(81, 13);
            this.label6.TabIndex = 57;
            this.label6.Text = "Proxy (Optional)";
            // 
            // ctrlProxyPort
            // 
            this.ctrlProxyPort.Location = new System.Drawing.Point(65, 204);
            this.ctrlProxyPort.Name = "ctrlProxyPort";
            this.ctrlProxyPort.Size = new System.Drawing.Size(180, 20);
            this.ctrlProxyPort.TabIndex = 7;
            this.ctrlProxyPort.Tag = "Proxy Port";
            // 
            // ctrlProxyUser
            // 
            this.ctrlProxyUser.Location = new System.Drawing.Point(65, 225);
            this.ctrlProxyUser.Name = "ctrlProxyUser";
            this.ctrlProxyUser.Size = new System.Drawing.Size(180, 20);
            this.ctrlProxyUser.TabIndex = 8;
            this.ctrlProxyUser.Tag = "Proxy User";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(7, 207);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(32, 13);
            this.label8.TabIndex = 56;
            this.label8.Text = "Port :";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(6, 186);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(35, 13);
            this.label9.TabIndex = 55;
            this.label9.Text = "Host :";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(6, 228);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(35, 13);
            this.label11.TabIndex = 53;
            this.label11.Text = "User :";
            // 
            // ctrlProxyHost
            // 
            this.ctrlProxyHost.Location = new System.Drawing.Point(65, 183);
            this.ctrlProxyHost.Name = "ctrlProxyHost";
            this.ctrlProxyHost.Size = new System.Drawing.Size(180, 20);
            this.ctrlProxyHost.TabIndex = 6;
            this.ctrlProxyHost.Tag = "Proxy Host";
            // 
            // ctrlProxyPasword
            // 
            this.ctrlProxyPasword.Location = new System.Drawing.Point(65, 246);
            this.ctrlProxyPasword.Name = "ctrlProxyPasword";
            this.ctrlProxyPasword.Size = new System.Drawing.Size(180, 20);
            this.ctrlProxyPasword.TabIndex = 9;
            this.ctrlProxyPasword.Tag = "Proxy Password";
            this.ctrlProxyPasword.UseSystemPasswordChar = true;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(6, 249);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(59, 13);
            this.label12.TabIndex = 53;
            this.label12.Text = "Password :";
            // 
            // toolTip
            // 
            this.toolTip.ShowAlways = true;
            // 
            // FrmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(329, 307);
            this.Controls.Add(this.ctrlUrl);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.btLogin);
            this.Controls.Add(this.ctrlProxyHost);
            this.Controls.Add(this.ctrlDomain);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.ctrlVersion);
            this.Controls.Add(this.ctrlAuth);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ctrlProxyPasword);
            this.Controls.Add(this.ctrlProxyUser);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ctrlProxyPort);
            this.Controls.Add(this.ctrlPassword);
            this.Controls.Add(this.ctrlLogin);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Name = "FrmLogin";
            this.Text = "Login";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox ctrlDomain;
        private System.Windows.Forms.Label label7;
        public ComboBoxCust ctrlAuth;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox ctrlPassword;
        public System.Windows.Forms.TextBox ctrlLogin;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.Button btLogin;
        private System.Windows.Forms.Label label1;
        public ComboBoxCust ctrlVersion;
        private ComboBoxCust ctrlUrl;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.TextBox ctrlProxyPort;
        public System.Windows.Forms.TextBox ctrlProxyUser;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label11;
        public System.Windows.Forms.TextBox ctrlProxyHost;
        public System.Windows.Forms.TextBox ctrlProxyPasword;
        private System.Windows.Forms.Label label12;
        public ToolTip toolTip;
    }
}