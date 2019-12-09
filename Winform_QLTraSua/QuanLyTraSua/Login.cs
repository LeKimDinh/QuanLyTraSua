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
    public partial class Login : Form
    {
        DBMain db;
        string err = "";
        public static string ID;
        public Login()
        {
            InitializeComponent();
            db = new DBMain();
        }

        private void btn_Login_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_user.Text == "" || txt_password.Text == "")
                {
                    MessageBox.Show("Bạn chưa nhập tên đăng nhập hoặc mật khẩu!", "Thông báo");
                    return;
                }
                //string LayUser = @"EXEC LayUser '" + this.txt_user.Text + "','" + this.txt_password.Text + "'";
                //DataTable dt = DBMain.getDataTable(LayUser);
                SqlCommand sqlCmd = new SqlCommand(@"EXEC LayUser '" + this.txt_user.Text + "','" + this.txt_password.Text + "'", db.conn) { CommandType = CommandType.Text };
                string x = Convert.ToString(db.FirstRowQuery(sqlCmd, ref err));
                if (x == "admin")
                    ID = "0001";
                else ID = x;
                if (x!="")
                {
                    //string LayMaNhom = @"EXEC LayMaNhom '" + this.txt_user.Text + "','" + this.txt_password.Text + "'";
                    //DataTable LayMN = DBMain.getDataTable(LayMaNhom);
                    sqlCmd = new SqlCommand(@"EXEC LayMaNhom '" + this.txt_user.Text + "','" + this.txt_password.Text + "'", db.conn) { CommandType = CommandType.Text };
                    string a = Convert.ToString(db.FirstRowQuery(sqlCmd, ref err));
                    if (a == "1")
                    {
                        Staff.trangthaidangnhap = 1;
                    }
                    if (a == "2")
                    {
                        Staff.trangthaidangnhap = 2;
                    }
                    Staff staff = new Staff();
                    staff.ShowDialog();

                    txt_user.ResetText();
                    txt_password.ResetText();
                }
                else
                {
                    MessageBox.Show("Đăng nhập không thành công!", "Thông báo");
                    txt_user.Clear();
                    txt_password.Clear();
                    txt_user.Focus();
                }
            }
            catch (sqlException)
            {
                MessageBox.Show("Lỗi SQL!!!");
            }
            this.Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Register register = new Register();
            register.ShowDialog();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Changepassword changepassword = new Changepassword();
            changepassword.ShowDialog();
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            Form1.trangthaidangnhap = 1;
            this.Close();
        }
    }
}
