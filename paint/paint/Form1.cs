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
        Color mainColor = Color.Black;
        float width = 1;
        Pen mainPen;
        Brush mainBrush;
        Brush testBrush;
        Region mainRegion;
        string tool = "pen";
        bool filled = false;
        public Form1()
        {
            InitializeComponent();
            g = panel1.CreateGraphics();
            mainBrush = new SolidBrush(mainColor);
            mainPen = new Pen(mainColor, width);           
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            testBrush = new LinearGradientBrush(lastPosition,e.Location, Color.Blue, Color.Red);
            mainPen = new Pen(testBrush, width);
            if (mousePressed)
            {
                switch (tool)
                {
                    case "pen":
                        g.DrawLine(mainPen, e.Location, lastPosition);
                        lastPosition = e.Location;
                        break;
                    case "eraser":
                        mainRegion = new Region(new Rectangle((int)(e.X - width), (int)(e.Y - width), (int)(2 * width), (int)(2 * width)));
                        panel1.Invalidate(mainRegion);
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
            if ((tool == "ellipse") && (filled = false)) g.DrawEllipse(mainPen, lastPosition.X, lastPosition.Y, e.X - lastPosition.X, e.Y - lastPosition.Y);
            else if ((tool == "ellipse") && (filled = true)) g.FillEllipse(mainBrush, lastPosition.X, lastPosition.Y, e.X - lastPosition.X, e.Y - lastPosition.Y);
            else if ((tool == "rectangle") && (filled = false)) g.DrawRectangle(mainPen, lastPosition.X, lastPosition.Y, e.X - lastPosition.X, e.Y - lastPosition.Y);
            else if ((tool == "rectangle") && (filled = true)) g.FillRectangle(mainBrush, lastPosition.X, lastPosition.Y, e.X - lastPosition.X, e.Y - lastPosition.Y);
            else if (tool == "line") g.DrawLine(mainPen, lastPosition.X, lastPosition.Y, e.X, e.Y);
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
            mainColor = myColorDialog.Color;
            mainBrush = new SolidBrush(mainColor);
            mainPen = new Pen(mainColor, width);
        }

        private void trackBarPen_Scroll(object sender, EventArgs e)
        {
            width = trackBarPen.Value;
            mainPen = new Pen(mainColor, width);
        }

        private void buttonElipsa_Click(object sender, EventArgs e)
        {
            tool = "pen";
        }

        private void buttonEllipse_Click(object sender, EventArgs e)
        {
            tool = "ellipse";
        }

        private void buttonFillObject_Click(object sender, EventArgs e)
        {
            if (filled == false) filled = true;
            else filled = false;
        }

        private void buttonRectangle_Click(object sender, EventArgs e)
        {
            tool = "rectangle";
        }

        private void buttonLine_Click(object sender, EventArgs e)
        {
            tool = "line";
        }

        private void buttonImage_Click(object sender, EventArgs e)
        {

        }

        private void buttonEraser_Click(object sender, EventArgs e)
        {
            tool = "eraser";
        }
    }
}
