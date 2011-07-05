using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Syntan.Demo
{
    public partial class StepsView : UserControl
    {
        #region Constructors

        public StepsView()
        {
            InitializeComponent();
        }

        #endregion

        #region Appearance

        private bool arrows_visible = true;
        private int arrow_width = 6;
        private Size arrow_head_size = new Size(6, 12);
        private SolidBrush arrow_brush = new SolidBrush(Color.DarkGray);

        private int current_step_border_width = 4;
        private int circle_size = 30;
        private int spacing = 20;
        private SolidBrush done_back_brush = new SolidBrush(Color.LightGreen);
        private SolidBrush undone_back_brush = new SolidBrush(Color.LightGray);
        private SolidBrush current_back_brush = new SolidBrush(Color.LightGreen);
        private SolidBrush done_fore_brush = new SolidBrush(Color.Black);
        private SolidBrush undone_fore_brush = new SolidBrush(Color.Black);
        private SolidBrush current_fore_brush = new SolidBrush(Color.Black);

        [Category("Appearance")]
        [DefaultValue(true)]
        public bool ArrowsVisible
        {
            get { return this.arrows_visible; }
            set
            {
                if( this.arrows_visible != value )
                {
                    this.arrows_visible = value;
                    this.Invalidate();
                }
            }
        }

        [Category("Appearance")]
        [DefaultValue(6)]
        public int ArrowWidth
        {
            get { return this.arrow_width; }
            set
            {
                if( value < 0 )
                    throw new ArgumentOutOfRangeException("ArrowWidth must not be negative.");

                if( this.arrow_width != value )
                {
                    this.arrow_width = value;
                    this.arrow_head_size = new Size(value, 2 * value);
                    if( this.arrows_visible )
                        this.Invalidate();
                }
            }
        }

        [Category("Appearance")]
        public Color ArrowColor
        {
            get { return this.arrow_brush.Color; }
            set
            {
                this.arrow_brush.Color = value;
                if( this.arrows_visible )
                    this.Invalidate();
            }
        }

        [Category("Appearance")]
        [DefaultValue(30)]
        public int CircleSize
        {
            get { return this.circle_size; }
            set
            {
                if( value <= 0 )
                    throw new ArgumentOutOfRangeException("CircleSize must be positive.");

                if( this.circle_size != value )
                {
                    this.circle_size = value;
                    this.RecalculateMinSize();
                    this.Invalidate();
                }
            }
        }

        [Category("Appearance")]
        [DefaultValue(20)]
        public int Spacing
        {
            get { return this.spacing; }
            set
            {
                if( value < 0 )
                    throw new ArgumentOutOfRangeException("Spacing must not be negative.");

                if( this.spacing != value )
                {
                    this.spacing = value;
                    this.RecalculateMinSize();
                    this.Invalidate();
                }
            }
        }

        [Category("Appearance")]
        public Color DoneBackColor
        {
            get { return this.done_back_brush.Color; }
            set
            {
                this.done_back_brush.Color = value;
                this.Invalidate();
            }
        }

        [Category("Appearance")]
        public Color DoneForeColor
        {
            get { return this.done_fore_brush.Color; }
            set
            {
                this.done_fore_brush.Color = value;
                this.Invalidate();
            }
        }

        [Category("Appearance")]
        public Color UndoneBackColor
        {
            get { return this.undone_back_brush.Color; }
            set
            {
                this.undone_back_brush.Color = value;
                this.Invalidate();
            }
        }

        [Category("Appearance")]
        public Color UndoneForeColor
        {
            get { return this.undone_fore_brush.Color; }
            set
            {
                this.undone_fore_brush.Color = value;
                this.Invalidate();
            }
        }

        [Category("Appearance")]
        public Color CurrentBackColor
        {
            get { return this.current_back_brush.Color; }
            set
            {
                this.current_back_brush.Color = value;
                this.Invalidate();
            }
        }

        [Category("Appearance")]
        public Color CurrentForeColor
        {
            get { return this.current_fore_brush.Color; }
            set
            {
                this.current_fore_brush.Color = value;
                this.Invalidate();
            }
        }

        #endregion

        #region Behavior

        private int step_count = 0;
        private int current_step = -1;

        [Category("Behavior")]
        [DefaultValue(0)]
        public int StepCount
        {
            get { return this.step_count; }
            set
            {
                this.step_count = Math.Max(0, value);

                // Update current_step
                if( this.step_count == 0 )
                    this.current_step = -1;
                else
                    this.current_step = Math.Min(this.current_step, this.step_count - 1);

                this.RecalculateMinSize();
                this.Invalidate();
            }
        }

        [Browsable(false)]
        [DefaultValue(-1)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int CurrentStep
        {
            get { return this.current_step; }
            set
            {
                if( this.step_count == 0 )
                {
                    if( value != -1 )
                        throw new ArgumentOutOfRangeException("CurrentStep must be -1, if StepCount = 0.");
                }
                else
                {
                    if( value < -1 || value >= this.step_count )
                        throw new ArgumentOutOfRangeException("CurrentStep must be in [0,StepCount-1] or -1 for no step selected.");
                }

                this.current_step = value;
                this.Invalidate();
            }
        }

        #endregion

        #region Private methods

        private void RecalculateMinSize()
        {
            this.MinimumSize = new Size(
                this.step_count * (this.circle_size + this.spacing) - this.spacing + 2 * this.current_step_border_width,
                this.circle_size + 2 * this.current_step_border_width);
        }

        protected override void OnPaintBackground( PaintEventArgs e )
        {
            base.OnPaintBackground(e);

            e.Graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            // Draw arrows
            int x = this.current_step_border_width + this.circle_size;
            if( this.arrows_visible )
            {
                for( int i = 1; i < this.step_count; ++i )
                {
                    e.Graphics.FillRectangle(this.arrow_brush,
                        x, 
                        this.current_step_border_width + this.circle_size / 2 - this.arrow_width / 2,
                        this.spacing - this.arrow_head_size.Width + 1,
                        this.arrow_width);

                    e.Graphics.FillPolygon(this.arrow_brush, new Point[]
                        {
                            new Point(
                                x + this.spacing - this.arrow_head_size.Width, 
                                this.current_step_border_width + this.circle_size / 2 - this.arrow_head_size.Height / 2),
                            new Point(
                                x + this.spacing - this.arrow_head_size.Width, 
                                this.current_step_border_width + this.circle_size / 2 + this.arrow_head_size.Height / 2),
                            new Point(
                                x + this.spacing, 
                                this.current_step_border_width + this.circle_size / 2),
                        });

                    x += this.circle_size + this.spacing;
                }
            }

            // Draw step circles
            SolidBrush back, fore;
            x = this.current_step_border_width;
            for( int i = 0; i < this.step_count; ++i )
            {
                if( i < this.current_step )
                {
                    back = this.done_back_brush;
                    fore = this.done_fore_brush;
                }
                else if( i == this.current_step )
                {
                    back = this.current_back_brush;
                    fore = this.current_fore_brush;
                }
                else
                {
                    back = this.undone_back_brush;
                    fore = this.undone_fore_brush;
                }

                e.Graphics.FillEllipse(back, x, this.current_step_border_width,
                    this.circle_size, this.circle_size);

                string label = (i + 1).ToString();
                var label_size = e.Graphics.MeasureString(label, this.Font);
                e.Graphics.DrawString(label, this.Font, fore,
                    x + (this.circle_size - label_size.Width) / 2,
                    this.current_step_border_width + (this.circle_size - label_size.Height) / 2);

                if( i == this.current_step && this.current_step_border_width > 0 )
                    using( var pen = new Pen(fore, this.current_step_border_width) )
                        e.Graphics.DrawEllipse(pen, x, this.current_step_border_width, 
                            this.circle_size, this.circle_size);

                x += this.circle_size + this.spacing;
            }
        }

        #endregion
    }
}
