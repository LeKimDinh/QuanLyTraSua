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
    public partial class MenuSuaTuoiNguyenChat : UserControl
    {
        public MenuSuaTuoiNguyenChat()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ChonMon.GiaTien = label11.Text;
            ChonMon.TenMon = label12.Text;
            ChonMon.Size = "M";
            ChonMon chonMon = new ChonMon();
            chonMon.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ChonMon.GiaTien = label7.Text;
            ChonMon.TenMon = label8.Text;
            ChonMon.Size = "M";
            ChonMon chonMon = new ChonMon();
            chonMon.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ChonMon.GiaTien = label1.Text;
            ChonMon.TenMon = label2.Text;
            ChonMon.Size = "M";
            ChonMon chonMon = new ChonMon();
            chonMon.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ChonMon.GiaTien = label3.Text;
            ChonMon.TenMon = label4.Text;
            ChonMon.Size = "M";
            ChonMon chonMon = new ChonMon();
            chonMon.ShowDialog();
        }
    }
}
