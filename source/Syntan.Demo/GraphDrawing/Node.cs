using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Syntan.Demo.GraphDrawing
{
    public enum NodeShape
    {
        Rectangle,
        Circle,
    }

    public enum NodeBorderType
    {
        None,
        Single,
        Double,
    }

    public class Node
    {
        public PointF Position { get; set; }

        public RectangleF Box { get; set; }

        public NodeShape Shape { get; set; }

        public string LabelText { get; set; }

        public PointF LabelOffset { get; set; }

        public Font LabelFont { get; set; }

        public Brush BackBrush { get; set; }

        public Brush LabelBrush { get; set; }

        public NodeBorderType BorderType { get; set; }

        public Pen BorderPen { get; set; }
    }
}
