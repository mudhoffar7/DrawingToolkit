using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingToolkit.Shapes
{
    class Connector : DrawingObject, IObserver
    {
        private const double EPSILON = 3.0;
        public Circle source;
        public Circle destination;
        public Connector(Circle source, Circle destination)
        {
            this.source = source;
            this.destination = destination;
            update();
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

        public void update()
        {
            this.Startpoint.X = (source.Endpoint.X + source.Startpoint.X) / 2;
            this.Startpoint.Y = (source.Endpoint.Y + source.Startpoint.Y) / 2;

            this.Endpoint.X = (destination.Endpoint.X + destination.Startpoint.X) / 2;
            this.Endpoint.Y = (destination.Endpoint.Y + destination.Startpoint.Y) / 2;
        }
    }
}
