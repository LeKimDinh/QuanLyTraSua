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
    public partial class HoaDon : Form
    {
        DataTable dt = null;
        Bill bill = new Bill();
        string err = "";
        int BillID = 0;
     
        public HoaDon()
        {
            InitializeComponent();
            timer1.Interval = 100;
            timer1.Start();
        }
        private void LoadData()
        {
            try
            {
                dt = new DataTable();
                dt.Clear();
                DateTime date = new DateTime();
               
                DataSet ds = bill.LayTTBill();
                dt = ds.Tables[0];
                dataGridView1.DataSource = dt;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            }
            catch (Exception errr)
            {
                MessageBox.Show(errr.Message);
            }

        }
        private void HoaDon_Load(object sender, EventArgs e)
        {
            icon1.BringToFront();
            LoadData();

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

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                dt = new DataTable();
                dt.Clear();
                DataTable dt1 = new DataTable();
                dt1.Clear();
          
                DataSet ds = bill.LayTongBill(dateTimePicker1.Value);
                dt = ds.Tables[1];
                dt1 = ds.Tables[0];
                dataGridView2.DataSource = dt;
                label5.Text = dataGridView2.Rows[0].Cells[0].Value.ToString();
                label6.Text = dataGridView2.Rows[0].Cells[1].Value.ToString();
                label8.Text = dataGridView2.Rows[0].Cells[2].Value.ToString();
                dataGridView1.DataSource = dt1;


            }
            catch (Exception errr)
            {
                MessageBox.Show(errr.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (bill.XoaBill(dateTimePicker1.Value) == false) MessageBox.Show("Không xóa được!!!");
            else MessageBox.Show("Xóa thành công");
            LoadData();
            dateTimePicker1.Text = DateTime.Now.ToString();
        }
    }
}
