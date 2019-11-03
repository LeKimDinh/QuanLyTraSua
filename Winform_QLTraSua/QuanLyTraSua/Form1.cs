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
            home31.BringToFront();
            sidepanel.Location = new Point(button1.Location.X+3, button1.Location.Y+button1.Height);
            icon1.BringToFront();
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
            Random random = new Random();
            
            value++;
            if (value == 10)
                icon1.BringToFront();
            if (value == 20)
            {
                home11.BringToFront();
                icon21.BringToFront();
            }
            else if (value == 30)
            {
                home21.BringToFront();
                icon31.BringToFront();
            }
            else if (value == 40)
            { home31.BringToFront();
                icon41.BringToFront();
                value = 0; 
            }
            
                
            
                
           
                
            label1.ForeColor = Color.FromArgb(random.Next(0, 255), random.Next(0, 255), random.Next(0, 255));
            sidepanel.BackColor = Color.FromArgb(random.Next(0, 255), random.Next(0, 255), random.Next(0, 255));

            

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            home31.BringToFront();
        }
    }
}
