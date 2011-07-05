using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Syntan.Demo.GraphDrawing;

namespace Syntan.Demo
{
    public partial class DfsmView : UserControl
    {
        #region Construcors

        public DfsmView()
        {
            InitializeComponent();

            this.node_map = new Dictionary<int, Node>();
            this.in_edge_map = new Dictionary<int, Dictionary<SyntacticAnalysis.Symbol, Edge>>();
            this.out_edge_map = new Dictionary<int, Dictionary<SyntacticAnalysis.Symbol, Edge>>();

            this.edge_pen = new Pen(new SolidBrush(Color.Silver), 5);
            this.edge_pen.EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;
            this.back_brush = new SolidBrush(Color.White);
            this.label_brush = new SolidBrush(Color.Black);
            this.border_pen = new Pen(new SolidBrush(Color.Black), 1);

            this.marked_nodes = new HashSet<Node>();
            this.marked_edges = new HashSet<Edge>();
        }

        #endregion

        #region Private fields

        private SyntacticAnalysis.Grammar grammar;
        private SyntacticAnalysis.LR.LR0CanonicalSets canonical_sets;
        private Dictionary<int, Node> node_map;
        private Dictionary<int, Dictionary<SyntacticAnalysis.Symbol, Edge>> in_edge_map;
        private Dictionary<int, Dictionary<SyntacticAnalysis.Symbol, Edge>> out_edge_map;

        private int updating = 0;
        private bool graph_geometry_changed;

        #endregion

        #region Appearance

        private float node_radius = 20;
        private float node_diameter = 40;
        private Pen edge_pen;
        private SolidBrush back_brush;
        private SolidBrush label_brush;
        private Pen border_pen;

        [Category("Appearance")]
        [DefaultValue(20f)]
        public float NodeRadius
        {
            get { return this.node_radius; }
            set
            {
                if( this.node_radius != value )
                {
                    if( value <= 0 )
                        throw new ArgumentOutOfRangeException("NodeRadius", "NodeRadius must be positive.");

                    this.node_radius = value;

                    this.FlagUpdate(true);
                }
            }
        }

        [Category("Appearance")]
        [DefaultValue(3f)]
        public float EdgeWidth
        {
            get { return this.edge_pen.Width; }
            set
            {
                if( this.edge_pen.Width != value )
                {
                    if( value < 0 )
                        throw new ArgumentOutOfRangeException("EdgeWidth");

                    this.edge_pen.Width = value;

                    this.FlagUpdate(false);
                }
            }
        }

        [Category("Appearance")]
        public Color EdgeColor
        {
            get { return this.edge_pen.Color; }
            set
            {
                if( this.edge_pen.Color != value )
                {
                    this.edge_pen.Color = value;

                    this.FlagUpdate(false);
                }
            }
        }

        [Category("Appearance")]
        public Color NodeBackColor
        {
            get { return this.back_brush.Color; }
            set
            {
                if( this.back_brush.Color != value )
                {
                    this.back_brush.Color = value;

                    this.FlagUpdate(false);
                }
            }
        }

        [Category("Appearance")]
        public Color LabelColor
        {
            get { return this.label_brush.Color; }
            set
            {
                if( this.label_brush.Color != value )
                {
                    this.label_brush.Color = value;

                    this.FlagUpdate(false);
                }
            }
        }

        #endregion

        #region Dfsm

        [DefaultValue(null)]
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public SyntacticAnalysis.Grammar Grammar
        {
            get { return this.grammar; }
        }

        [DefaultValue(null)]
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public SyntacticAnalysis.LR.LR0CanonicalSets CanonicalSets
        {
            get { return this.canonical_sets; }
        }

        public void SetCanonicalSets( SyntacticAnalysis.Grammar grammar, SyntacticAnalysis.LR.LR0CanonicalSets canonical_sets )
        {
            this.grammar = grammar;
            this.canonical_sets = canonical_sets;

            this.marked_nodes.Clear();
            this.marked_edges.Clear();

            this.RebuildGraph();
            this.FlagUpdate(true);
        }

