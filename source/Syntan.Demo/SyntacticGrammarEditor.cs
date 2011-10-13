using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Syntan.SyntacticAnalysis;

namespace Syntan.Demo
{
    public partial class SyntacticGrammarEditor : UserControl
    {
        #region Constructors

        public SyntacticGrammarEditor()
        {
            InitializeComponent();

            this.grammaticals = new List<GrammaticalSymbol>();
            this.terminals = new List<TerminalSymbol>();
            this.rules = new List<SyntacticAnalysis.Rule>();

            this.Grammar = null;
        }

        #endregion

        #region Grammar

        [DefaultValue(null)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public Grammar Grammar
        {
            get
            {
                return new Grammar(
                    this.terminals,
                    this.grammaticals,
                    this.rules,
                    this.StartSymbol_ComboBox.SelectedIndex);
            }
            set
            {
                this.Rules_ListBox.BeginUpdate();
                this.Rules_ListBox.Items.Clear();

                this.terminals.Clear();
                this.grammaticals.Clear();
                this.rules.Clear();

                if( value != null )
                {
                    this.grammaticals.AddRange(value.Grammaticals);
                    this.Grammaticals_TextBox.Text = string.Join(",", this.grammaticals.Select(gr => gr.Name));

                    foreach( var gr in this.grammaticals )
                        this.StartSymbol_ComboBox.Items.Add(gr.Name);
                    this.StartSymbol_ComboBox.SelectedIndex = value.IndexOf(value.StartSymbol);

                    this.terminals.AddRange(value.Terminals);
                    this.Terminals_TextBox.Text = string.Join(",", this.terminals.Select(tr => tr.Name));

                    this.rules.AddRange(value.Rules);
                    for( int i = 0; i < this.rules.Count; ++i )
                        this.Rules_ListBox.Items.Add(this.rules[i]);
                }
                else
                {
                    this.Grammaticals_TextBox.Text = string.Empty;
                    this.Terminals_TextBox.Text = string.Empty;
                }

                this.Rules_ListBox.EndUpdate();
            }
        }

        #endregion

        #region Grammaticals

        private class SymbolComparer : IComparer<Symbol>
        {
            #region IComparer<Symbol> Members

            public int Compare( Symbol x, Symbol y )
            {
                return x.Name.CompareTo(y.Name);
            }

            #endregion
        }

        private SymbolComparer symbol_comparer = new SymbolComparer();

        private List<GrammaticalSymbol> grammaticals;

        internal void RebuildGrammaticals()
        {
            var symbol_names = this.Grammaticals_TextBox.Text.Split(',')
                .Select(name => name.Trim())
                .Where(name => !string.IsNullOrEmpty(name));

            var to_be_deleted = new Dictionary<string, bool>(this.grammaticals.Count);
            foreach( var gr in this.grammaticals )
                to_be_deleted[gr.Name] = true;

            foreach( string name in symbol_names )
            {
                // Do not delete this symbol
                to_be_deleted[name] = false;

                // Add new symbols
                if( this.grammaticals.Find(gr => gr.Name == name) == null )
                    this.grammaticals.Add(new GrammaticalSymbol(name));
            }

            // Delete symbols
            var affected_rule_indices = new HashSet<int>();
            foreach( var kv in to_be_deleted )
                if( kv.Value )
                {
                    var grammatical = this.grammaticals.Find(gr => gr.Name == kv.Key);
                    this.grammaticals.Remove(grammatical);

                    // Find affected rules, and remember their index.
                    for( int i = 0; i < this.rules.Count; ++i )
                    {
                        var rule = this.rules[i];
                        if( rule.LeftHandSide == grammatical ||
                            rule.RightHandSide.Contains(grammatical) )
                            affected_rule_indices.Add(i);
                    }
                }

            // Sort the symbols
            this.grammaticals.Sort(this.symbol_comparer);

            // Remove affected Rules
            if( affected_rule_indices.Count > 0 )
            {
                this.Rules_ListBox.BeginUpdate();
                foreach( int rule_index in affected_rule_indices.OrderByDescending(i => i) )
                {
                    this.rules.RemoveAt(rule_index);
                    this.Rules_ListBox.Items.RemoveAt(rule_index);
                }
                this.Rules_ListBox.EndUpdate();
            }

            // Reformat the text representation
            this.Grammaticals_TextBox.Text = string.Join(",", this.grammaticals.Select(gr => gr.Name));

            this.UpdateStartSymbolList();
        }

        private void Grammaticals_TextBox_Leave( object sender, EventArgs e )
        {
            this.RebuildGrammaticals();
        }

        private void Grammaticals_TextBox_KeyDown( object sender, KeyEventArgs e )
        {
            if( e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return )
                this.RebuildGrammaticals();
        }

        private void UpdateStartSymbolList()
        {
            string old_symbol_name = null;
            if( this.StartSymbol_ComboBox.SelectedIndex != -1 )
                old_symbol_name = this.StartSymbol_ComboBox.SelectedItem.ToString();

            // Update the grammatical list.
            this.StartSymbol_ComboBox.BeginUpdate();
            this.StartSymbol_ComboBox.Items.Clear();
            for( int i = 0; i < this.grammaticals.Count; ++i )
                this.StartSymbol_ComboBox.Items.Add(this.grammaticals[i].Name);
            this.StartSymbol_ComboBox.EndUpdate();

            // Restore selection, if possible.
            if( this.StartSymbol_ComboBox.Items.Count > 0 )
            {
                if( old_symbol_name == null )
                {
                    this.StartSymbol_ComboBox.SelectedIndex = 0;
                }
                else
                {
                    int ind = this.StartSymbol_ComboBox.Items.IndexOf(old_symbol_name);
                    this.StartSymbol_ComboBox.SelectedIndex = ind != -1 ? ind : 0;
                }
            }
        }

        #endregion

        #region Terminals

        private List<TerminalSymbol> terminals;

        internal void RebuildTerminals()
        {
            var names = this.Terminals_TextBox.Text.Split(',')
                .Select(name => name.Trim())
                .Where(name => !string.IsNullOrEmpty(name));

            var to_be_deleted = new Dictionary<string, bool>(this.terminals.Count);
            foreach( var tr in this.terminals )
                to_be_deleted.Add(tr.Name, true);

            foreach( string name in names )
            {
                // Do not delete this symbol
                to_be_deleted[name] = false;

                // Add new symbols
                if( this.terminals.Find(tr => tr.Name == name) == null )
                    this.terminals.Add(new TerminalSymbol(name));
            }

            // Delete symbols
            var affected_rule_indices = new HashSet<int>();
            foreach( var kv in to_be_deleted )
                if( kv.Value )
                {
                    var terminal = this.terminals.Find(tr => tr.Name == kv.Key);
                    this.terminals.Remove(terminal);

                    // Find affected rules, and remember their index.
                    for( int i = 0; i < this.rules.Count; ++i )
                    {
                        var rule = this.rules[i];
                        if( rule.RightHandSide.Contains(terminal) )
                            affected_rule_indices.Add(i);
                    }
                }

            // Sort the symbols.
            this.terminals.Sort(this.symbol_comparer);

            // Remove affected Rules
            if( affected_rule_indices.Count > 0 )
            {
                this.Rules_ListBox.BeginUpdate();
                foreach( int index in affected_rule_indices.OrderByDescending(i => i) )
                {
                    this.rules.RemoveAt(index);
                    this.Rules_ListBox.Items.RemoveAt(index);
                }
                this.Rules_ListBox.EndUpdate();
            }

            // Reformat the text representation
            this.Terminals_TextBox.Text = string.Join(",", this.terminals.Select(tr => tr.Name));
        }

        private void Terminals_TextBox_Leave( object sender, EventArgs e )
        {
            this.RebuildTerminals();
        }

        private void Terminals_TextBox_KeyDown( object sender, KeyEventArgs e )
        {
            if( e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return )
                this.RebuildTerminals();
        }

        #endregion

        #region Rules

        private List<Syntan.SyntacticAnalysis.Rule> rules;

        private void CheckRule( Syntan.SyntacticAnalysis.Rule rule )
        {
            if( rule == null )
                throw new ArgumentException("Szabályt nem sikerült létrehozni.");
        }

        private void AddRule_Button_Click( object sender, EventArgs e )
        {
            this.RebuildGrammaticals();
            this.RebuildTerminals();

            using( var dlg = new RuleForm(this.grammaticals, this.terminals) )
            {
                dlg.Text = this.AddRule_Button.Text;
                dlg.OKButtonText = "Új szabály hozzáadása";
                dlg.ValidatorCallback = this.CheckRule;
                dlg.GrammaticalFont = this.Grammaticals_TextBox.Font;
                dlg.TerminalFont = this.Terminals_TextBox.Font;

                if( dlg.ShowDialog(this.FindForm()) == DialogResult.OK )
                {
                    var new_rule = dlg.Rule;
                    this.rules.Add(new_rule);
                    this.Rules_ListBox.Items.Add(new_rule);
                }
            }
        }

        private void EditRule_Button_Click( object sender, EventArgs e )
        {
            this.RebuildGrammaticals();
            this.RebuildTerminals();

            if( this.Rules_ListBox.SelectedIndices.Count != 1 )
            {
                MessageBox.Show(
                    this.FindForm(),
                    "Válasszon ki pontosan egy szabályt a listából.",
                    this.EditRule_Button.Text,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                return;
            }

            int index = this.Rules_ListBox.SelectedIndices[0];
            var old_rule = this.rules[index];

            using( var dlg = new RuleForm(this.grammaticals, this.terminals) )
            {
                dlg.Rule = old_rule;
                dlg.Text = this.EditRule_Button.Text;
                dlg.OKButtonText = "Szabály megváltoztatása";
                //dlg.ValidatorCallback = 
                dlg.GrammaticalFont = this.Grammaticals_TextBox.Font;
                dlg.TerminalFont = this.Terminals_TextBox.Font;

                if( dlg.ShowDialog(this.FindForm()) == DialogResult.OK )
                {
                    var new_rule = dlg.Rule;
                    this.rules[index] = new_rule;
                    this.Rules_ListBox.Items[index] = new_rule;
                }
            }
        }

        private void DeleteRules_Button_Click( object sender, EventArgs e )
        {
            this.RebuildGrammaticals();
            this.RebuildTerminals();

            int count = this.Rules_ListBox.SelectedIndices.Count;
            if( count == 0 )
            {
                MessageBox.Show(
                    this.FindForm(),
                    "Legalább egy szabályt ki kell jelölnie a listában.",
                    this.DeleteRules_Button.Text,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                return;
            }

            var to_be_deleted = new int[count];
            this.Rules_ListBox.SelectedIndices.CopyTo(to_be_deleted, 0);
            Array.Sort(to_be_deleted);

            this.Rules_ListBox.BeginUpdate();
            for( int i = count - 1; i >= 0; --i )
            {
                this.rules.RemoveAt(to_be_deleted[i]);
                this.Rules_ListBox.Items.RemoveAt(to_be_deleted[i]);
            }
            this.Rules_ListBox.EndUpdate();
        }

        private void Rules_ListBox_KeyDown( object sender, KeyEventArgs e )
        {
            e.Handled = true;

            if( e.KeyCode == Keys.C || e.KeyCode == Keys.F2 )
                this.AddRule_Button_Click(sender, EventArgs.Empty);
            else if( e.KeyCode == Keys.Enter || e.KeyCode == Keys.E )
                this.EditRule_Button_Click(sender, EventArgs.Empty);
            else if( e.KeyCode == Keys.Delete || e.KeyCode == Keys.Back )
                this.DeleteRules_Button_Click(sender, EventArgs.Empty);
            else
                e.Handled = false;
        }

        private void Rules_ListBox_DrawItem( object sender, DrawItemEventArgs e )
        {
            e.DrawBackground();

            if( e.Index == -1 )
                return;

            var rule = this.rules[e.Index];
            using( var brush = new SolidBrush(e.ForeColor) )
            {
                // Draw index
                e.Graphics.DrawString("(" + e.Index + ")",
                    e.Font, brush, e.Bounds.Location);

                // Draw LeftHandSide
                e.Graphics.DrawString(rule.LeftHandSide.Name, this.Grammaticals_TextBox.Font, brush, 50, e.Bounds.Y);
                float lhs_width = e.Graphics.MeasureString(rule.LeftHandSide.Name, this.Grammaticals_TextBox.Font).Width;

                // Draw array
                const int arrow_space = 20;
                float arrow_left = 50 + lhs_width + arrow_space;
                e.Graphics.DrawString("->", e.Font, brush, arrow_left, e.Bounds.Y);
                float arrow_width = e.Graphics.MeasureString("->", e.Font).Width;

                // Draw RightHandSide
                float rhs_left = arrow_left + arrow_width + arrow_space;
                if( rule.IsEpsilonRule )
                {
                    e.Graphics.DrawString("ε", this.Terminals_TextBox.Font, brush, rhs_left, e.Bounds.Y);
                }
                else
                {
                    Font rhs_font;
                    for( int i = 0; i < rule.RightHandSide.Count; ++i )
                    {
                        var symbol = rule.RightHandSide[i];
                        rhs_font = symbol is GrammaticalSymbol ? this.Grammaticals_TextBox.Font : this.Terminals_TextBox.Font;
                        e.Graphics.DrawString(symbol.Name, rhs_font, brush, rhs_left, e.Bounds.Y);
                        rhs_left += e.Graphics.MeasureString(symbol.Name, rhs_font).Width;
                    }
                }
            }


            // Focus
            if( (e.State & DrawItemState.Focus) != 0 )
                e.DrawFocusRectangle();
        }

        #endregion
    }
}
