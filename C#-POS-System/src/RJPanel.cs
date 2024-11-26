using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace RoundedPanelClass
{
    public class RJPanel : Panel
    {
        //FIelds
        private int borderRadius = 30;
        private float gradientAngle = 90F;
        private Color gradientTopColor = Color.Green;
        private Color gradientBottomColor = Color.DarkGray;
        
        //Constructor
        public RJPanel()
        {
            this.BackColor = Color.White;
            this.ForeColor = Color.White;
            this.Size = new Size(350, 200);

        }

        public int BorderRadius
        {
            get => borderRadius;
            set { borderRadius = value; this.Invalidate(); }
        }
        public float GradientAngle
        {
            get => gradientAngle;
            set { gradientAngle = value; this.Invalidate(); }
        }
        public Color GradientTopColor
        {
            get => gradientTopColor;
            set { gradientTopColor = value; this.Invalidate(); }
        }
        public Color GradientBottomColor
        {
            get => gradientBottomColor;
            set { gradientBottomColor = value; this.Invalidate(); }
        }

        //properties
        //methods
        private GraphicsPath GetPanelPath(RectangleF rectangle, float radius)
        {
            GraphicsPath graphicpath = new GraphicsPath();
            graphicpath.StartFigure();
            graphicpath.AddArc(rectangle.Width - radius, rectangle.Height - radius,radius,radius,0,90);
            graphicpath.AddArc(rectangle.X, rectangle.Height - radius, radius, radius, 90, 90);
            graphicpath.AddArc(rectangle.X, rectangle.Y, radius, radius, 180, 90);
            graphicpath.AddArc(rectangle.Width - radius, rectangle.Y, radius, radius, 270, 90);
            graphicpath.CloseFigure();
            return graphicpath;
        }

        //Override Methods
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            //Gradient
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            LinearGradientBrush brushArt = new LinearGradientBrush(this.ClientRectangle, this.GradientTopColor, this.GradientBottomColor, this.GradientAngle);
            Graphics graphics = e.Graphics;
            graphics.FillRectangle(brushArt, ClientRectangle);
            //Border radius
            RectangleF rectangleF = new RectangleF(0, 0, this.Width, this.Height);
            if (borderRadius>2)
            {
                using(GraphicsPath graphicsPath = GetPanelPath(rectangleF, borderRadius))
                {
                    this.Region = new Region(graphicsPath);
                    using (Pen pen = new Pen(this.Parent.BackColor, 2))
                    {
                        this.Region = new Region(graphicsPath);
                        e.Graphics.DrawPath(pen, graphicsPath);

                    }
                }   
            }
            else this.Region = new Region(rectangleF);
        }
    }
}
