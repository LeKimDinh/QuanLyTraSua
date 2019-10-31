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
    public partial class MenuTraXanh : UserControl
    {       
        public MenuTraXanh()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ChonMon.GiaTien = label9.Text;
            ChonMon.TenMon = label2.Text;
            ChonMon chonMon = new ChonMon();
            chonMon.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ChonMon.GiaTien = label11.Text;
            ChonMon.TenMon = label7.Text;
            ChonMon chonMon = new ChonMon();
            chonMon.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ChonMon.GiaTien = label10.Text;
            ChonMon.TenMon = label3.Text;
            ChonMon chonMon = new ChonMon();
            chonMon.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ChonMon.GiaTien = label12.Text;
            ChonMon.TenMon = label5.Text;
            ChonMon chonMon = new ChonMon();
            chonMon.ShowDialog();
        }
    }
}
