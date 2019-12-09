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
    class Category
    {
        DBMain db;
        string err = "";
        public Category()
        {
            db = new DBMain();
        }

        public DataSet LayTTCategory()
        {
            SqlCommand sqlCmd = new SqlCommand(@"EXEC Load_Category", db.conn) { CommandType = CommandType.Text };
            return db.ExecuteQueryDataSet(sqlCmd);
        }

        public bool ThemCategory(string Ma, string TenLoai, ref string error)
        {

            SqlCommand sqlCmd = new SqlCommand(@"EXEC Insert_Category N'" + Ma+"',N'"+TenLoai+"'", db.conn) { CommandType = CommandType.Text };
            return db.MyExecuteNonQuery(sqlCmd);
        }
    }
}
