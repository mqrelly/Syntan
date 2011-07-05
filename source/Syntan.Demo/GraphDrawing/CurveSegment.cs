using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Syntan.Demo.GraphDrawing
{
    public class CurveSegment
    {
        public CurveSegment( PointF[] points )
        {
            if( points == null )
                throw new ArgumentNullException("points");

            this.Points = points;
        }

        public bool IsLinear
        {
            get { return this.Points.Length == 2; }
        }

        public PointF[] Points { get; private set; }
    }
}
