using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingToolkit.Shapes
{
    public class StatefulLine : StatefulDrawingObject
    {
        public Point Startpoint { get; set; }
        public Point Endpoint { get; set; }
        private Pen pen;
        public StatefulLine()
        {
            this.pen = new Pen(Color.Black);
            pen.Width = 1.5f;
        }
        public StatefulLine(Point startpoint) :
           this()
        {
            this.Startpoint = startpoint;
        }
        public StatefulLine(Point startpoint, Point endpoint) :
           this(startpoint)
        {
            this.Endpoint = endpoint;
        }
        public override void RenderOnStaticView()
        {
            this.pen = new Pen(Color.Black);
            pen.Width = 1.5f;
            if (this.Graphics != null)
            {
                this.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                this.Graphics.DrawLine(pen, this.Startpoint, this.Endpoint);
            }
        }
        public override void RenderOnEditingView()
        {
            RenderOnStaticView();
        }
        public override void RenderOnPreview()
        {
            this.pen = new Pen(Color.Red);
            pen.Width = 1.5f;
            pen.DashStyle = DashStyle.DashDotDot;
            if (this.Graphics != null)
            {
                this.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                this.Graphics.DrawLine(pen, this.Startpoint, this.Endpoint);
            }
        }

        public override bool isSelected(Point mouse)
        {
            throw new NotImplementedException();
        }

        public override void isNotSelected()
        {
            throw new NotImplementedException();
        }
    }
}
