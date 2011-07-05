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
    public partial class SyntcticTreeView : UserControl
    {
        #region Constructors

        public SyntcticTreeView()
        {
            InitializeComponent();

            this.top_level_nodes = new List<SyntacticTreeViewNode>();
            this.TopLevelNodes = this.top_level_nodes.AsReadOnly();
            this.node_map = new Dictionary<SyntacticTreeViewNode, Node>();
            this.style_map = new Dictionary<SyntacticTreeViewNode, NodeStyle>();

            this.top_level_node_style = new NodeStyle()
            {
                BackBrush = new SolidBrush(Color.White),
                LabelBrush = new SolidBrush(Color.Black),
                BorderPen = new Pen(new SolidBrush(Color.Black), 1),
            };

            this.internal_node_style = new NodeStyle()
            {
                BackBrush = new SolidBrush(Color.WhiteSmoke),
                LabelBrush = new SolidBrush(Color.DarkGray),
                BorderPen = new Pen(new SolidBrush(Color.DarkGray), 1),
            };

            this.leaf_node_style = new NodeStyle()
            {
                BackBrush = new SolidBrush(Color.White),
                LabelBrush = new SolidBrush(Color.Black),
                BorderPen = new Pen(new SolidBrush(Color.Black), 1),
            };
        }

        #endregion

        #region Appearance

        private class NodeStyle : IDisposable
        {
            public SolidBrush BackBrush { get; set; }
            public SolidBrush LabelBrush { get; set; }
            public Pen BorderPen { get; set; }

            public void Dispose()
            {
                if( this.BackBrush != null )
                {
                    this.BackBrush.Dispose();
                    this.BackBrush = null;
                }

                if( this.LabelBrush != null )
                {
                    this.LabelBrush.Dispose();
                    this.LabelBrush = null;
                }

                if( this.BorderPen != null )
                {
                    this.BorderPen.Dispose();
                    this.BorderPen = null;
                }
            }
        };

        private Pen edge_pen = new Pen(new SolidBrush(Color.Silver), 3);

        private NodeStyle top_level_node_style;
        private NodeStyle internal_node_style;
        private NodeStyle leaf_node_style;

        private int label_margin = 5;
        private int horizontal_space = 10;
        private int vertical_space = 20;

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
        [DefaultValue(3)]
        public float EdgeWidth
        {
            get { return this.edge_pen.Width; }
            set
            {
                if( this.edge_pen.Width != value )
                {
                    this.edge_pen.Width = value;

                    this.FlagUpdate(false);
                }
            }
        }

        [Category("Appearance")]
        public Color TopLevelNodeBackColor
        {
            get { return this.top_level_node_style.BackBrush.Color; }
            set
            {
                if( this.top_level_node_style.BackBrush.Color != value )
                {
                    this.top_level_node_style.BackBrush.Color = value;
                    this.FlagUpdate(false);
                }
            }
        }

        [Category("Appearance")]
        public Color TopLevelNodeForeColor
        {
            get { return this.top_level_node_style.LabelBrush.Color; }
            set
            {
                if( this.top_level_node_style.LabelBrush.Color != value )
                {
                    this.top_level_node_style.LabelBrush.Color = value;
                    this.top_level_node_style.BorderPen.Color = value;
                    this.FlagUpdate(false);
                }
            }
        }

        [Category("Appearance")]
        public Color InternalNodeBackColor
        {
            get { return this.internal_node_style.BackBrush.Color; }
            set
            {
                if( this.internal_node_style.BackBrush.Color != value )
                {
                    this.internal_node_style.BackBrush.Color = value;

                    this.FlagUpdate(false);
                }
            }
        }

        [Category("Appearance")]
        public Color InternalNodeForeColor
        {
            get { return this.internal_node_style.LabelBrush.Color; }
            set
            {
                if( this.internal_node_style.LabelBrush.Color != value )
                {
                    this.internal_node_style.LabelBrush.Color = value;
                    this.internal_node_style.BorderPen.Color = value;

                    this.FlagUpdate(false);
                }
            }
        }

        [Category("Appearance")]
        public Color LeafNodeBackColor
        {
            get { return this.leaf_node_style.BackBrush.Color; }
            set
            {
                if( this.leaf_node_style.BackBrush.Color != value )
                {
                    this.leaf_node_style.BackBrush.Color = value;

                    this.FlagUpdate(false);
                }
            }
        }

        [Category("Appearance")]
        public Color LeafNodeForeColor
        {
            get { return this.leaf_node_style.LabelBrush.Color; }
            set
            {
                if( this.leaf_node_style.LabelBrush.Color != value )
                {
                    this.leaf_node_style.LabelBrush.Color = value;
                    this.leaf_node_style.BorderPen.Color = value;

                    this.FlagUpdate(false);
                }
            }
        }

        [Category("Appearance")]
        [DefaultValue(5)]
        public int LabelMargin
        {
            get { return this.label_margin; }
            set
            {
                if( this.label_margin != value )
                {
                    if( value < 0 )
                        throw new ArgumentOutOfRangeException("LabelMargin must not be negative.");

                    this.label_margin = value;

                    this.FlagUpdate(true);
                }
            }
        }

        [Category("Appearance")]
        [DefaultValue(10)]
        public int VerticalSpace
        {
            get { return this.vertical_space; }
            set
            {
                if( this.vertical_space != value )
                {
                    if( value < 0 )
                        throw new ArgumentOutOfRangeException("VerticalSpace must not be negative.");

                    this.vertical_space = value;

                    this.FlagUpdate(true);
                }
            }
        }

        [Category("Appearance")]
        [DefaultValue(20)]
        public int HorizontalSpace
        {
            get { return this.horizontal_space; }
            set
            {
                if( this.horizontal_space != value )
                {
                    if( value < 0 )
                        throw new ArgumentOutOfRangeException("LabelMargin must not be negative.");

                    this.horizontal_space = value;

                    this.FlagUpdate(true);
                }
            }
        }

        #endregion

        #region SyntacticTree

        private List<SyntacticTreeViewNode> top_level_nodes;
        private Dictionary<SyntacticTreeViewNode, Node> node_map;

        private int updating = 0;
        private bool graph_geometry_changed;

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public IList<SyntacticTreeViewNode> TopLevelNodes { get; private set; }

        public void BeginUpdate()
        {
            if( this.updating == 0 )
                this.graph_geometry_changed = false;
            this.updating += 1;
        }

        public void EndUpdate()
        {
            if( this.updating > 0 )
            {
                this.updating -= 1;
                if( this.updating == 0 )
                {
                    if( this.graph_geometry_changed )
                        this.UpdateGraphLayout();
                    this.UpdateNodeStyle();
                    this.Graph.UpdateGraph(this.graph_geometry_changed);
                }
            }
        }

        private void FlagUpdate( bool graph_geometry_changed )
        {
            if( this.updating == 0 )
            {
                if( this.graph_geometry_changed )
                    this.UpdateGraphLayout();
                this.UpdateNodeStyle();
                this.Graph.UpdateGraph(this.graph_geometry_changed);
            }
            else if( graph_geometry_changed )
            {
                this.graph_geometry_changed = true;
            }
        }

        public void ClearNodes()
        {
            this.top_level_nodes.Clear();
            this.node_map.Clear();
            this.style_map.Clear();

            this.Graph.Nodes.Clear();
            this.Graph.Edges.Clear();

            this.FlagUpdate(true);
        }

        public void AddTopLevelNode( string symbol_name, int child_count )
        {
            int tln_count = this.top_level_nodes.Count;
            if( child_count > tln_count )
                throw new ArgumentOutOfRangeException(string.Format(
                    "Insufficient top level nodes ({0}) to match child count ({1}).",
                    tln_count, child_count));


            var new_node = new SyntacticTreeViewNode(symbol_name);
            for( int i = 0; i < child_count; ++i )
                new_node.AddChild(this.top_level_nodes[tln_count - child_count + i]);
            for( int i = 0; i < child_count; ++i )
                this.top_level_nodes.RemoveAt(this.top_level_nodes.Count - 1);
            this.top_level_nodes.Add(new_node);

            // Update graph
            var new_layout_node = new Node()
            {
                Shape = NodeShape.Rectangle,
                BorderType = NodeBorderType.Single,
                LabelText = new_node.Name,
                LabelFont = this.Font,
            };
            this.node_map.Add(new_node, new_layout_node);
            this.Graph.Nodes.Add(new_layout_node);

            for( int i = 0; i < child_count; ++i )
                this.Graph.Edges.Add(new Edge()
                    {
                        StartNode = new_layout_node,
                        EndNode = this.node_map[new_node.Children[i]],
                        LinePen = this.edge_pen,
                    });

            this.FlagUpdate(true);
        }

        private void UpdateBoundingBoxRecursively( SyntacticTreeViewNode node )
        {
            var label_size = this.Graph.MeasureString(this.Font, node.Name);
            var node_box = new RectangleF(
                -this.label_margin - label_size.Width / 2,
                -this.label_margin - label_size.Height / 2,
                2 * this.label_margin + label_size.Width,
                2 * this.label_margin + label_size.Height);
            node.NodeBox = node_box;
            node.NodeBBox = new RectangleF(
                node_box.X - this.horizontal_space,
                node_box.Y - this.vertical_space,
                node_box.Width + 2 * this.horizontal_space,
                node_box.Height + 2 * this.vertical_space);

            if( node.Children.Count > 0 )
            {
                for( int i = 0; i < node.Children.Count; ++i )
                    this.UpdateBoundingBoxRecursively(node.Children[i]);

                if( node.Children.Count == 1 )
                {
                    var child_bbox = node.Children[0].SubtreeBBox;
                    float left = Math.Min(node.NodeBBox.Left, child_bbox.Left);
                    float right = Math.Max(node.NodeBBox.Right, child_bbox.Right);

                    node.SubtreeBBox = new RectangleF(
                        left,
                        node.NodeBBox.Top,
                        right - left,
                        node.NodeBBox.Height + child_bbox.Height);

                    node.Children[0].OffsetFromParent = new PointF(0, node.NodeBBox.Bottom - child_bbox.Top);
                }
                else
                {
                    float children_width = 0;
                    for( int i = 0; i < node.Children.Count; ++i )
                        children_width += node.Children[i].SubtreeBBox.Width;

                    float horizontal_center = children_width + node.Children[0].SubtreeBBox.Left
                        - node.Children[node.Children.Count - 1].SubtreeBBox.Right;
                    horizontal_center /= 2;

                    float child_offs = -horizontal_center + node.Children[0].SubtreeBBox.Left;
                    float top = 0;
                    float bottom = 0;
                    for( int i = 0; i < node.Children.Count; ++i )
                    {
                        // Set child's offset
                        var child_bbox = node.Children[i].SubtreeBBox;
                        node.Children[i].OffsetFromParent = new PointF(child_offs - child_bbox.Left,
                            node.NodeBBox.Bottom - child_bbox.Top);
                        child_offs += child_bbox.Width;

                        // Find the most top and most bottom bbox values.
                        if( top > child_bbox.Top )
                            top = child_bbox.Top;
                        if( bottom < child_bbox.Bottom )
                            bottom = child_bbox.Bottom;
                    }

                    float left = Math.Min(node.NodeBBox.Left, node.Children[0].OffsetFromParent.X
                        + node.Children[0].SubtreeBBox.Left);
                    float right = Math.Max(node.NodeBBox.Right,
                        node.Children[node.Children.Count - 1].OffsetFromParent.X +
                        node.Children[node.Children.Count - 1].SubtreeBBox.Right);

                    node.SubtreeBBox = new RectangleF(
                        left,
                        node.NodeBBox.Top,
                        right - left,
                        node.NodeBBox.Height + bottom - top);
                }
            }
            else
            {
                node.SubtreeBBox = node.NodeBBox;
            }
        }

        private void LayoutChildrenRecursively( SyntacticTreeViewNode parent )
        {
            var parent_layout = this.node_map[parent];
            for( int i = 0; i < parent.Children.Count; ++i )
            {
                var node = parent.Children[i];
                var layout_node = this.node_map[node];

                // Layout the child
                layout_node.Position = new PointF(
                    parent_layout.Position.X + node.OffsetFromParent.X,
                    parent_layout.Position.Y + node.OffsetFromParent.Y);
                layout_node.Box = node.NodeBox;
                layout_node.LabelOffset = new PointF(
                    node.NodeBox.Left + this.label_margin,
                    node.NodeBox.Top + this.label_margin);

                // Layout the child's children
                this.LayoutChildrenRecursively(node);
            }

            // Layout edges
            foreach( var edge in this.Graph.OutEdgesOf(parent_layout) )
            {
                edge.StartPosition = edge.StartNode.Position;
                edge.EndPosition = edge.EndNode.Position;
            }
        }

        private void UpdateNodeStyle()
        {
            for( int i = 0; i < this.top_level_nodes.Count; ++i )
                this.UpdateNodeStyleRecursively(this.top_level_nodes[i]);
        }

        private void UpdateNodeStyleRecursively( SyntacticTreeViewNode node )
        {
            NodeStyle base_style;
            if( node.Parent == null )
                base_style = this.top_level_node_style;
            else if( node.Children.Count == 0 )
                base_style = this.leaf_node_style;
            else
                base_style = this.internal_node_style;

            NodeStyle custom_style = null;
            this.style_map.TryGetValue(node, out custom_style);

            var layout_node = this.node_map[node];
            layout_node.BackBrush = custom_style != null ? (custom_style.BackBrush ?? base_style.BackBrush) : base_style.BackBrush;
            layout_node.LabelBrush = custom_style != null ? (custom_style.LabelBrush ?? base_style.LabelBrush) : base_style.LabelBrush;
            layout_node.BorderPen = custom_style != null ? (custom_style.BorderPen ?? base_style.BorderPen) : base_style.BorderPen;

            for( int i = 0; i < node.Children.Count; ++i )
                this.UpdateNodeStyleRecursively(node.Children[i]);
        }

        private void UpdateGraphLayout()
        {
            float left = 0;
            for( int i = 0; i < this.top_level_nodes.Count; ++i )
            {
                var node = this.top_level_nodes[i];
                var layout_node = this.node_map[node];

                this.UpdateBoundingBoxRecursively(node);

                layout_node.Position = new PointF(
                    left - node.SubtreeBBox.Left,
                    -node.SubtreeBBox.Top);
                layout_node.LabelOffset = new PointF(
                    node.NodeBox.Left + this.label_margin,
                    node.NodeBox.Top + this.label_margin);
                layout_node.Box = node.NodeBox;

                this.LayoutChildrenRecursively(node);

                left += node.SubtreeBBox.Width;
            }
        }

        #endregion

        #region Marking

        private Dictionary<SyntacticTreeViewNode, NodeStyle> style_map;

        public void ClearMarks()
        {
            if( this.style_map.Count == 0 )
                return;

            foreach( var ns in this.style_map.Values )
                ns.Dispose();
            this.style_map.Clear();
            this.UpdateNodeStyle();

            this.FlagUpdate(false);
        }

        public void MarkNode( SyntacticTreeViewNode node, Color back_color )
        {
            if( node == null )
                throw new ArgumentNullException("node");

            var layout_node = this.node_map[node];
            NodeStyle custom_style;
            if( this.style_map.TryGetValue(node, out custom_style) )
            {
                if( custom_style.BorderPen != null )
                {
                    custom_style.BorderPen.Dispose();
                    custom_style.BorderPen = null;
                }

                if( custom_style.LabelBrush != null )
                {
                    custom_style.LabelBrush.Dispose();
                    custom_style.LabelBrush = null;
                }
            }
            else
            {
                custom_style = new NodeStyle();
                this.style_map.Add(node, custom_style);
            }

            if( custom_style.BackBrush == null )
                custom_style.BackBrush = new SolidBrush(back_color);
            else
                custom_style.BackBrush.Color = back_color;

            this.FlagUpdate(false);
        }

        public void FocusMarkedItems()
        {
            if( this.style_map.Count == 0 )
                return;

            var bboxes = new List<RectangleF>(this.style_map.Count);
            foreach( var node in this.style_map.Keys )
                bboxes.Add(this.Graph.BoundingBoxOf(this.node_map[node]));

            this.Graph.ZoomToFit(RectangleExtensions.BoundingBox(bboxes).AddPadding(10, 10, 10, 10));
        }

        #endregion
    }
}
