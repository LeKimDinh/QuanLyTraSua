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
    public partial class ChiTietHoaDon : Form
    {

        DataGridView data;
        public ChiTietHoaDon(DataGridView dt)
        {
            InitializeComponent();
            data = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ChiTietHoaDon_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.Columns.Count; i++)
            {
                dataGridView1.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
            for (int i = 0; i < data.Rows.Count - 1; i++)
            {
                dataGridView1.Rows.Add(data.Rows[i].Cells[0].Value, data.Rows[i].Cells[1].Value, data.Rows[i].Cells[2].Value, data.Rows[i].Cells[3].Value);
            }
            dataGridView1.Refresh();
            label4.Text = ChonMon.GiaTien + " VND";
        }

        private void label8_Click(object sender, EventArgs e)
        {
            LayGiamGia layGiamGia = new LayGiamGia();
            layGiamGia.ShowDialog();
            label7.Text = LayGiamGia.giamgia;
            string x = label7.Text;
            x = x.Remove(x.Length - 1, 1);
            MessageBox.Show(x);
            int tinhtoan = Convert.ToInt32(x);
            int TongTien = 0;
            TongTien = (Convert.ToInt32(ChonMon.GiaTien.ToString()) * tinhtoan) / 100;
            label4.Text = TongTien.ToString()+" VNĐ";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
