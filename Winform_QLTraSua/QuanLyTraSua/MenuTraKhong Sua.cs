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
    public partial class MenuTraKhong_Sua : UserControl
    {
        public MenuTraKhong_Sua()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ChonMon.GiaTien = label11.Text;
            ChonMon.TenMon = label12.Text;
            ChonMon chonMon = new ChonMon();
            chonMon.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ChonMon.GiaTien = label4.Text;
            ChonMon.TenMon = label5.Text;
            ChonMon chonMon = new ChonMon();
            chonMon.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ChonMon.GiaTien = label1.Text;
            ChonMon.TenMon = label2.Text;
            ChonMon chonMon = new ChonMon();
            chonMon.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ChonMon.GiaTien = label3.Text;
            ChonMon.TenMon = label6.Text;
            ChonMon chonMon = new ChonMon();
            chonMon.ShowDialog();
        }
    }
}
