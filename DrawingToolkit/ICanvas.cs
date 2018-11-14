﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingToolkit
{
    public interface ICanvas
    {
        void SetActiveTool(ITool tool);
        void Repaint();
        void SetBackgroundColor(Color color);
        void AddDrawingObject(DrawingObject drawingObject);
        List<DrawingObject> GetListObjects();
    }
}
