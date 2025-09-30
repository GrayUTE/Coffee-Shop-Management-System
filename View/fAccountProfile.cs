using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyQuanCafe.DataBase;

namespace QuanLyQuanCafe
{
    public partial class fAccountProfile : Form
    {
        DatabaseConnection db = new DatabaseConnection();
        public fAccountProfile()
        {
            InitializeComponent();
        }

        private void lbTTTK_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void fAccountProfile_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {
            using(SqlConnection conn = db.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = "SELECT * FROM NhanVien";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dgvDanhSachNV.DataSource = dt;

                    // 📌 Chỉ căn chỉnh hiển thị
                    dgvDanhSachNV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dgvDanhSachNV.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                    dgvDanhSachNV.AllowUserToAddRows = false;
                    dgvDanhSachNV.ReadOnly = true;
                    dgvDanhSachNV.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    dgvDanhSachNV.MultiSelect = false;
                    dgvDanhSachNV.RowHeadersVisible = false;

                    // 📌 Căn chỉnh độ rộng từng cột
                    if (dgvDanhSachNV.Columns.Contains("MaNV"))
                        dgvDanhSachNV.Columns["MaNV"].Width = 60;
                    if (dgvDanhSachNV.Columns.Contains("HoTen"))
                        dgvDanhSachNV.Columns["HoTen"].Width = 100;
                    if (dgvDanhSachNV.Columns.Contains("SDT"))
                        dgvDanhSachNV.Columns["SDT"].Width = 120;
                    if (dgvDanhSachNV.Columns.Contains("NgayVaoLam"))
                        dgvDanhSachNV.Columns["NgayVaoLam"].Width = 120;
                    if (dgvDanhSachNV.Columns.Contains("Luong"))
                        dgvDanhSachNV.Columns["Luong"].Width = 100;
                    if (dgvDanhSachNV.Columns.Contains("DiaChi"))
                        dgvDanhSachNV.Columns["DiaChi"].Width = 150;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi kết nối: " + ex.Message, "Thông báo lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgvDanhSachNV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
