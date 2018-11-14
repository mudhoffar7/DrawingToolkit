using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingToolkit.Shapes
{
    class Group : DrawingObject
    {
        private List<DrawingObject> memberGroup = new List<DrawingObject>();
        public override void ChangeState(DrawingState state)
        {
            foreach (DrawingObject obj in memberGroup)
            {
                obj.ChangeState(state);
            }
            this.state = state;
        }
        public override void DrawLogic()
        {
            foreach (DrawingObject obj in memberGroup)
            {
                obj.Draw();
            }
        }
        public override bool intersect(Point MousePosition)
        {
            foreach (DrawingObject obj in memberGroup)
            {
                if (obj.intersect(MousePosition))
                {
                    return true;
                }
            }
            return false;
        }
        public override void move(int x, int y, int xAmount, int yAmount)
        {
            foreach (DrawingObject obj in memberGroup)
            {
                obj.move(x, y, xAmount, yAmount);
            }
        }
        public void addMember(DrawingObject obj)
        {
            this.memberGroup.Add(obj);
        }
        public void removeMember(DrawingObject obj)
        {
            //this.memberGroup.Remove(obj);
        }
    }
}
