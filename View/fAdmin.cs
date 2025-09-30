using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyQuanCafe.BUS;
using QuanLyQuanCafe.DTO;

namespace QuanLyQuanCafe
{
    public partial class fAdmin : Form
    {
        public fAdmin()
        {
            InitializeComponent();
            LoadFoodList();
        }

        private void ADMIN_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có thật sự muốn thoát chương trình?", "Thông báo", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true;
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void lbAdmin_Click(object sender, EventArgs e)
        {

        }

        private void ADMIN_Load(object sender, EventArgs e)
        {

        }

        private void btnTKadmin_Click(object sender, EventArgs e)
        {
            fAccountProfile f = new fAccountProfile();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void lblRevenue_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void tcQLmenu_Click(object sender, EventArgs e)
        {

        }

        private void dgSp_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void LoadFoodList()
        {
            List<FoodDTO> foodList = FoodBUS.Instance.GetFoodList();
            dgFood.DataSource = foodList;
            // Tùy chỉnh tiêu đề cột
            dgFood.Columns["TenSP"].HeaderText = "Tên món";
            dgFood.Columns["LoaiSP"].HeaderText = "Loại";
            dgFood.Columns["DonGia"].HeaderText = "Đơn giá";

            // 📌 Chỉ căn chỉnh hiển thị
            dgFood.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgFood.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgFood.AllowUserToAddRows = false;
            dgFood.ReadOnly = true;
            dgFood.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgFood.MultiSelect = false;
            dgFood.RowHeadersVisible = false;
        }
    }
}
