using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyTraSua
{
    public partial class MenuComboTietKiem : UserControl
    {
        public MenuComboTietKiem()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ChonMon2.GiaTien = label11.Text;
            ChonMon2.TenMon = label12.Text;
            ChonMon2 chonMon = new ChonMon2();
            chonMon.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ChonMon2.GiaTien = label1.Text;
            ChonMon2.TenMon = label2.Text;
            ChonMon2 chonMon = new ChonMon2();
            chonMon.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ChonMon2.GiaTien = label3.Text;
            ChonMon2.TenMon = label4.Text;
            ChonMon2 chonMon = new ChonMon2();
            chonMon.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ChonMon2.GiaTien = label5.Text;
            ChonMon2.TenMon = label6.Text;
            ChonMon2 chonMon = new ChonMon2();
            chonMon.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ChonMon2.GiaTien = label7.Text;
            ChonMon2.TenMon = label8.Text;
            ChonMon2 chonMon = new ChonMon2();
            chonMon.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ChonMon2.GiaTien = label9.Text;
            ChonMon2.TenMon = label10.Text;
            ChonMon2 chonMon = new ChonMon2();
            chonMon.ShowDialog();
        }
    }
}
