﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using QuanLyTraSua.BSLayer;

namespace QuanLyTraSua
{
    public partial class Menu_ComBo_TietKiem : UserControl
    {
        DataTable dt = null;
        Drinks Drinks = new Drinks();

        String strFilePath = "";
        Byte[] ImageByteArray;
        //DBMain dbMain = null;
        string err = "";
        public Menu_ComBo_TietKiem()
        {
            InitializeComponent();
            this.dataGridView1.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dataGridView1_DataError);
            LoadData();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int r = dataGridView1.CurrentCell.RowIndex;
                textBox1.Text = dataGridView1.Rows[r].Cells[1].Value.ToString();
                comboBox1.Text = dataGridView1.Rows[r].Cells[2].Value.ToString();
                textBox2.Text = dataGridView1.Rows[r].Cells[3].Value.ToString();
                label11.Text = textBox2.Text+" đ";
                MemoryStream ms = new MemoryStream((byte[])dataGridView1.CurrentRow.Cells[4].Value);
                button4.BackgroundImage = Image.FromStream(ms);
                textBox3.Text = dataGridView1.Rows[r].Cells[5].Value.ToString();
            }
            catch { }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox3.Text.Trim() == "")
            {
                ChonMon2.GiaTien = label11.Text;
                ChonMon2.TenMon = textBox1.Text;
                ChonMon.Size = "";
                ChonMon2 chonMon2 = new ChonMon2();
                chonMon2.ShowDialog();
            }
            else
            {
                ChonMon.GiaTien = label11.Text;
                ChonMon.TenMon = textBox1.Text;
                ChonMon.Size = "M";
                ChonMon chonMon = new ChonMon();
                chonMon.ShowDialog();
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
        private void LoadData()
        {
            string category = "";
            try
            {
                dt = new DataTable();
                dt.Clear();
                DataSet ds = Drinks.LayDrinks(category);
                dt = ds.Tables[0];
                dataGridView1.DataSource = dt;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            }
            catch 
            {
                
            }
        }
        private void Menu_ComBo_TietKiem_Load(object sender, EventArgs e)
        {
            if (Staff.trangthaidangnhap == 2)
            {
                button1.Visible = false;
                button2.Visible = false;
                button3.Visible = false;
                button5.Visible = false;
                label5.Visible = false;
                pictureBox2.Visible = false;
                pictureBox3.Visible = false;
                pictureBox4.Visible = false;
            }
            else
            {
                button1.Visible = true;
                button2.Visible = true;
                button3.Visible = true;
                button5.Visible = true;
                label5.Visible = true;
                pictureBox2.Visible = true;
                pictureBox3.Visible = true;
                pictureBox4.Visible = true;
            }
            LoadData();
            try
            {
                MemoryStream ms = new MemoryStream((byte[])dataGridView1.CurrentRow.Cells[4].Value);
                button4.BackgroundImage = Image.FromStream(ms);
                textBox1.Text = dataGridView1.Rows[0].Cells[1].Value.ToString();
                comboBox1.Text = dataGridView1.Rows[0].Cells[2].Value.ToString();
                textBox2.Text = dataGridView1.Rows[0].Cells[3].Value.ToString();
                label11.Text = textBox2.Text + " đ";
                textBox3.Text = dataGridView1.Rows[0].Cells[5].Value.ToString();
            }
            catch { }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int ID = 0;
            if (strFilePath == "")
            {
                if (ImageByteArray.Length != 0)
                    ImageByteArray = new byte[] { };
            }
            else
            {
                Image temp = new Bitmap(strFilePath);
                MemoryStream strm = new MemoryStream();
                temp.Save(strm, System.Drawing.Imaging.ImageFormat.Jpeg);
                ImageByteArray = strm.ToArray();
            }

            if (Drinks.ThemOrSuaThucAn(ID, textBox1.Text.Trim(), comboBox1.Text, int.Parse(textBox2.Text.ToString()), ImageByteArray, textBox3.Text, ref err) == false)
            {
                MessageBox.Show("Khong them duoc");
            }
            else
                MessageBox.Show("Da thanh cong");
            LoadData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (strFilePath == "")
            {
                if (ImageByteArray.Length != 0)
                    ImageByteArray = new byte[] { };
            }
            else
            {

                Image temp = new Bitmap(strFilePath);
                MemoryStream strm = new MemoryStream();
                temp.Save(strm, System.Drawing.Imaging.ImageFormat.Jpeg);
                ImageByteArray = strm.ToArray();
            }
            if (Drinks.ThemOrSuaThucAn(int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString()), textBox1.Text.Trim().ToString(), comboBox1.Text.Trim().ToString(), int.Parse(textBox2.Text.Trim().ToString()), ImageByteArray, textBox3.Text.Trim().ToString(), ref err) == false)
            {
                MessageBox.Show("Khong Sua duoc");
            }
            else
                MessageBox.Show("Da thanh cong");
            LoadData();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (Drinks.XoaThucAn(int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString()), ref err) == true)
                MessageBox.Show("Xoa thanh cong");
            else MessageBox.Show("Khong thanh cong");
            LoadData();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                button5.BackColor = Color.FromArgb(81, 36, 103);
                button5.ForeColor = Color.White;
                button6.BackColor = Color.White;
                button6.ForeColor = Color.FromArgb(81, 36, 103);
                LoadData();
            }
            catch { }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            button6.BackColor = Color.FromArgb(81, 36, 103);
            button6.ForeColor = Color.White;
            button5.BackColor = Color.White;
            button5.ForeColor = Color.FromArgb(81, 36, 103);
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Images(.jpg,.png)|*.png;*.jpg";
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                strFilePath = openFile.FileName;
                button4.BackgroundImage = Image.FromFile(openFile.FileName);

            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }

        private void label5_Click_1(object sender, EventArgs e)
        {
            Drinks.RestoreThucAn();
            LoadData();
        }
    }
}
