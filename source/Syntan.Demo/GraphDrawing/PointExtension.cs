using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Syntan.Demo.GraphDrawing
{
    public static class PointExtension
    {
        public static float Length( this PointF p )
        {
            return (float)Math.Sqrt(Math.Pow(p.X, 2) + Math.Pow(p.Y, 2));
        }

        public static PointF Norm( this PointF p )
        {
            float l = p.Length();
            if( l == 0 )
                return PointF.Empty;

            return new PointF(p.X / l, p.Y / l);
        }

        public static PointF Multiply( this PointF p, float scalar )
        {
            return new PointF(scalar * p.X, scalar * p.Y);
        }
        
        public static PointF Multiply( this PointF p, double scalar )
        {
            return p.Multiply((float)scalar);
        }

        public static PointF Add( this PointF p, PointF other )
        {
            return new PointF(p.X + other.X, p.Y + other.Y);
        }

        public static PointF Substract( this PointF p, PointF other )
        {
            return new PointF(p.X - other.X, p.Y - other.Y);
        }
    }
}
