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
    public partial class ChonMon : Form 
    {
        public int x, y;
        public static int TrangThai;
        public List<TextBox> lTextBox;
        public static string TenMon = "";
        public static string GiaTien = "";
        public int costsize;
        public int giathanh = 0;
        public string cost;
       
        public ChonMon()
        {

            InitializeComponent();

            x = textBox2.Location.X;
            y = textBox2.Location.Y;
            label1.Text = ChonMon.TenMon;
            label3.Text = ChonMon.GiaTien;
            cost = label3.Text.Remove(label3.Text.Length - 1, 1);
            for (int i = 0; i < cost.Length; i++)
            {
                if (cost[i].ToString().Equals(".") == true)
                {
                    cost = cost.Remove(cost.Length -i - 3, 1);
                    break;
                }

            }
            giathanh = Convert.ToInt32(cost.ToString())*int.Parse(numericUpDown1.Value.ToString());
            giathanh *= Convert.ToInt32(numericUpDown1.Value.ToString());
            label5.Text = giathanh.ToString();                   
            lTextBox = new List<TextBox>();
            lTextBox.Add(textBox1);
            lTextBox.Add(textBox2);
            ChonMon.GiaTien = giathanh.ToString();
        }
        
       
        
        private void ChonMon_Load(object sender, EventArgs e)
        {
            
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            button1.BackColor = Color.FromArgb(81, 36, 103);
            button1.ForeColor = Color.White;
            button2.BackColor = Color.Gainsboro;
            button2.ForeColor = Color.Black;
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
            giathanh *= Convert.ToInt32(numericUpDown1.Value.ToString());
            label5.Text = giathanh.ToString();
            for (int i = lTextBox.Count -1 ; i >= 2 ; i--)
            {
                
                lTextBox.Remove(lTextBox[i]);
                panel3.Controls.RemoveAt(i+3);
            }
            x = textBox2.Location.X;
            y = textBox2.Location.Y;
            panel3.Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.BackColor =  Color.FromArgb(81, 36, 103);
            button1.ForeColor = Color.White;
            costsize = 10000* Convert.ToInt32(numericUpDown1.Value.ToString()); 
            button2.BackColor = Color.Gainsboro;
            button2.ForeColor = Color.Black;
            giathanh -= costsize;
            label5.Text = giathanh.ToString();
            ChonMon.GiaTien = giathanh.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button2.BackColor = Color.FromArgb(81, 36, 103);
            button2.ForeColor = Color.White;
            costsize = 10000 * Convert.ToInt32(numericUpDown1.Value.ToString());
            button1.BackColor = Color.Gainsboro;
            button1.ForeColor = Color.Black;
            giathanh += costsize;
            label5.Text = giathanh.ToString();
            ChonMon.GiaTien = giathanh.ToString();

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            giathanh *= Convert.ToInt32(numericUpDown1.Value.ToString());
            label5.Text = giathanh.ToString();
            ChonMon.GiaTien = giathanh.ToString();
        }

       
        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button31_Click(object sender, EventArgs e)
        {
            TextBox newTextBox = new TextBox();
            newTextBox.Multiline = true;
            newTextBox.Font = new Font("Microsoft Sans Serif, 12pt, style=Bold", 12);
            newTextBox.TextAlign = HorizontalAlignment.Center;
            if (x > 550)
            {
                y += 100;
                x = textBox1.Location.X - 170;
            }
            if (lTextBox.Count < 10)
            {
                newTextBox.Location = new Point(x + 170, y);
                newTextBox.Enabled = false;
                newTextBox.Width = textBox1.Width;
                newTextBox.Height = textBox1.Height;
                newTextBox.Text = "\r\n" + "Cốt dừa";
                x = newTextBox.Location.X;
                y = newTextBox.Location.Y;


                lTextBox.Add(newTextBox);
                panel3.Controls.Add(lTextBox[lTextBox.Count - 1]);
                panel3.Refresh();
                panel3.Show();

                giathanh += 7000;
                label5.Text = giathanh.ToString();
                ChonMon.GiaTien = giathanh.ToString();
                ChonMon.TenMon += ", " + newTextBox.Text;
            }
        }

        private void button33_Click(object sender, EventArgs e)
        {
            TextBox newTextBox = new TextBox();
            newTextBox.Multiline = true;
            newTextBox.Font = new Font("Microsoft Sans Serif, 12pt, style=Bold", 12);
            newTextBox.TextAlign = HorizontalAlignment.Center;
            if (x > 550)
            {
                y += 100;
                x = textBox1.Location.X - 170;
            }
            if (lTextBox.Count < 10)
            {
                newTextBox.Location = new Point(x + 170, y);
                newTextBox.Enabled = false;
                newTextBox.Width = textBox1.Width;
                newTextBox.Height = textBox1.Height;
                newTextBox.Text = "\r\n" + "Socola";
                x = newTextBox.Location.X;
                y = newTextBox.Location.Y;


                lTextBox.Add(newTextBox);
                panel3.Controls.Add(lTextBox[lTextBox.Count - 1]);
                panel3.Refresh();
                panel3.Show();

                giathanh += 7000;
                label5.Text = giathanh.ToString();
                ChonMon.GiaTien = giathanh.ToString();
                ChonMon.TenMon += ", " + newTextBox.Text;
            }
        }

        private void button34_Click(object sender, EventArgs e)
        {
            TextBox newTextBox = new TextBox();
            newTextBox.Multiline = true;
            newTextBox.Font = new Font("Microsoft Sans Serif, 12pt, style=Bold", 12);
            newTextBox.TextAlign = HorizontalAlignment.Center;
            if (x > 550)
            {
                y += 100;
                x = textBox1.Location.X - 170;
            }
            if (lTextBox.Count < 10)
            {
                newTextBox.Location = new Point(x + 170, y);
                newTextBox.Enabled = false;
                newTextBox.Width = textBox1.Width;
                newTextBox.Height = textBox1.Height;
                newTextBox.Text = "\r\n" + "P.T.Thống";
                x = newTextBox.Location.X;
                y = newTextBox.Location.Y;


                lTextBox.Add(newTextBox);
                panel3.Controls.Add(lTextBox[lTextBox.Count - 1]);
                panel3.Refresh();
                panel3.Show();

                giathanh += 7000;
                label5.Text = giathanh.ToString();
                ChonMon.GiaTien = giathanh.ToString();
                ChonMon.TenMon += ", " + newTextBox.Text;
            }
        }

        private void button35_Click(object sender, EventArgs e)
        {
            TextBox newTextBox = new TextBox();
            newTextBox.Multiline = true;
            newTextBox.Font = new Font("Microsoft Sans Serif, 12pt, style=Bold", 12);
            newTextBox.TextAlign = HorizontalAlignment.Center;
            if (x > 550)
            {
                y += 100;
                x = textBox1.Location.X - 170;
            }
            if (lTextBox.Count < 10)
            {
                newTextBox.Location = new Point(x + 170, y);
                newTextBox.Enabled = false;
                newTextBox.Width = textBox1.Width;
                newTextBox.Height = textBox1.Height;
                newTextBox.Text = "\r\n" + "P.Trứng";
                x = newTextBox.Location.X;
                y = newTextBox.Location.Y;


                lTextBox.Add(newTextBox);
                panel3.Controls.Add(lTextBox[lTextBox.Count - 1]);
                panel3.Refresh();
                panel3.Show();

                giathanh += 7000;
                label5.Text = giathanh.ToString();
                ChonMon.GiaTien = giathanh.ToString();
                ChonMon.TenMon += ", " + newTextBox.Text;
            }
        }

        private void button36_Click(object sender, EventArgs e)
        {
            TextBox newTextBox = new TextBox();
            newTextBox.Multiline = true;
            newTextBox.Font = new Font("Microsoft Sans Serif, 12pt, style=Bold", 12);
            newTextBox.TextAlign = HorizontalAlignment.Center;
            if (x > 550)
            {
                y += 100;
                x = textBox1.Location.X - 170;
            }
            if (lTextBox.Count < 10)
            {
                newTextBox.Location = new Point(x + 170, y);
                newTextBox.Enabled = false;
                newTextBox.Width = textBox1.Width;
                newTextBox.Height = textBox1.Height;
                newTextBox.Text = "\r\n" + "Kiwi";
                x = newTextBox.Location.X;
                y = newTextBox.Location.Y;


                lTextBox.Add(newTextBox);
                panel3.Controls.Add(lTextBox[lTextBox.Count - 1]);
                panel3.Refresh();
                panel3.Show();

                giathanh += 7000;
                label5.Text = giathanh.ToString();
                ChonMon.GiaTien = giathanh.ToString();
                ChonMon.TenMon += ", " + newTextBox.Text;
            }
        }

        private void button25_Click(object sender, EventArgs e)
        {
            TextBox newTextBox = new TextBox();
            newTextBox.Multiline = true;
            newTextBox.Font = new Font("Microsoft Sans Serif, 12pt, style=Bold", 12);
            newTextBox.TextAlign = HorizontalAlignment.Center;
            if (x > 550)
            {
                y += 100;
                x = textBox1.Location.X - 170;
            }
            if (lTextBox.Count < 10)
            {
                newTextBox.Location = new Point(x + 170, y);
                newTextBox.Enabled = false;
                newTextBox.Width = textBox1.Width;
                newTextBox.Height = textBox1.Height;
                newTextBox.Text = "\r\n" + "Khoai Môn";
                x = newTextBox.Location.X;
                y = newTextBox.Location.Y;


                lTextBox.Add(newTextBox);
                panel3.Controls.Add(lTextBox[lTextBox.Count - 1]);
                panel3.Refresh();
                panel3.Show();

                giathanh += 7000;
                label5.Text = giathanh.ToString();
                ChonMon.GiaTien = giathanh.ToString();
                ChonMon.TenMon += ", " + newTextBox.Text;
            }
        }

        private void button26_Click(object sender, EventArgs e)
        {
            TextBox newTextBox = new TextBox();
            newTextBox.Multiline = true;
            newTextBox.Font = new Font("Microsoft Sans Serif, 12pt, style=Bold", 12);
            newTextBox.TextAlign = HorizontalAlignment.Center;
            if (x > 550)
            {
                y += 100;
                x = textBox1.Location.X - 170;
            }
            if (lTextBox.Count < 10)
            {
                newTextBox.Location = new Point(x + 170, y);
                newTextBox.Enabled = false;
                newTextBox.Width = textBox1.Width;
                newTextBox.Height = textBox1.Height;
                newTextBox.Text = "\r\n" + "TC.Trắng";
                x = newTextBox.Location.X;
                y = newTextBox.Location.Y;


                lTextBox.Add(newTextBox);
                panel3.Controls.Add(lTextBox[lTextBox.Count - 1]);
                panel3.Refresh();
                panel3.Show();

                giathanh += 7000;
                label5.Text = giathanh.ToString();
                ChonMon.GiaTien = giathanh.ToString();
                ChonMon.TenMon += ", " + newTextBox.Text;
            }
        }

        private void button30_Click(object sender, EventArgs e)
        {
            TextBox newTextBox = new TextBox();
            newTextBox.Multiline = true;
            newTextBox.Font = new Font("Microsoft Sans Serif, 12pt, style=Bold", 12);
            newTextBox.TextAlign = HorizontalAlignment.Center;
            if (x > 550)
            {
                y += 100;
                x = textBox1.Location.X - 170;
            }
            if (lTextBox.Count < 10)
            {
                newTextBox.Location = new Point(x + 170, y);
                newTextBox.Enabled = false;
                newTextBox.Width = textBox1.Width;
                newTextBox.Height = textBox1.Height;
                newTextBox.Text = "\r\n" + "Trai dẻo";
                x = newTextBox.Location.X;
                y = newTextBox.Location.Y;


                lTextBox.Add(newTextBox);
                panel3.Controls.Add(lTextBox[lTextBox.Count - 1]);
                panel3.Refresh();
                panel3.Show();

                giathanh += 7000;
                label5.Text = giathanh.ToString();
                ChonMon.GiaTien = giathanh.ToString();
                ChonMon.TenMon += ", " + newTextBox.Text;
            }
        }

        private void button28_Click(object sender, EventArgs e)
        {
            TextBox newTextBox = new TextBox();
            newTextBox.Multiline = true;
            newTextBox.Font = new Font("Microsoft Sans Serif, 12pt, style=Bold", 12);
            newTextBox.TextAlign = HorizontalAlignment.Center;
            if (x > 550)
            {
                y += 100;
                x = textBox1.Location.X - 170;
            }
            if (lTextBox.Count < 10)
            {
                newTextBox.Location = new Point(x + 170, y);
                newTextBox.Enabled = false;
                newTextBox.Width = textBox1.Width;
                newTextBox.Height = textBox1.Height;
                newTextBox.Text = "\r\n" + "TC.Xanh";
                x = newTextBox.Location.X;
                y = newTextBox.Location.Y;


                lTextBox.Add(newTextBox);
                panel3.Controls.Add(lTextBox[lTextBox.Count - 1]);
                panel3.Refresh();
                panel3.Show();

                giathanh += 7000;
                label5.Text = giathanh.ToString();
                ChonMon.GiaTien = giathanh.ToString();
                ChonMon.TenMon += ", " + newTextBox.Text;
            }
        }

        private void button29_Click(object sender, EventArgs e)
        {
            TextBox newTextBox = new TextBox();
            newTextBox.Multiline = true;
            newTextBox.Font = new Font("Microsoft Sans Serif, 12pt, style=Bold", 12);
            newTextBox.TextAlign = HorizontalAlignment.Center;
            if (x > 550)
            {
                y += 100;
                x = textBox1.Location.X - 170;
            }
            if (lTextBox.Count < 10)
            {
                newTextBox.Location = new Point(x + 170, y);
                newTextBox.Enabled = false;
                newTextBox.Width = textBox1.Width;
                newTextBox.Height = textBox1.Height;
                newTextBox.Text = "\r\n" + "Củ Năng";
                x = newTextBox.Location.X;
                y = newTextBox.Location.Y;


                lTextBox.Add(newTextBox);
                panel3.Controls.Add(lTextBox[lTextBox.Count - 1]);
                panel3.Refresh();
                panel3.Show();

                giathanh += 7000;
                label5.Text = giathanh.ToString();
                ChonMon.GiaTien = giathanh.ToString();
                ChonMon.TenMon += ", " + newTextBox.Text;
            }
        }

        private void button20_Click(object sender, EventArgs e)
        {
            TextBox newTextBox = new TextBox();
            newTextBox.Multiline = true;
            newTextBox.Font = new Font("Microsoft Sans Serif, 12pt, style=Bold", 12);
            newTextBox.TextAlign = HorizontalAlignment.Center;
            if (x > 550)
            {
                y += 100;
                x = textBox1.Location.X - 170;
            }
            if (lTextBox.Count < 10)
            {
                newTextBox.Location = new Point(x + 170, y);
                newTextBox.Enabled = false;
                newTextBox.Width = textBox1.Width;
                newTextBox.Height = textBox1.Height;
                newTextBox.Text = "\r\n" + "Mùi Ổi";
                x = newTextBox.Location.X;
                y = newTextBox.Location.Y;


                lTextBox.Add(newTextBox);
                panel3.Controls.Add(lTextBox[lTextBox.Count - 1]);
                panel3.Refresh();
                panel3.Show();
                giathanh += 7000;
                label5.Text = giathanh.ToString();
                ChonMon.GiaTien = giathanh.ToString();
                ChonMon.TenMon += ", " +newTextBox.Text;
            }
        }

        private void button21_Click(object sender, EventArgs e)
        {
            TextBox newTextBox = new TextBox();
            newTextBox.Multiline = true;
            newTextBox.Font = new Font("Microsoft Sans Serif, 12pt, style=Bold", 12);
            newTextBox.TextAlign = HorizontalAlignment.Center;
            if (x > 550)
            {
                y += 100;
                x = textBox1.Location.X - 170;
            }
            if (lTextBox.Count < 10)
            {
                newTextBox.Location = new Point(x + 170, y);
                newTextBox.Enabled = false;
                newTextBox.Width = textBox1.Width;
                newTextBox.Height = textBox1.Height;
                newTextBox.Text = "\r\n" + "MatCha";
                x = newTextBox.Location.X;
                y = newTextBox.Location.Y;


                lTextBox.Add(newTextBox);
                panel3.Controls.Add(lTextBox[lTextBox.Count - 1]);
                panel3.Refresh();
                panel3.Show();
                giathanh += 7000;
                label5.Text = giathanh.ToString();
                ChonMon.GiaTien = giathanh.ToString();
                ChonMon.TenMon += ", " + newTextBox.Text;
            }
        }

        private void button22_Click(object sender, EventArgs e)
        {
            TextBox newTextBox = new TextBox();
            newTextBox.Multiline = true;
            newTextBox.Font = new Font("Microsoft Sans Serif, 12pt, style=Bold", 12);
            newTextBox.TextAlign = HorizontalAlignment.Center;
            if (x > 550)
            {
                y += 100;
                x = textBox1.Location.X - 170;
            }
            if (lTextBox.Count < 10)
            {
                newTextBox.Location = new Point(x + 170, y);
                newTextBox.Enabled = false;
                newTextBox.Width = textBox1.Width;
                newTextBox.Height = textBox1.Height;
                newTextBox.Text = "\r\n" + "Hương Socola";
                x = newTextBox.Location.X;
                y = newTextBox.Location.Y;


                lTextBox.Add(newTextBox);
                panel3.Controls.Add(lTextBox[lTextBox.Count - 1]);
                panel3.Refresh();
                panel3.Show();

                giathanh += 7000;
                label5.Text = giathanh.ToString();
                ChonMon.GiaTien = giathanh.ToString();
                ChonMon.TenMon += ", " + newTextBox.Text;
            }
        }

        private void button23_Click(object sender, EventArgs e)
        {
            TextBox newTextBox = new TextBox();
            newTextBox.Multiline = true;
            newTextBox.Font = new Font("Microsoft Sans Serif, 12pt, style=Bold", 12);
            newTextBox.TextAlign = HorizontalAlignment.Center;
            if (x > 550)
            {
                y += 100;
                x = textBox1.Location.X - 170;
            }
            if (lTextBox.Count < 10)
            {
                newTextBox.Location = new Point(x + 170, y);
                newTextBox.Enabled = false;
                newTextBox.Width = textBox1.Width;
                newTextBox.Height = textBox1.Height;
                newTextBox.Text = "\r\n" + "Dưa Lưới";
                x = newTextBox.Location.X;
                y = newTextBox.Location.Y;


                lTextBox.Add(newTextBox);
                panel3.Controls.Add(lTextBox[lTextBox.Count - 1]);
                panel3.Refresh();
                panel3.Show();

                giathanh += 7000;
                label5.Text = giathanh.ToString();

                ChonMon.GiaTien = giathanh.ToString();
                ChonMon.TenMon += ", " + newTextBox.Text;
            }
        }

        private void button24_Click(object sender, EventArgs e)
        {
            TextBox newTextBox = new TextBox();
            newTextBox.Multiline = true;
            newTextBox.Font = new Font("Microsoft Sans Serif, 12pt, style=Bold", 12);
            newTextBox.TextAlign = HorizontalAlignment.Center;
            if (x > 550)
            {
                y += 100;
                x = textBox1.Location.X - 170;
            }
            if (lTextBox.Count < 10)
            {
                newTextBox.Location = new Point(x + 170, y);
                newTextBox.Enabled = false;
                newTextBox.Width = textBox1.Width;
                newTextBox.Height = textBox1.Height;
                newTextBox.Text = "\r\n" + "Mật Ong";
                x = newTextBox.Location.X;
                y = newTextBox.Location.Y;


                lTextBox.Add(newTextBox);
                panel3.Controls.Add(lTextBox[lTextBox.Count - 1]);
                panel3.Refresh();
                panel3.Show();

                giathanh += 7000;
                label5.Text = giathanh.ToString();
                ChonMon.GiaTien = giathanh.ToString();
                ChonMon.TenMon += ", " + newTextBox.Text;
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            TextBox newTextBox = new TextBox();
            newTextBox.Multiline = true;
            newTextBox.Font = new Font("Microsoft Sans Serif, 12pt, style=Bold", 12);
            newTextBox.TextAlign = HorizontalAlignment.Center;
            if (x > 550)
            {
                y += 100;
                x = textBox1.Location.X - 170;
            }
            if (lTextBox.Count < 10)
            {
                newTextBox.Location = new Point(x + 170, y);
                newTextBox.Enabled = false;
                newTextBox.Width = textBox1.Width;
                newTextBox.Height = textBox1.Height;
                newTextBox.Text = "\r\n" + button16.Text;
                x = newTextBox.Location.X;
                y = newTextBox.Location.Y;


                lTextBox.Add(newTextBox);
                panel3.Controls.Add(lTextBox[lTextBox.Count - 1]);
                panel3.Refresh();
                panel3.Show();
                ChonMon.TenMon += ", " + newTextBox.Text;

            }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            TextBox newTextBox = new TextBox();
            newTextBox.Multiline = true;
            newTextBox.Font = new Font("Microsoft Sans Serif, 12pt, style=Bold", 12);
            newTextBox.TextAlign = HorizontalAlignment.Center;
            if (x > 550)
            {
                y += 100;
                x = textBox1.Location.X - 170;
            }
            if (lTextBox.Count < 10)
            {
                newTextBox.Location = new Point(x + 170, y);
                newTextBox.Enabled = false;
                newTextBox.Width = textBox1.Width;
                newTextBox.Height = textBox1.Height;
                newTextBox.Text = "\r\n" + button17.Text;
                x = newTextBox.Location.X;
                y = newTextBox.Location.Y;


                lTextBox.Add(newTextBox);
                panel3.Controls.Add(lTextBox[lTextBox.Count - 1]);
                panel3.Refresh();
                panel3.Show();
                ChonMon.TenMon += ", " + newTextBox.Text;

            }
        }

        private void button18_Click(object sender, EventArgs e)
        {
            TextBox newTextBox = new TextBox();
            newTextBox.Multiline = true;
            newTextBox.Font = new Font("Microsoft Sans Serif, 12pt, style=Bold", 12);
            newTextBox.TextAlign = HorizontalAlignment.Center;
            if (x > 550)
            {
                y += 100;
                x = textBox1.Location.X - 170;
            }
            if (lTextBox.Count < 10)
            {
                newTextBox.Location = new Point(x + 170, y);
                newTextBox.Enabled = false;
                newTextBox.Width = textBox1.Width;
                newTextBox.Height = textBox1.Height;
                newTextBox.Text = "\r\n" + button18.Text;
                x = newTextBox.Location.X;
                y = newTextBox.Location.Y;


                lTextBox.Add(newTextBox);
                panel3.Controls.Add(lTextBox[lTextBox.Count - 1]);
                panel3.Refresh();
                panel3.Show();
                ChonMon.TenMon += ", " + newTextBox.Text;

            }
        }

        private void button19_Click(object sender, EventArgs e)
        {
            TextBox newTextBox = new TextBox();
            newTextBox.Multiline = true;
            newTextBox.Font = new Font("Microsoft Sans Serif, 12pt, style=Bold", 12);
            newTextBox.TextAlign = HorizontalAlignment.Center;
            if (x > 550)
            {
                y += 100;
                x = textBox1.Location.X - 170;
            }
            if (lTextBox.Count < 10)
            {
                newTextBox.Location = new Point(x + 170, y);
                newTextBox.Enabled = false;
                newTextBox.Width = textBox1.Width;
                newTextBox.Height = textBox1.Height;
                newTextBox.Text = "\r\n" + button19.Text;
                x = newTextBox.Location.X;
                y = newTextBox.Location.Y;


                lTextBox.Add(newTextBox);
                panel3.Controls.Add(lTextBox[lTextBox.Count - 1]);
                panel3.Refresh();
                panel3.Show();
                ChonMon.TenMon += ", " + newTextBox.Text;

            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            TextBox newTextBox = new TextBox();
            newTextBox.Multiline = true;
            newTextBox.Font = new Font("Microsoft Sans Serif, 12pt, style=Bold", 12);
            newTextBox.TextAlign = HorizontalAlignment.Center;
            if (x > 550)
            {
                y += 100;
                x = textBox1.Location.X - 170;
            }
            if (lTextBox.Count < 10)
            {
                newTextBox.Location = new Point(x + 170, y);
                newTextBox.Enabled = false;
                newTextBox.Width = textBox1.Width;
                newTextBox.Height = textBox1.Height;
                newTextBox.Text = "\r\n" + button11.Text;
                x = newTextBox.Location.X;
                y = newTextBox.Location.Y;


                lTextBox.Add(newTextBox);
                panel3.Controls.Add(lTextBox[lTextBox.Count - 1]);
                panel3.Refresh();
                panel3.Show();
                ChonMon.TenMon += ", " + newTextBox.Text;

            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            TextBox newTextBox = new TextBox();
            newTextBox.Multiline = true;
            newTextBox.Font = new Font("Microsoft Sans Serif, 12pt, style=Bold", 12);
            newTextBox.TextAlign = HorizontalAlignment.Center;
            if (x > 550)
            {
                y += 100;
                x = textBox1.Location.X - 170;
            }
            if (lTextBox.Count < 10)
            {
                newTextBox.Location = new Point(x + 170, y);
                newTextBox.Enabled = false;
                newTextBox.Width = textBox1.Width;
                newTextBox.Height = textBox1.Height;
                newTextBox.Text = "\r\n" + button12.Text;
                x = newTextBox.Location.X;
                y = newTextBox.Location.Y;


                lTextBox.Add(newTextBox);
                panel3.Controls.Add(lTextBox[lTextBox.Count - 1]);
                panel3.Refresh();
                panel3.Show();
                ChonMon.TenMon += ", " + newTextBox.Text;

            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            TextBox newTextBox = new TextBox();
            newTextBox.Multiline = true;
            newTextBox.Font = new Font("Microsoft Sans Serif, 12pt, style=Bold", 12);
            newTextBox.TextAlign = HorizontalAlignment.Center;
            if (x > 550)
            {
                y += 100;
                x = textBox1.Location.X - 170;
            }
            if (lTextBox.Count < 10)
            {
                newTextBox.Location = new Point(x + 170, y);
                newTextBox.Enabled = false;
                newTextBox.Width = textBox1.Width;
                newTextBox.Height = textBox1.Height;
                newTextBox.Text = "\r\n" + button13.Text;
                x = newTextBox.Location.X;
                y = newTextBox.Location.Y;


                lTextBox.Add(newTextBox);
                panel3.Controls.Add(lTextBox[lTextBox.Count - 1]);
                panel3.Refresh();
                panel3.Show();
                ChonMon.TenMon += ", " + newTextBox.Text;

            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            TextBox newTextBox = new TextBox();
            newTextBox.Multiline = true;
            newTextBox.Font = new Font("Microsoft Sans Serif, 12pt, style=Bold", 12);
            newTextBox.TextAlign = HorizontalAlignment.Center;
            if (x > 550)
            {
                y += 100;
                x = textBox1.Location.X - 170;
            }
            if (lTextBox.Count < 10)
            {
                newTextBox.Location = new Point(x + 170, y);
                newTextBox.Enabled = false;
                newTextBox.Width = textBox1.Width;
                newTextBox.Height = textBox1.Height;
                newTextBox.Text = "\r\n" + button14.Text;
                x = newTextBox.Location.X;
                y = newTextBox.Location.Y;


                lTextBox.Add(newTextBox);
                panel3.Controls.Add(lTextBox[lTextBox.Count - 1]);
                panel3.Refresh();
                panel3.Show();
                ChonMon.TenMon += ", " + newTextBox.Text;

            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            TextBox newTextBox = new TextBox();
            newTextBox.Multiline = true;
            newTextBox.Font = new Font("Microsoft Sans Serif, 12pt, style=Bold", 12);
            newTextBox.TextAlign = HorizontalAlignment.Center;
            if (x > 550)
            {
                y += 100;
                x = textBox1.Location.X - 170;
            }
            if (lTextBox.Count < 10)
            {
                newTextBox.Location = new Point(x + 170, y);
                newTextBox.Enabled = false;
                newTextBox.Width = textBox1.Width;
                newTextBox.Height = textBox1.Height;
                newTextBox.Text = "\r\n" + button15.Text;
                x = newTextBox.Location.X;
                y = newTextBox.Location.Y;


                lTextBox.Add(newTextBox);
                panel3.Controls.Add(lTextBox[lTextBox.Count - 1]);
                panel3.Refresh();
                panel3.Show();

                ChonMon.TenMon += ", " + newTextBox.Text;
            }
        }

        public static int SoLuong;
        private void button3_Click(object sender, EventArgs e)
        {
            //Lưu vào chi tiết hóa đơn
            MessageBox.Show(ChonMon.TenMon);
            MessageBox.Show(ChonMon.GiaTien);
            ChonMon.SoLuong = Convert.ToInt32(numericUpDown1.Value.ToString());
            ChonMon.TrangThai = 1;
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }
    }
}
