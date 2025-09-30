using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyQuanCafe
{
    public partial class fTableManager : Form
    {
        public fTableManager()
        {
            InitializeComponent();
        }

        private void fTableManager_Load(object sender, EventArgs e)
        {

        }

        private void btnAdmin_Click(object sender, EventArgs e)
        {

            fLogin f = new fLogin("admin");
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void btnNV_Click(object sender, EventArgs e)
        {
            fLogin f = new fLogin("staff");
            this.Hide();
            f.ShowDialog();
            this.Show();
        }
    }
}
