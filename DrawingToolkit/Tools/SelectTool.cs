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
    public class SelectTool : ToolStripButton, ITool
    {
        private ICanvas canvas;
        private int xInitial;
        private int yInitial;
        private DrawingObject currentObject = null;

        private Boolean multiselectProcess = false;
        
        private List<DrawingObject> memberGroup = new List<DrawingObject>();

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
            if (currentObject != null && !multiselectProcess) currentObject.ChangeState(StaticState.GetInstance());
            foreach (DrawingObject obj in this.canvas.GetListObjects().Reverse<DrawingObject>())
            {
                if (obj.intersect(e.Location))
                {
                    if (!multiselectProcess) memberGroup.Clear();
                    else
                    {
                        if (!memberGroup.Any()) memberGroup.Add(this.currentObject);
                        memberGroup.Add(obj);
                    }
                    this.currentObject = obj;
                    obj.ChangeState(EditState.GetInstance());
                    break;
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
                currentObject.move(e.X, e.Y, xAmount, yAmount);
            }
        }
        public void ToolMouseUp(object sender, MouseEventArgs e)
        {


        }
        public void ToolHotKeysDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == System.Windows.Forms.Keys.ControlKey)
            {
                multiselectProcess = true;
            }
            else if (e.KeyCode == System.Windows.Forms.Keys.G)
            {
                if (memberGroup.Count() > 0)
                {
                    Group groupObject = new Group();
                    foreach (DrawingObject obj in memberGroup)
                    {
                        groupObject.addMember(obj);
                    }
                    groupObject.ChangeState(EditState.GetInstance());
                    this.canvas.AddDrawingObject(groupObject);
                    this.currentObject = groupObject;
                }
            }
            
        }
        public void updatePos(ITool tool)
        {

            if (tool.GetType() == typeof(AlignmentLeftTool))
            {
                
                if (memberGroup.Count() > 0)
                {
                    foreach (DrawingObject obj in memberGroup)
                    {
                        obj.Allignment(1, this.canvas);
                    }
                    canvas.Repaint();
                }
                else
                {
                    currentObject.Allignment(1, this.canvas);
                    canvas.Repaint();
                }
            }
            else if (tool.GetType() == typeof(AlignmentRightTool))
            {
                if (memberGroup.Count() > 0)
                {
                    foreach (DrawingObject obj in memberGroup)
                    {
                        obj.Allignment(2, this.canvas);
                    }
                    canvas.Repaint();
                }
                else
                {
                    currentObject.Allignment(2, this.canvas);
                    canvas.Repaint();
                }
            }
            else if (tool.GetType() == typeof(AlignmentCenterTool))
            {
                if (memberGroup.Count() > 0)
                {
                    foreach (DrawingObject obj in memberGroup)
                    {
                        obj.Allignment(3, this.canvas);
                    }
                    canvas.Repaint();
                }
                else
                {
                    currentObject.Allignment(3, this.canvas);
                    canvas.Repaint();
                }
            }
        }
        public void ToolHotKeysUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == System.Windows.Forms.Keys.ControlKey)
            {
                multiselectProcess = false;
            }
        }
    }
}
