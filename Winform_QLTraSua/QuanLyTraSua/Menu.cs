using QuanLyTraSua.BSLayer;
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
       
       
        public Menu()
        {

                InitializeComponent();
           
            
        }
       
        private void button1_Click(object sender, EventArgs e)
        {
            
            label1.Text = button1.Text;
            side.Top = button1.Top;
            side.Height = button1.Height;
            menu_TraXanh1.BringToFront();
            button1.BackColor = Color.FromArgb(81, 36, 103);
            button1.ForeColor = Color.White;
            button1.ForeColor = Color.Black;
            button2.BackColor = Color.Silver;
            button2.ForeColor = Color.Black;
            button3.BackColor = Color.Silver;
            button3.ForeColor = Color.Black;
            button4.BackColor = Color.Silver;
            button4.ForeColor = Color.Black;
            button5.BackColor = Color.Silver;
            button5.ForeColor = Color.Black;
            button6.BackColor = Color.Silver;
            button6.ForeColor = Color.Black;
            button7.BackColor = Color.Silver;
            button7.ForeColor = Color.Black;
            button8.BackColor = Color.Silver;
            button8.ForeColor = Color.Black;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            button2.BackColor = Color.FromArgb(81, 36, 103);
            button2.ForeColor = Color.White;
            button1.BackColor = Color.Silver;
            button1.ForeColor = Color.Black;
            button3.BackColor = Color.Silver;
            button3.ForeColor = Color.Black;
            button4.BackColor = Color.Silver;
            button4.ForeColor = Color.Black;
            button5.BackColor = Color.Silver;
            button5.ForeColor = Color.Black;
            button6.BackColor = Color.Silver;
            button6.ForeColor = Color.Black;
            button7.BackColor = Color.Silver;
            button7.ForeColor = Color.Black;
            button8.BackColor = Color.Silver;
            button8.ForeColor = Color.Black;


            menu_ComBo1.BringToFront();
            side.Top = button2.Top;
            side.Height = button2.Height;
            label1.Text = button2.Text;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            button3.BackColor = Color.FromArgb(81, 36, 103);
            button3.ForeColor = Color.White;
            button1.BackColor = Color.Silver;
            button1.ForeColor = Color.Black;
            button2.BackColor = Color.Silver;
            button2.ForeColor = Color.Black;
            button4.BackColor = Color.Silver;
            button4.ForeColor = Color.Black;
            button5.BackColor = Color.Silver;
            button5.ForeColor = Color.Black;
            button6.BackColor = Color.Silver;
            button6.ForeColor = Color.Black;
            button7.BackColor = Color.Silver;
            button7.ForeColor = Color.Black;
            button8.BackColor = Color.Silver;
            button8.ForeColor = Color.Black;

            menu_TraKhongSua1.BringToFront();
            side.Top = button3.Top;
            side.Height = button3.Height;
            label1.Text = button3.Text;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            button4.BackColor = Color.FromArgb(81, 36, 103);
            button4.ForeColor = Color.White;
            button1.BackColor = Color.Silver;
            button1.ForeColor = Color.Black;
            button2.BackColor = Color.Silver;
            button2.ForeColor = Color.Black;
            button3.BackColor = Color.Silver;
            button3.ForeColor = Color.Black;
            button5.BackColor = Color.Silver;
            button5.ForeColor = Color.Black;
            button6.BackColor = Color.Silver;
            button6.ForeColor = Color.Black;
            button7.BackColor = Color.Silver;
            button7.ForeColor = Color.Black;
            button8.BackColor = Color.Silver;
            button8.ForeColor = Color.Black;

            menu_SuaTuoiNguyenChat1.BringToFront();
            side.Top = button4.Top;
            side.Height = button4.Height;
            label1.Text = button4.Text;
        }

        private void Menu_Load(object sender, EventArgs e)
        {
          
                label1.Text = button1.Text;
                menu_TraXanh1.BringToFront();

         
        }

        private void button5_Click(object sender, EventArgs e)
        {
            button5.BackColor = Color.FromArgb(81, 36, 103);
            button5.ForeColor = Color.White;
            button1.BackColor = Color.Silver;
            button1.ForeColor = Color.Black;
            button2.BackColor = Color.Silver;
            button2.ForeColor = Color.Black;
            button3.BackColor = Color.Silver;
            button3.ForeColor = Color.Black;
            button4.BackColor = Color.Silver;
            button4.ForeColor = Color.Black;
            button6.BackColor = Color.Silver;
            button6.ForeColor = Color.Black;
            button7.BackColor = Color.Silver;
            button7.ForeColor = Color.Black;
            button8.BackColor = Color.Silver;
            button8.ForeColor = Color.Black;

            menu_Topping1.BringToFront();
            side.Top = button5.Top;
            side.Height = button5.Height;
            label1.Text = button5.Text;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            button6.BackColor = Color.FromArgb(81, 36, 103);
            button6.ForeColor = Color.White;
            button1.BackColor = Color.Silver;
            button1.ForeColor = Color.Black;
            button2.BackColor = Color.Silver;
            button2.ForeColor = Color.Black;
            button3.BackColor = Color.Silver;
            button3.ForeColor = Color.Black;
            button4.BackColor = Color.Silver;
            button4.ForeColor = Color.Black;
            button5.BackColor = Color.Silver;
            button5.ForeColor = Color.Black;
            button7.BackColor = Color.Silver;
            button7.ForeColor = Color.Black;
            button8.BackColor = Color.Silver;
            button8.ForeColor = Color.Black;

            menu_XienQue1.BringToFront();
            side.Top = button6.Top;
            side.Height = button6.Height;
            label1.Text = button6.Text;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            button7.BackColor = Color.FromArgb(81, 36, 103);
            button7.ForeColor = Color.White;
            button1.BackColor = Color.Silver;
            button1.ForeColor = Color.Black;
            button2.BackColor = Color.Silver;
            button2.ForeColor = Color.Black;
            button3.BackColor = Color.Silver;
            button3.ForeColor = Color.Black;
            button4.BackColor = Color.Silver;
            button4.ForeColor = Color.Black;
            button5.BackColor = Color.Silver;
            button5.ForeColor = Color.Black;
            button6.BackColor = Color.Silver;
            button6.ForeColor = Color.Black;
            button8.BackColor = Color.Silver;
            button8.ForeColor = Color.Black;

            menu_ThucAn1.BringToFront();
            side.Top = button7.Top;
            side.Height = button7.Height;
            label1.Text = button7.Text;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            button8.BackColor = Color.FromArgb(81, 36, 103);
            button8.ForeColor = Color.White;
            button1.BackColor = Color.Silver;
            button1.ForeColor = Color.Black;
            button2.BackColor = Color.Silver;
            button2.ForeColor = Color.Black;
            button3.BackColor = Color.Silver;
            button3.ForeColor = Color.Black;
            button4.BackColor = Color.Silver;
            button4.ForeColor = Color.Black;
            button5.BackColor = Color.Silver;
            button5.ForeColor = Color.Black;
            button6.BackColor = Color.Silver;
            button6.ForeColor = Color.Black;
            button7.BackColor = Color.Silver;
            button7.ForeColor = Color.Black;

            menu_ComBo_TietKiem1.BringToFront();
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
                dataGridView1.Rows.Add(ChonMon.TenMon, ChonMon.SoLuong, ChonMon.GiaTien,ChonMon.Size);               
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
      
        private void button9_Click(object sender, EventArgs e)
        {
            ChiTietHoaDon chiTietHoaDon = new ChiTietHoaDon(dataGridView1);
            ChonMon.GiaTien = textBox1.Text;
            chiTietHoaDon.ShowDialog();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {
           
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    if (dataGridView1.Rows[i].Cells[0].Value.ToString() == dataGridView1.CurrentRow.Cells[0].Value.ToString())
                        dataGridView1.Rows.RemoveAt(i);
                }
           
        }

      
    }
}
