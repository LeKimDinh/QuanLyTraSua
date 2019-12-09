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
    public partial class LayGiamGia : Form
    {
        DataTable dt = null;
        Discount discount = new Discount();
        string err = "";
        public static string giamgia = "0%";
        public static string Level = "";
        public static string MemberPoints = "";
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
        public static string TenKhacHang ="";
        private void label2_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void LoadData()
        {
            try
            {
                dt = new DataTable();
                dt.Clear();
                DataSet ds = discount.LayTTDC();
                dt = ds.Tables[0];
                dataGridView1.DataSource = dt;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            }
            catch (Exception errr)
            {
                MessageBox.Show(errr.Message);
            }

        }
        private void LayGiamGia_Load(object sender, EventArgs e)
        {
            LoadData();
            textBox1.Text = ChiTietHoaDon.Phonenumber;
            LayGiamGia.giamgia = discount.LayGiamGia(dataGridView1.CurrentRow.Cells[0].Value.ToString()).ToString() + "%";
            label3.Text = LayGiamGia.giamgia;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                LayGiamGia.giamgia = discount.LayGiamGia(dataGridView1.CurrentRow.Cells[0].Value.ToString()).ToString() + "%";
                label3.Text = LayGiamGia.giamgia;
                LayGiamGia.Level = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                LayGiamGia.MemberPoints = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                LayGiamGia.TenKhacHang = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                    }
            catch{ }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                dt = new DataTable();
                dt.Clear();
                DataSet ds = discount.LayMaGiamGia(textBox1.Text.Trim());
                dt = ds.Tables[0];
                dataGridView1.DataSource = dt;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            }
            catch (Exception errr)
            {
                MessageBox.Show(errr.Message);
            }
        }
    }
}
