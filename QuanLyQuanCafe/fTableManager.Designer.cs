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
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.TextCoffe = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // ngan
            // 
            this.ngan.BackColor = System.Drawing.Color.Snow;
            this.ngan.Location = new System.Drawing.Point(304, 0);
            this.ngan.Name = "ngan";
            this.ngan.Size = new System.Drawing.Size(8, 678);
            this.ngan.TabIndex = 0;
            // 
            // pbLogo
            // 
            this.pbLogo.Image = global::QuanLyQuanCafe.Properties.Resources.logo;
            this.pbLogo.Location = new System.Drawing.Point(24, 0);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(268, 235);
            this.pbLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbLogo.TabIndex = 1;
            this.pbLogo.TabStop = false;
            // 
            // TextCoffe
            // 
            this.TextCoffe.AutoSize = true;
            this.TextCoffe.Font = new System.Drawing.Font("Times New Roman", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextCoffe.ForeColor = System.Drawing.Color.NavajoWhite;
            this.TextCoffe.Location = new System.Drawing.Point(0, 238);
            this.TextCoffe.Name = "TextCoffe";
            this.TextCoffe.Size = new System.Drawing.Size(337, 36);
            this.TextCoffe.TabIndex = 2;
            this.TextCoffe.Text = "THING LONG COFFE";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::QuanLyQuanCafe.Properties.Resources.welcom;
            this.pictureBox1.Location = new System.Drawing.Point(307, -1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(995, 678);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // fTableManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Sienna;
            this.ClientSize = new System.Drawing.Size(1301, 672);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.TextCoffe);
            this.Controls.Add(this.pbLogo);
            this.Controls.Add(this.ngan);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "fTableManager";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Phần mềm quản lý";
            this.Load += new System.EventHandler(this.fTableManager_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel ngan;
        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.Label TextCoffe;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}