using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Syntan.Demo.GraphDrawing
{
    public static class RectangleExtensions
    {
        public static RectangleF BoundingBox( IEnumerable<RectangleF> rectangles )
        {
            float left = float.MaxValue;
            float top = float.MaxValue;
            float right = float.MinValue;
            float bottom = float.MinValue;

            foreach( var r in rectangles )
            {
                if( left > r.Left )
                    left = r.Left;
                if( right < r.Right )
                    right = r.Right;
                if( top > r.Top )
                    top = r.Top;
                if( bottom < r.Bottom )
                    bottom = r.Bottom;
            }

            return new RectangleF(left, top, right - left, bottom - top);
        }

        public static RectangleF AddPadding( this RectangleF r, float left, float right, float top, float bottom )
        {
            return new RectangleF(
                r.Left - left, 
                r.Top - top, 
                r.Width + left + right, 
                r.Height + top + bottom);
        }

        public static RectangleF AddPadding( this RectangleF r, System.Windows.Forms.Padding padding )
        {
            return new RectangleF(
                r.Left - padding.Left,
                r.Top - padding.Top,
                r.Width + padding.Horizontal,
                r.Height + padding.Vertical);
        }
    }
}
