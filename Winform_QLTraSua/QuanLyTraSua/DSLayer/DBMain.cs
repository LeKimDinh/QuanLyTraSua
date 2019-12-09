using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyTraSua.DBLayer
{
    class DBMain
    {
        public SqlConnection conn = null;
        SqlCommand cmd = null;
        SqlDataAdapter dt = null;

        string strConnection = "Data Source=DESKTOP-MRT5TD1;" + "Initial Catalog=QLTraSua;" + "Integrated Security=True";
        public DBMain()
        {
            conn = new SqlConnection(strConnection);
            cmd = conn.CreateCommand();
        }

        /// <summary>
        /// Lấy dữ liệu đổ lên dataset
        /// </summary>
        public DataSet ExecuteQueryDataSet(SqlCommand ct)
        {
            //Kiểm tra xem csdl đang kết nối, để đóng lại
            if (conn.State == ConnectionState.Open)
                conn.Close();
            conn.Open();

            cmd = ct;
            

            dt = new SqlDataAdapter(cmd);

            DataSet ds = new DataSet();
            dt.Fill(ds);

            return ds;
        }

        /// <summary>
        /// Thực hiện câu truy vấn, dùng để cập nhật, xóa, thêm.
        /// </summary>
        /// <returns></returns>
        public bool MyExecuteNonQuery(SqlCommand ct)
        {
            bool f = false;
            try
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
                conn.Open();
                cmd = ct;
                cmd.ExecuteNonQuery();
                f = true;
            }
            catch (SqlException sqlEx)
            {
               
                MessageBox.Show(sqlEx.Message);
                f = false;
            }
            finally
            {
                conn.Close();
            }
            return f;
        }

        /// <summary>
        /// Lấy dữ liệu dòng đầu tiên của câu truy vấn.
        /// </summary>
        public object FirstRowQuery( SqlCommand ct, ref string error)
        {
            object obj = null;
            try
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
                conn.Open();
                cmd = ct;
                obj = cmd.ExecuteScalar();
               
            }
            catch (SqlException sqlEx)
            {
                error = sqlEx.Message;
                MessageBox.Show(sqlEx.Message);
            }
            finally
            {
                conn.Close();
            }
            
            return obj;
        }
      


    }
}
