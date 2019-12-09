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
    public partial class Changepassword : Form
    {
        DBMain db;
        string err = "";
        public Changepassword()
        {
            InitializeComponent();
            db = null;
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void Changepassword_Load(object sender, EventArgs e)
        {

        }

        private void txt_update_Click(object sender, EventArgs e)
        {
            db = new DBMain();
            try
            {
                string ten = txt_user.Text;
                if (ten == "")
                {
                    MessageBox.Show("Bạn chưa nhập tên truy cập");
                }
                else
                {
                    if (txt_oldpassword.Text == "")
                    {
                        MessageBox.Show("Bạn chưa nhập mật khẩu");
                    }
                    else
                    {
                        if (txt_newpassword.Text == "")
                        {
                            MessageBox.Show("Bạn chưa nhập mật khẩu mới");
                        }
                        else
                        {
                            if (txt_verification.Text == "")
                            {
                                MessageBox.Show("Bạn chưa xác nhận mật khẩu mới");
                            }
                            else
                            {
                                SqlCommand sqlCmd = new SqlCommand(@"EXEC LayMatKhau'" + txt_user.Text.ToString() + "' ", db.conn) { CommandType = CommandType.Text };
                               string MK = (db.FirstRowQuery(sqlCmd, ref err)).ToString();
                                if ((txt_newpassword.Text == txt_verification.Text) && txt_oldpassword.Text == MK)
                                {
                                    sqlCmd = new SqlCommand(@"EXEC CapNhatMatKhau '" + txt_newpassword.Text + "','" + txt_user.Text + "','" + txt_oldpassword.Text + "'", db.conn) { CommandType = CommandType.Text };
                                    db.MyExecuteNonQuery(sqlCmd);
                                    MessageBox.Show("Bạn đã thay đổi mật khẩu thành công");
                                    txt_user.ResetText();
                                    txt_verification.ResetText();
                                    txt_newpassword.ResetText();
                                    txt_oldpassword.ResetText();
                                }
                                else
                                {
                                    MessageBox.Show("Bạn nhập lại mật khẩu không đúng");
                                    //txtTaiKhoan.ResetText();
                                    txt_verification.ResetText();
                                    txt_newpassword.ResetText();
                                    txt_oldpassword.ResetText();
                                }
                            }
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("Tên tài khoản không đúng!");
            }
        }
    }
}
