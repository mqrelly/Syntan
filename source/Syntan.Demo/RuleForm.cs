using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Syntan.SyntacticAnalysis;

namespace Syntan.Demo
{
    public partial class RuleForm : Form
    {
        #region Constructors

        public RuleForm( IList<GrammaticalSymbol> grammaticals, IList<TerminalSymbol> terminals )
        {
            InitializeComponent();

            this.terminals = terminals;
            this.grammaticals = grammaticals;

            this.rhs = new List<Symbol>();

            this.grammatical_font = new Font("Arial Black", 8, FontStyle.Regular);
            this.terminal_font = new Font("Arial", 8, FontStyle.Italic);
            this.LoadItemsIntoComboBox(this.Lhs_ComboBox, this.grammaticals);

            this.UpdateRuleString();
        }

        #endregion

        #region Private fields

        private IList<TerminalSymbol> terminals;
        private IList<GrammaticalSymbol> grammaticals;

        #endregion

        #region Public properties

        private StringBuilder rule_str = new StringBuilder();

        public string OKButtonText
        {
            get { return this.OK_Button.Text; }
            set { this.OK_Button.Text = value; }
        }

        public Action<Syntan.SyntacticAnalysis.Rule> ValidatorCallback { get; set; }

        public Syntan.SyntacticAnalysis.Rule Rule
        {
            get
            {
                if( this.Lhs_ComboBox.SelectedIndex == -1 ||
                    this.rhs.Contains(null) )
                    return null;

                return new SyntacticAnalysis.Rule(
                    this.grammaticals[this.Lhs_ComboBox.SelectedIndex],
                    this.rhs);
            }
            set
            {
                this.Lhs_ComboBox.SelectedIndex = -1;
                this.ClearRhsItems();

                if( value != null )
                {
                    this.Lhs_ComboBox.SelectedIndex =
                        this.grammaticals.IndexOf(value.LeftHandSide);

                    foreach( var symbol in value.RightHandSide )
                        this.AddRhsItem(symbol);
                }
            }
        }

        private void UpdateRuleString()
        {
            this.rule_str.Clear();

            // Lhs
            if( this.Lhs_ComboBox.SelectedIndex == -1 )
            {
                this.RuleString_Label.Text = "Bal oldal nincs kiválasztva";
                this.RuleString_Label.BackColor = Color.LightSalmon;
                return;
            }
            this.rule_str.Append(this.grammaticals[this.Lhs_ComboBox.SelectedIndex].Name);

            // Arrow
            this.rule_str.Append("->");

            // Rhs
            for( int i = 0; i < this.rhs.Count; ++i )
            {
                if( this.rhs[i] == null )
                {
                    this.RuleString_Label.Text = string.Format("Jobb oldal {0}. szimbóluma nincs kiválasztva", i + 1);
                    this.RuleString_Label.BackColor = Color.LightSalmon;
                    return;
                }
                this.rule_str.Append(this.rhs[i].Name);
            }

            this.RuleString_Label.BackColor = SystemColors.Control;
            this.RuleString_Label.Text = this.rule_str.ToString();
        }

        public Font GrammaticalFont
        {
            get { return this.grammatical_font; }
            set
            {
                this.grammatical_font = value;
                this.Lhs_ComboBox.Font = value;
            }
        }

        public Font TerminalFont
        {
            get { return this.terminal_font; }
            set { this.terminal_font = value; }
        }

        #endregion

        #region ComboBox helpers

        private void LoadItemsIntoComboBox( ComboBox combobox, IEnumerable<object> items )
        {
            combobox.BeginUpdate();
            foreach( var item in items )
                combobox.Items.Add(item);
            combobox.EndUpdate();
        }

        private Font grammatical_font;
        private Font terminal_font;

        private void Symbol_ComboBox_DrawItem( object sender, DrawItemEventArgs e )
        {
            e.DrawBackground();

            if( e.Index == -1 )
                return;

            var item = (Symbol)((ComboBox)sender).Items[e.Index];
            var font = item is GrammaticalSymbol ? this.grammatical_font : this.terminal_font;
            var brush = new SolidBrush(e.ForeColor);
            e.Graphics.DrawString(item.Name, font, brush, e.Bounds.Location);
            brush.Dispose();

            if( (e.State & DrawItemState.Focus) != 0 )
                e.DrawFocusRectangle();
        }

