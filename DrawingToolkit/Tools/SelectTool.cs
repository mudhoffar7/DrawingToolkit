using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrawingToolkit.Tools
{
    public class SelectTool : ToolStripButton, ITool
    {
        private ICanvas canvas;
        public Cursor Cursor
        {
            get
            {
                return Cursors.Arrow;
            }
        }

        public ICanvas TargetCanvas
        {
            get
            {
                return this.canvas;
            }
            set
            {
                this.canvas = value;
            }
        }

        public SelectTool()
        {
            this.Name = "Select Tool";
            this.ToolTipText = "Select Tool";
            this.Image = IconSet.cursor;
            this.CheckOnClick = true;
        }
        public void ToolMouseDown(object sender, MouseEventArgs e)
        {
            List<DrawingObject> ListObjects = this.canvas.GetListObjects();
            foreach (DrawingObject dobject in ListObjects)
            {

                if (dobject.isSelected(e.Location))
                {

                    this.canvas.Repaint();
                }
                else
                {
                    dobject.isNotSelected();
                    this.canvas.Repaint();
                }

            }
        }

        public void ToolMouseMove(object sender, MouseEventArgs e)
        {
            
        }

        public void ToolMouseUp(object sender, MouseEventArgs e)
        {
            
        }
    }
}