        public void BeginUpdate()
        {
            this.graph_geometry_changed = false;
            this.updating += 1;
        }

        public void EndUpdate()
        {
            if( this.updating > 0 )
            {
                this.updating -= 1;
                if( this.updating == 0 )
                    this.Graph.UpdateGraph(this.graph_geometry_changed);
            }
        }

        private void FlagUpdate( bool graph_geometry_changed )
        {
            if( this.updating == 0 )
                this.Graph.UpdateGraph(graph_geometry_changed);
            else if( graph_geometry_changed )
                this.graph_geometry_changed = true;
        }

        private void RebuildGraph()
        {
            // Clear prev Graph
            this.node_map.Clear();
            this.in_edge_map.Clear();
            this.out_edge_map.Clear();
            this.Graph.Nodes.Clear();
            this.Graph.Edges.Clear();

            // Build new Graph
            if( this.grammar == null || this.canonical_sets == null )
                return;

            // Make the layout with the Glee lib
            var layout_g = new Microsoft.Glee.Drawing.Graph("Fdsm");
            layout_g.Directed = true;
            var layout_nodes = new Dictionary<Node, Microsoft.Glee.Drawing.Node>();
            var layout_edges = new Dictionary<Edge, Microsoft.Glee.Drawing.Edge>();

            // Create nodes
            for( int state_index = 0; state_index < this.canonical_sets.Sets.Count; ++state_index )
            {
                var node = new Node();
                node.Shape = NodeShape.Circle;
                node.Box = new RectangleF(this.node_diameter / -2, this.node_diameter / -2, this.node_diameter, this.node_diameter);
                node.BorderType = (this.canonical_sets.Sets[state_index].FirstOrDefault(
                    item => item.CursorPosition == item.Rule.RightHandSide.Count) == null)
                        ? NodeBorderType.Single
                        : NodeBorderType.Double;
                node.LabelText = state_index.ToString();
                node.LabelFont = this.Font;
                var label_size = this.Graph.MeasureString(this.Font, node.LabelText);
                node.LabelOffset = new PointF(label_size.Width / -2, label_size.Height / -2);
                node.BorderPen = this.border_pen;
                node.BackBrush = this.back_brush;
                node.LabelBrush = this.label_brush;

                this.Graph.Nodes.Add(node);
                this.node_map.Add(state_index, node);
                this.in_edge_map.Add(state_index, new Dictionary<SyntacticAnalysis.Symbol, Edge>());
                this.out_edge_map.Add(state_index, new Dictionary<SyntacticAnalysis.Symbol, Edge>());

                // Layout
                var layout_node = layout_g.AddNode(node.LabelText);
                layout_node.Attr.LabelMargin = 6;
                layout_nodes.Add(node, layout_node);
            }

            // Create edges
            for( int state_index = 0; state_index < this.canonical_sets.Sets.Count; ++state_index )
            {
                // Terminals
                foreach( var symbol in this.grammar.Terminals )
                {
                    int transition_to = this.canonical_sets.GetTransition(state_index, symbol);
                    if( transition_to != -1 )
                    {
                        var edge = new Edge();
                        edge.StartNode = this.node_map[state_index];
                        edge.EndNode = this.node_map[transition_to];
                        edge.LabelText = symbol.Name;
                        edge.LabelFont = this.Font;
                        edge.LabelBrush = this.label_brush;
                        edge.LinePen = this.edge_pen;

                        this.Graph.Edges.Add(edge);
                        this.out_edge_map[state_index][symbol] = edge;
                        this.in_edge_map[transition_to][symbol] = edge;

                        // Layout
                        var layout_edge = layout_g.AddEdge(edge.StartNode.LabelText, edge.EndNode.LabelText);
                        layout_edge.Attr.Label = edge.LabelText;
                        layout_edges.Add(edge, layout_edge);
                    }
                }

                // Grammaticals
                foreach( var symbol in this.grammar.Grammaticals )
                {
                    int transition_to = this.canonical_sets.GetTransition(state_index, symbol);
                    if( transition_to != -1 )
                    {
                        var edge = new Edge();
                        edge.StartNode = this.node_map[state_index];
                        edge.EndNode = this.node_map[transition_to];
                        edge.LabelText = symbol.Name;
                        edge.LabelFont = this.Font;
                        edge.LabelBrush = this.label_brush;
                        edge.LinePen = this.edge_pen;

                        this.Graph.Edges.Add(edge);
                        this.out_edge_map[state_index][symbol] = edge;
                        this.in_edge_map[transition_to][symbol] = edge;

                        // Layout
                        var layout_edge = layout_g.AddEdge(edge.StartNode.LabelText, edge.EndNode.LabelText);
                        layout_edge.Attr.Label = edge.LabelText;
                        layout_edges.Add(edge, layout_edge);
                    }
                }
            }


            // Let Glee calculate a layout
            var layout_rnd = new Microsoft.Glee.GraphViewerGdi.GraphRenderer(layout_g);
            layout_rnd.CalculateLayout();

            // Extract and replicate layout
            // Nodes
            foreach( var kv in layout_nodes )
                kv.Key.Position = this.FromGleePoint(kv.Value.Attr.Pos);

            // Edges
            foreach( var kv in layout_edges )
            {
                var edge = kv.Key;
                var layout_edge = kv.Value;

                var curve = layout_edge.Attr.EdgeCurve as Microsoft.Glee.Splines.Curve;
                if( curve != null )
                {
                    var segments = new List<CurveSegment>();

                    foreach( Microsoft.Glee.Splines.ICurve segment in curve.Segs )
                    {
                        if( segment is Microsoft.Glee.Splines.CubicBezierSeg )
                        {
                            var b = (Microsoft.Glee.Splines.CubicBezierSeg)segment;

                            segments.Add(new CurveSegment(new PointF[]
                                {
                                    this.FromGleePoint(b.B(0)),
                                    this.FromGleePoint(b.B(1)),
                                    this.FromGleePoint(b.B(2)),
                                    this.FromGleePoint(b.B(3)),
                                }));
                        }
                        else // Fallback to linearity, even if it is not a LineSeg.
                        {
                            segments.Add(new CurveSegment(new PointF[]
                                {
                                    this.FromGleePoint(segment.Start),
                                    this.FromGleePoint(segment.End),
                                }));
                        }
                    }

                    // Snap edge ends to nodes
                    var e = new PointF(
                        edge.StartNode.Position.X - segments[0].Points[0].X,
                        edge.StartNode.Position.Y - segments[0].Points[0].Y);
                    var diff = e.Norm().Multiply(e.Length() - this.node_radius);
                    edge.StartPosition = segments[0].Points[0] = segments[0].Points[0].Add(diff);

                    var seg = segments[segments.Count - 1];
                    e = new PointF(
                        edge.EndNode.Position.X - seg.Points[seg.Points.Length - 1].X,
                        edge.EndNode.Position.Y - seg.Points[seg.Points.Length - 1].Y);
                    diff = e.Norm().Multiply(e.Length() - this.node_radius);
                    edge.EndPosition = seg.Points[seg.Points.Length - 1] =
                        seg.Points[seg.Points.Length - 1].Add(diff);


                    edge.Segments = segments.ToArray();
                }
                else
                {
                    // Fallback to line
                    edge.StartPosition = edge.StartNode.Position;
                    edge.EndPosition = edge.EndNode.Position;

                    // Snap edge ends to nodes
                    var e = new PointF(
                        edge.EndPosition.X - edge.StartPosition.X,
                        edge.EndPosition.Y - edge.StartPosition.Y)
                        .Norm().Multiply(this.node_radius);

                    edge.StartPosition = edge.StartPosition.Add(e);
                    edge.EndPosition = edge.EndPosition.Substract(e);
                }

                // Label
                edge.LabelPosition = new PointF(
                    (float)layout_edge.Attr.LabelLeft,
                    (float)layout_edge.Attr.LabelTop);
            }

            // Add an 'in-edge' to the start state node
            var start_edge = new Edge();
            start_edge.LinePen = this.edge_pen;
            start_edge.EndNode = this.node_map[0];
            start_edge.EndPosition = new PointF(
                start_edge.EndNode.Position.X,
                start_edge.EndNode.Position.Y + this.node_radius);
            start_edge.StartPosition = new PointF(
                start_edge.EndPosition.X,
                start_edge.EndPosition.Y + this.node_diameter);

            this.Graph.Edges.Add(start_edge);
        }

