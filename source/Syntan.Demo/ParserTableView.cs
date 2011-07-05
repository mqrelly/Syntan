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
    public partial class ParserTableView : UserControl
    {
        public ParserTableView()
        {
            InitializeComponent();
        }

        private SyntacticAnalysis.ExtendedGrammar grammar;
        private SyntacticAnalysis.LR.ParserTable table;

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public SyntacticAnalysis.ExtendedGrammar Grammar
        {
            get { return this.grammar; }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public SyntacticAnalysis.LR.ParserTable ParserTable
        {
            get { return this.table; }
        }

        public void SetTable( SyntacticAnalysis.ExtendedGrammar grammar, SyntacticAnalysis.LR.ParserTable table )
        {
            this.grammar = grammar;
            this.table = table;
            this.UpdateTable();
        }

        public void ClearMarks()
        {
            for( int i = 0; i < this.GridView.Rows.Count; ++i )
                for( int j = 0; j < this.GridView.Columns.Count; ++j )
                    this.GridView[j, i].Style.BackColor = SystemColors.Window;
        }

        public void MarkState( int state_index, Color color )
        {
            for( int j = 0; j < this.GridView.Columns.Count; ++j )
                this.GridView[j, state_index].Style.BackColor = color;
        }

        public void MarkGoto( SyntacticAnalysis.GrammaticalSymbol grammatical, Color color )
        {
            for( int i = 0; i < this.GridView.Rows.Count; ++i )
                this.GridView[this.grammar.Terminals.Count + 
                    this.grammar.Grammaticals.IndexOf(grammatical) - 1, i].Style.BackColor = color;
        }

        public void MarkAction( SyntacticAnalysis.TerminalSymbol terminal, Color color )
        {
            for( int i = 0; i < this.GridView.Rows.Count; ++i )
                this.GridView[this.grammar.Terminals.IndexOf(terminal), i].Style.BackColor = color;
        }

        private void UpdateTable()
        {
            this.GridView.Rows.Clear();
            this.GridView.Columns.Clear();

            if( this.table == null || this.grammar == null )
                return;

            // Actions
            for( int i = 0; i < this.grammar.Terminals.Count; ++i )
            {
                var column = new DataGridViewColumn();
                column.Name = string.Format("Action{0}_Column", i);
                column.HeaderText = this.grammar.Terminals[i].Name;
                column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter;
                column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter;

                this.GridView.Columns.Add(column);
            }

            // Gotos
            for( int i = 1; i < this.grammar.Grammaticals.Count; ++i )
            {
                var column = new DataGridViewColumn();
                column.Name = string.Format("Goto{0}_Column", i);
                column.HeaderText = this.grammar.Grammaticals[i].Name;
                column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter;
                column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter;

                this.GridView.Columns.Add(column);
            }

            // States
            for( int i = 0; i < this.table.StateCount; ++i )
            {
                var row = new DataGridViewRow();
                row.HeaderCell.Value = i.ToString();

                // Actions 
                for( int j = 0; j < this.grammar.Terminals.Count; ++j )
                {
                    var cell = new DataGridViewTextBoxCell();

                    var action = this.table.GetAction(i, j);
                    switch( action.Type )
                    {
                    case SyntacticAnalysis.LR.ParserTable.ActionType.Accept:
                        cell.Value = "accept";
                        break;

                    case SyntacticAnalysis.LR.ParserTable.ActionType.Reduction:
                        cell.Value = "r" + action.Argument.ToString();
                        break;

                    case SyntacticAnalysis.LR.ParserTable.ActionType.Step:
                        cell.Value = "s" + action.Argument.ToString();
                        break;

                    case SyntacticAnalysis.LR.ParserTable.ActionType.Error:
                        // Leave it empty
                        break;

                    default:
                        throw new InvalidProgramException();
                    }

                    row.Cells.Add(cell);
                }

                // Gotos
                for( int j = 1; j < this.grammar.Grammaticals.Count; ++j )
                {
                    var cell = new DataGridViewTextBoxCell();

                    int goto_state = this.table.GetGoto(i, j);
                    if( goto_state != -1 )
                        cell.Value = goto_state.ToString();

                    row.Cells.Add(cell);
                }

                this.GridView.Rows.Add(row);
            }
        }

        private void Table_GridView_SelectionChanged( object sender, EventArgs e )
        {
            if( this.GridView.SelectedCells.Count > 0 )
                this.GridView.ClearSelection();
        }
    }
}
