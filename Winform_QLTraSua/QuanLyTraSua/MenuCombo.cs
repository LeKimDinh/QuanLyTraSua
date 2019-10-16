using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyTraSua
{
    public partial class MenuCombo : UserControl
    {
        public static string TenMon = "";
        public MenuCombo()
        {
            InitializeComponent();
        }

       

        

        private void btnChonMon1_Click(object sender, EventArgs e)
        {
            MenuCombo.TenMon = label12.Text;
            ChonMon chonMon = new ChonMon();
            chonMon.ShowDialog();
            
        }
    }
}
