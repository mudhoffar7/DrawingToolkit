using DrawingToolkit.States;
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
        private Boolean multiSelect = false;
        private int xInitial;
        private int yInitial;
        private DrawingObject currentObject = null;
        private DrawingObject parentObject = null;
        
        public SelectTool()
        {
            this.Name = "Select Tool";
            this.ToolTipText = "Select Tool";
            this.Image = IconSet.cursor;
            this.CheckOnClick = true;
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

        public Cursor Cursor => throw new NotImplementedException();

        public void ToolMouseDown(object sender, MouseEventArgs e)
        {
            this.xInitial = e.X;
            this.yInitial = e.Y;

            int flag = 0;
            foreach (DrawingObject obj in this.canvas.GetListObjects().Reverse<DrawingObject>())
            {
                if (obj.intersect(e.Location) && flag == 0)
                {
                    if (!this.multiSelect)
                    {
                        flag = 1;
                    }
                    else
                    {
                        if (parentObject == null) parentObject = obj;
                        if (currentObject != null) currentObject.addChild(obj);
                    }
                    this.currentObject = obj;
                    obj.ChangeState(EditState.GetInstance());
                }
                else if (!this.multiSelect)
                {
                    obj.ChangeState(StaticState.GetInstance());
                }
            }
        }

        public void ToolMouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && this.currentObject != null)
            {
                int xAmount = e.X - xInitial;
                int yAmount = e.Y - yInitial;
                xInitial = e.X;
                yInitial = e.Y;
                if (this.multiSelect) parentObject.move(e.X, e.Y, xAmount, yAmount);
                else currentObject.move(e.X, e.Y, xAmount, yAmount);
            }
        }
        public void ToolMouseUp(object sender, MouseEventArgs e)
        {


        }
        public void ToolHotKeysDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == System.Windows.Forms.Keys.ControlKey)
            {
                this.multiSelect = true;
            }
        }
        public void ToolHotKeysUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == System.Windows.Forms.Keys.ControlKey)
            {
                this.multiSelect = false;
            }
        }
    }
}
