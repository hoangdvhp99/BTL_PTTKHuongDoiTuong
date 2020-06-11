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
using System.Data.SqlClient;

namespace QlyBanThuoc
{

    public partial class frmThuoc : DevExpress.XtraEditors.XtraForm
    {

        public frmThuoc()
        {
            InitializeComponent();
        }
        Xuly cn = new Xuly();

        private void frmThuoc_Load(object sender, EventArgs e)
        {
            cn.KetNoi();
            loadMaLoai();
            taiDSThuoc();
        }
        private void loadMaLoai()
        {
            string sql = "SELECT MaLoai,TenLoai FROM LoaiThuoc";
            cbLoaiThuoc.DataSource = layDuLieu(sql);
            cbLoaiThuoc.ValueMember = "MaLoai";
            cbLoaiThuoc.DisplayMember = "TenLoai";
        }
        private void taiDSThuoc()
        {
            string sql = "SELECT *FROM Thuoc_LT";
            dgvThuoc.DataSource = layDuLieu(sql);
        }
        private DataTable layDuLieu(string sql)
        {
            cn.KetNoi();
            try
            {
                DataSet dts = new DataSet();
                SqlDataAdapter dta = new SqlDataAdapter(sql, cn.con);
                dta.Fill(dts, sql);
                DataTable dtb = dts.Tables[0];
                

                return dtb;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu!");
                return null;
            }
        }
        private void command(string sql)
        {
            cn.KetNoi();
            SqlCommand cmd = new SqlCommand(sql, cn.con);
            cmd.ExecuteNonQuery();
            cn.DongKetNoi();
        }

        private void dgvThuoc_SelectionChanged(object sender, EventArgs e)
        {
            txtMaThuoc.Text = dgvThuoc.CurrentRow.Cells[0].Value.ToString();
            txtTenThuoc.Text = dgvThuoc.CurrentRow.Cells[1].Value.ToString();
            cbLoaiThuoc.Text = dgvThuoc.CurrentRow.Cells[2].Value.ToString();
            txtDonGiaNhap.Text = dgvThuoc.CurrentRow.Cells[3].Value.ToString();
            txtGiaBan.Text = dgvThuoc.CurrentRow.Cells[4].Value.ToString();
            txtXuatXu.Text = dgvThuoc.CurrentRow.Cells[5].Value.ToString();
            dtpNgaySX.Text = dgvThuoc.CurrentRow.Cells[6].Value.ToString();
            dtpNgayHH.Text = dgvThuoc.CurrentRow.Cells[7].Value.ToString();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            Thuoc thuoc = new Thuoc()
            {
                maThuoc = int.Parse(txtMaThuoc.Text),
                tenThuoc = txtTenThuoc.Text,
                tenGiaNhap = float.Parse(txtDonGiaNhap.Text),
                giaBan = float.Parse(txtGiaBan.Text),
                xuatXu = txtXuatXu.Text,
                ngaySanXuat = dtpNgaySX.Value,
                ngayHetHan = dtpNgayHH.Value,
                maLoaiThuoc = int.Parse(cbLoaiThuoc.SelectedValue.ToString())
            };
            
            command(thuoc.them());
            taiDSThuoc();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            Thuoc thuoc = new Thuoc() { maThuoc = int.Parse(txtMaThuoc.Text) };
            command(thuoc.xoa());
            taiDSThuoc();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            Thuoc thuoc = new Thuoc()
            {
                maThuoc = int.Parse(txtMaThuoc.Text),
                tenThuoc = txtTenThuoc.Text,
                tenGiaNhap = float.Parse(txtDonGiaNhap.Text),
                giaBan = float.Parse(txtGiaBan.Text),
                xuatXu = txtXuatXu.Text,
                ngaySanXuat = dtpNgaySX.Value,
                ngayHetHan = dtpNgayHH.Value,
                maLoaiThuoc = int.Parse(cbLoaiThuoc.SelectedValue.ToString())
            };
            command(thuoc.sua());
            taiDSThuoc();
        }

        private void txtTKTenThuoc_TextChanged(object sender, EventArgs e)
        {
            Thuoc thuoc = new Thuoc();
            dgvThuoc.DataSource = layDuLieu(thuoc.timKiem(txtTKTenThuoc.Text, txtTKLoaiThuoc.Text));
        }

        private void txtTKLoaiThuoc_TextChanged(object sender, EventArgs e)
        {
            Thuoc thuoc = new Thuoc();
            dgvThuoc.DataSource = layDuLieu(thuoc.timKiem(txtTKTenThuoc.Text, txtTKLoaiThuoc.Text));
        }
    }
}