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
    public partial class MenuCombo : UserControl
    {
        
        public MenuCombo()
        {
            InitializeComponent();
        }
       
        private void btnChonMon1_Click(object sender, EventArgs e)
        {
            ChonMon.GiaTien = label11.Text;
            ChonMon.TenMon = label12.Text;
            ChonMon.Size = "M";
            ChonMon chonMon = new ChonMon();
            chonMon.ShowDialog();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ChonMon.GiaTien = label4.Text;
            ChonMon.TenMon = label5.Text;
            ChonMon.Size = "M";
            ChonMon chonMon = new ChonMon();
            chonMon.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ChonMon.GiaTien = label1.Text;
            ChonMon.TenMon = label3.Text;
            ChonMon.Size = "M";
            ChonMon chonMon = new ChonMon();
            chonMon.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ChonMon.GiaTien = label6.Text;
            ChonMon.TenMon = label7.Text;
            ChonMon.Size = "M";
            ChonMon chonMon = new ChonMon();
            chonMon.ShowDialog();
        }
    }
}
