namespace QuanLyQuanCafe
{
    partial class fLogin
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
            this.lbName = new System.Windows.Forms.Label();
            this.ptbLogoUsername = new System.Windows.Forms.PictureBox();
            this.PbLogo = new System.Windows.Forms.PictureBox();
            this.txbUserName = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txbPassword = new System.Windows.Forms.TextBox();
            this.pblogoPassword = new System.Windows.Forms.PictureBox();
            this.LOGIN = new System.Windows.Forms.Button();
            this.Exit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ptbLogoUsername)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbLogo)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pblogoPassword)).BeginInit();
            this.SuspendLayout();
            // 
            // lbName
            // 
            this.lbName.AutoSize = true;
            this.lbName.Font = new System.Drawing.Font("Times New Roman", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbName.ForeColor = System.Drawing.Color.NavajoWhite;
            this.lbName.Location = new System.Drawing.Point(33, 237);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(337, 36);
            this.lbName.TabIndex = 1;
            this.lbName.Text = "THING LONG COFFE";
            this.lbName.Click += new System.EventHandler(this.lbName_Click);
            // 
            // ptbLogoUsername
            // 
            this.ptbLogoUsername.Image = global::QuanLyQuanCafe.Properties.Resources.Tk;
            this.ptbLogoUsername.Location = new System.Drawing.Point(11, 13);
            this.ptbLogoUsername.Name = "ptbLogoUsername";
            this.ptbLogoUsername.Size = new System.Drawing.Size(60, 49);
            this.ptbLogoUsername.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ptbLogoUsername.TabIndex = 2;
            this.ptbLogoUsername.TabStop = false;
            this.ptbLogoUsername.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // PbLogo
            // 
            this.PbLogo.Image = global::QuanLyQuanCafe.Properties.Resources.logo;
            this.PbLogo.Location = new System.Drawing.Point(39, -34);
            this.PbLogo.Name = "PbLogo";
            this.PbLogo.Size = new System.Drawing.Size(313, 281);
            this.PbLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PbLogo.TabIndex = 0;
            this.PbLogo.TabStop = false;
            // 
            // txbUserName
            // 
            this.txbUserName.BackColor = System.Drawing.Color.Peru;
            this.txbUserName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txbUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbUserName.Location = new System.Drawing.Point(65, 17);
            this.txbUserName.Multiline = true;
            this.txbUserName.Name = "txbUserName";
            this.txbUserName.Size = new System.Drawing.Size(249, 43);
            this.txbUserName.TabIndex = 1;
            this.txbUserName.TextChanged += new System.EventHandler(this.txbUserName_TextChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Peru;
            this.panel1.Controls.Add(this.txbUserName);
            this.panel1.Controls.Add(this.ptbLogoUsername);
            this.panel1.Location = new System.Drawing.Point(28, 287);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(333, 73);
            this.panel1.TabIndex = 4;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Peru;
            this.panel2.Controls.Add(this.txbPassword);
            this.panel2.Controls.Add(this.pblogoPassword);
            this.panel2.Location = new System.Drawing.Point(28, 378);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(333, 73);
            this.panel2.TabIndex = 5;
            // 
            // txbPassword
            // 
            this.txbPassword.BackColor = System.Drawing.Color.Peru;
            this.txbPassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txbPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbPassword.Location = new System.Drawing.Point(65, 17);
            this.txbPassword.Name = "txbPassword";
            this.txbPassword.Size = new System.Drawing.Size(249, 39);
            this.txbPassword.TabIndex = 2;
            this.txbPassword.UseSystemPasswordChar = true;
            this.txbPassword.TextChanged += new System.EventHandler(this.txbPassword_TextChanged);
            // 
            // pblogoPassword
            // 
            this.pblogoPassword.Image = global::QuanLyQuanCafe.Properties.Resources.pass;
            this.pblogoPassword.Location = new System.Drawing.Point(11, 13);
            this.pblogoPassword.Name = "pblogoPassword";
            this.pblogoPassword.Size = new System.Drawing.Size(60, 49);
            this.pblogoPassword.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pblogoPassword.TabIndex = 2;
            this.pblogoPassword.TabStop = false;
            // 
            // LOGIN
            // 
            this.LOGIN.BackColor = System.Drawing.Color.Peru;
            this.LOGIN.Font = new System.Drawing.Font("Times New Roman", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LOGIN.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.LOGIN.Location = new System.Drawing.Point(121, 466);
            this.LOGIN.Name = "LOGIN";
            this.LOGIN.Size = new System.Drawing.Size(131, 51);
            this.LOGIN.TabIndex = 3;
            this.LOGIN.Text = "ĐĂNG NHẬP";
            this.LOGIN.UseVisualStyleBackColor = false;
            this.LOGIN.Click += new System.EventHandler(this.LOGIN_Click);
            // 
            // Exit
            // 
            this.Exit.BackColor = System.Drawing.Color.Peru;
            this.Exit.Font = new System.Drawing.Font("Times New Roman", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Exit.ForeColor = System.Drawing.Color.DarkRed;
            this.Exit.Location = new System.Drawing.Point(271, 466);
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(90, 51);
            this.Exit.TabIndex = 4;
            this.Exit.Text = "THOÁT";
            this.Exit.UseVisualStyleBackColor = false;
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // fLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SaddleBrown;
            this.ClientSize = new System.Drawing.Size(392, 538);
            this.Controls.Add(this.Exit);
            this.Controls.Add(this.LOGIN);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lbName);
            this.Controls.Add(this.PbLogo);
            this.ForeColor = System.Drawing.SystemColors.Control;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "fLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đăng Nhập";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.fLogin_FormClosing);
            this.Load += new System.EventHandler(this.fLogin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ptbLogoUsername)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbLogo)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pblogoPassword)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox PbLogo;
        private System.Windows.Forms.Label lbName;
        private System.Windows.Forms.PictureBox ptbLogoUsername;
        private System.Windows.Forms.TextBox txbUserName;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txbPassword;
        private System.Windows.Forms.PictureBox pblogoPassword;
        private System.Windows.Forms.Button LOGIN;
        private System.Windows.Forms.Button Exit;
        private System.Windows.Forms.Panel panel2;
    }
}