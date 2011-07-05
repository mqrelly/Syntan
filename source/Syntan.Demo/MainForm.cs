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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            this.Size = new Size(800, 600);

            this.parser = new SyntacticAnalysis.LR.Parser();
            this.parser.PhaseChanged += this.Parser_PhaseChanged;

            this.colors = new ColorScheme()
            {
                CurrentInputSymbol = Color.Orange,
                CurrentState = Color.DeepSkyBlue,
                NewState = Color.LawnGreen,
                RuleLhsToReducate = Color.Violet,
            };
        }

        #region Syntactic Grammar

        private ExtendedGrammar ext_grammar;
        private SyntacticAnalysis.LR.LR0CanonicalSets canonical_sets;
        private ISet<GrammaticalSymbol> epsilon_grammaticals;
        private IDictionary<GrammaticalSymbol, ISet<TerminalSymbol>> follow_sets;
        private SyntacticAnalysis.LR.ParserTable parser_table;

        #endregion

        #region Input

        private static IEnumerable<TerminalSymbol> BuildInput( ExtendedGrammar grammar, string input )
        {
            if( grammar == null )
                throw new ArgumentNullException("grammar");


            if( string.IsNullOrEmpty(input) )
            {
                return new TerminalSymbol[] { grammar.EndOfSourceSymbol };
            }

            if( input.EndsWith(grammar.EndOfSourceSymbol.Name) )
                input = input.Substring(0, input.Length - grammar.EndOfSourceSymbol.Name.Length);

            var name_to_tr = new Dictionary<string, TerminalSymbol>(grammar.Terminals.Count - 1);
            var regex_pattern = new StringBuilder();
            for( int i = 0; i < grammar.Terminals.Count - 1; ++i )
            {
                var tr = grammar.Terminals[i];

                name_to_tr[tr.Name] = tr;
                if( i > 0 )
                    regex_pattern.Append("|");
                regex_pattern.Append(System.Text.RegularExpressions.Regex.Escape(tr.Name));
            }

            string regex_pattern_str = regex_pattern.ToString();
            if( string.IsNullOrEmpty(regex_pattern_str) )
            {
                if( !string.IsNullOrEmpty(input) )
                    throw new ArgumentException("Hibás elem az input 0. helyén.");

                return new TerminalSymbol[] { grammar.EndOfSourceSymbol };
            }

            var regex = new System.Text.RegularExpressions.Regex(regex_pattern.ToString(),
                System.Text.RegularExpressions.RegexOptions.Singleline);

            var symnol_list = new List<TerminalSymbol>();
            int last_index = 0;
            foreach( System.Text.RegularExpressions.Match match in regex.Matches(input) )
            {
                if( !match.Success )
                    throw new ArgumentException("Nem tudtam feldolgozni az inputot!");

                // Check if there is an unmatched part
                if( match.Index > last_index )
                    throw new ArgumentException(string.Format("Hibás elem az inputban a {0}. helyen.", last_index));

                symnol_list.Add(name_to_tr[match.Value]);
                last_index += match.Length;
            }

            if( last_index < input.Length )
                throw new ArgumentException(string.Format("Hibás elem az inputban a {0}. helyen.", last_index));

            symnol_list.Add(grammar.EndOfSourceSymbol);
            return symnol_list;
        }

        #endregion

        #region Syntactic Parsing

        private SyntacticAnalysis.LR.Parser parser;
        private ColorScheme colors;

        private void Parser_PhaseChanged( object sender, EventArgs e )
        {
            switch( this.parser.Phase )
            {
            case SyntacticAnalysis.LR.ParsingPhase.NotParsing: break; // Do nothing
            case SyntacticAnalysis.LR.ParsingPhase.Error: this.OnError(); break;
            case SyntacticAnalysis.LR.ParsingPhase.Accept: this.OnAccept(); break;
            case SyntacticAnalysis.LR.ParsingPhase.Step1: this.OnStep1(); break;
            case SyntacticAnalysis.LR.ParsingPhase.Step2: this.OnStep2(); break;
            case SyntacticAnalysis.LR.ParsingPhase.Reduction1: this.OnReduction1(); break;
            case SyntacticAnalysis.LR.ParsingPhase.Reduction2: this.OnReduction2(); break;
            case SyntacticAnalysis.LR.ParsingPhase.Reduction3: this.OnReduction3(); break;

            default:
                throw new NotSupportedException(string.Format(
                    "ParserPhase '{0}' not supported.", this.parser.Phase.ToString()));
            }
        }

        private void OnError()
        {
            this.ParserStep_ToolButton.Enabled = false;
            this.ParserFastforward_ToolButton.Enabled = false;

            this.ParserView.StepsView.StepCount = 1;
            this.ParserView.StepsView.CurrentStep = 0;
            this.ParserView.ShowAction("Elemzés hibával ért véget", Color.Red); //TODO color
            this.ParserView.ShowInputSymbol(this.parser.CurrentInputSymbol.Name, this.colors.CurrentInputSymbol);
            this.ParserView.ShowState("Aktuális állapot:", this.parser.CurrentState.ToString(), this.colors.CurrentState);
            this.ParserView.HideRule();
            this.ParserView.StackView.ClearSymbolMarks();
            this.ParserView.StackView.MarkState(this.colors.CurrentState);

            this.ParserTable.ClearMarks();
            this.ParserTable.MarkState(this.parser.CurrentState, this.colors.CurrentState);
            this.ParserTable.MarkAction(this.parser.CurrentInputSymbol, this.colors.CurrentInputSymbol);

            this.DfsmView.MarkState(this.parser.CurrentState, this.colors.CurrentState);
        }

        private void OnAccept()
        {
            this.ParserStep_ToolButton.Enabled = false;
            this.ParserFastforward_ToolButton.Enabled = false;

            this.ParserView.StepsView.StepCount = 1;
            this.ParserView.StepsView.CurrentStep = 0;
            this.ParserView.ShowAction("Elemzés sikeresen véget ért", Color.Green); //TODO color
            this.ParserView.ShowInputSymbol(this.parser.CurrentInputSymbol.Name, this.colors.CurrentInputSymbol);
            this.ParserView.ShowState("Aktuális állapot:", this.parser.CurrentState.ToString(), this.colors.CurrentState);
            this.ParserView.HideRule();
            this.ParserView.StackView.ClearSymbolMarks();
            this.ParserView.StackView.MarkState(this.colors.CurrentState);

            this.ParserTable.ClearMarks();
            this.ParserTable.MarkState(this.parser.CurrentState, this.colors.CurrentState);
            this.ParserTable.MarkAction(this.parser.CurrentInputSymbol, this.colors.CurrentInputSymbol);

            this.DfsmView.MarkState(this.parser.CurrentState, this.colors.CurrentState);

            this.SyntacticTreeView.AddTopLevelNode(this.ext_grammar.StartSymbol.Name,
                this.SyntacticTreeView.TopLevelNodes.Count);
        }

        private void OnStep1()
        {
            this.ParserView.StepsView.StepCount = 2;
            this.ParserView.StepsView.CurrentStep = 0;
            this.ParserView.ShowAction(string.Format("Léptetés a {0}. állapotra", this.parser.ActionArgument));
            this.ParserView.ShowInputSymbol(this.parser.CurrentInputSymbol.Name, this.colors.CurrentInputSymbol);
            this.ParserView.ShowState("Aktuális állapot:", this.parser.CurrentState.ToString(), this.colors.CurrentState);
            this.ParserView.HideRule();
            this.ParserView.StackView.ClearSymbolMarks();
            this.ParserView.StackView.MarkState(this.colors.CurrentState);

            this.ParserTable.ClearMarks();
            this.ParserTable.MarkState(this.parser.CurrentState, this.colors.CurrentState);
            this.ParserTable.MarkAction(this.parser.CurrentInputSymbol, this.colors.CurrentInputSymbol);

            this.DfsmView.BeginUpdate();
            this.DfsmView.ClearStateMarks();
            this.DfsmView.MarkState(this.parser.CurrentState, this.colors.CurrentState);
            this.DfsmView.MarkTransition(this.parser.CurrentState, this.parser.CurrentInputSymbol,
                this.colors.CurrentInputSymbol, this.colors.CurrentInputSymbol);
            this.DfsmView.EndUpdate();
            if( this.DfsmViewAutoTarget_CheckBox.Checked )
                this.DfsmView.FocusMarkedItems();

            this.SyntacticTreeView.BeginUpdate();
            this.SyntacticTreeView.AddTopLevelNode(this.parser.CurrentInputSymbol.Name, 0);
            this.SyntacticTreeView.MarkNode(
                this.SyntacticTreeView.TopLevelNodes[this.SyntacticTreeView.TopLevelNodes.Count - 1],
                this.SyntacticTreeView.TopLevelNodeBackColor);
            this.SyntacticTreeView.EndUpdate();
            if( this.SyntacticTreeViewAutoTarget_CheckBox.Checked )
                this.SyntacticTreeView.FocusMarkedItems();
        }

        private void OnStep2()
        {
            this.ParserView.StepsView.CurrentStep = 1;
            this.ParserView.ShowState("Új állapot:", this.parser.ActionArgument.ToString(), this.colors.NewState);
            this.ParserView.ColorInputSymbol(Color.Empty);
            this.ParserView.StackView.Push(this.parser.Stack.TopState.ToString(), this.parser.Stack.TopSymbol.Name);
            this.ParserView.StackView.MarkState(this.colors.NewState);

            this.ParserView.InputText = this.ParserView.InputText.Substring(this.parser.Stack.TopSymbol.Name.Length);

            this.ParserTable.ClearMarks();
            this.ParserTable.MarkState(this.parser.CurrentState, this.colors.NewState);

            this.DfsmView.BeginUpdate();
            this.DfsmView.ClearStateMarks();
            this.DfsmView.ClearTransitionMarks();
            this.DfsmView.MarkState(this.parser.CurrentState, this.colors.NewState);
            this.DfsmView.EndUpdate();
            if( this.DfsmViewAutoTarget_CheckBox.Checked )
                this.DfsmView.FocusMarkedItems();

            this.SyntacticTreeView.ClearMarks();
        }

        private void OnReduction1()
        {
            int rule_ind = this.parser.Grammar.Rules.IndexOf(this.parser.ReductionRule);

            this.ParserView.StepsView.StepCount = 3;
            this.ParserView.StepsView.CurrentStep = 0;
            this.ParserView.ShowAction(string.Format("Redukálás a {0}. szabály szerint", rule_ind));
            this.ParserView.ShowState("Aktuális állapot:", this.parser.CurrentState.ToString(), this.colors.CurrentState);
            this.ParserView.ShowInputSymbol(this.parser.CurrentInputSymbol.Name, this.colors.CurrentInputSymbol);
            this.ParserView.ShowRule(rule_ind, this.parser.ReductionRule);
            this.ParserView.ColorRule(Color.Empty, this.colors.RuleLhsToReducate);
            this.ParserView.StackView.MarkState(this.colors.CurrentState);
            this.ParserView.StackView.MarkSymbols(this.parser.ReductionRule.RightHandSide.Count, this.colors.RuleLhsToReducate);

            this.ParserTable.ClearMarks();
            this.ParserTable.MarkState(this.parser.CurrentState, this.colors.CurrentState);
            this.ParserTable.MarkAction(this.parser.CurrentInputSymbol, this.colors.CurrentInputSymbol);

            this.DfsmView.BeginUpdate();
            this.DfsmView.ClearStateMarks();
            this.DfsmView.MarkState(this.parser.CurrentState, this.colors.CurrentState);
            for( int i = 0; i < this.parser.ReductionRule.RightHandSide.Count; ++i )
            {
                int index = this.parser.Stack.Count - this.parser.ReductionRule.RightHandSide.Count + i;

                this.DfsmView.MarkState(this.parser.Stack.States[index],
                    this.colors.RuleLhsToReducate);
                this.DfsmView.MarkTransition(
                    this.parser.Stack.States[index - 1],
                    this.parser.Stack.Symbols[index],
                    this.colors.RuleLhsToReducate,
                    this.colors.RuleLhsToReducate);
            }
            this.DfsmView.EndUpdate();
            if( this.DfsmViewAutoTarget_CheckBox.Checked )
                this.DfsmView.FocusMarkedItems();

            // Mark symbols to be reduced in the SyntacticTree
            if( this.parser.ReductionRule.RightHandSide.Count > 0 )
            {
                this.SyntacticTreeView.BeginUpdate();
                for( int i = 0; i < this.parser.ReductionRule.RightHandSide.Count; ++i )
                    this.SyntacticTreeView.MarkNode(
                        this.SyntacticTreeView.TopLevelNodes[this.SyntacticTreeView.TopLevelNodes.Count - 1 - i],
                        this.colors.RuleLhsToReducate);
                this.SyntacticTreeView.EndUpdate();
                if( this.SyntacticTreeViewAutoTarget_CheckBox.Checked )
                    this.SyntacticTreeView.FocusMarkedItems();
            }
        }

        private void OnReduction2()
        {
            this.ParserView.StepsView.CurrentStep = 1;
            this.ParserView.ShowState("Köztes állapot:", this.parser.CurrentState.ToString(), this.colors.NewState);
            this.ParserView.ColorInputSymbol(Color.Empty);
            this.ParserView.ColorRule(this.colors.CurrentInputSymbol, Color.Empty);
            this.ParserView.StackView.ClearSymbolMarks();
            this.ParserView.StackView.MarkState(this.colors.NewState);
            for( int i = 0; i < this.parser.ReductionRule.RightHandSide.Count; ++i )
                this.ParserView.StackView.Pop();

            this.ParserTable.ClearMarks();
            this.ParserTable.MarkState(this.parser.CurrentState, this.colors.NewState);
            this.ParserTable.MarkGoto(this.parser.GotoSymbol, this.colors.CurrentInputSymbol);

            this.DfsmView.BeginUpdate();
            this.DfsmView.ClearStateMarks();
            this.DfsmView.ClearTransitionMarks();
            this.DfsmView.MarkState(this.parser.CurrentState, this.colors.NewState);
            this.DfsmView.MarkTransition(this.parser.CurrentState, this.parser.ReductionRule.LeftHandSide,
                this.colors.CurrentInputSymbol, this.colors.CurrentInputSymbol);
            this.DfsmView.EndUpdate();
            if( this.DfsmViewAutoTarget_CheckBox.Checked )
                this.DfsmView.FocusMarkedItems();

            this.SyntacticTreeView.BeginUpdate();
            if( this.parser.ReductionRule.RightHandSide.Count == 0 )
            {
                this.SyntacticTreeView.AddTopLevelNode("ε", 0); // Add an extra epsilon symbol
                this.SyntacticTreeView.AddTopLevelNode(this.parser.ReductionRule.LeftHandSide.Name, 1);
            }
            else
            {
                //this.SyntacticTreeView.ClearMarks();
                this.SyntacticTreeView.AddTopLevelNode(this.parser.ReductionRule.LeftHandSide.Name, this.parser.ReductionRule.RightHandSide.Count);
            }
            this.SyntacticTreeView.MarkNode(
                this.SyntacticTreeView.TopLevelNodes[this.SyntacticTreeView.TopLevelNodes.Count - 1],
                this.colors.CurrentInputSymbol);
            this.SyntacticTreeView.EndUpdate();
            if( this.SyntacticTreeViewAutoTarget_CheckBox.Checked )
                this.SyntacticTreeView.FocusMarkedItems();
        }

        private void OnReduction3()
        {
            this.ParserView.StepsView.CurrentStep = 2;
            this.ParserView.StackView.Push(this.parser.Stack.TopState.ToString(), this.parser.Stack.TopSymbol.Name);
            this.ParserView.ShowState("Új állapot:", this.parser.CurrentState.ToString(), this.colors.NewState);
            this.ParserView.ColorRule(Color.Empty, Color.Empty);

            this.ParserTable.ClearMarks();
            this.ParserTable.MarkState(this.parser.CurrentState, this.colors.NewState);

            this.DfsmView.BeginUpdate();
            this.DfsmView.ClearStateMarks();
            this.DfsmView.ClearTransitionMarks();
            this.DfsmView.MarkState(this.parser.CurrentState, this.colors.NewState);
            this.DfsmView.EndUpdate();
            if( this.DfsmViewAutoTarget_CheckBox.Checked )
                this.DfsmView.FocusMarkedItems();

            this.SyntacticTreeView.ClearMarks();
        }

        #endregion

        #region User Commands

        private void Grammar_MenuItem_Click( object sender, EventArgs e )
        {
            if( this.parser.IsParsing )
                return; //TODO: ask user?

            using( var dlg = new GrammarForm() )
            {
                dlg.Text = "Nyelvtan szerkesztő";
                dlg.Grammar = this.ext_grammar != null ? this.ext_grammar.RestrictedGrammar.BaseGrammar : null;

                if( dlg.ShowDialog(this) == System.Windows.Forms.DialogResult.OK )
                {
                    try
                    {
                        var grammar = dlg.Grammar;
                        var rst_grammar = new RestrictedStartSymbolGrammar(grammar);
                        this.ext_grammar = new ExtendedGrammar(rst_grammar);
                        this.canonical_sets = SyntacticAnalysis.LR.LR0CanonicalSets.Build(rst_grammar);
                        this.epsilon_grammaticals = EpsilonGrammaticals.Build(grammar);
                        this.follow_sets = FollowSets.Build(this.ext_grammar, this.epsilon_grammaticals);
                        this.parser_table = SyntacticAnalysis.LR.SLR1ParserTableBuilder.Build(
                            this.ext_grammar, this.canonical_sets, this.follow_sets);
                    }
                    catch( Exception ex )
                    {
                        MessageBox.Show(this,
                            ex.Message, "A Nyelvtant nem tudom használni",
                            MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                        this.ext_grammar = null;
                        this.canonical_sets = null;
                        this.epsilon_grammaticals = null;
                        this.follow_sets = null;
                        this.parser_table = null;
                    }

                    // Update controls
                    if( this.ext_grammar != null )
                    {
                        this.ParserStart_ToolButton.Enabled = true;

                        this.ParserView.ClearInputHistory();

                        this.ParserTable.SetTable(this.ext_grammar, this.parser_table);

                        this.DfsmView.SetCanonicalSets(this.ext_grammar.RestrictedGrammar.BaseGrammar, this.canonical_sets);
                        this.DfsmView.Invalidate();

                        this.SyntacticTreeView.ClearNodes();
                    }
                    else
                    {
                        this.ParserStart_ToolButton.Enabled = false;
                    }
                }
            }
        }

        private void ParserStart_ToolButton_Click( object sender, EventArgs e )
        {
            //TODO: Check all requirements!
            if( this.ext_grammar == null || this.parser_table == null )
                //TODO: inform user
                return;

            using( var dlg = new ParserStartForm() )
            {
                dlg.StepIntervall = this.ParserTimer.Interval;

                if( dlg.ShowDialog(this) == System.Windows.Forms.DialogResult.OK )
                {
                    // Get the input
                    IEnumerable<TerminalSymbol> input;
                    try
                    {
                        string input_text = this.ParserView.InputText;
                        input = BuildInput(this.ext_grammar, input_text);
                        if( !input_text.EndsWith(this.ext_grammar.EndOfSourceSymbol.Name) )
                            input_text += this.ext_grammar.EndOfSourceSymbol.Name;
                        this.ParserView.InputText = input_text;
                        this.ParserView.AddToInputHistory(input_text);
                    }
                    catch( Exception ex )
                    {
                        MessageBox.Show(this, ex.Message, "Hibás input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }

                    // Start parsing
                    try
                    {
                        this.ParserView.StackView.Push("0", "#"); // Initial stack - for convention
                        this.parser.Start(this.ext_grammar, this.parser_table, input);
                    }
                    catch( Exception ex )
                    {
                        MessageBox.Show(this, ex.Message, "Hiba az elemzés indítása közben", 
                            MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }

                    if( dlg.AutoStep )
                    {
                        this.ParserTimer.Interval = dlg.StepIntervall;
                        this.ParserTimer.Enabled = true;
                        this.ParserStep_ToolButton.Enabled = false;
                    }
                    else
                    {
                        this.ParserStep_ToolButton.Enabled = true;
                    }

                    this.ParserView.InputEditEnabled = false;

                    this.Grammar_ToolButton.Enabled = false;
                    this.ParserStart_ToolButton.Enabled = false;
                    this.ParserFastforward_ToolButton.Enabled = true;
                    this.ParserStop_ToolButton.Enabled = true;
                }
            }
        }

        private void ParserStop_ToolButton_Click( object sender, EventArgs e )
        {
            this.ParserTimer.Enabled = false;
            this.parser.Stop();

            this.ParserView.StepsView.StepCount = 0;
            this.ParserView.InputEditEnabled = true;
            this.ParserView.StackView.Clear();
            this.ParserView.HideAction();
            this.ParserView.HideState();
            this.ParserView.HideInputSymbol();
            this.ParserView.HideRule();

            this.ParserTable.ClearMarks();

            this.DfsmView.BeginUpdate();
            this.DfsmView.ClearStateMarks();
            this.DfsmView.ClearTransitionMarks();
            this.DfsmView.EndUpdate();

            this.SyntacticTreeView.ClearNodes();

            this.Grammar_ToolButton.Enabled = true;
            this.ParserStart_ToolButton.Enabled = true;
            this.ParserStep_ToolButton.Enabled = false;
            this.ParserFastforward_ToolButton.Enabled = false;
            this.ParserStop_ToolButton.Enabled = false;
        }

        private void ParserStep_ToolButton_Click( object sender, EventArgs e )
        {
            if( this.parser.IsParsing && !this.parser.IsFinished )
                this.parser.StepPhase();
        }

        private void ParserFastforward_ToolButton_Click( object sender, EventArgs e )
        {
            this.ParserTimer.Enabled = false;
            this.ParserStep_ToolButton.Enabled = false;
            this.ParserFastforward_ToolButton.Enabled = false;

            while( !this.parser.IsFinished )
                this.parser.StepPhase();
        }

        private void Help_ToolButton_Click( object sender, EventArgs e )
        {
            try
            {
                using( var prc = new System.Diagnostics.Process() )
                {
                    prc.StartInfo.FileName = System.IO.Path.Combine(
                        System.IO.Path.GetDirectoryName(Application.ExecutablePath), "user-manual.pdf");
                    prc.Start();
                }
            }
            catch( Exception ex )
            {
                MessageBox.Show(this,
                    "Nem sikerült megnyitni a súgó fájlt.\n\n" + ex.Message, "Súgó",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion
    }
}
