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
    public partial class KhachHang : Form
    {
        public KhachHang()
        {
            InitializeComponent();
            timer1.Interval = 100;
            timer1.Start();
        }
        int value = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            value++;
            Random rd = new Random();
            if (value % 2 == 0)
            {
                panel2.BackColor = Color.FromArgb(rd.Next(0, 255), rd.Next(0, 255), rd.Next(0, 255));
            }

        }
    }
}
