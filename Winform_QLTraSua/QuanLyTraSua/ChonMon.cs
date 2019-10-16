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
    public partial class ChonMon : Form 
    {
        public ChonMon()
        {
            InitializeComponent();
            label1.Text = MenuCombo.TenMon;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            TextBox text1 = new TextBox();
            text1.Multiline = true;
            text1.TextAlign = HorizontalAlignment.Center;
            text1.Location = new Point(textBox1.Location.X+170, textBox1.Location.Y);
           
            text1.Width = textBox1.Width;
            text1.Height = textBox1.Height;
            
            panel3.Controls.Add(text1);
            panel3.Show();
            
        }
        
        private void ChonMon_Load(object sender, EventArgs e)
        {
            
        }
    }
}
