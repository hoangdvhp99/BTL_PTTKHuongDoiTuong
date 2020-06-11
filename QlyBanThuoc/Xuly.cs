using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace QlyBanThuoc
{
    class Xuly
    {
        public SqlConnection con = new SqlConnection();
        string ChuoiKetNoi = @"Data Source=ADMIN\HOANGSQL;Initial Catalog=QlyBanThuoc;Integrated Security=True";
        public bool KetNoi()
        {
            try
            {
                con = new SqlConnection(ChuoiKetNoi);
                con.Open();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public void DongKetNoi()
        {
            con.Close();
        }
    }
}
