using DrawingToolkit.Shapes;
using DrawingToolkit.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrawingToolkit.Tools
{
    class ConnectorTool : ToolStripButton, ITool
    {
        private ICanvas canvas;
        private Circle circle;

        Circle sourceObject;
        Circle destinationObject;

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

        public Cursor Cursor => throw new NotImplementedException();

        public ConnectorTool()
        {
            this.Name = "Connector tool";
            this.ToolTipText = "Connector tool";
            this.CheckOnClick = true;
            this.Text = "C";
        }


        public void ToolMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                foreach (DrawingObject obj in this.canvas.GetListObjects().Reverse<DrawingObject>())
                {
                    if (obj.intersect(e.Location))
                    {
                        if (obj.GetType() == typeof(Circle))
                        {
                            sourceObject = (Circle)obj;
                        }
                        break;
                    }
                }
            }
        }

        public void ToolMouseMove(object sender, MouseEventArgs e)
        {

        }

        public void ToolMouseUp(object sender, MouseEventArgs e)
        {
            if (sourceObject != null)
            {
                foreach (DrawingObject obj in this.canvas.GetListObjects().Reverse<DrawingObject>())
                {
                    if (obj.intersect(e.Location))
                    {
                        if (obj.GetType() == typeof(Circle))
                        {
                            destinationObject = (Circle)obj;
                            Connector connect = new Connector(sourceObject, destinationObject);

                            sourceObject.addObserver(connect);
                            destinationObject.addObserver(connect);

                            canvas.AddDrawingObject(connect);
                            connect.ChangeState(StaticState.GetInstance());
                        }
                        break;
                    }
                }
            }
            sourceObject = null;
            destinationObject = null;
        }

        public void ToolHotKeysDown(object sender, KeyEventArgs e)
        {
            throw new NotImplementedException();
        }
        public void ToolHotKeysUp(object sender, KeyEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
