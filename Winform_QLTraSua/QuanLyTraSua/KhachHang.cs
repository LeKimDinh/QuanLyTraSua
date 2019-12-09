using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyTraSua.BSLayer;
namespace QuanLyTraSua
{
    public partial class KhachHang : Form
    {
        DataTable dt = null;
        Customer customer = new Customer();
        string err = "";
        int id = 0;
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
                panel3.BackColor = Color.FromArgb(rd.Next(0, 255), rd.Next(0, 255), rd.Next(0, 255));
            }
            panel2.BackColor = Color.FromArgb(rd.Next(0, 255), rd.Next(0, 255), rd.Next(0, 255));
            if (value % 3 == 0)
            {
                panel4.BackColor = Color.FromArgb(rd.Next(0, 255), rd.Next(0, 255), rd.Next(0, 255));
            }
        }

        private void KhachHang_Load(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                dt = new DataTable();
                dt.Clear();
                DataSet ds = customer.LayTTKH(textBox1.Text, ref err);
                dt = ds.Tables[0];
                dataGridView1.DataSource = dt;
                textBox5.Text = dataGridView1.Rows[0].Cells[0].Value.ToString();
                textBox6.Text = dataGridView1.Rows[0].Cells[1].Value.ToString();
                textBox7.Text = dataGridView1.Rows[0].Cells[2].Value.ToString();
                textBox8.Text = dataGridView1.Rows[0].Cells[3].Value.ToString();
                dateTimePicker1.Text = dataGridView1.Rows[0].Cells[5].Value.ToString();
                textBox9.Text = dataGridView1.Rows[0].Cells[4].Value.ToString();
                textBox2.Text = dataGridView1.Rows[0].Cells[6].Value.ToString();
                textBox3.Text = dataGridView1.Rows[0].Cells[7].Value.ToString();

                id = customer.LayID(textBox1.Text);
            
            }
            catch (Exception errr)
            {
                MessageBox.Show(errr.Message);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            id = 0;
                if (customer.ThemOrSuaKH(textBox5.Text.Trim(), dateTimePicker1.Value, textBox6.Text.Trim(), textBox7.Text.Trim(), textBox8.Text.Trim(), textBox9.Text.Trim(),id, ref err) == false)
                {
                    MessageBox.Show("Khong them duoc");
                }
                else
                {
                    MessageBox.Show("Da thanh cong");
                    textBox5.ResetText();
                    textBox6.ResetText();
                    textBox7.ResetText();
                    textBox8.ResetText();
                    dateTimePicker1.Text = DateTime.Now.ToString();
                    textBox9.ResetText();
                    textBox2.ResetText();
                    textBox3.ResetText();
                }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
                if (customer.ThemOrSuaKH(textBox5.Text.Trim(), dateTimePicker1.Value, textBox6.Text.Trim(), textBox7.Text.Trim(), textBox8.Text.Trim(), textBox9.Text.Trim(), id, ref err) == false)
                    MessageBox.Show("Không sữa được");
                else
                {
                    MessageBox.Show("Thay đổi thành công");
                    textBox5.ResetText();
                    textBox6.ResetText();
                    textBox7.ResetText();
                    textBox8.ResetText();
                    dateTimePicker1.Text = DateTime.Now.ToString();
                    textBox9.ResetText();
                    textBox2.ResetText();
                    textBox3.ResetText();
                }
            }
        }
    }

