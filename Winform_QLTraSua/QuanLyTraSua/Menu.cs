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
    public partial class Menu : Form
    {
        public static string TenMon;
        public static int GiaTien;
        public static int SoLuong;
       
        public Menu()
        {
            InitializeComponent();
            
        }
       
        private void button1_Click(object sender, EventArgs e)
        {
            
            label1.Text = button1.Text;
            side.Top = button1.Top;
            side.Height = button1.Height;
            menuTraXanh1.BringToFront();
            button1.BackColor = Color.FromArgb(81, 36, 103);           
            button2.BackColor = Color.Silver;
            button3.BackColor = Color.Silver;
            button4.BackColor = Color.Silver;
            button5.BackColor = Color.Silver;
            button6.BackColor = Color.Silver;
            button7.BackColor = Color.Silver;
            button8.BackColor = Color.Silver;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            button2.BackColor = Color.FromArgb(81, 36, 103);
            button1.BackColor = Color.Silver;
            button3.BackColor = Color.Silver;
            button4.BackColor = Color.Silver;
            button5.BackColor = Color.Silver;
            button6.BackColor = Color.Silver;
            button7.BackColor = Color.Silver;
            button8.BackColor = Color.Silver;

            menuCombo1.BringToFront();
            side.Top = button2.Top;
            side.Height = button2.Height;
            label1.Text = button2.Text;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            button3.BackColor = Color.FromArgb(81, 36, 103);
            button1.BackColor = Color.Silver;
            button2.BackColor = Color.Silver;
            button4.BackColor = Color.Silver;
            button5.BackColor = Color.Silver;
            button6.BackColor = Color.Silver;
            button7.BackColor = Color.Silver;
            button8.BackColor = Color.Silver;

            menuTraKhong_Sua1.BringToFront();
            side.Top = button3.Top;
            side.Height = button3.Height;
            label1.Text = button3.Text;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            button4.BackColor = Color.FromArgb(81, 36, 103);
            button1.BackColor = Color.Silver;
            button2.BackColor = Color.Silver;
            button3.BackColor = Color.Silver;
            button5.BackColor = Color.Silver;
            button6.BackColor = Color.Silver;
            button7.BackColor = Color.Silver;
            button8.BackColor = Color.Silver;

            menuSuaTuoiNguyenChat1.BringToFront();
            side.Top = button4.Top;
            side.Height = button4.Height;
            label1.Text = button4.Text;
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            menuTraXanh1.BringToFront();
            label1.Text = button1.Text;
            
            
            //for (int i = 0; i < dataGridView1.RowCount; i++)
            //{
            //    if (dataGridView1.Rows[i].Cells[0].Value == null)
            //    {
            //        dataGridView1.Rows[i].Cells[0].Value = "TraSua";
            //    }
            //    else
            //    {
            //        DataGridViewRow row = (DataGridViewRow)dataGridView1.Rows[i].Clone();
            //        dataGridView1.Rows.Add(row);
            //        dataGridView1.Rows[i].Cells[0].Value = "TraSua";
            //    }
            //}
        }

        private void button5_Click(object sender, EventArgs e)
        {
            button5.BackColor = Color.FromArgb(81, 36, 103);
            button1.BackColor = Color.Silver;
            button2.BackColor = Color.Silver;
            button3.BackColor = Color.Silver;
            button4.BackColor = Color.Silver;
            button6.BackColor = Color.Silver;
            button7.BackColor = Color.Silver;
            button8.BackColor = Color.Silver;

            menuTopping1.BringToFront();
            side.Top = button5.Top;
            side.Height = button5.Height;
            label1.Text = button5.Text;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            button6.BackColor = Color.FromArgb(81, 36, 103);
            button1.BackColor = Color.Silver;
            button2.BackColor = Color.Silver;
            button3.BackColor = Color.Silver;
            button4.BackColor = Color.Silver;
            button5.BackColor = Color.Silver;
            button7.BackColor = Color.Silver;
            button8.BackColor = Color.Silver;

            menuXienQue1.BringToFront();
            side.Top = button6.Top;
            side.Height = button6.Height;
            label1.Text = button6.Text;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            button7.BackColor = Color.FromArgb(81, 36, 103);
            button1.BackColor = Color.Silver;
            button2.BackColor = Color.Silver;
            button3.BackColor = Color.Silver;
            button4.BackColor = Color.Silver;
            button5.BackColor = Color.Silver;
            button6.BackColor = Color.Silver;
            button8.BackColor = Color.Silver;

            menuThucAn1.BringToFront();
            side.Top = button7.Top;
            side.Height = button7.Height;
            label1.Text = button7.Text;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            button8.BackColor = Color.FromArgb(81, 36, 103);
            button1.BackColor = Color.Silver;
            button2.BackColor = Color.Silver;
            button3.BackColor = Color.Silver;
            button4.BackColor = Color.Silver;
            button5.BackColor = Color.Silver;
            button6.BackColor = Color.Silver;
            button7.BackColor = Color.Silver;

            menuComboTietKiem1.BringToFront();
            side.Top = button8.Top;
            side.Height = button8.Height;
            label1.Text = button8.Text;
        }
        int TongTien = 0;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {            
            for (int i = 0; i < dataGridView1.Columns.Count; i++)
            {
                dataGridView1.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
            if (ChonMon.TrangThai == 1)
            {
                dataGridView1.Rows.Add(ChonMon.TenMon, ChonMon.SoLuong, ChonMon.GiaTien);
                MessageBox.Show(ChonMon.TenMon);
                TongTien += Convert.ToInt32(ChonMon.GiaTien);
                textBox1.Text = TongTien.ToString();
            }
            ChonMon.TrangThai = 0;
            
        }

        private void button10_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            textBox1.ResetText();
        }
    }
}
