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
    public partial class ParserStackView : UserControl
    {
        #region Constructors

        public ParserStackView()
        {
            InitializeComponent();

            this.states = new List<string>();
            this.symbols = new List<string>();
        }

        #endregion

        #region Stack

        private List<string> states;
        private List<string> symbols;
        private string dummy_item = string.Empty;

        public void Clear()
        {
            this.states.Clear();
            this.symbols.Clear();

            this.marked_state_count = 0;
            this.marked_symbol_count = 0;

            this.Stack_ListBox.Items.Clear();
        }

        public void Push( string state, string symbol )
        {
            this.states.Insert(0, state);
            this.symbols.Insert(0, symbol);

            this.Stack_ListBox.Items.Insert(0, this.dummy_item);
        }

        public void Pop()
        {
            this.states.RemoveAt(0);
            this.symbols.RemoveAt(0);

            this.Stack_ListBox.Items.RemoveAt(0);
        }

        #endregion

        #region Mark state

        private int marked_state_count;
        private SolidBrush state_mark_brush = new SolidBrush(Color.Orange);

        public void MarkState( Color color )
        {
            this.marked_state_count = 1;
            this.state_mark_brush.Color = color;
            this.Stack_ListBox.Invalidate();
        }

        public void ClearStateMarks()
        {
            this.marked_state_count = 0;
            this.Stack_ListBox.Invalidate();
        }

        #endregion

        #region Mark symbols

        private int marked_symbol_count;
        private SolidBrush symbol_mark_brush = new SolidBrush(Color.LightBlue);

        public void MarkSymbols( int count, Color color )
        {
            if( count < 0 )
                throw new ArgumentOutOfRangeException("Count must not be negative.");

            this.marked_symbol_count = count;
            this.symbol_mark_brush.Color = color;
            this.Stack_ListBox.Invalidate();
        }

        public void ClearSymbolMarks()
        {
            this.marked_symbol_count = 0;
            this.Stack_ListBox.Invalidate();
        }

        #endregion

        private void Stack_ListBox_DrawItem( object sender, DrawItemEventArgs e )
        {
            e.Graphics.FillRectangle(SystemBrushes.Window, e.Bounds);
            
            if( e.Index == -1 )
                return;


            // Draw State-Symbol separator
            e.Graphics.DrawLine(Pens.Gray,
                (e.Bounds.Left + e.Bounds.Right) / 2, e.Bounds.Top + 1,
                (e.Bounds.Left + e.Bounds.Right) / 2, e.Bounds.Bottom - 2);


            // Draw item separator
            if( e.Index < this.states.Count - 1 )
                e.Graphics.DrawLine(Pens.LightGray,
                    e.Bounds.Left, e.Bounds.Bottom - 1, e.Bounds.Right, e.Bounds.Bottom - 1);


            // Draw State
            var state_box = new Rectangle(e.Bounds.Left, e.Bounds.Top, e.Bounds.Width / 2, e.Bounds.Height - 1);
            if( e.Index < this.marked_state_count )
            {
                e.Graphics.FillRectangle(this.state_mark_brush,
                    state_box.X + 2, state_box.Y + 2, state_box.Width - 4, state_box.Height - 4);
                
                //TODO: nice corners!
                //e.Graphics.FillRectangle(SystemBrushes.Window,
                //    state_box.X + 2, state_box.Y + 2, 2, 1);
                //e.Graphics.FillRectangle(SystemBrushes.Window,
                //    state_box.X + 2, state_box.Y + 2, 1, 2);
            }

            string label = this.states[e.Index];
            var label_size = e.Graphics.MeasureString(label, this.Font);
            e.Graphics.DrawString(label, this.Font, SystemBrushes.WindowText,
                state_box.X + (state_box.Width - label_size.Width) / 2,
                state_box.Y + (state_box.Height - label_size.Height) / 2);


            // Draw Symbol
            var symbol_box = new Rectangle(e.Bounds.Left + e.Bounds.Width / 2 + 1, e.Bounds.Top, e.Bounds.Width / 2 - 1, e.Bounds.Height - 1);
            if( e.Index < this.marked_symbol_count )
            {
                e.Graphics.FillRectangle(this.symbol_mark_brush,
                    symbol_box.X + 2, symbol_box.Y + 2, symbol_box.Width - 4, symbol_box.Height - 4);
            }

            label = this.symbols[e.Index];
            label_size = e.Graphics.MeasureString(label, this.Font);
            e.Graphics.DrawString(label, this.Font, SystemBrushes.WindowText,
                symbol_box.X + (symbol_box.Width - label_size.Width) / 2,
                symbol_box.Y + (symbol_box.Height - label_size.Height) / 2);
        }
    }
}