        #endregion

        #region RHS items

        private List<Symbol> rhs;

        private void ClearRhsItems()
        {
            this.rhs.Clear();
            this.Rhs_TablePanel.Controls.Clear();
        }

        private void AddRhsItem( Symbol symbol )
        {
            int index = this.rhs.Count;
            this.rhs.Add(symbol);

            // ComboBox
            var combobox = new ComboBox();
            this.LoadItemsIntoComboBox(combobox, this.grammaticals);
            this.LoadItemsIntoComboBox(combobox, this.terminals);
            combobox.DropDownStyle = ComboBoxStyle.DropDownList;
            combobox.Margin = new Padding(0);
            combobox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            combobox.DrawMode = DrawMode.OwnerDrawFixed;
            combobox.DrawItem += this.Symbol_ComboBox_DrawItem;
            if( symbol != null )
            {
                if( symbol is GrammaticalSymbol )
                {
                    int ind = this.grammaticals.IndexOf((GrammaticalSymbol)symbol);
                    if( ind == -1 )
                        this.rhs[index] = null;
                    else
                        combobox.SelectedIndex = ind;
                }
                else
                {
                    int ind = this.terminals.IndexOf((TerminalSymbol)symbol);
                    if( ind == -1 )
                        this.rhs[index] = null;
                    else
                        combobox.SelectedIndex = this.grammaticals.Count + ind;
                }
            }
            combobox.SelectedIndexChanged += ( s_, e_ ) =>
                {
                    int index_ = this.Rhs_TablePanel.Controls.IndexOf(combobox);

                    if( combobox.SelectedIndex == -1 )
                        this.rhs[index_] = null;
                    else if( combobox.SelectedIndex < this.grammaticals.Count )
                        this.rhs[index_] = this.grammaticals[combobox.SelectedIndex];
                    else
                        this.rhs[index_] = this.terminals[combobox.SelectedIndex - this.grammaticals.Count];

                    this.UpdateRuleString();
                };

            // Add a new row only if there is no more left. (Must only happen with the first item!)
            if( this.Rhs_TablePanel.RowCount == this.rhs.Count )
            {
                this.Rhs_TablePanel.RowCount += 1;
                this.Rhs_TablePanel.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            }
            this.Rhs_TablePanel.Controls.Add(combobox);

            this.UpdateRuleString();
        }

        private void RhsAddItem_Button_Click( object sender, EventArgs e )
        {
            this.AddRhsItem(null);
        }

        private void RhsRemoveItem_ToolButton_Click( object sender, EventArgs e )
        {
            for( int i = 0; i < this.Rhs_TablePanel.Controls.Count; ++i )
                // Is this the selected item's ComboBox?
                if( this.Rhs_TablePanel.Controls[i].Focused )
                {
                    this.rhs.RemoveAt(i);
                    this.Rhs_TablePanel.Controls.RemoveAt(i);

                    // Correct the RowIndex of the controls following the deleted one.
                    for( int j = i; j < this.Rhs_TablePanel.Controls.Count; ++j )
                        this.Rhs_TablePanel.SetRow(this.Rhs_TablePanel.Controls[j], j);

                    // Get rid of the extre row.
                    this.Rhs_TablePanel.RowCount -= 1;

                    this.UpdateRuleString();

                    // Select the next item, if there is any
                    if( this.rhs.Count > 0 )
                        this.Rhs_TablePanel.Controls[Math.Min(i, this.rhs.Count - 1)].Focus();

                    break;
                }

        }

        #endregion

        #region Event handlers

        private void Lhs_ComboBox_SelectedIndexChanged( object sender, EventArgs e )
        {
            this.UpdateRuleString();
        }

        private void OK_Button_Click( object sender, EventArgs e )
        {
            try
            {
                var rule = this.Rule;
                if( this.ValidatorCallback != null )
                    this.ValidatorCallback(rule);

                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            catch( Exception ex )
            {
                this.RuleString_Label.Text = ex.Message;
                this.RuleString_Label.BackColor = Color.LightSalmon;
            }
        }

        #endregion

    }
}
