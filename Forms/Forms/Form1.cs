using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Forms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == "Cancel")
            {
                textBox1.Text = "";
                button1.Text = "Button";
            }
            else
            {
                textBox1.Text = "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA";
                button1.Text = "Cancel";
            }
        }
    }
}
