﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingToolkit.Shapes
{
    public class Circle : DrawingObject
    {
        public int cirX { get; set; }
        public int cirY { get; set; }
        public int cirWidth { get; set; }
        public int cirHeight { get; set; }

        private Pen pen;

        public Circle()
        {
            this.pen = new Pen(Color.Black);
        }

        public Circle(int initX, int initY) : this()
        {
            this.cirX = initX;
            this.cirY = initY;
        }

        public Circle(int initX, int initY, int initWidth, int initHeight) : this(initX, initY)
        {
            this.cirWidth = initWidth;
            this.cirHeight = initHeight;
        }

        public override void Draw()
        {
            this.Graphics.DrawEllipse(pen, cirX, cirY, cirWidth, cirHeight);
        }

        public override bool isSelected(Point mouse)
        {
            if ((mouse.X >= cirX && mouse.X <= cirX + cirWidth) && (mouse.Y >= cirY && mouse.Y <= cirY + cirHeight))
            {
                pen.Color = Color.FromArgb(255, 255, 0, 0);
                return true;
            }
            return false;
        }

        public override void isNotSelected()
        {
            pen.Color = Color.FromArgb(255, 0, 0, 0);
        }
    }
}