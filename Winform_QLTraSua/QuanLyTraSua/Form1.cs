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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            HomeTime.Interval = 100;
            HomeTime.Start();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            home21.BringToFront();
            sidepanel.Location = new Point(button1.Location.X+3, button1.Location.Y+button1.Height);
            
        }
        private void button1_Click(object sender, EventArgs e)          
        {
            home21.BringToFront();
            sidepanel.Location = new Point(button1.Location.X+3, button1.Location.Y + button1.Height);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            sidepanel.Location = new Point(button2.Location.X+3, button2.Location.Y+button2.Height);           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            sidepanel.Location = new Point(button3.Location.X+3, button3.Location.Y + button3.Height);
            Menu menu = new Menu();
            menu.ShowDialog();
            

        }

        private void button4_Click(object sender, EventArgs e)
        {
            sidepanel.Location = new Point(button4.Location.X+3, button4.Location.Y + button4.Height);

        }

        private void button5_Click(object sender, EventArgs e)
        {
            sidepanel.Location = new Point(button5.Location.X+3, button5.Location.Y + button5.Height);

        }

        private void button6_Click(object sender, EventArgs e)
        {
            sidepanel.Location = new Point(button6.Location.X+3, button6.Location.Y + button6.Height);

        }

        private void rdHome1_CheckedChanged(object sender, EventArgs e)
        {
            home11.BringToFront();
        }

        private void rdHome2_CheckedChanged(object sender, EventArgs e)
        {
            home21.BringToFront();
        }
        int value = 0;
        private void HomeTime_Tick(object sender, EventArgs e)
        {
            value++;
            if (value == 25)
                home11.BringToFront();
            else if (value == 50)
            {
                home21.BringToFront();
                value = 0;
            }
            

        }
    }
}
