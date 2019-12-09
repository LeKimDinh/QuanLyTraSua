using QuanLyTraSua.BSLayer;
using QuanLyTraSua.DBLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyTraSua
{
    public partial class ChiTietHoaDon : Form
    {
        DataTable dt = null;
        Bill bill = new Bill();
        string err = "";
        int BillID = 0;
        DataGridView data;
        DBMain db;
        public ChiTietHoaDon(DataGridView dt)
        {
            InitializeComponent();
            data = dt;
            db = new DBMain();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ChiTietHoaDon_Load(object sender, EventArgs e)
        {
            SqlCommand sqlCmd = new SqlCommand(@"exec LayTenNhanVien '" + Login.ID + "'", db.conn) { CommandType = CommandType.Text };
            comboBox1.Text = Convert.ToString(db.FirstRowQuery(sqlCmd, ref err));
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
        public static string Phonenumber = "";
        private void label8_Click(object sender, EventArgs e)
        {
            ChiTietHoaDon.Phonenumber = textBox2.Text.Trim().ToString();
            if (textBox2.Text.Trim() == "")
            {
                MessageBox.Show("Xin vui lòng kiểm tra thông tin khách đã có thẻ thành viên chưa");
                label7.Text = "0%";
            }
            else
            {
                LayGiamGia layGiamGia = new LayGiamGia();
                layGiamGia.ShowDialog();
                label7.Text = LayGiamGia.giamgia;
                string giamgiaDU = label7.Text;

                giamgiaDU = giamgiaDU.Remove(giamgiaDU.Length - 1, 1);
                int tinhtoan = Convert.ToInt32(giamgiaDU);
                int TongTien = 0;
                if (ChonMon.GiaTien == "")
                    TongTien = 0;
                else
                {
                    if (tinhtoan != 0)
                        TongTien = (Convert.ToInt32(ChonMon.GiaTien.ToString()) * tinhtoan) / 100;
                    else
                        TongTien = Convert.ToInt32(ChonMon.GiaTien.ToString());
                }
                label4.Text = TongTien.ToString() + " VNĐ";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dateTimePicker1.Value.Date != bill.LayDateBuy().Date)
            {
                BillID = 0;
            }
            else
            {
                BillID = bill.LayBillID(dateTimePicker1.Value);
            }
            try
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    BillID++;
                    if (bill.ThemBill(BillID,Login.ID,comboBox1.Text.Trim(), dataGridView1.Rows[i].Cells[0].Value.ToString(), Convert.ToInt32(dataGridView1.Rows[i].Cells[1].Value.ToString()),
                         LayGiamGia.TenKhacHang, textBox2.Text.Trim(), dateTimePicker1.Value, Convert.ToInt32(dataGridView1.Rows[i].Cells[2].Value.ToString())) == false)
                        MessageBox.Show("Không mua được!!!");
                }
            }
            catch { }
            MessageBox.Show("Xin hãy ra quầy tính tiền");
           // Xử lý bên Discount
            if (textBox2.Text != "")
            {
                Discount discount = new Discount();
                string TT = label4.Text;
                TT = TT.Remove(TT.Length - 3, 3);
                int MemberPoints = Convert.ToInt32(TT) / 10000;
                string giamgiaDU = LayGiamGia.MemberPoints;
                //giamgiaDU = giamgiaDU.Remove(giamgiaDU.Length - 1, 1);
                MemberPoints += Convert.ToInt32(giamgiaDU);
                string level = LayGiamGia.Level;
                discount.UpdateDiscount(MemberPoints, textBox2.Text.Trim());
            }
            this.Close();
        }
    }
}
