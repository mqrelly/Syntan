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
    public partial class SimpleSyntacticGrammarEditor : UserControl
    {
        #region Constructors

        public SimpleSyntacticGrammarEditor()
        {
            InitializeComponent();

            this.terminals = new Dictionary<string, int>();
            this.grammaticals = new Dictionary<string, int>();
            this.rules = new List<RuleStrRep>();

            this.UpdateRulesList();
            this.UpdateGrammaticals();
            this.UpdateTerminals();
        }

        #endregion

        #region Grammar

        public SyntacticAnalysis.Grammar SyntacticGrammar
        {
            get { return this.BuildGrammar(); }
            set { this.LoadGrammar(value); }
        }

        private SyntacticAnalysis.Grammar BuildGrammar()
        {
            // Generate terminals
            var terminals = new Dictionary<string, TerminalSymbol>(this.terminals.Count);
            foreach( string tr_name in this.terminals.Keys )
                terminals.Add(tr_name, new TerminalSymbol(tr_name));

            // Generate grammaticals
            var grammaticals = new Dictionary<string, GrammaticalSymbol>(this.grammaticals.Count);
            foreach( string gr_name in this.grammaticals.Keys )
                grammaticals.Add(gr_name, new GrammaticalSymbol(gr_name));

            // Generate rules
            var rules = new List<SyntacticAnalysis.Rule>(this.rules.Count);
            foreach( var rule in this.rules )
            {
                var rhs = new Symbol[rule.Rhs.Count];
                for( int i = 0; i < rule.Rhs.Count; ++i )
                {
                    GrammaticalSymbol gr;
                    if( grammaticals.TryGetValue(rule.Rhs[i], out gr) )
                    {
                        rhs[i] = gr;
                    }
                    else
                    {
                        rhs[i] = terminals[rule.Rhs[i]];
                    }
                }

                rules.Add(new SyntacticAnalysis.Rule(
                    grammaticals[rule.Lhs],
                    rhs));
            }

            return new SyntacticAnalysis.Grammar(terminals.Values, grammaticals.Values, rules);
        }

        private void LoadGrammar( Grammar grammar )
        {
            this.terminals.Clear();
            this.grammaticals.Clear();
            this.rules.Clear();

            try
            {
                // Check symbol names
                foreach( var tr in grammar.Terminals )
                    if( tr.Name.Length != 1 )
                        throw new ArgumentException(string.Format("Terminal's name '{0}' is not simple.", tr.Name));

                foreach( var gr in grammar.Grammaticals )
                    if( gr.Name.Length != 1 && gr.Name != "S'" )
                        throw new ArgumentException(string.Format("Grammatical's name '{0}' is not simple.", gr.Name));

                foreach( var rule in grammar.Rules )
                {
                    var rule_rep = new RuleStrRep();

                    rule_rep.Lhs = rule.LeftHandSide.Name;
                    if( this.grammaticals.ContainsKey(rule.LeftHandSide.Name) )
                        this.grammaticals[rule.LeftHandSide.Name] += 1;
                    else
                        this.grammaticals[rule.LeftHandSide.Name] = 1;

                    foreach( var symbol in rule.RightHandSide )
                    {
                        rule_rep.Rhs.Add(symbol.Name);
                        if( symbol is GrammaticalSymbol )
                        {
                            if( this.grammaticals.ContainsKey(symbol.Name) )
                                this.grammaticals[symbol.Name] += 1;
                            else
                                this.grammaticals[symbol.Name] = 1;
                        }
                        else
                        {
                            if( this.terminals.ContainsKey(symbol.Name) )
                                this.terminals[symbol.Name] += 1;
                            else
                                this.terminals[symbol.Name] = 1;
                        }
                    }

                    this.rules.Add(rule_rep);
                }
            }
            finally
            {
                // Update gui
                this.UpdateRulesList();
                this.UpdateGrammaticals();
                this.UpdateTerminals();
            }
        }

        #endregion

        #region Rules list

        private void UpdateRulesList()
        {
            this.Rules_ListBox.BeginUpdate();
            this.Rules_ListBox.Items.Clear();
            foreach( var rule in this.rules )
                this.Rules_ListBox.Items.Add(rule.ToString());
            this.Rules_ListBox.EndUpdate();
        }

        #endregion

        #region Rule management

        private class RuleStrRep
        {
            public string Lhs;
            public List<string> Rhs = new List<string>();

            public override string ToString()
            {
                return string.Format("{0}->{1}",
                    this.Lhs,
                    string.Join(string.Empty, this.Rhs.ToArray()));
            }
        }

        private List<RuleStrRep> rules;
        private Dictionary<string, int> terminals;
        private Dictionary<string, int> grammaticals;

        private void CheckRuleString( string rule_str )
        {
            if( rule_str.Length < 3 )
                throw new ArgumentException("Rule is too short.");

            if( rule_str[1] != '-' || rule_str[2] != '>' )
                throw new ArgumentException("The arrow '->' must came right after the first grammatical symbol.");

            if( rule_str.Contains('#') )
                throw new ArgumentException("Rule must not include End-of-input metasymbol '#'.");
        }

        private RuleStrRep ParseRule( string str )
        {
            var new_rule = new RuleStrRep();

            new_rule.Lhs = str.Substring(0, 1);

            for( int i = 3; i < str.Length; ++i )
                new_rule.Rhs.Add(str.Substring(i, 1));

            return new_rule;
        }

        private void UpdateSymbolsAfterRuleAdded( RuleStrRep rule, ref bool grammaticals_changed, ref bool terminals_changed )
        {
            // LeftHandSide is a grammatical.
            if( this.grammaticals.ContainsKey(rule.Lhs) )
            {
                this.grammaticals[rule.Lhs] += 1;
            }
            else
            {
                this.grammaticals.Add(rule.Lhs, 1);
                grammaticals_changed = true;

                if( this.terminals.ContainsKey(rule.Lhs) )
                    terminals_changed = true;
            }

            // Count all RightHandSide symbols as terminals.
            for( int i = 0; i < rule.Rhs.Count; ++i )
            {
                string symbol = rule.Rhs[i];

                if( this.terminals.ContainsKey(symbol) )
                {
                    this.terminals[symbol] += 1;
                }
                else
                {
                    this.terminals.Add(symbol, 1);
                    terminals_changed = true;
                }
            }
        }

        private void UpdateSymbolsAfterRuleRemoved( RuleStrRep rule, ref bool grammaticals_changed, ref bool terminals_changed )
        {
            // LeftHandSide
            if( this.grammaticals[rule.Lhs] <= 1 )
            {
                this.grammaticals.Remove(rule.Lhs);
                grammaticals_changed = true;

                if( this.terminals.ContainsKey(rule.Lhs) )
                    terminals_changed = true;
            }
            else
            {
                this.grammaticals[rule.Lhs] -= 1;
            }

            // RightHandSide
            for( int i = 0; i < rule.Rhs.Count; ++i )
            {
                string symbol = rule.Rhs[i];

                if( this.terminals[symbol] <= 1 )
                {
                    this.terminals.Remove(symbol);
                    terminals_changed = true;
                }
                else
                {
                    this.terminals[symbol] -= 1;
                }
            }
        }

        private void UpdateGrammaticals()
        {
            this.Grammaticals_TextBox.Text = string.Join(" ", this.grammaticals.Keys);
        }

        private void UpdateTerminals()
        {
            var sb = new StringBuilder();
            foreach( string symbol in this.terminals.Keys )
                if( !this.grammaticals.ContainsKey(symbol) )
                    sb.Append(symbol).Append(" ");

            this.Terminals_TextBox.Text = sb.ToString();
        }

        #endregion

        #region User commands

        private void AddRule_Button_Click( object sender, EventArgs e )
        {
            using( var dlg = new InputForm() )
            {
                dlg.OKButtonLabel = "Add new rule";
                dlg.CheckRuleCallback = this.CheckRuleString;
                dlg.RuleString = string.Empty;

                if( dlg.ShowDialog(this.ParentForm) == DialogResult.OK )
                {
                    bool grammaticals_changed = false, terminals_changed = false;

                    var new_rule = this.ParseRule(dlg.RuleString);
                    this.UpdateSymbolsAfterRuleAdded(new_rule, ref grammaticals_changed, ref terminals_changed);
                    this.rules.Add(new_rule);

                    // Update gui
                    this.Rules_ListBox.Items.Add(dlg.RuleString); //TODO: new_rule instead?
                    if( grammaticals_changed )
                        this.UpdateGrammaticals();
                    if( terminals_changed )
                        this.UpdateTerminals();
                }
            }
        }

        private void EditRule_Button_Click( object sender, EventArgs e )
        {
            if( this.Rules_ListBox.SelectedIndices.Count != 1 )
            {
                MessageBox.Show(
                    this.ParentForm,
                    "Select one rule!",
                    "Edit rule",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                return;
            }

            int index = this.Rules_ListBox.SelectedIndices[0];
            var old_rule = this.rules[index];

            using( var dlg = new InputForm() )
            {
                dlg.OKButtonLabel = "Save rule";
                dlg.CheckRuleCallback = this.CheckRuleString;
                dlg.RuleString = old_rule.ToString();

                if( dlg.ShowDialog(this.ParentForm) == DialogResult.OK )
                {
                    bool grammaticals_changed = false, terminals_changed = false;

                    var new_rule = this.ParseRule(dlg.RuleString);
                    this.rules[index] = new_rule;
                    this.UpdateSymbolsAfterRuleRemoved(old_rule, ref grammaticals_changed, ref terminals_changed);
                    this.UpdateSymbolsAfterRuleAdded(new_rule, ref grammaticals_changed, ref terminals_changed);

                    // Update Gui accordingly
                    this.Rules_ListBox.Items[index] = dlg.RuleString; //TODO: new_rule ?
                    if( grammaticals_changed )
                        this.UpdateGrammaticals();
                    if( terminals_changed )
                        this.UpdateTerminals();
                }
            }
        }

        private void DeleteRule_Button_Click( object sender, EventArgs e )
        {
            if( this.Rules_ListBox.SelectedIndices.Count == 0 )
            {
                MessageBox.Show(
                        this.ParentForm,
                        "Select one or more rules!",
                        "Delete rules",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                return;
            }

            // Copy indices.
            var to_delete = new int[this.Rules_ListBox.SelectedIndices.Count];
            this.Rules_ListBox.SelectedIndices.CopyTo(to_delete, 0);
            Array.Reverse(to_delete);

            // Delete rules.
            this.Rules_ListBox.BeginUpdate();
            bool grammaticals_changed = false, terminals_changed = false;
            for( int i = 0; i < to_delete.Length; ++i )
            {
                int index = to_delete[i];

                // Remove from grammar
                var rule = this.rules[index];
                this.rules.RemoveAt(index);
                this.UpdateSymbolsAfterRuleRemoved(rule, ref grammaticals_changed, ref terminals_changed);

                // Remove from gui list
                this.Rules_ListBox.Items.RemoveAt(index);
            }
            this.Rules_ListBox.EndUpdate();


            // Update symbol listings
            if( grammaticals_changed )
                this.UpdateGrammaticals();
            if( terminals_changed )
                this.UpdateTerminals();
        }

        #endregion
    }
}
