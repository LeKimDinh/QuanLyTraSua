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
    public partial class HoaDon : Form
    {
        public HoaDon()
        {
            InitializeComponent();
            timer1.Interval = 100;
            timer1.Start();
        }

        private void HoaDon_Load(object sender, EventArgs e)
        {
            icon1.BringToFront();
        }
        int value = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            value++;
            if (value == 10)
                icon1.BringToFront();
            if (value == 20)
            {               
                icon21.BringToFront();               
            }
            else if (value == 30)
            {               
                icon31.BringToFront();
            }
            else if (value == 40)
            {              
                icon41.BringToFront();              
                value = 0;
            }
        }
    }
}
