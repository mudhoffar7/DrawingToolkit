using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrawingToolkit
{
    public abstract class DrawingObject
    {
        public Graphics Graphics { get; set; }

        public abstract void Draw();
        public abstract Boolean isSelected(Point mouse);
        public abstract void isNotSelected();

        public abstract void Move(MouseEventArgs e, int x, int y);
    }
}
