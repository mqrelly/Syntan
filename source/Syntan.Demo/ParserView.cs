using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Syntan.SyntacticAnalysis.LR;
using Syntan.SyntacticAnalysis;

namespace Syntan.Demo
{
    public partial class ParserView : UserControl
    {
        #region Constructor

        public ParserView()
        {
            InitializeComponent();
        }

        #endregion

        #region Input

        public string InputText
        {
            get { return this.Input_ComboBox.Text; }
            set { this.Input_ComboBox.Text = value; }
        }

        public bool InputEditEnabled
        {
            get { return this.Input_ComboBox.Enabled; }
            set { this.Input_ComboBox.Enabled = value; }
        }

        public void ClearInputHistory()
        {
            this.Input_ComboBox.Items.Clear();
        }

        public void AddToInputHistory( string item )
        {
            if( this.Input_ComboBox.Items.IndexOf(item) == -1 )
                this.Input_ComboBox.Items.Add(item);
        }

        #endregion

        #region State indication

        public ParserStackView StackView
        {
            get { return this.ParserStackView; }
        }

        public StepsView StepsView
        {
            get { return this.InternalStepsView; }
        }

        public void ShowState( string label, string value, Color color )
        {
            this.State_Label.Text = label;
            this.State_Label.Visible = true;
            this.StateValue_Label.Text = value;
            this.StateValue_Label.BackColor = color;
            this.StateValue_Label.Visible = true;
        }

        public void ColorState( Color color )
        {
            this.StateValue_Label.BackColor = color;
        }

        public void HideState()
        {
            this.State_Label.Visible = false;
            this.StateValue_Label.Visible = false;
        }

        public void ShowInputSymbol( string value, Color color )
        {
            this.InputSymbol_Label.Visible = true;
            this.InputSymbolValue_Label.Text = value;
            this.InputSymbolValue_Label.BackColor = color;
            this.InputSymbolValue_Label.Visible = true;
        }

        public void HideInputSymbol()
        {
            this.InputSymbol_Label.Visible = false;
            this.InputSymbolValue_Label.Visible = false;
        }

        public void ColorInputSymbol( Color color )
        {
            this.InputSymbolValue_Label.BackColor = color;
        }

        public void ShowAction( string action )
        {
            this.NextAction_Label.Text = action;
            this.NextAction_Label.ForeColor = SystemColors.ControlText;
            this.NextAction_Label.Visible = true;
        }

        public void ShowAction( string action, Color color )
        {
            this.NextAction_Label.Text = action;
            this.NextAction_Label.ForeColor = color;
            this.NextAction_Label.Visible = true;
        }

        public void HideAction()
        {
            this.NextAction_Label.Visible = false;
        }

        public void ShowRule( int rule_index, Syntan.SyntacticAnalysis.Rule rule )
        {
            this.RuleIndex_Label.Text = "(" + rule_index.ToString() + ")";
            this.RuleLhs_Label.Text = rule.LeftHandSide.Name;
            this.RuleLhs_Label.BackColor = this.BackColor;
            this.RuleRhs_Label.Text = rule.RightHandSide.Count == 0 ? "ε" :
                string.Join(string.Empty, rule.RightHandSide.Select(s => s.Name));
            this.RuleRhs_Label.BackColor = this.BackColor;
            this.Rule_TableLayout.Visible = true;
        }

        public void HideRule()
        {
            this.Rule_TableLayout.Visible = false;
        }

        public void ColorRule( Color left_hand_side, Color right_hand_side )
        {
            this.RuleLhs_Label.BackColor = left_hand_side;
            this.RuleRhs_Label.BackColor = right_hand_side;
        }

        #endregion
    }
}
