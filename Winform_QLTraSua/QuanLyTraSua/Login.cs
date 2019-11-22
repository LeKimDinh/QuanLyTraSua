using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyTraSua
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {


        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void login()
        {
            if (txt_user.Text.Length == 0 && txt_password.Text.Length == 0)
                MessageBox.Show("Bạn chưa đăng nhập mật khẩu");
            else
                if (this.txt_user.Text.Length == 0)
                MessageBox.Show("Bạn chưa nhập User");
            else
                if (this.txt_password.Text.Length == 0)
                MessageBox.Show("Bạn chưa nhập mật khẩu ");
            else
                if (this.txt_user.Text == "admin" && this.txt_password.Text == "1") ;
            else MessageBox.Show("Mật khẩu của bạn không đúng!");

        }

        private void btn_Login_Click_1(object sender, EventArgs e)
        {
            Staff staff = new Staff();
            if (this.txt_user.Text == "admin" && this.txt_password.Text == "1")
            {

                staff.Show();


            }
            login();
        }

        private void btn_Exit_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
