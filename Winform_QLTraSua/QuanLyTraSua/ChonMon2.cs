using System;
using System.Collections.Generic;
using System.ComponentModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Collections;

namespace QuanLyTraSua
{
    public partial class ChonMon2 : Form
    {
        public static string TenMon = "";
        public static string GiaTien = "";
        public int costsize;
        public int giathanh = 0;
        public string cost;
        public ChonMon2()
        {
            InitializeComponent();
            label1.Text = ChonMon2.TenMon;
            label3.Text = ChonMon2.GiaTien;
            cost = label3.Text.Remove(label3.Text.Length - 1, 1);
            for (int i = 0; i < cost.Length; i++)
            {
                if (cost[i].ToString().Equals(".") == true)
                {
                    cost = cost.Remove(cost.Length - i - 3, 1);
                    break;
                }

            }
            giathanh = Convert.ToInt32(cost.ToString()) * int.Parse(numericUpDown1.Value.ToString());
            costsize = giathanh;
            giathanh *= Convert.ToInt32(numericUpDown1.Value.ToString());
           
            label5.Text = giathanh.ToString();
         
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

            giathanh += costsize;
            label5.Text = giathanh.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ChonMon.TenMon = label1.Text;
            ChonMon.GiaTien = giathanh.ToString();
            MessageBox.Show(ChonMon.TenMon);
            MessageBox.Show(ChonMon.GiaTien);
            ChonMon.SoLuong = Convert.ToInt32(numericUpDown1.Value.ToString());
            ChonMon.TrangThai = 1;
            this.Close();
        }
    }
}