        private PointF FromGleePoint( Microsoft.Glee.Splines.Point p )
        {
            return new PointF((float)p.X, (float)p.Y);
        }

        #endregion

        #region State and Transition marks

        private HashSet<Node> marked_nodes;
        private HashSet<Edge> marked_edges;

        public void ClearStateMarks()
        {
            if( this.marked_nodes.Count == 0 )
                return;

            foreach( var node in this.marked_nodes )
                if( node.BackBrush != this.back_brush )
                {
                    node.BackBrush.Dispose();
                    node.BackBrush = this.back_brush;
                }

            this.marked_nodes.Clear();
            this.FlagUpdate(false);
        }

        public void MarkState( int state_index, Color color )
        {
            var node = this.node_map[state_index];
            if( node.BackBrush == this.back_brush )
                node.BackBrush = new SolidBrush(color);
            else
                ((SolidBrush)node.BackBrush).Color = color;

            this.marked_nodes.Add(node);
            this.FlagUpdate(false);
        }

        public void MarkTransition( int state_index, SyntacticAnalysis.Symbol symbol, Color line_color, Color label_color )
        {
            var edge = this.out_edge_map[state_index][symbol];

            if( edge.LinePen == this.edge_pen )
            {
                edge.LinePen = (Pen)this.edge_pen.Clone();
                edge.LinePen.Color = line_color;
            }
            else
            {
                edge.LinePen.Color = line_color;
            }

            if( edge.LabelBrush == this.label_brush )
                edge.LabelBrush = new SolidBrush(label_color);
            else
                ((SolidBrush)edge.LabelBrush).Color = label_color;

            this.marked_edges.Add(edge);
            this.FlagUpdate(false);
        }

        public void ClearTransitionMarks()
        {
            if( this.marked_edges.Count == 0 )
                return;

            foreach( var edge in this.marked_edges )
            {
                if( edge.LinePen != this.edge_pen )
                {
                    edge.LinePen.Dispose();
                    edge.LinePen = this.edge_pen;
                }

                if( edge.LabelBrush != this.label_brush )
                {
                    edge.LabelBrush.Dispose();
                    edge.LabelBrush = this.label_brush;
                }
            }

            this.marked_edges.Clear();
            this.FlagUpdate(false);
        }

        public void FocusMarkedItems()
        {
            if( this.marked_nodes.Count == 0 && this.marked_edges.Count == 0 )
                return;

            var bboxes = new List<RectangleF>(this.marked_nodes.Count + this.marked_edges.Count);
            foreach( var node in this.marked_nodes )
                bboxes.Add(this.Graph.BoundingBoxOf(node));
            foreach( var edge in this.marked_edges )
                bboxes.Add(this.Graph.BoundingBoxOf(edge));

            this.Graph.ZoomToFit(RectangleExtensions.BoundingBox(bboxes).AddPadding(30, 30, 10, 10));
        }

        #endregion
    }
}
