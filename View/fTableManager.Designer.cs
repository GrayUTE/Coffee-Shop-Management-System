namespace QuanLyQuanCafe
{
    partial class fTableManager
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
            this.ngan = new System.Windows.Forms.Panel();
            this.TextCoffe = new System.Windows.Forms.Label();
            this.btnAdmin = new System.Windows.Forms.Button();
            this.btnNV = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // ngan
            // 
            this.ngan.BackColor = System.Drawing.Color.Snow;
            this.ngan.Location = new System.Drawing.Point(349, 0);
            this.ngan.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ngan.Name = "ngan";
            this.ngan.Size = new System.Drawing.Size(9, 848);
            this.ngan.TabIndex = 0;
            // 
            // TextCoffe
            // 
            this.TextCoffe.AutoSize = true;
            this.TextCoffe.Font = new System.Drawing.Font("Times New Roman", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextCoffe.ForeColor = System.Drawing.Color.NavajoWhite;
            this.TextCoffe.Location = new System.Drawing.Point(0, 298);
            this.TextCoffe.Name = "TextCoffe";
            this.TextCoffe.Size = new System.Drawing.Size(337, 36);
            this.TextCoffe.TabIndex = 2;
            this.TextCoffe.Text = "THING LONG COFFE";
            // 
            // btnAdmin
            // 
            this.btnAdmin.BackColor = System.Drawing.Color.Peru;
            this.btnAdmin.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdmin.ForeColor = System.Drawing.Color.NavajoWhite;
            this.btnAdmin.Location = new System.Drawing.Point(62, 385);
            this.btnAdmin.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnAdmin.Name = "btnAdmin";
            this.btnAdmin.Size = new System.Drawing.Size(219, 75);
            this.btnAdmin.TabIndex = 4;
            this.btnAdmin.Text = "ADMIN";
            this.btnAdmin.UseVisualStyleBackColor = false;
            this.btnAdmin.Click += new System.EventHandler(this.btnAdmin_Click);
            // 
            // btnNV
            // 
            this.btnNV.BackColor = System.Drawing.Color.Peru;
            this.btnNV.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNV.ForeColor = System.Drawing.Color.NavajoWhite;
            this.btnNV.Location = new System.Drawing.Point(62, 512);
            this.btnNV.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnNV.Name = "btnNV";
            this.btnNV.Size = new System.Drawing.Size(219, 75);
            this.btnNV.TabIndex = 5;
            this.btnNV.Text = "NHÂN VIÊN";
            this.btnNV.UseVisualStyleBackColor = false;
            this.btnNV.Click += new System.EventHandler(this.btnNV_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::QuanLyQuanCafe.Properties.Resources.welcom;
            this.pictureBox1.Location = new System.Drawing.Point(356, -1);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1107, 848);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // pbLogo
            // 
            this.pbLogo.Image = global::QuanLyQuanCafe.Properties.Resources.logo;
            this.pbLogo.Location = new System.Drawing.Point(27, 0);
            this.pbLogo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(302, 294);
            this.pbLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbLogo.TabIndex = 1;
            this.pbLogo.TabStop = false;
            // 
            // fTableManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Sienna;
            this.ClientSize = new System.Drawing.Size(1464, 840);
            this.Controls.Add(this.btnNV);
            this.Controls.Add(this.btnAdmin);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.TextCoffe);
            this.Controls.Add(this.pbLogo);
            this.Controls.Add(this.ngan);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "fTableManager";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Phần mềm quản lý";
            this.Load += new System.EventHandler(this.fTableManager_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel ngan;
        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.Label TextCoffe;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnAdmin;
        private System.Windows.Forms.Button btnNV;
    }
}