using QuanLyTraSua.DBLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyTraSua.BSLayer
{
    class Bill
    {
        DBMain db;
        string err = "";
        public Bill()
        {
            db = new DBMain();
        }
        public DataSet LayTTBill()
        {
            
            SqlCommand sqlCmd = new SqlCommand(@"EXEC sp_Load_Bill", db.conn) { CommandType = CommandType.Text };
            return db.ExecuteQueryDataSet(sqlCmd);
        }
        public DateTime LayDateBuy()
        {
            SqlCommand sqlCmd = new SqlCommand(@"EXEC sp_Select_DateBuy", db.conn) { CommandType = CommandType.Text };
            return Convert.ToDateTime(db.FirstRowQuery(sqlCmd,ref err));
        }
        public int LayBillID(DateTime DateBuy)
        {           
            SqlCommand sqlCmd = new SqlCommand(@"select dbo.fn_Select_BillID(N'"+DateBuy+"')as BillID", db.conn) { CommandType = CommandType.Text };
            return Convert.ToInt32(db.FirstRowQuery(sqlCmd,ref err));
        }
        public bool ThemBill(int BillID,string StaffID,string NameStaff,string NameDrink,int Numbers,string NameCustomer, string PhoneCustomer,DateTime DateBuy,int Money)
        {
            SqlCommand sqlCmd = new SqlCommand(@"Exec sp_Insert_Bill '" + BillID +"',N'"+StaffID+"',N'" + NameStaff + "',N'" + NameDrink + "','" + Numbers + "',N'" + NameCustomer + "',N'" +
                PhoneCustomer + "','" + DateBuy + "','" + Money + "'", db.conn) { CommandType = CommandType.Text };
            return db.MyExecuteNonQuery(sqlCmd);
        }
        public DataSet LayTongBill(DateTime DateBuy)
        {
          
            SqlCommand sqlCmd = new SqlCommand(@"EXEC sp_Select_Bill '" + DateBuy + "'", db.conn) { CommandType = CommandType.Text };
            return db.ExecuteQueryDataSet(sqlCmd);
        }
        public bool XoaBill(DateTime date)
        {
            SqlCommand sqlCmd = new SqlCommand(@"EXEC sp_Delete_Bill '" + date+"'", db.conn) { CommandType = CommandType.Text };
            return db.MyExecuteNonQuery(sqlCmd);
        }
    }
}
