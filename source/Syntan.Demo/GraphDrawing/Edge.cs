using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Syntan.Demo.GraphDrawing
{
    public class Edge
    {
        public Node StartNode { get; set; }

        public Node EndNode { get; set; }

        public PointF StartPosition { get; set; }

        public PointF EndPosition { get; set; }

        public Pen LinePen { get; set; }

        public CurveSegment[] Segments;

        public string LabelText { get; set; }

        public PointF LabelPosition { get; set; }

        public Font LabelFont { get; set; }

        public Brush LabelBrush { get; set; }

        public bool IsComplex
        {
            get { return this.Segments != null; }
        }
    }
}
