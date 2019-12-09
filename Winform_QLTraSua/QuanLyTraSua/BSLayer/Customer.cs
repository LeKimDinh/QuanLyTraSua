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
  
    class Customer
    {
        DBMain db;
        string err = "";
        public Customer()
        {
            db = new DBMain();
        }
        public DataSet LayTTKH( string SDT, ref string error)
        {

            SqlCommand sqlCmd = new SqlCommand(@"select * from fn_Customer_DisCount(N'" + SDT + "') as Customer_DisCount", db.conn) { CommandType = CommandType.Text };
             return db.ExecuteQueryDataSet(sqlCmd);
        }

        public bool ThemOrSuaKH(string TenKH, DateTime NgaySinh, string Phone, string Email, string City,string District,int ID, ref string error)
        {
            SqlCommand sqlCmd = new SqlCommand(@"EXEC sp_Insert_Edit_Customer N'" + TenKH + "','" + NgaySinh + "',N'" + Phone + "',N'" + Email + "',N'" + City + "',N'" + District + "',N'"+ID+"'",db.conn) { CommandType = CommandType.Text };
            return db.MyExecuteNonQuery(sqlCmd);
        }


        public int LayID(string PhoneNumber)
        {        
            SqlCommand sqlCmd = new SqlCommand(@"select dbo.fn_Select_CustomerID (N'" + PhoneNumber + "') as CustomerID",db.conn) { CommandType = CommandType.Text };
            return Convert.ToInt32(db.FirstRowQuery(sqlCmd,ref err));

        }

       
    }
}
