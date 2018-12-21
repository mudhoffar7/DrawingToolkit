﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrawingToolkit.Tools
{
    class AlignmentLeftTool : ToolStripButton, ITool
    {
        private ICanvas canvas;

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

        public AlignmentLeftTool()
        {
            this.Name = "Alignment Left Tool";
            this.ToolTipText = "Alignment Left Tool";
            this.Image = IconSet.left;
            this.CheckOnClick = true;

        }


        public void ToolMouseDown(object sender, MouseEventArgs e)
        {
            throw new NotImplementedException();
        }

        public void ToolMouseMove(object sender, MouseEventArgs e)
        {
            throw new NotImplementedException();
        }

        public void ToolMouseUp(object sender, MouseEventArgs e)
        {
            throw new NotImplementedException();
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
