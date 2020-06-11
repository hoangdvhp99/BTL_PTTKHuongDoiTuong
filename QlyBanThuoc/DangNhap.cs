using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace QlyBanThuoc
{
    public partial class DangNhap : DevExpress.XtraEditors.XtraForm
    {
        public DangNhap()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
        public bool PhanQuyen, Access;

        private void DangNhap_Load(object sender, EventArgs e)
        {

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTaiKhoan.Text) || string.IsNullOrEmpty(txtMatKhau.Text))
                MessageBox.Show("Kiểm tra thông tin còn trống!");
            else
            {
                if (txtTaiKhoan.Text == "admin" && txtMatKhau.Text == "admin")
                {
                    PhanQuyen = true; Access = true;
                    this.Hide();
                    frmMain frm = new frmMain(PhanQuyen);
                    frm.ShowDialog();

                    
            
                }
                else if (txtTaiKhoan.Text == "duocsi" && txtMatKhau.Text == "duocsi")
                {
                    PhanQuyen = false; Access = true;
                    this.Hide();
                    frmMain frm = new frmMain(PhanQuyen);
                    frm.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Thông tin đăng nhập không đúng!");
                    Access = false;
                }
            }
        }
    }
}