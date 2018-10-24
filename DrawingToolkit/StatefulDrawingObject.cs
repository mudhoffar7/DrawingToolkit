using DrawingToolkit.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingToolkit
{
    public abstract class StatefulDrawingObject : DrawingObject
    {
        public DrawingState State
        {
            get
            {
                return this.state;
            }
        }

        private DrawingState state;

        public StatefulDrawingObject()
        {
            this.ChangeState(PreviewState.GetInstance()); //default initial state
        }

        public abstract void RenderOnStaticView();
        public abstract void RenderOnEditingView();
        public abstract void RenderOnPreview();

        public void ChangeState(DrawingState state)
        {
            this.state = state;
        }

        public override void Draw()
        {
            this.state.Draw(this);
        }

        public void Select()
        {
            this.state.Select(this);
        }

        public void Deselect()
        {
            this.state.Deselect(this);
        }
    }
}
