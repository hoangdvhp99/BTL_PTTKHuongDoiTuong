using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QlyBanThuoc
{
    public class Thuoc
    {
        public int maThuoc { set; get; }
        public String tenThuoc { set; get; }
        public float tenGiaNhap { get; set; }
        public float giaBan { get; set; }
        public String xuatXu { set; get; }
        public DateTime ngaySanXuat { set; get; }
        public DateTime ngayHetHan { set; get; }
        public int maLoaiThuoc { set; get; }

        public String them()
        {
            return "insert into Thuoc values('" + maThuoc + "',N'" + tenThuoc + "','" + tenGiaNhap + "','" + giaBan + "','" + xuatXu + "','" + ngaySanXuat.ToString("yyyy/MM/dd") + "','" + ngayHetHan.ToString("yyyy/MM/dd") + "','" + maLoaiThuoc + "')";
        }
        public String sua()
        {
            return "update Thuoc set TenThuoc=N'" + tenThuoc + "', DonGiaNhap='" + tenGiaNhap + "',GiaBan='" + giaBan + "',XuatXu='" + xuatXu + "', NgaySX='" + ngaySanXuat.ToString("yyyy/MM/dd") + "', NgayHH='" + ngayHetHan.ToString("yyyy/MM/dd") + "', MaLoai='" + maLoaiThuoc + "' where MaThuoc='" + maThuoc + "'";
        }
        public String xoa()
        {
            return "delete from Thuoc where MaThuoc='" + maThuoc + "'";
        }
        public String timKiem(String ten, String loaiThuoc)
        {
            return "Select *from Thuoc_LT as t where (t.[Tên thuốc] like N'%" + ten + "%')and( t.[Loại thuốc] like N'%" + loaiThuoc + "%')";
        }
    }
}
