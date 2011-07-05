using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Syntan.SyntacticAnalysis.LR
{
    /// <summary>
    /// Parser class, that can use a <see cref="ParserTable"/> to do SLR(1), LR(1) or LALR(1) syntactic parsing.
    /// </summary>
    public class Parser
    {
        #region Constructor

        /// <summary>
        /// Default constructor.
        /// </summary>
        public Parser()
        {
            this.stack = new ParserStack();

            this.phase = ParsingPhase.NotParsing;
        }

        #endregion

        #region Private fields

        private ExtendedGrammar grammar;
        private ParserTable table;
        private ParserStack stack;

        private ParsingPhase phase;
        private IEnumerator<TerminalSymbol> input;
        private int step_count;
        private ParserTable.Action action;
        private Rule reduction_rule;
        private int goto_state;

        #endregion

        #region Parsing state information

        /// <summary>
        /// Gets the <see cref="ExtendedGrammar"/>, which is currently used for parsing.
        /// Undefined, if <see cref="IsParsing"/> is <c>false</c>.
        /// </summary>
        public ExtendedGrammar Grammar
        {
            get { return this.grammar; }
        }

        /// <summary>
        /// Gets the <see cref="ParserTable"/>, which is currently used for parsing.
        /// Undefined, if <see cref="IsParsing"/> is <c>false</c>.
        /// </summary>
        public ParserTable Table
        {
            get { return this.table; }
        }

        /// <summary>
        /// Gets the <see cref="ParserStack"/>.
        /// </summary>
        public ParserStack Stack
        {
            get { return this.stack; }
        }

        /// <summary>
        /// Returns <c>true</c>, if <see cref="Phase"/> is not equal to <see cref="ParsingPhase.NotParsing"/>,
        /// <c>false</c> otherwise.
        /// </summary>
        public bool IsParsing
        {
            get { return this.phase != ParsingPhase.NotParsing; }
        }

        /// <summary>
        /// Returns <c>true</c>, if <see cref="Phase"/> is <see cref="ParsingPhase.Accept"/> or
        /// <see cref="ParsingPhase.Error"/>, <c>false</c> otherwise.
        /// </summary>
        public bool IsFinished
        {
            get { return this.phase == ParsingPhase.Accept || this.phase == ParsingPhase.Error; }
        }

        /// <summary>
        /// Gets the current phase of this parser.
        /// </summary>
        public ParsingPhase Phase
        {
            get { return this.phase; }
        }

        /// <summary>
        /// Fires when <see cref="Phase"/> is changed.s
        /// </summary>
        public event EventHandler PhaseChanged;

        private void OnPhaseChanged()
        {
            if( this.PhaseChanged != null )
                this.PhaseChanged(this, EventArgs.Empty);
        }

        /// <summary>
        /// Gets the count of traditional steps was taken so far in the current parsing.
        /// </summary>
        public int StepCount
        {
            get { return this.step_count; }
        }

        /// <summary>
        /// Gets the current state. (<see cref="ParserStack.TopState"/>)
        /// </summary>
        public int CurrentState
        {
            get { return this.stack.TopState; }
        }

        /// <summary>
        /// Gets the current input <see cref="TerminalSymbol"/>.
        /// </summary>
        public TerminalSymbol CurrentInputSymbol
        {
            get { return this.input.Current; }
        }

        /// <summary>
        /// Gets the reduction-rule.
        /// Only valid when <see cref="Phase"/> is Reduction1, Reduction2 or Reduction3.
        /// </summary>
        public Rule ReductionRule
        {
            get { return this.reduction_rule; }
        }

        /// <summary>
        /// Gets the <see cref="ReductionRule"/>'s left hand side.
        /// Only valid when <see cref="Phase"/> is Reduction1, Reduction2 or Reduction3.
        /// </summary>
        public GrammaticalSymbol GotoSymbol
        {
            get { return this.reduction_rule.LeftHandSide; }
        }

        /// <summary>
        /// Gets the new state index to go into, after Reduction1.
        /// Only valid when <see cref="Phase"/> is Reduction1, Reduction2 or Reduction3.
        /// </summary>
        public int GotoState
        {
            get { return this.goto_state; }
        }

        /// <summary>
        /// Gets the int argument of the current <see cref="ParserTable.Action"/>.
        /// </summary>
        public int ActionArgument
        {
            get { return this.action.Argument; }
        }

        #endregion

        #region Parsing mechanism/control

        /// <summary>
        /// Starts the syntactic parsing of <paramref name="input"/> using the given <paramref name="grammar"/>,
        /// <paramref name="table"/>
        /// </summary>
        /// <param name="grammar">The grammar to be used for parsing.</param>
        /// <param name="table">The parser table to be used for parsing.</param>
        /// <param name="input">The input to be parsed.</param>
        /// <exception cref="ArgumentNullException"> if any of the parameters is <c>null</c>.</exception>
        /// <exception cref="InvalidOperationException"> if <see cref="IsParsing"/> is <c>true</c>.</exception>
        /// <exception cref="UnexpectedEndOfSourceException"> if the <paramref name="input"/> contains no 
        /// <see cref="TerminalSymbol"/>s.</exception>
        public void Start( ExtendedGrammar grammar, ParserTable table, IEnumerable<TerminalSymbol> input )
        {
            if( this.IsParsing )
                throw new InvalidOperationException("Parser is already parsing.");
            if( grammar == null )
                throw new ArgumentNullException("grammar");
            if( table == null )
                throw new ArgumentNullException("table");
            if( input == null )
                throw new ArgumentNullException("input");

            // Get grammar and table
            this.grammar = grammar;
            this.table = table;

            // Get input
            this.input = input.GetEnumerator();
            this.input.Reset();
            if( !this.input.MoveNext() )
                throw new UnexpectedEndOfSourceException("Input must contain at least the EndOfSource symbol.");

            // Start the actual parsing
            this.step_count = -1;
            this.stack.Clear();
            this.stack.Push(0, this.grammar.EndOfSourceSymbol);
            this.BeginNewPhase();
            this.OnPhaseChanged();
        }

        /// <summary>
        /// Stops the ongoing parsing. If it was not parsing, it will have no effect.
        /// </summary>
        public void Stop()
        {
            if( !this.IsParsing )
                return;

            this.phase = ParsingPhase.NotParsing;
            this.input = null;

            this.OnPhaseChanged();
        }

        /// <summary>
        /// Advances the parsing to the next phase. It can only be called, 
        /// when <see cref="IsParsing"/> is <c>true</c> and <see cref="IsFinished"/> is <c>false</c>.
        /// This will couse <see cref="PhaseChanged"/> to fire.
        /// </summary>
        /// <exception cref="InvalidOperationException"> if it's not parsing, or finished.</exception>
        public void StepPhase()
        {
            switch( this.phase )
            {
            case ParsingPhase.NotParsing:
            case ParsingPhase.Accept:
            case ParsingPhase.Error:
                throw new InvalidOperationException();

            case ParsingPhase.Reduction1:
                this.Reduction2();
                this.OnPhaseChanged();
                break;

            case ParsingPhase.Reduction2:
                this.Reduction3();
                this.OnPhaseChanged();
                break;

            case ParsingPhase.Step1:
                this.Step2();
                this.OnPhaseChanged();
                break;

            case ParsingPhase.Reduction3:
            case ParsingPhase.Step2:
                this.BeginNewPhase();
                this.OnPhaseChanged();
                break;

            default:
                throw new InternalParserException("New ParserPhases are not handeled.",
                    new NotSupportedException(string.Format("ParsingPhase '{0}' not supported.", this.phase.ToString())));
            }
        }

        private void BeginNewPhase()
        {
            this.action = this.table.GetAction(this.CurrentState, this.grammar.IndexOf(this.CurrentInputSymbol));
            switch( this.action.Type )
            {
            case ParserTable.ActionType.Accept:
                this.phase = ParsingPhase.Accept;
                break;

            case ParserTable.ActionType.Error:
                this.phase = ParsingPhase.Error;
                break;

            case ParserTable.ActionType.Reduction:
                this.Reduction1();
                break;

            case ParserTable.ActionType.Step:
                this.Step1();
                break;

            default:
                throw new NotSupportedException(string.Format("ActionType '{0}' not supported.", this.action.Type.ToString()));
            }

            this.step_count += 1;
        }

        private void Step1()
        {
#if DEBUG
            if( this.action.Type != ParserTable.ActionType.Step )
                throw new InternalParserException(string.Format(
                    "Internal state is {0}, but ActionType.Step expected.",
                    this.action.Type));
#endif

            this.phase = ParsingPhase.Step1;
        }

        private void Step2()
        {
#if DEBUG
            if( this.action.Type != ParserTable.ActionType.Step )
                throw new InternalParserException(string.Format(
                    "Internal state is {0}, but ActionType.Reduction expected.",
                    this.action.Type));

            if( this.phase != ParsingPhase.Step1 )
                throw new InternalParserException(string.Format(
                    "Internal phase is {0}, but ParsingPhase.Step1 expected.",
                    this.phase));
#endif

            this.phase = ParsingPhase.Step2;
            this.stack.Push(this.action.Argument, this.CurrentInputSymbol);

            if( !this.input.MoveNext() )
                throw new UnexpectedEndOfSourceException();
        }

        private void Reduction1()
        {
#if DEBUG
            if( this.action.Type != ParserTable.ActionType.Reduction )
                throw new InternalParserException(string.Format(
                    "Internal state is {0}, but ActionType.Reduction expected.",
                    this.action.Type));
#endif

            this.phase = ParsingPhase.Reduction1;
            this.reduction_rule = this.grammar.Rules[this.action.Argument];
        }

        private void Reduction2()
        {
#if DEBUG
            if( this.action.Type != ParserTable.ActionType.Reduction )
                throw new InternalParserException(string.Format(
                    "Internal state is {0}, but ActionType.Reduction expected.",
                    this.action.Type));

            if( this.phase != ParsingPhase.Reduction1 )
                throw new InternalParserException(string.Format(
                    "Internal phase is {0}, but ParsingPhase.Reduction1 expected.",
                    this.phase));
#endif

            this.phase = ParsingPhase.Reduction2;
            for( int i = 0; i < this.reduction_rule.RightHandSide.Count; ++i )
                this.stack.Pop();
            this.goto_state = this.table.GetGoto(this.CurrentState, this.grammar.IndexOf(this.reduction_rule.LeftHandSide));
            if( this.goto_state == -1 )
                this.phase = ParsingPhase.Error;
        }

        private void Reduction3()
        {
#if DEBUG
            if( this.action.Type != ParserTable.ActionType.Reduction )
                throw new InternalParserException(string.Format(
                    "Internal state is {0}, but ActionType.Reduction expected.",
                    this.action.Type));

            if( this.phase != ParsingPhase.Reduction2 )
                throw new InternalParserException(string.Format(
                    "Internal phase is {0}, but ParsingPhase.Reduction2 expected.",
                    this.phase));
#endif

            this.phase = ParsingPhase.Reduction3;
            this.stack.Push(this.goto_state, this.reduction_rule.LeftHandSide);
            this.reduction_rule = null;
        }

        #endregion
    }
}
