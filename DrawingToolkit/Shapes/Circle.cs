using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingToolkit.Shapes
{
    public class Circle : DrawingObject, IObservable
    {
        List<IObserver> obsList = new List<IObserver>();
        public Circle(Point startPoints, Point endPoints)
        {
            this.Startpoint = startPoints;
            this.Endpoint = endPoints;
        }

        public override void DrawLogic()
        {
            if (Startpoint.X > Endpoint.X)
            {
                var temp = Startpoint.X;
                Startpoint.X = Endpoint.X;
                Endpoint.X = temp;
            }
            if (Startpoint.Y > Endpoint.Y)
            {
                var temp = Startpoint.Y;
                Startpoint.Y = Endpoint.Y;
                Endpoint.Y = temp;
            }
            Rectangle objek = new Rectangle(Startpoint.X, Startpoint.Y, Endpoint.X - Startpoint.X, Endpoint.Y - Startpoint.Y);
            this.Graphics.DrawEllipse(pen, objek);
            notifyObserver();
        }

        public override bool intersect(Point MousePosition)
        {
            if ((MousePosition.X >= Startpoint.X && MousePosition.X <= Startpoint.X + (Endpoint.X - Startpoint.X)) && (MousePosition.Y >= Startpoint.Y && MousePosition.Y <= Startpoint.Y + (Endpoint.Y - Startpoint.Y)))
            {
                pen.Color = Color.FromArgb(255, 255, 0, 0);
                return true;
            }
            return false;
        }

        public void addObserver(IObserver observer)
        {
            obsList.Add(observer);
        }

        public void notifyObserver()
        {
            foreach (IObserver obs in obsList)
            {
                obs.update();
            }
        }

        public void removeObserver(IObserver observer)
        {
            obsList.Remove(observer);
        }
    }
}
