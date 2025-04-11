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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

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
        Region mainRegion;
        string tool = "pen";
        bool filled = false;
        Bitmap image;
        public Form1()
        {
            InitializeComponent();
            g = panel1.CreateGraphics();
            mainBrush = new SolidBrush(mainColor);
            mainPen = new Pen(mainColor, width);
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
                        break;
                    case "eraser":
                        mainRegion = new Region(new Rectangle((int)(e.X - width), (int)(e.Y - width), (int)(2 * width), (int)(2 * width)));
                        panel1.Invalidate(mainRegion);
                        break;
                    case "crayon":
                        g.DrawLine(mainPen, e.Location, lastPosition);
                        lastPosition = e.Location;
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
            if ((tool == "ellipse") && (filled == false)) g.DrawEllipse(mainPen, lastPosition.X, lastPosition.Y, e.X - lastPosition.X, e.Y - lastPosition.Y);
            else if ((tool == "ellipse") && (filled == true)) g.FillEllipse(mainBrush, lastPosition.X, lastPosition.Y, e.X - lastPosition.X, e.Y - lastPosition.Y);
            else if ((tool == "rectangle") && (filled == false)) g.DrawRectangle(mainPen, lastPosition.X, lastPosition.Y, e.X - lastPosition.X, e.Y - lastPosition.Y);
            else if ((tool == "rectangle") && (filled == true)) g.FillRectangle(mainBrush, lastPosition.X, lastPosition.Y, e.X - lastPosition.X, e.Y - lastPosition.Y);
            else if (tool == "line") g.DrawLine(mainPen, lastPosition.X, lastPosition.Y, e.X, e.Y);
            else if (tool == "image") g.DrawImage(image, lastPosition.X, lastPosition.Y, e.X - lastPosition.X, e.Y - lastPosition.Y);
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
            if (tool == "crayon")
            {
                mainBrush = new SolidBrush(Color.FromArgb(125, mainColor));
                mainPen = new Pen(Color.FromArgb(125, mainColor), width);
            }
            else
            {
                mainBrush = new SolidBrush(mainColor);
                mainPen = new Pen(mainColor, width);
            }
        }

        private void trackBarPen_Scroll(object sender, EventArgs e)
        {
            width = trackBarPen.Value;
            if (tool == "crayon") mainPen = new Pen(Color.FromArgb(125, mainColor), width);
            else mainPen = new Pen(mainColor, width);
        }

        private void buttonElipsa_Click(object sender, EventArgs e)
        {
            tool = "pen";
            mainBrush = new SolidBrush(Color.FromArgb(255, mainColor));
            mainPen = new Pen(Color.FromArgb(255, mainColor), width);
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
            tool = "image";           
            listBox1.BeginUpdate();
            listBox1.Items.Clear();
            listBox1.Items.Add(nameof(Properties.Resources.Mlok));
            listBox1.Items.Add(nameof(Properties.Resources.gigamlok));
            listBox1.Items.Add(nameof(Properties.Resources.house));
            listBox1.EndUpdate();
        }

        private void buttonEraser_Click(object sender, EventArgs e)
        {
            tool = "eraser";
        }

        private void buttonCrayon_Click(object sender, EventArgs e) //přidal jsme voskovku
        {
            tool = "crayon";
            mainBrush = new SolidBrush(Color.FromArgb(125, mainColor));
            mainPen = new Pen(Color.FromArgb(125, mainColor), width);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (listBox1.SelectedIndex)
            {
                case 0:
                    image = Properties.Resources.Mlok;                   
                    break;
                case 1:
                    image = Properties.Resources.gigamlok;
                    break;
                case 2:
                    image = Properties.Resources.house;
                    break;
            }
            pictureBox1.Image = image;
        }
    }
}
