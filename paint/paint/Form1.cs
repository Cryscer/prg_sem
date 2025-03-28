using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
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
        bool mousePressed;
        Pen mainPen = new Pen(Color.Black, 1);
        string tool = "pen";
        GraphicsState newState;
        public Form1()
        {
            InitializeComponent();
            g = panel1.CreateGraphics();
            newState = g.Save();
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mousePressed)
            {
                switch (tool)
                {
                    case "pen":
                        g.DrawLine(mainPen, e.Location, lastPosition);
                        lastPosition = e.Location;
                        newState = g.Save();
                        break;
                    case "ellipse":
                        g.Restore(newState);
                        g.DrawEllipse(mainPen, lastPosition.X, lastPosition.Y, e.X - lastPosition.X, e.Y - lastPosition.Y);
                        break;
                }
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            mousePressed = true;
            lastPosition = e.Location;
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            mousePressed = false;
            newState = g.Save();
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            panel1.Refresh();
        }

        private void buttonColor_Click(object sender, EventArgs e)
        {
            ColorDialog myColorDialog = new ColorDialog();
            myColorDialog.Color = mainPen.Color;
            myColorDialog.ShowDialog();
            mainPen.Color = myColorDialog.Color;
        }

        private void trackBarPen_Scroll(object sender, EventArgs e)
        {
            mainPen.Width = trackBarPen.Value;
        }

        private void buttonElipsa_Click(object sender, EventArgs e)
        {
            tool = "pen";
        }

        private void buttonEllipse_Click(object sender, EventArgs e)
        {
            tool = "ellipse";
        }
    }
}
