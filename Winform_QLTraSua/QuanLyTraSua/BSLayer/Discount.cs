using QuanLyTraSua.DBLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyTraSua.BSLayer
{
    class Discount
    {
        DBMain db;
        string err;
        public Discount()
        {
            db = new DBMain();
        }

        public DataSet LayTTDC()
        {
            SqlCommand sqlCmd = new SqlCommand(@"EXEC sp_Load_Discount", db.conn) { CommandType = CommandType.Text };
            return db.ExecuteQueryDataSet(sqlCmd);
        }

        public DataSet LayMaGiamGia(string PhoneNumber)
        {
            SqlCommand sqlCmd = new SqlCommand(@"EXEC sp_Select_Discount N'" + PhoneNumber + "%'",db.conn) { CommandType = CommandType.Text };
            return db.ExecuteQueryDataSet(sqlCmd);
        }
        public int LayGiamGia(string PhoneNumber)
        {
            SqlCommand sqlCmd = new SqlCommand(@"select dbo.fn_Select_Discount(N'"+PhoneNumber+"')as MemberDiscount", db.conn) { CommandType = CommandType.Text };
            return Convert.ToInt32(db.FirstRowQuery(sqlCmd, ref err));
        }
        public bool UpdateDiscount(int MemberPoints,string PhoneNumber)
        {
            SqlCommand sqlCmd = new SqlCommand(@"sp_Edit_Discount '" + MemberPoints + "',N'" + PhoneNumber + "'",db.conn) { CommandType = CommandType.Text };
            return db.MyExecuteNonQuery(sqlCmd);
            
        }
    }
}
