using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyTraSua.DBLayer;
using System.Data.SqlClient;
using System.Data;
namespace QuanLyTraSua.BSLayer
{

    class Drinks
    {
        DBMain db;
        string err = "";
        public Drinks()
        {
            db = new DBMain();
        }

        public DataSet LayDrinks(string CatagoryID)
        {          
            SqlCommand sqlCmd = new SqlCommand(@"EXEC sp_Load_Drink N'" + CatagoryID + "'",db.conn) { CommandType = CommandType.Text };
            return db.ExecuteQueryDataSet(sqlCmd);
        }

       


        public bool ThemOrSuaThucAn(int DrinkID, string TenDoUong, string Loai, int Gia, Byte[] HinhAnh,string MoTa, ref string error)
        {

            SqlCommand sqlCmd = new SqlCommand("sp_Insert_Edit_Drink",db.conn) { CommandType = CommandType.StoredProcedure};
            sqlCmd.Parameters.AddWithValue("@DrinkID", DrinkID);
            sqlCmd.Parameters.AddWithValue("@NameDrink", TenDoUong);
            sqlCmd.Parameters.AddWithValue("@CategoryID", Loai);
            sqlCmd.Parameters.AddWithValue("@Cost", Gia);
            sqlCmd.Parameters.AddWithValue("@Image", HinhAnh);
            sqlCmd.Parameters.AddWithValue("@Description", MoTa);


            return db.MyExecuteNonQuery(sqlCmd);                                
        }

        public bool XoaThucAn(int DrinkID,ref string err)
        {  
            SqlCommand sqlCmd = new SqlCommand(@"EXEC sp_Delete_Drink '" + DrinkID + "'", db.conn) { CommandType = CommandType.Text };
            return db.MyExecuteNonQuery(sqlCmd);
        }

        public bool RestoreThucAn()
        {
            SqlCommand sqlCmd = new SqlCommand(@"set identity_insert Drink on EXEC sp_Restore_Drink  set identity_insert Drink off", db.conn) { CommandType = CommandType.Text };
            return db.MyExecuteNonQuery(sqlCmd);
        }
        public bool XoaRestoreThucAn()
        {
            SqlCommand sqlCmd = new SqlCommand(@"Delete DrinkArchive;", db.conn) { CommandType = CommandType.Text };
            return db.MyExecuteNonQuery(sqlCmd);
        }
    }
}
