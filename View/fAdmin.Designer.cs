namespace QuanLyQuanCafe
{
    partial class fAdmin
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
            this.label1 = new System.Windows.Forms.Label();
            this.lbAdmin = new System.Windows.Forms.Label();
            this.pnAdmin = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.tpQLKH = new System.Windows.Forms.TabPage();
            this.tpQLNV = new System.Windows.Forms.TabPage();
            this.tcQLmenu = new System.Windows.Forms.TabPage();
            this.dgFood = new System.Windows.Forms.DataGridView();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.btnAddMon = new System.Windows.Forms.Button();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnXoaMon = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.tbLoaiMon = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbGia = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbTenMon = new System.Windows.Forms.TextBox();
            this.tbMaMon = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tpDB = new System.Windows.Forms.TabPage();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lblAmountOrder = new System.Windows.Forms.Label();
            this.lblOrder = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblAmountItems = new System.Windows.Forms.Label();
            this.lblItems = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblAmountStaff = new System.Windows.Forms.Label();
            this.lblStaff = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblAmountRenevue = new System.Windows.Forms.Label();
            this.lblRevenue = new System.Windows.Forms.Label();
            this.tpDashBoard = new System.Windows.Forms.TabControl();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.pnAdmin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tcQLmenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgFood)).BeginInit();
            this.panel5.SuspendLayout();
            this.tpDB.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tpDashBoard.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.NavajoWhite;
            this.label1.Location = new System.Drawing.Point(7, 300);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(337, 36);
            this.label1.TabIndex = 2;
            this.label1.Text = "THING LONG COFFE";
            // 
            // lbAdmin
            // 
            this.lbAdmin.AutoSize = true;
            this.lbAdmin.BackColor = System.Drawing.Color.SandyBrown;
            this.lbAdmin.Font = new System.Drawing.Font("Times New Roman", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbAdmin.ForeColor = System.Drawing.Color.NavajoWhite;
            this.lbAdmin.Location = new System.Drawing.Point(115, 20);
            this.lbAdmin.Name = "lbAdmin";
            this.lbAdmin.Size = new System.Drawing.Size(126, 36);
            this.lbAdmin.TabIndex = 3;
            this.lbAdmin.Text = "ADMIN";
            this.lbAdmin.Click += new System.EventHandler(this.lbAdmin_Click);
            // 
            // pnAdmin
            // 
            this.pnAdmin.BackColor = System.Drawing.Color.SandyBrown;
            this.pnAdmin.Controls.Add(this.lbAdmin);
            this.pnAdmin.Location = new System.Drawing.Point(-3, 371);
            this.pnAdmin.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnAdmin.Name = "pnAdmin";
            this.pnAdmin.Size = new System.Drawing.Size(382, 76);
            this.pnAdmin.TabIndex = 4;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::QuanLyQuanCafe.Properties.Resources.logo;
            this.pictureBox1.Location = new System.Drawing.Point(20, -31);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(310, 356);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // tabPage4
            // 
            this.tabPage4.BackColor = System.Drawing.Color.Sienna;
            this.tabPage4.Location = new System.Drawing.Point(4, 36);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(908, 804);
            this.tabPage4.TabIndex = 4;
            this.tabPage4.Text = "Quản Lý Hóa Đơn";
            // 
            // tpQLKH
            // 
            this.tpQLKH.BackColor = System.Drawing.Color.Sienna;
            this.tpQLKH.Location = new System.Drawing.Point(4, 36);
            this.tpQLKH.Name = "tpQLKH";
            this.tpQLKH.Padding = new System.Windows.Forms.Padding(3);
            this.tpQLKH.Size = new System.Drawing.Size(908, 804);
            this.tpQLKH.TabIndex = 3;
            this.tpQLKH.Text = "Quản Lý Khách Hàng";
            // 
            // tpQLNV
            // 
            this.tpQLNV.BackColor = System.Drawing.Color.Sienna;
            this.tpQLNV.Location = new System.Drawing.Point(4, 36);
            this.tpQLNV.Name = "tpQLNV";
            this.tpQLNV.Padding = new System.Windows.Forms.Padding(3);
            this.tpQLNV.Size = new System.Drawing.Size(908, 804);
            this.tpQLNV.TabIndex = 2;
            this.tpQLNV.Text = "Quản Lý Nhân Viên";
            // 
            // tcQLmenu
            // 
            this.tcQLmenu.BackColor = System.Drawing.Color.Sienna;
            this.tcQLmenu.Controls.Add(this.dgFood);
            this.tcQLmenu.Controls.Add(this.comboBox1);
            this.tcQLmenu.Controls.Add(this.label8);
            this.tcQLmenu.Controls.Add(this.panel5);
            this.tcQLmenu.Controls.Add(this.label2);
            this.tcQLmenu.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.tcQLmenu.Location = new System.Drawing.Point(4, 36);
            this.tcQLmenu.Name = "tcQLmenu";
            this.tcQLmenu.Padding = new System.Windows.Forms.Padding(3);
            this.tcQLmenu.Size = new System.Drawing.Size(908, 804);
            this.tcQLmenu.TabIndex = 1;
            this.tcQLmenu.Text = "Quản Lý Menu";
            this.tcQLmenu.Click += new System.EventHandler(this.tcQLmenu_Click);
            // 
            // dgFood
            // 
            this.dgFood.BackgroundColor = System.Drawing.Color.SaddleBrown;
            this.dgFood.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgFood.Location = new System.Drawing.Point(27, 437);
            this.dgFood.Name = "dgFood";
            this.dgFood.RowHeadersWidth = 62;
            this.dgFood.RowTemplate.Height = 28;
            this.dgFood.Size = new System.Drawing.Size(867, 336);
            this.dgFood.TabIndex = 18;
            this.dgFood.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgSp_CellContentClick);
            // 
            // comboBox1
            // 
            this.comboBox1.BackColor = System.Drawing.Color.Linen;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(108, 371);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(259, 35);
            this.comboBox1.TabIndex = 17;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.NavajoWhite;
            this.label8.Location = new System.Drawing.Point(18, 377);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(84, 23);
            this.label8.TabIndex = 16;
            this.label8.Text = "Lọc theo";
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.SaddleBrown;
            this.panel5.Controls.Add(this.btnAddMon);
            this.panel5.Controls.Add(this.btnLuu);
            this.panel5.Controls.Add(this.btnXoaMon);
            this.panel5.Controls.Add(this.button2);
            this.panel5.Controls.Add(this.label7);
            this.panel5.Controls.Add(this.tbLoaiMon);
            this.panel5.Controls.Add(this.label6);
            this.panel5.Controls.Add(this.tbGia);
            this.panel5.Controls.Add(this.label5);
            this.panel5.Controls.Add(this.tbTenMon);
            this.panel5.Controls.Add(this.tbMaMon);
            this.panel5.Controls.Add(this.label4);
            this.panel5.Controls.Add(this.label3);
            this.panel5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel5.Location = new System.Drawing.Point(0, 73);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(902, 258);
            this.panel5.TabIndex = 15;
            // 
            // btnAddMon
            // 
            this.btnAddMon.BackColor = System.Drawing.Color.LightGray;
            this.btnAddMon.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddMon.ForeColor = System.Drawing.Color.Sienna;
            this.btnAddMon.Location = new System.Drawing.Point(480, 44);
            this.btnAddMon.Name = "btnAddMon";
            this.btnAddMon.Size = new System.Drawing.Size(134, 44);
            this.btnAddMon.TabIndex = 15;
            this.btnAddMon.Text = "Thêm món";
            this.btnAddMon.UseVisualStyleBackColor = false;
            // 
            // btnLuu
            // 
            this.btnLuu.BackColor = System.Drawing.Color.LightGray;
            this.btnLuu.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLuu.ForeColor = System.Drawing.Color.SaddleBrown;
            this.btnLuu.Location = new System.Drawing.Point(387, 193);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(114, 45);
            this.btnLuu.TabIndex = 14;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseVisualStyleBackColor = false;
            // 
            // btnXoaMon
            // 
            this.btnXoaMon.BackColor = System.Drawing.Color.LightGray;
            this.btnXoaMon.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoaMon.ForeColor = System.Drawing.Color.SaddleBrown;
            this.btnXoaMon.Location = new System.Drawing.Point(620, 44);
            this.btnXoaMon.Name = "btnXoaMon";
            this.btnXoaMon.Size = new System.Drawing.Size(129, 44);
            this.btnXoaMon.TabIndex = 12;
            this.btnXoaMon.Text = "Xóa món";
            this.btnXoaMon.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.LightGray;
            this.button2.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.SaddleBrown;
            this.button2.Location = new System.Drawing.Point(755, 44);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(140, 44);
            this.button2.TabIndex = 11;
            this.button2.Text = "Cập nhật";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label7.Location = new System.Drawing.Point(724, 105);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(88, 22);
            this.label7.TabIndex = 9;
            this.label7.Text = "Danh mục";
            // 
            // tbLoaiMon
            // 
            this.tbLoaiMon.BackColor = System.Drawing.Color.LightSalmon;
            this.tbLoaiMon.Location = new System.Drawing.Point(728, 130);
            this.tbLoaiMon.Name = "tbLoaiMon";
            this.tbLoaiMon.Size = new System.Drawing.Size(167, 35);
            this.tbLoaiMon.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label6.Location = new System.Drawing.Point(476, 105);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 22);
            this.label6.TabIndex = 7;
            this.label6.Text = "Đơn giá";
            // 
            // tbGia
            // 
            this.tbGia.BackColor = System.Drawing.Color.LightSalmon;
            this.tbGia.Location = new System.Drawing.Point(480, 130);
            this.tbGia.Name = "tbGia";
            this.tbGia.Size = new System.Drawing.Size(174, 35);
            this.tbGia.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label5.Location = new System.Drawing.Point(245, 105);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 22);
            this.label5.TabIndex = 5;
            this.label5.Text = "Tên";
            // 
            // tbTenMon
            // 
            this.tbTenMon.BackColor = System.Drawing.Color.LightSalmon;
            this.tbTenMon.Location = new System.Drawing.Point(249, 130);
            this.tbTenMon.Name = "tbTenMon";
            this.tbTenMon.Size = new System.Drawing.Size(167, 35);
            this.tbTenMon.TabIndex = 4;
            // 
            // tbMaMon
            // 
            this.tbMaMon.BackColor = System.Drawing.Color.LightSalmon;
            this.tbMaMon.Location = new System.Drawing.Point(24, 130);
            this.tbMaMon.Name = "tbMaMon";
            this.tbMaMon.Size = new System.Drawing.Size(158, 35);
            this.tbMaMon.TabIndex = 3;
            this.tbMaMon.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label4.Location = new System.Drawing.Point(20, 105);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 22);
            this.label4.TabIndex = 2;
            this.label4.Text = "Mã món";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.NavajoWhite;
            this.label3.Location = new System.Drawing.Point(18, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(280, 26);
            this.label3.TabIndex = 1;
            this.label3.Text = "Thông tin chi tiết của món";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.NavajoWhite;
            this.label2.Location = new System.Drawing.Point(21, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(299, 32);
            this.label2.TabIndex = 0;
            this.label2.Text = "QUẢN LÝ THỰC ĐƠN";
            // 
            // tpDB
            // 
            this.tpDB.BackColor = System.Drawing.Color.Sienna;
            this.tpDB.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.tpDB.Controls.Add(this.panel4);
            this.tpDB.Controls.Add(this.panel3);
            this.tpDB.Controls.Add(this.panel2);
            this.tpDB.Controls.Add(this.panel1);
            this.tpDB.ForeColor = System.Drawing.Color.Black;
            this.tpDB.Location = new System.Drawing.Point(4, 36);
            this.tpDB.Name = "tpDB";
            this.tpDB.Padding = new System.Windows.Forms.Padding(3);
            this.tpDB.Size = new System.Drawing.Size(908, 804);
            this.tpDB.TabIndex = 0;
            this.tpDB.Text = "DashBoard ";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.LightSalmon;
            this.panel4.Controls.Add(this.lblAmountOrder);
            this.panel4.Controls.Add(this.lblOrder);
            this.panel4.Location = new System.Drawing.Point(709, 30);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(188, 90);
            this.panel4.TabIndex = 5;
            // 
            // lblAmountOrder
            // 
            this.lblAmountOrder.AutoSize = true;
            this.lblAmountOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAmountOrder.ForeColor = System.Drawing.Color.White;
            this.lblAmountOrder.Location = new System.Drawing.Point(25, 45);
            this.lblAmountOrder.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAmountOrder.Name = "lblAmountOrder";
            this.lblAmountOrder.Size = new System.Drawing.Size(134, 20);
            this.lblAmountOrder.TabIndex = 2;
            this.lblAmountOrder.Text = "lblAmountOrder";
            // 
            // lblOrder
            // 
            this.lblOrder.AutoSize = true;
            this.lblOrder.Font = new System.Drawing.Font("Roboto", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrder.ForeColor = System.Drawing.Color.White;
            this.lblOrder.Location = new System.Drawing.Point(15, 21);
            this.lblOrder.Name = "lblOrder";
            this.lblOrder.Size = new System.Drawing.Size(158, 24);
            this.lblOrder.TabIndex = 1;
            this.lblOrder.Text = "Tổng số hóa đơn";
            this.lblOrder.Click += new System.EventHandler(this.label7_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.LightSalmon;
            this.panel3.Controls.Add(this.lblAmountItems);
            this.panel3.Controls.Add(this.lblItems);
            this.panel3.Location = new System.Drawing.Point(473, 30);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(190, 90);
            this.panel3.TabIndex = 4;
            // 
            // lblAmountItems
            // 
            this.lblAmountItems.AutoSize = true;
            this.lblAmountItems.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAmountItems.ForeColor = System.Drawing.Color.White;
            this.lblAmountItems.Location = new System.Drawing.Point(28, 45);
            this.lblAmountItems.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAmountItems.Name = "lblAmountItems";
            this.lblAmountItems.Size = new System.Drawing.Size(134, 20);
            this.lblAmountItems.TabIndex = 2;
            this.lblAmountItems.Text = "lblAmountItems";
            // 
            // lblItems
            // 
            this.lblItems.AutoSize = true;
            this.lblItems.Font = new System.Drawing.Font("Roboto", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItems.ForeColor = System.Drawing.Color.White;
            this.lblItems.Location = new System.Drawing.Point(15, 21);
            this.lblItems.Name = "lblItems";
            this.lblItems.Size = new System.Drawing.Size(160, 24);
            this.lblItems.TabIndex = 1;
            this.lblItems.Text = "Số lượng món ăn";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LightSalmon;
            this.panel2.Controls.Add(this.lblAmountStaff);
            this.panel2.Controls.Add(this.lblStaff);
            this.panel2.Location = new System.Drawing.Point(235, 30);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(189, 90);
            this.panel2.TabIndex = 4;
            // 
            // lblAmountStaff
            // 
            this.lblAmountStaff.AutoSize = true;
            this.lblAmountStaff.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAmountStaff.ForeColor = System.Drawing.Color.White;
            this.lblAmountStaff.Location = new System.Drawing.Point(29, 45);
            this.lblAmountStaff.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAmountStaff.Name = "lblAmountStaff";
            this.lblAmountStaff.Size = new System.Drawing.Size(129, 20);
            this.lblAmountStaff.TabIndex = 2;
            this.lblAmountStaff.Text = "lblAmountStaff";
            // 
            // lblStaff
            // 
            this.lblStaff.AutoSize = true;
            this.lblStaff.Font = new System.Drawing.Font("Roboto", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStaff.ForeColor = System.Drawing.Color.White;
            this.lblStaff.Location = new System.Drawing.Point(6, 21);
            this.lblStaff.Name = "lblStaff";
            this.lblStaff.Size = new System.Drawing.Size(180, 24);
            this.lblStaff.TabIndex = 1;
            this.lblStaff.Text = "Số lượng nhân viên";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightSalmon;
            this.panel1.Controls.Add(this.lblAmountRenevue);
            this.panel1.Controls.Add(this.lblRevenue);
            this.panel1.Location = new System.Drawing.Point(6, 30);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(183, 90);
            this.panel1.TabIndex = 3;
            // 
            // lblAmountRenevue
            // 
            this.lblAmountRenevue.AutoSize = true;
            this.lblAmountRenevue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAmountRenevue.ForeColor = System.Drawing.Color.White;
            this.lblAmountRenevue.Location = new System.Drawing.Point(10, 45);
            this.lblAmountRenevue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAmountRenevue.Name = "lblAmountRenevue";
            this.lblAmountRenevue.Size = new System.Drawing.Size(160, 20);
            this.lblAmountRenevue.TabIndex = 2;
            this.lblAmountRenevue.Text = "lblAmountRenevue";
            // 
            // lblRevenue
            // 
            this.lblRevenue.AutoSize = true;
            this.lblRevenue.Font = new System.Drawing.Font("Roboto", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRevenue.ForeColor = System.Drawing.Color.White;
            this.lblRevenue.Location = new System.Drawing.Point(39, 21);
            this.lblRevenue.Name = "lblRevenue";
            this.lblRevenue.Size = new System.Drawing.Size(105, 24);
            this.lblRevenue.TabIndex = 1;
            this.lblRevenue.Text = "Doanh Thu";
            this.lblRevenue.Click += new System.EventHandler(this.lblRevenue_Click);
            // 
            // tpDashBoard
            // 
            this.tpDashBoard.Controls.Add(this.tpDB);
            this.tpDashBoard.Controls.Add(this.tcQLmenu);
            this.tpDashBoard.Controls.Add(this.tpQLNV);
            this.tpDashBoard.Controls.Add(this.tpQLKH);
            this.tpDashBoard.Controls.Add(this.tabPage4);
            this.tpDashBoard.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tpDashBoard.Location = new System.Drawing.Point(370, -3);
            this.tpDashBoard.Name = "tpDashBoard";
            this.tpDashBoard.SelectedIndex = 0;
            this.tpDashBoard.Size = new System.Drawing.Size(916, 844);
            this.tpDashBoard.TabIndex = 5;
            this.tpDashBoard.Tag = "";
            // 
            // fAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Sienna;
            this.ClientSize = new System.Drawing.Size(1285, 840);
            this.Controls.Add(this.tpDashBoard);
            this.Controls.Add(this.pnAdmin);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "fAdmin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ADMIN";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ADMIN_FormClosing);
            this.Load += new System.EventHandler(this.ADMIN_Load);
            this.pnAdmin.ResumeLayout(false);
            this.pnAdmin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tcQLmenu.ResumeLayout(false);
            this.tcQLmenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgFood)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.tpDB.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tpDashBoard.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbAdmin;
        private System.Windows.Forms.Panel pnAdmin;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabPage tpQLKH;
        private System.Windows.Forms.TabPage tpQLNV;
        private System.Windows.Forms.TabPage tcQLmenu;
        private System.Windows.Forms.TabPage tpDB;
        private System.Windows.Forms.TabControl tpDashBoard;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label lblAmountRenevue;
        private System.Windows.Forms.Label lblRevenue;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label lblAmountOrder;
        private System.Windows.Forms.Label lblOrder;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblAmountItems;
        private System.Windows.Forms.Label lblItems;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblAmountStaff;
        private System.Windows.Forms.Label lblStaff;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbMaMon;
        private System.Windows.Forms.Button btnXoaMon;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbLoaiMon;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbGia;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbTenMon;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnAddMon;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridView dgFood;
    }
}