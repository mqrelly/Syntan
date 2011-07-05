using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Syntan.Demo.GraphDrawing
{
    public partial class GraphView : UserControl
    {
        #region Constructors

        public GraphView()
        {
            InitializeComponent();

            this.nodes = new List<Node>();
            this.edges = new List<Edge>();

            this.PageColor = Color.White;

            this.buff_img = new Bitmap(1, 1, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            this.buff_g = Graphics.FromImage(this.buff_img);

            this.UpdateZoomControls();
        }

        #endregion

        #region Graph

        private List<Node> nodes;
        private List<Edge> edges;

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public IList<Node> Nodes
        {
            get { return this.nodes; }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public IList<Edge> Edges
        {
            get { return this.edges; }
        }

        public IEnumerable<Edge> OutEdgesOf( Node start_node )
        {
            for( int i = 0; i < this.edges.Count; ++i )
                if( this.edges[i].StartNode == start_node )
                    yield return this.edges[i];
        }

        public IEnumerable<Edge> InEdgesOf( Node end_node )
        {
            for( int i = 0; i < this.edges.Count; ++i )
                if( this.edges[i].EndNode == end_node )
                    yield return this.edges[i];
        }

        public RectangleF BoundingBoxOf( Node node )
        {
            return new RectangleF(
                node.Position.X + node.Box.Left,
                node.Position.Y + node.Box.Top,
                node.Box.Width, node.Box.Height);
        }

        public RectangleF BoundingBoxOf( Edge edge )
        {
            float left = float.MaxValue;
            float top = float.MaxValue;
            float right = float.MinValue;
            float bottom = float.MinValue;

            // Line
            if( edge.IsComplex )
            {
                for( int i = 0; i < edge.Segments.Length; ++i )
                {
                    var seg = edge.Segments[i];
                    for( int j = 0; j < seg.Points.Length; ++j )
                    {
                        this.Minimize(ref left, ref top, seg.Points[j]);
                        this.Maximize(ref right, ref bottom, seg.Points[j]);
                    }
                }
            }
            else
            {
                this.Minimize(ref left, ref top, edge.StartPosition);
                this.Maximize(ref right, ref bottom, edge.StartPosition);
                this.Minimize(ref left, ref top, edge.EndPosition);
                this.Maximize(ref right, ref bottom, edge.EndPosition);
            }

            // Label
            if( edge.LabelText != null )
            {
                var label_size = this.MeasureString(edge.LabelFont, edge.LabelText);

                this.Minimize(ref left, ref top, edge.LabelPosition);

                if( right < edge.LabelPosition.X + label_size.Width )
                    right = edge.LabelPosition.X + label_size.Width;
                if( bottom < edge.LabelPosition.Y + label_size.Height )
                    bottom = edge.LabelPosition.Y + label_size.Height;
            }

            return new RectangleF(left, top, right - left, bottom - top);
        }

        public void UpdateGraph( bool geometry_changed )
        {
            if( geometry_changed )
            {
                // Update BoundingBox
                this.UpdateBoundingBox();

                // Update img buffer
                this.UpdateImageBuffer();

                // Update zoomed_size
                this.min_zoom = Math.Min(
                    Math.Min(1, (float)this.pan_frame.Width / this.bbox.Width),
                    Math.Min(1, (float)this.pan_frame.Height / this.bbox.Height));
                this.zoomed_size = new Size(
                    (int)Math.Ceiling(this.zoom * this.bbox.Width),
                    (int)Math.Ceiling(this.zoom * this.bbox.Height));

                // Update Panning
                this.UpdatePanningPosition();
            }
            else
            {
                // Update img buffer
                this.UpdateImageBuffer();
            }

            this.Invalidate();
        }

        #endregion

        #region Zooming

        private float min_zoom = 0;
        private float zoom = 1;
        private Size zoomed_size;
        private bool mouse_zoom_enabled = true;

        [Category("Behavior")]
        [DefaultValue(1f)]
        public float Zoom
        {
            get { return this.zoom; }
            set
            {
                if( value <= this.min_zoom )
                    value = this.min_zoom;
                else if( value > 1 )
                    value = 1;

                if( this.zoom != value )
                {
                    this.zoom = value;
                    this.zoomed_size = new Size(
                        (int)Math.Ceiling(this.zoom * this.bbox.Width),
                        (int)Math.Ceiling(this.zoom * this.bbox.Height));

                    this.UpdateZoomControls();
                    this.UpdatePanningPosition();
                    this.Invalidate();
                }
            }
        }

        private void UpdateZoomControls()
        {
            this.Zoom_Label.Text = string.Format("{0:0.#}%", this.zoom * 100f);
            this.ZoomIn_Button.Enabled = this.zoom < 1;
            this.ZoomOut_Button.Enabled = this.zoom > this.min_zoom;
        }

        [Category("Behavior")]
        [DefaultValue(true)]
        public bool ZoomControlsVisible
        {
            get { return this.Zoom_LayoutPanel.Visible; }
            set { this.Zoom_LayoutPanel.Visible = value; }
        }

        [Category("Behavior")]
        [DefaultValue(true)]
        public bool MouseZoomEnabled
        {
            get { return this.mouse_zoom_enabled; }
            set { this.mouse_zoom_enabled = true; }
        }

        public void ZoomToFitAll()
        {
            this.DoZoomToFit(this.bbox);
        }

        public void ZoomToFit( RectangleF rect )
        {
            // Make rect fit inside the bounding box
            float left = Math.Max(rect.Left, this.bbox.Left);
            float right = Math.Min(rect.Right, this.bbox.Right);
            float top = Math.Max(rect.Top, this.bbox.Top);
            float bottom = Math.Min(rect.Bottom, this.bbox.Bottom);

            this.DoZoomToFit(new RectangleF(left, top, right - left, bottom - top));
        }

        private void DoZoomToFit( RectangleF rect )
        {
            // Zooming
            this.Zoom = Math.Min(
                Math.Min(1, this.pan_frame.Width / rect.Width),
                Math.Min(1, this.pan_frame.Height / rect.Height));

            // Panning
            float left = (rect.Left - this.bbox.Left) * this.zoom - (this.pan_frame.Width - rect.Width * this.zoom) / 2;
            float top = (rect.Top - this.bbox.Top) * this.zoom - (this.pan_frame.Height - rect.Height * this.zoom) / 2;

            if( this.pan_horizontally )
                this.pan_x = Math.Max(0, Math.Min((int)left, this.max_pan_x));
            if( this.pan_vertically )
                this.pan_y = Math.Max(0, Math.Min((int)top, this.max_pan_y));
        }

        private void DoZoomIn()
        {
            if( this.zoom > 0.1f )
            {
                float z = (float)Math.Round(this.zoom * 10f);
                z += 1f;
                z /= 10f;
                this.Zoom = z;
            }
            else
            {
                this.Zoom = Math.Min(1, this.zoom * 2);
            }
        }

        private void DoZoomOut()
        {
            if( this.zoom > 0.1f )
            {
                float z = (float)Math.Round(this.zoom * 10f);
                z -= 1f;
                z /= 10f;
                this.Zoom = z;
            }
            else
            {
                this.Zoom /= 2;
            }
        }

        protected override void OnMouseWheel( MouseEventArgs e )
        {
            if( this.mouse_zoom_enabled && e.Delta != 0 )
            {
                if( e.Delta > 0 )
                    for( int i = 0; i < e.Delta; ++i )
                        this.DoZoomIn();
                else
                    for( int i = 0; i < -e.Delta; ++i )
                        this.DoZoomOut();
            }

            base.OnMouseWheel(e);
        }

        private void ZoomIn_Button_Click( object sender, EventArgs e )
        {
            this.DoZoomIn();
        }

        private void ZoomOut_Button_Click( object sender, EventArgs e )
        {
            this.DoZoomOut();
        }

        private void ZoomAll_Button_Click( object sender, EventArgs e )
        {
            this.ZoomToFitAll();
        }

        private void Zoom_LayoutPanel_Resize( object sender, EventArgs e )
        {
            this.Zoom_LayoutPanel.Left = this.ClientSize.Width - this.Zoom_LayoutPanel.Width - 1;
        }

        #endregion

        #region Panning

        private Size pan_frame;
        private bool pan_horizontally;
        private bool pan_vertically;
        private int max_pan_x;
        private int max_pan_y;
        private int pan_x;
        private int pan_y;

        private bool mouse_panning_enabled = true;
        private bool is_mouse_panning;
        private Point last_mouse_pos;

        [Category("Behavior")]
        [DefaultValue(true)]
        public bool MousePanningEnabled
        {
            get { return this.mouse_panning_enabled; }
            set
            {
                if( this.mouse_panning_enabled != value )
                {
                    this.mouse_panning_enabled = value;

                    this.is_mouse_panning = false;
                    if( this.mouse_panning_enabled )
                    {
                        this.Cursor = Cursors.Hand;
                    }
                    else
                    {
                        this.Cursor = Cursors.Default;
                    }
                }
            }
        }

        protected override void OnMouseDown( MouseEventArgs e )
        {
            if( this.mouse_panning_enabled &&
                (e.Button & System.Windows.Forms.MouseButtons.Left) != 0 )
            {
                this.is_mouse_panning = true;
                this.last_mouse_pos = e.Location;

                this.Cursor = Cursors.SizeAll;
            }

            base.OnMouseDown(e);
        }

        protected override void OnMouseUp( MouseEventArgs e )
        {
            if( this.mouse_panning_enabled &&
                this.is_mouse_panning )
            {
                this.is_mouse_panning = false;

                this.Cursor = Cursors.Hand;
            }

            base.OnMouseUp(e);
        }

        protected override void OnMouseMove( MouseEventArgs e )
        {
            if( this.is_mouse_panning )
            {
                bool changed = false;

                if( this.pan_horizontally )
                {
                    int new_pan_x = Math.Max(0, Math.Min(this.pan_x - e.X + this.last_mouse_pos.X, this.max_pan_x));
                    if( new_pan_x != this.pan_x )
                    {
                        this.pan_x = new_pan_x;
                        changed = true;
                    }
                }

                if( this.pan_vertically )
                {
                    int new_pan_y = Math.Max(0, Math.Min(this.pan_y - e.Y + this.last_mouse_pos.Y, this.max_pan_y));
                    if( new_pan_y != this.pan_y )
                    {
                        this.pan_y = new_pan_y;
                        changed = true;
                    }
                }

                this.last_mouse_pos = e.Location;

                if( changed )
                    this.Invalidate();
            }

            base.OnMouseMove(e);
        }

        protected override void OnResize( EventArgs e )
        {
            base.OnResize(e);

            this.UpdatePanningFrame();
            this.Invalidate();
        }

        private void UpdatePanningFrame()
        {
            // Update pan frame
            this.pan_frame = this.ClientSize;

            float new_min_zoom = Math.Min(
                Math.Min(1, (float)this.pan_frame.Width / this.bbox.Width),
                Math.Min(1, (float)this.pan_frame.Height / this.bbox.Height));

            if( this.min_zoom != new_min_zoom )
            {
                this.min_zoom = new_min_zoom;
                if( this.zoom < this.min_zoom )
                    this.Zoom = this.min_zoom;
            }
            else
            {
                this.UpdatePanningPosition();
            }
        }

        private void UpdatePanningPosition()
        {
            // Save old relative pan position
            float rel_pan_x = this.pan_horizontally ? (float)this.pan_x / this.max_pan_x : 0f;
            float rel_pan_y = this.pan_vertically ? (float)this.pan_y / this.max_pan_y : 0f;

            this.pan_horizontally = this.zoomed_size.Width > this.pan_frame.Width;
            this.pan_vertically = this.zoomed_size.Height > this.pan_frame.Height;
            this.max_pan_x = this.zoomed_size.Width - this.pan_frame.Width;
            this.max_pan_y = this.zoomed_size.Height - this.pan_frame.Height;

            // Set new pan position
            this.pan_x = (int)(rel_pan_x * this.max_pan_x);
            this.pan_y = (int)(rel_pan_y * this.max_pan_y);
        }

        #endregion

        #region  Drawing

        private Bitmap buff_img;
        private Graphics buff_g;
        private Rectangle bbox;
        private Padding margin = new Padding(10);

        [Category("Appearance")]
        public Color PageColor { get; set; }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Rectangle BoundingBox
        {
            get { return this.bbox; }
        }

        public SizeF MeasureString( Font font, string str )
        {
            return this.buff_g.MeasureString(str, font);
        }

        [Category("Appearance")]
        public Padding PageMargin
        {
            get { return this.margin; }
            set
            {
                if( this.margin != value )
                {
                    this.margin = value;
                    this.UpdateGraph(true);
                }
            }
        }

        private void UpdateBoundingBox()
        {
            if( this.nodes.Count == 0 )
            {
                this.bbox = Rectangle.Empty;
                return;
            }

            float left = float.MaxValue, right = float.MinValue,
                top = float.MaxValue, bottom = float.MinValue;

            foreach( var node in this.nodes )
            {
                if( left > node.Position.X + node.Box.Left )
                    left = node.Position.X + node.Box.Left;
                if( right < node.Position.X + node.Box.Right )
                    right = node.Position.X + node.Box.Right;
                if( top > node.Position.Y + node.Box.Top )
                    top = node.Position.Y + node.Box.Top;
                if( bottom < node.Position.Y + node.Box.Bottom )
                    bottom = node.Position.Y + node.Box.Bottom;
            }

            foreach( var edge in this.edges )
            {
                // Edge lines
                if( edge.IsComplex )
                {
                    for( int i = 0; i < edge.Segments.Length; ++i )
                    {
                        var seg = edge.Segments[i];

                        for( int j = 0; j < seg.Points.Length; ++j )
                        {
                            this.Minimize(ref left, ref top, seg.Points[j]);
                            this.Maximize(ref right, ref bottom, seg.Points[j]);
                        }
                    }
                }
                else
                {
                    this.Minimize(ref left, ref top, edge.StartPosition);
                    this.Maximize(ref right, ref bottom, edge.StartPosition);
                    this.Minimize(ref left, ref top, edge.EndPosition);
                    this.Maximize(ref right, ref bottom, edge.EndPosition);
                }

                // Edge labels
                if( edge.LabelText != null )
                {
                    var label_size = this.MeasureString(edge.LabelFont, edge.LabelText);

                    if( left > edge.LabelPosition.X )
                        left = edge.LabelPosition.X;
                    if( right < edge.LabelPosition.X + label_size.Width )
                        right = edge.LabelPosition.X + label_size.Width;
                    if( top > edge.LabelPosition.Y )
                        top = edge.LabelPosition.Y;
                    if( bottom < edge.LabelPosition.Y + label_size.Height )
                        bottom = edge.LabelPosition.Y + label_size.Height;
                }
            }

            this.bbox = new Rectangle(
                (int)Math.Floor(left) - this.margin.Left,
                (int)Math.Floor(top) - this.margin.Top,
                (int)Math.Ceiling(right - left) + this.margin.Horizontal,
                (int)Math.Ceiling(bottom - top) + this.margin.Vertical);
        }

        private void Minimize( ref float x, ref float y, PointF candidate )
        {
            if( x > candidate.X )
                x = candidate.X;
            if( y > candidate.Y )
                y = candidate.Y;
        }

        private void Maximize( ref float x, ref float y, PointF candidate )
        {
            if( x < candidate.X )
                x = candidate.X;
            if( y < candidate.Y )
                y = candidate.Y;
        }

        protected override void OnPaintBackground( PaintEventArgs e )
        {
            base.OnPaintBackground(e);

            if( this.buff_img != null )
            {
                int src_x, src_y, src_width, src_height, dest_x, dest_y, dest_width, dest_height;
                if( this.pan_horizontally )
                {
                    src_x = (int)Math.Floor(this.pan_x / this.zoom);
                    src_width = (int)Math.Ceiling(this.pan_frame.Width / this.zoom);
                    dest_x = 0;
                    dest_width = this.pan_frame.Width;
                }
                else
                {
                    src_x = 0;
                    src_width = this.buff_img.Width;
                    dest_x = (this.pan_frame.Width - this.zoomed_size.Width) / 2;
                    dest_width = this.zoomed_size.Width;
                }

                if( this.pan_vertically )
                {
                    src_y = (int)Math.Floor(this.pan_y / this.zoom);
                    src_height = (int)Math.Ceiling(this.pan_frame.Height / this.zoom);
                    dest_y = 0;
                    dest_height = this.pan_frame.Height;
                }
                else
                {
                    src_y = 0;
                    src_height = this.buff_img.Height;
                    dest_y = (this.pan_frame.Height - this.zoomed_size.Height) / 2;
                    dest_height = this.zoomed_size.Height;
                }

                e.Graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;

                e.Graphics.DrawImage(this.buff_img, new Rectangle(dest_x, dest_y, dest_width, dest_height),
                    src_x, src_y, src_width, src_height, GraphicsUnit.Pixel);
            }
        }

        private void UpdateImageBuffer()
        {
            if( this.buff_img == null || this.buff_img.Width != this.bbox.Width || this.buff_img.Height != this.bbox.Height )
            {
                if( this.buff_g != null )
                    this.buff_g.Dispose();
                if( this.buff_img != null )
                    this.buff_img.Dispose();

                if( this.bbox.Width == 0 || this.bbox.Height == 0 )
                {
                    this.buff_img = new Bitmap(1, 1, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
                    this.buff_g = Graphics.FromImage(this.buff_img);
                    return;
                }

                this.buff_img = new Bitmap(this.bbox.Width, this.bbox.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
                this.buff_g = Graphics.FromImage(this.buff_img);
            }


            this.buff_g.ResetTransform();
            this.buff_g.TranslateTransform(-this.bbox.X, -this.bbox.Y); // Make the graph positioned onto the image buffer
            this.buff_g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            this.buff_g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;
            this.buff_g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            this.buff_g.Clear(this.PageColor);

            for( int i = 0; i < this.edges.Count; ++i )
                GraphRenderer.DrawEdge(this.buff_g, this.edges[i]);

            for( int i = 0; i < this.nodes.Count; ++i )
                GraphRenderer.DrawNode(this.buff_g, this.nodes[i]);
        }

        #endregion
    }
}
