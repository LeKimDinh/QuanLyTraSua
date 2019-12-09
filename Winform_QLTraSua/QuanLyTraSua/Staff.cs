<<<<<<< HEAD
﻿
using QuanLyTraSua.DBLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
=======
﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
>>>>>>> e73bcb2fe638eb223989d71606edc5ae4a3059a0
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyTraSua
{
    public partial class Staff : Form
    {
<<<<<<< HEAD
        DBMain db;
        DataTable dt = null;
        public static int trangthaidangnhap = 2;

        public Staff()
        {
            InitializeComponent();
            db = new DBMain();
=======
        public Staff()
        {
            InitializeComponent();
>>>>>>> e73bcb2fe638eb223989d71606edc5ae4a3059a0
        }

        private void Staff_Load(object sender, EventArgs e)
        {
<<<<<<< HEAD
            Form1.trangthaidangnhap = 2;
            if (trangthaidangnhap == 1)
            {
                btn_ADD.Visible = true;
                btn_UPDATE.Visible = true;
                btn_DELETE.Visible = true;
            }

            else if (trangthaidangnhap == 2)
            {
                btn_ADD.Visible = false;
                btn_UPDATE.Visible = false;
                btn_DELETE.Visible = false;
            }
            Load_Data();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        public void Load_Data()
        {

            //try
            //{
            //    //string LoadNhanVien = @"EXEC LayNhanVien";
            //    //DataTable dt = DBMain.getDataTable(LoadNhanVien);
            //    SqlCommand sqlCmd = new SqlCommand(@"EXEC LayNhanVien", db.conn) { CommandType = CommandType.Text };
            //    dt = new DataTable();
            //    dt.Clear();
            //    DataSet ds = db.ExecuteQueryDataSet(sqlCmd);
            //    dt = ds.Tables[0];
            //    dgvNhanVien.DataSource = dt;
            //}
            //catch (sqlException)
            //{

            //}

            try
            {
                SqlCommand sqlCmd = new SqlCommand(@"EXEC LayNhanVien", db.conn) { CommandType = CommandType.Text };
                dt = new DataTable();
                dt.Clear();
                DataSet ds = db.ExecuteQueryDataSet(sqlCmd);
                dt = ds.Tables[0];
                dgvNhanVien.DataSource = dt;
                dgvNhanVien.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            }
            catch (Exception errr)
            {
                MessageBox.Show(errr.Message);
            }
        }

        private void btn_ADD_Click(object sender, EventArgs e)
        {
            try
            {

                int a = dgvNhanVien.Rows.Count;
                if (this.txtMaNV.Text == "" || this.txtTenNV.Text == "")
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                else
                {
                    string GioiTinh = "nữ";
                    if (nam.Checked == true)
                        GioiTinh = "nam";
                    DateTime NgaySinh = ngaysinh.Value;
                    //string ThemNhanVien = @"EXEC ThemNhanVien '" + txtMaNV.Text + "',N'" + txtTenNV.Text + "','" + GioiTinh + "','" + NgaySinh + "',N'" + txtQuequan.Text + "','" + txtEmail.Text + "','" + manhom.Text + "','" + txtLuong.Text + "','" + txtMaQuanLy + "'";
                    //DBMain.executeQuery(ThemNhanVien);
                    SqlCommand sqlCmd = new SqlCommand(@"EXEC ThemNhanVien '" + txtMaNV.Text + "',N'" + txtTenNV.Text + "','" + GioiTinh + "','" + NgaySinh + "',N'" + txtQuequan.Text + "','" + txtEmail.Text + "','" + manhom.Text + "','" + txtLuong.Text + "','" + txtMaQuanLy + "'", db.conn) { CommandType = CommandType.Text };
                    db.MyExecuteNonQuery(sqlCmd);
                    Load_Data();
                    if (a < dgvNhanVien.Rows.Count)
                        MessageBox.Show("Thêm thành công!");
                }
            }
            catch
            {

            }
        }

        private void btn_UPDATE_Click(object sender, EventArgs e)
        {
            try
            {
                string GioiTinh = "Nữ";
                if (nam.Checked == true)
                    GioiTinh = "Nam";
                DateTime NgaySinh = ngaysinh.Value;
                //string up = @"EXEC CapNhatNhanVien '" + this.txtMaNV.Text + "',N'" + this.txtTenNV.Text + "','" + GioiTinh + "','" + NgaySinh + "',N'" + txtQuequan.Text + "','" + txtEmail.Text + "','" + manhom.Text + "','" + txtLuong.Text + "','" + txtMaQuanLy.Text + "'";
                //DBMain.executeQuery(up);
                SqlCommand sqlCmd = new SqlCommand(@"EXEC CapNhatNhanVien '" + this.txtMaNV.Text + "',N'" + this.txtTenNV.Text + "',N'" + GioiTinh + "',N'" + NgaySinh + "',N'" + txtQuequan.Text + "',N'" + txtEmail.Text + "','" + manhom.Text + "','" + txtLuong.Text + "',N'" + txtMaQuanLy.Text + "'", db.conn) { CommandType = CommandType.Text };
                db.MyExecuteNonQuery(sqlCmd);
                Load_Data();
                //MessageBox.Show("Cập nhật thành công!");
            }
            catch (SqlException)
            {

            }
        }

        private void btn_DELETE_Click(object sender, EventArgs e)
        {
            int a = dgvNhanVien.Rows.Count;
            //string xoa = @"EXEC XoaNhanVien'" + txtMaNV.Text + "'";
            SqlCommand sqlCmd = new SqlCommand(@"EXEC XoaNhanVien'" + txtMaNV.Text + "'", db.conn) { CommandType = CommandType.Text };

            if (txtMaNV.Text == "")
                MessageBox.Show("Mã nhân viên không được để trống!");
            else
            {
                DialogResult dialog = MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialog == DialogResult.Yes)
                {
                    //DBMain.executeQuery(xoa);
                    db.MyExecuteNonQuery(sqlCmd);
                    Load_Data();
                    if (a > dgvNhanVien.Rows.Count)
                        MessageBox.Show("Xóa thành công!");
                }
                else if (dialog == DialogResult.No)
                {

                }
            }
        }


        private void dgvNhanVien_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow row = new DataGridViewRow();
                row = dgvNhanVien.Rows[e.RowIndex];
                txtMaNV.Text = row.Cells[0].Value.ToString();
                txtTenNV.Text = row.Cells[1].Value.ToString();
                if (row.Cells[2].Value.ToString() == "Nam")
                    nam.Checked = true;
                else
                    nu.Checked = false;
                ngaysinh.Value = DateTime.Parse(row.Cells[3].Value.ToString());
                txtQuequan.Text = row.Cells[4].Value.ToString();
                txtEmail.Text = row.Cells[5].Value.ToString();
                manhom.Text = row.Cells[6].Value.ToString();
                txtLuong.Text = row.Cells[7].Value.ToString();
                txtMaQuanLy.Text = row.Cells[8].Value.ToString();
            }
            catch
            {
                MessageBox.Show("Không có giá trị!");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Bạn có chắc chắn muốn LogOut không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialog == DialogResult.Yes)
            {
                Form1.trangthaidangnhap = 3;
                this.Close();
            }
            else if (dialog == DialogResult.No)
            {
                Form1.trangthaidangnhap = 2;
            }
        }

=======

        }
>>>>>>> e73bcb2fe638eb223989d71606edc5ae4a3059a0
    }
}
