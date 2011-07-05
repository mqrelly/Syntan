using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Syntan.Demo.GraphDrawing
{
    public static class GraphRenderer
    {
        public static void DrawNode( Graphics g, Node node )
        {
            if( node.Shape == NodeShape.Rectangle )
            {
                // Background
                g.FillRectangle(node.BackBrush,
                    node.Position.X + node.Box.X, node.Position.Y + node.Box.Y,
                    node.Box.Width, node.Box.Height);

                // Border
                if( node.BorderType == NodeBorderType.Single )
                {
                    g.DrawRectangle(node.BorderPen,
                        node.Position.X + node.Box.X, node.Position.Y + node.Box.Y,
                        node.Box.Width, node.Box.Height);
                }
                else if( node.BorderType == NodeBorderType.Double )
                {
                    g.DrawRectangle(node.BorderPen,
                        node.Position.X + node.Box.X, node.Position.Y + node.Box.Y,
                        node.Box.Width, node.Box.Height);

                    float diff = node.BorderPen.Width * 2;
                    g.DrawRectangle(node.BorderPen,
                        node.Position.X + node.Box.X + diff, node.Position.Y + node.Box.Y + diff,
                        node.Box.Width - 2 * diff, node.Box.Height - 2 * diff);
                }
            }
            else
            {
                // Background
                g.FillEllipse(node.BackBrush,
                    node.Position.X + node.Box.X, node.Position.Y + node.Box.Y,
                    node.Box.Width, node.Box.Height);

                // Border
                if( node.BorderType == NodeBorderType.Single )
                {
                    g.DrawEllipse(node.BorderPen,
                        node.Position.X + node.Box.X, node.Position.Y + node.Box.Y,
                        node.Box.Width, node.Box.Height);
                }
                else if( node.BorderType == NodeBorderType.Double )
                {
                    g.DrawEllipse(node.BorderPen,
                        node.Position.X + node.Box.X, node.Position.Y + node.Box.Y,
                        node.Box.Width, node.Box.Height);

                    float diff = node.BorderPen.Width * 2;
                    g.DrawEllipse(node.BorderPen,
                         node.Position.X + node.Box.X + diff, node.Position.Y + node.Box.Y + diff,
                        node.Box.Width - 2 * diff, node.Box.Height - 2 * diff);
                }
            }

            // Label
            if( node.LabelText != null )
                g.DrawString(node.LabelText, node.LabelFont, node.LabelBrush,
                    node.Position.X + node.LabelOffset.X, node.Position.Y + node.LabelOffset.Y);
        }

        public static void DrawEdge( Graphics g, Edge edge )
        {
            // Line
            if( edge.IsComplex )
            {
                var old_end_cap = edge.LinePen.EndCap;
                edge.LinePen.EndCap = System.Drawing.Drawing2D.LineCap.Round;

                for( int seg_ind = 0; seg_ind < edge.Segments.Length - 1; ++seg_ind )
                {
                    var segment = edge.Segments[seg_ind];
                    if( segment.IsLinear )
                        g.DrawLine(edge.LinePen, segment.Points[0], segment.Points[1]);
                    else
                        g.DrawBezier(edge.LinePen, segment.Points[0], segment.Points[1], segment.Points[2], segment.Points[3]);
                }

                edge.LinePen.EndCap = old_end_cap;

                var last_segment = edge.Segments[edge.Segments.Length - 1];
                if( last_segment.IsLinear )
                    g.DrawLine(edge.LinePen, last_segment.Points[0], last_segment.Points[1]);
                else
                    g.DrawBezier(edge.LinePen, last_segment.Points[0], last_segment.Points[1], last_segment.Points[2], last_segment.Points[3]);
            }
            else
            {
                g.DrawLine(edge.LinePen, edge.StartPosition, edge.EndPosition);
            }

            // Label
            if( edge.LabelText != null )
                g.DrawString(edge.LabelText, edge.LabelFont, edge.LabelBrush,
                    edge.LabelPosition.X, edge.LabelPosition.Y);
        }
    }
}
