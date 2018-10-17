using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingToolkit.Shapes
{
    public class Line : DrawingObject
    {
        private const double EPSILON = 3.0;

        public Point startPoint { get; set; }
        public Point finishPoint { get; set; }
        private Pen pen;

        public Line()
        {
            this.pen = new Pen(Color.Black);
        }

        public Line(Point initX) : this()
        {
            this.startPoint = initX;
        }

        public Line(Point initX, Point initY) : this(initX)
        {
            this.finishPoint = initY;
        }

        public override void Draw()
        {
            this.Graphics.DrawLine(this.pen, startPoint, finishPoint);
        }

        public override bool isSelected(Point mouse)
        {
            double m = (double)(finishPoint.Y - startPoint.Y) / (double)(finishPoint.X - startPoint.X);
            double b = finishPoint.Y - m * finishPoint.X;
            double y_point = m * mouse.X + b;

            if (Math.Abs(mouse.Y - y_point) < EPSILON)
            {
                pen.Color = Color.FromArgb(255, 255, 0, 0);
                return true;
            }
            return false;
        }

        public override void isNotSelected()
        {
            pen.Color = Color.FromArgb(255, 0, 0, 0);
        }
    }
}
