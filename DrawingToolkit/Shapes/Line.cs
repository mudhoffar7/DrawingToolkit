﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingToolkit.Shapes
{
    public class Line : DrawingObject
    {
        private const double EPSILON = 3.0;

        public Line()
        {

        }
        public Line(Point startpoint) :
            this()
        {
            this.Startpoint = startpoint;
        }

        public Line(Point startpoint, Point endpoint) :
            this(startpoint)
        {
            this.Endpoint = endpoint;
        }

        public override void Allignment(int position, ICanvas canvas)
        {
            if (position == 1)
            {
                Endpoint.X -= Startpoint.X;
                Startpoint.X = 0;
            }
            if (position == 2)
            {
                int delta = canvas.GetWidth() - this.Endpoint.X;
                Endpoint.X = canvas.GetWidth();
                Startpoint.X += delta;
            }
            if(position == 3)
            {
                int center = canvas.GetWidth() / 2;
                int objWidth = Endpoint.X - Startpoint.X;
                Startpoint.X = center - (objWidth / 2);
                Endpoint.X = center + (objWidth / 2);
            }
        }

        public override void DrawLogic()
        {
            this.Graphics.DrawLine(pen, Startpoint, Endpoint);
        }

        public override bool intersect(Point MousePosition)
        {
            double m = (double)(Endpoint.Y - Startpoint.Y) / (double)(Endpoint.X - Startpoint.X);
            double b = Endpoint.Y - m * Endpoint.X;
            double y_point = m * MousePosition.X + b;

            if (Math.Abs(MousePosition.Y - y_point) < EPSILON)
            {
                return true;
            }
            return false;
        }
    }
}
