using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars;

namespace QlyBanThuoc
{
    public partial class frmMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        bool PhanQuyen;
        public frmMain(bool PhanQuyen)
        {
            InitializeComponent();
            this.PhanQuyen = PhanQuyen;
        }

        private void btnDangNhap_ItemClick(object sender, ItemClickEventArgs e)
        {
            DangNhap frm = new DangNhap();
            frm.MdiParent = this;
            frm.Show();
        }

        private void barButtonItem3_ItemClick(object sender, ItemClickEventArgs e)
        {
            
        }

        private void barBtnThuoc_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmThuoc frm = new frmThuoc();
            frm.MdiParent = this;
            frm.Show();
        }
        
        
        private void frmMain_Load(object sender, EventArgs e)
        {
           
      
            if(this.PhanQuyen==false)
            {
                barBtnHopDong.Enabled = false;
                barBtnNCC.Enabled = false;
            }
            else
            {
                barBtnHopDong.Enabled = true;
                barBtnNCC.Enabled = true;
            }
        }

        private void barBtnDangXuat_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Hide();
            DangNhap dn = new DangNhap();
            dn.ShowDialog();
        }
    }
}