﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace paint
{
    public partial class Form1 : Form
    {
        System.Drawing.Point lastPosition;
        Graphics g;
        public Form1()
        {
            InitializeComponent();
            g = panel1.CreateGraphics();
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {           
            g.DrawLine(Pens.Black, e.Location, lastPosition);  
            lastPosition = e.Location;
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            
        }
    }
}
