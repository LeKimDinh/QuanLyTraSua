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
    public partial class LayGiamGia : Form
    {
        public static string giamgia = "0%";
        public LayGiamGia()
        {
            InitializeComponent();
            timer1.Interval = 100;
            timer1.Start();
        }
        int value = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            value++;
           
                
            if (value % 5 == 0)
            {
                    Color color = new Color();
                    color = panel4.BackColor;
                    panel4.BackColor = panel3.BackColor;
                    panel3.BackColor = panel2.BackColor;
                    panel2.BackColor = panel1.BackColor;
                    panel1.BackColor = color;
            }


            
        }

        private void label2_Click(object sender, EventArgs e)
        {           
            LayGiamGia.giamgia =label3.Text;
            this.Close();
        }
    }
}
