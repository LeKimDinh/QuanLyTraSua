using QuanLyTraSua.DBLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyTraSua
{
    public partial class Register : Form
    {
        DBMain db;
        string err = "";
        
        public Register()
        {
            InitializeComponent();
            db = null;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Register_Load(object sender, EventArgs e)
        {

        }

        private void btn_register_Click(object sender, EventArgs e)
        {
            db = new DBMain();
            if (btn_userDK.Text == "")
            {
                MessageBox.Show("Vui lòng nhập tên tài khoản!");
                return;
            }
            if (btn_passwordDK.Text == "")
            {
                MessageBox.Show("Vui lòng nhập mật khẩu!");
                return;
            }

            if (btn_passwordDK.Text != btn_RetypeDK.Text)
                MessageBox.Show("Hai mật khẩu không khớp!");
            else
            {
                //string LayMaQL = @"EXEC LayMaQuanLy '" + btn_userDK.Text.ToString().TrimEnd() + "'";
                //DataTable dtQL = DBMain.getDataTable(LayMaQL);
                //string LayMaNV = @"EXEC LayMaNhanVien '" + btn_userDK.Text.ToString().TrimEnd() + "'";
                //DataTable dtNV = DBMain.getDataTable(LayMaNV);
                SqlCommand sqlCmd = new SqlCommand(@"EXEC LayMaQuanLy '" + btn_userDK.Text.ToString().TrimEnd() + "'", db.conn) { CommandType = CommandType.Text };
                string laymaql = Convert.ToString(db.FirstRowQuery(sqlCmd, ref err));
                sqlCmd = new SqlCommand(@"EXEC LayMaNhanVien '" + btn_userDK.Text.ToString().TrimEnd() + "'", db.conn) { CommandType = CommandType.Text };
                string laymanv = Convert.ToString(db.FirstRowQuery(sqlCmd, ref err));
                if (laymaql == "" && laymanv == "")
                {
                    MessageBox.Show("Hãy dùng mã số để đăng ký!");
                }
                else
                {
                    //string LayTenDangNhap = @"EXEC LayTenDangNhap '" + btn_userDK.Text + "'";
                    //DataTable a = DBMain.getDataTable(LayTenDangNhap);
                    sqlCmd = new SqlCommand(@"EXEC LayTenDangNhap '" + btn_userDK.Text + "'", db.conn) { CommandType = CommandType.Text };
                    string a = Convert.ToString(db.FirstRowQuery(sqlCmd, ref err));
                    if (a!="") //tên tài khoản này đã tồn tại
                    {
                        MessageBox.Show("Tên tài khoản đã được dùng!");
                    }
                    else

                    {
                        //Thêm dữ liệu vào bảng DANGNHAP trên SQL
                        int MaNhom = 0;
                        if (positionDK.Text == "Quản Lý")
                            MaNhom = 1;
                        if (positionDK.Text == "Nhân Viên")
                            MaNhom = 2;
                        //string ThemTaiKhoan = @"EXEC ThemTaiKhoan '" + this.btn_userDK.Text + "','" + this.btn_passwordDK.Text + "','" + MaNhom + "'";
                        //DBMain.executeQuery(ThemTaiKhoan);
                        sqlCmd = new SqlCommand(@"EXEC ThemTaiKhoan '" + this.btn_userDK.Text + "','" + this.btn_passwordDK.Text + "','" + MaNhom + "'", db.conn) { CommandType = CommandType.Text };
                        db.MyExecuteNonQuery(sqlCmd);
                        MessageBox.Show("Bạn đã đăng kí thành công!");
                    }
                }



            }
        }

        private void txtTaiKhoanDK_TextChanged(object sender, EventArgs e)
        {
            db = new DBMain();
            //string LayMaQL = @"EXEC LayMaQuanLy '" + btn_userDK.Text.ToString().TrimEnd() + "'";
            //DataTable dtQL = DBMain.getDataTable(LayMaQL);
            //string LayMaNV = @"EXEC LayMaNhanVien '" + btn_userDK.Text.ToString().TrimEnd() + "'";
            //DataTable dtNV = DBMain.getDataTable(LayMaNV);
            SqlCommand sqlCmd = new SqlCommand(@"EXEC LayMaQuanLy '" + btn_userDK.Text.ToString().TrimEnd() + "'", db.conn) { CommandType = CommandType.Text };
            string laymaql = (db.FirstRowQuery(sqlCmd, ref err)).ToString();
            sqlCmd = new SqlCommand(@"EXEC LayMaNhanVien '" + btn_userDK.Text.ToString().TrimEnd() + "'", db.conn) { CommandType = CommandType.Text };
            string laymanv = (db.FirstRowQuery(sqlCmd, ref err)).ToString();

            if (laymaql == "" && laymanv == "")
            {
                positionDK.Text = "--------";
            }
            else if (laymaql.Length>0)
            {
                positionDK.Text = "Quản Lý";

            }
            else if (laymanv.Length>0)
            {
                positionDK.Text = "Nhân Viên";
            }

        }

        private void positionDK_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_userDK_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            db = new DBMain();
            SqlCommand sqlCmd = new SqlCommand(@"EXEC LayMaQuanLy N'" + btn_userDK.Text.ToString() + "'", db.conn) { CommandType = CommandType.Text };
            string laymaql = "";
            laymaql = Convert.ToString(db.FirstRowQuery(sqlCmd, ref err));
            if (db.FirstRowQuery(sqlCmd, ref err) == null)
            {
                laymaql = "";
            }
            sqlCmd = new SqlCommand(@"EXEC LayMaNhanVien '" + btn_userDK.Text.ToString().TrimEnd() + "'", db.conn) { CommandType = CommandType.Text };
            string laymanv = "";
            laymanv = Convert.ToString(db.FirstRowQuery(sqlCmd, ref err));
            if (db.FirstRowQuery(sqlCmd, ref err) == null)
            {
                laymanv = "";
            }
            if (laymaql == "" && laymanv == "")
            {
                positionDK.Text = "--------";
            }
            else if (laymaql != "")
            {
                positionDK.Text = "Quản Lý";

            }
            else if (laymanv!="")
            {
                positionDK.Text = "Nhân Viên";
            }

        }
    }
}
