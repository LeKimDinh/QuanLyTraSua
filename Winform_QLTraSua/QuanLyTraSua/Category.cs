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
    public partial class Category : Form
    {
        DataTable dt = null;
        QuanLyTraSua.BSLayer.Category category = new QuanLyTraSua.BSLayer.Category();
        string err = "";
        public Category()
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

                DataSet ds = category.LayTTCategory();
                dt = ds.Tables[0];
                dataGridView1.DataSource = dt;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            }
            catch (Exception errr)
            {
                MessageBox.Show(errr.Message);
            }
        }
        private void Category_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        int value = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            value++;
            if (value % 5 == 0)
            {
                Color color = new Color();
                color = panel7.BackColor;
                panel7.BackColor = panel6.BackColor;
                panel6.BackColor = panel5.BackColor;
                panel5.BackColor = panel4.BackColor;
                panel4.BackColor = panel2.BackColor;
                panel2.BackColor = panel1.BackColor;
                panel1.BackColor = color;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            category.ThemCategory("C9", "Thử Nghiệm",ref err);
        }
    }
}
