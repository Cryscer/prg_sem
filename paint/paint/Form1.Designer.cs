namespace paint
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonClear = new System.Windows.Forms.Button();
            this.buttonColor = new System.Windows.Forms.Button();
            this.trackBarPen = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonPen = new System.Windows.Forms.Button();
            this.buttonEllipse = new System.Windows.Forms.Button();
            this.buttonFillObject = new System.Windows.Forms.Button();
            this.buttonRectangle = new System.Windows.Forms.Button();
            this.buttonLine = new System.Windows.Forms.Button();
            this.buttonImage = new System.Windows.Forms.Button();
            this.buttonEraser = new System.Windows.Forms.Button();
            this.buttonCrayon = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarPen)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(441, 252);
            this.panel1.TabIndex = 0;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            this.panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseUp);
            // 
            // buttonClear
            // 
            this.buttonClear.Location = new System.Drawing.Point(447, 12);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(74, 32);
            this.buttonClear.TabIndex = 1;
            this.buttonClear.Text = "Clear panel";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // buttonColor
            // 
            this.buttonColor.Location = new System.Drawing.Point(447, 50);
            this.buttonColor.Name = "buttonColor";
            this.buttonColor.Size = new System.Drawing.Size(74, 33);
            this.buttonColor.TabIndex = 2;
            this.buttonColor.Text = "Color";
            this.buttonColor.UseVisualStyleBackColor = true;
            this.buttonColor.Click += new System.EventHandler(this.buttonColor_Click);
            // 
            // trackBarPen
            // 
            this.trackBarPen.Location = new System.Drawing.Point(536, 38);
            this.trackBarPen.Name = "trackBarPen";
            this.trackBarPen.Size = new System.Drawing.Size(122, 45);
            this.trackBarPen.TabIndex = 3;
            this.trackBarPen.Scroll += new System.EventHandler(this.trackBarPen_Scroll);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(574, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Pen size";
            // 
            // buttonPen
            // 
            this.buttonPen.Location = new System.Drawing.Point(448, 139);
            this.buttonPen.Name = "buttonPen";
            this.buttonPen.Size = new System.Drawing.Size(73, 34);
            this.buttonPen.TabIndex = 5;
            this.buttonPen.Text = "Pen";
            this.buttonPen.UseVisualStyleBackColor = true;
            this.buttonPen.Click += new System.EventHandler(this.buttonElipsa_Click);
            // 
            // buttonEllipse
            // 
            this.buttonEllipse.Location = new System.Drawing.Point(527, 139);
            this.buttonEllipse.Name = "buttonEllipse";
            this.buttonEllipse.Size = new System.Drawing.Size(73, 34);
            this.buttonEllipse.TabIndex = 6;
            this.buttonEllipse.Text = "Ellipse";
            this.buttonEllipse.UseVisualStyleBackColor = true;
            this.buttonEllipse.Click += new System.EventHandler(this.buttonEllipse_Click);
            // 
            // buttonFillObject
            // 
            this.buttonFillObject.Location = new System.Drawing.Point(448, 89);
            this.buttonFillObject.Name = "buttonFillObject";
            this.buttonFillObject.Size = new System.Drawing.Size(73, 34);
            this.buttonFillObject.TabIndex = 7;
            this.buttonFillObject.Text = "Fill";
            this.buttonFillObject.UseVisualStyleBackColor = true;
            this.buttonFillObject.Click += new System.EventHandler(this.buttonFillObject_Click);
            // 
            // buttonRectangle
            // 
            this.buttonRectangle.Location = new System.Drawing.Point(606, 140);
            this.buttonRectangle.Name = "buttonRectangle";
            this.buttonRectangle.Size = new System.Drawing.Size(73, 33);
            this.buttonRectangle.TabIndex = 8;
            this.buttonRectangle.Text = "Rectangle";
            this.buttonRectangle.UseVisualStyleBackColor = true;
            this.buttonRectangle.Click += new System.EventHandler(this.buttonRectangle_Click);
            // 
            // buttonLine
            // 
            this.buttonLine.Location = new System.Drawing.Point(685, 140);
            this.buttonLine.Name = "buttonLine";
            this.buttonLine.Size = new System.Drawing.Size(73, 33);
            this.buttonLine.TabIndex = 9;
            this.buttonLine.Text = "Line";
            this.buttonLine.UseVisualStyleBackColor = true;
            this.buttonLine.Click += new System.EventHandler(this.buttonLine_Click);
            // 
            // buttonImage
            // 
            this.buttonImage.Location = new System.Drawing.Point(764, 140);
            this.buttonImage.Name = "buttonImage";
            this.buttonImage.Size = new System.Drawing.Size(73, 33);
            this.buttonImage.TabIndex = 10;
            this.buttonImage.Text = "Image";
            this.buttonImage.UseVisualStyleBackColor = true;
            this.buttonImage.Click += new System.EventHandler(this.buttonImage_Click);
            // 
            // buttonEraser
            // 
            this.buttonEraser.Location = new System.Drawing.Point(449, 179);
            this.buttonEraser.Name = "buttonEraser";
            this.buttonEraser.Size = new System.Drawing.Size(72, 33);
            this.buttonEraser.TabIndex = 11;
            this.buttonEraser.Text = "Eraser";
            this.buttonEraser.UseVisualStyleBackColor = true;
            this.buttonEraser.Click += new System.EventHandler(this.buttonEraser_Click);
            // 
            // buttonCrayon
            // 
            this.buttonCrayon.Location = new System.Drawing.Point(527, 179);
            this.buttonCrayon.Name = "buttonCrayon";
            this.buttonCrayon.Size = new System.Drawing.Size(72, 33);
            this.buttonCrayon.TabIndex = 12;
            this.buttonCrayon.Text = "Crayon";
            this.buttonCrayon.UseVisualStyleBackColor = true;
            this.buttonCrayon.Click += new System.EventHandler(this.buttonCrayon_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(893, 574);
            this.Controls.Add(this.buttonCrayon);
            this.Controls.Add(this.buttonEraser);
            this.Controls.Add(this.buttonImage);
            this.Controls.Add(this.buttonLine);
            this.Controls.Add(this.buttonRectangle);
            this.Controls.Add(this.buttonFillObject);
            this.Controls.Add(this.buttonEllipse);
            this.Controls.Add(this.buttonPen);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.trackBarPen);
            this.Controls.Add(this.buttonColor);
            this.Controls.Add(this.buttonClear);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.trackBarPen)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.Button buttonColor;
        private System.Windows.Forms.TrackBar trackBarPen;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonPen;
        private System.Windows.Forms.Button buttonEllipse;
        private System.Windows.Forms.Button buttonFillObject;
        private System.Windows.Forms.Button buttonRectangle;
        private System.Windows.Forms.Button buttonLine;
        private System.Windows.Forms.Button buttonImage;
        private System.Windows.Forms.Button buttonEraser;
        private System.Windows.Forms.Button buttonCrayon;
    }
}

