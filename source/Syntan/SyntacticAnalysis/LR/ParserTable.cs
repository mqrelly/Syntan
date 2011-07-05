using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Syntan.SyntacticAnalysis.LR
{
    /// <summary>
    /// Represents a parser-table. It provides means to set and get actions and goto state indices
    /// for LR parsing.
    /// </summary>
    [Serializable]
    public class ParserTable
    {
        /// <summary>
        /// Type of an <see cref="Action"/>.
        /// </summary>
        [Serializable]
        public enum ActionType
        {
            /// <summary>
            /// Indicates an error in the input.
            /// </summary>
            Error,

            /// <summary>
            /// A stepping move in the input stream is needed. Has an <see cref="int"/> argument, to tell to which state 
            /// the state-machine parser must go after the stepping.
            /// </summary>
            Step,

            /// <summary>
            /// A reduction is needed. Has an <see cref="int"/> arguemnt, to tell with which rule must the reduction
            /// be performed.
            /// </summary>
            Reduction,

            /// <summary>
            /// Marks the successful ending of the parsing procedure.
            /// </summary>
            Accept,
        }

        /// <summary>
        /// Represents an action in the table's one cell.
        /// This stuct is immutable.
        /// </summary>
        [Serializable]
        public struct Action
        {
            /// <summary>
            /// The type of this action.
            /// </summary>
            public readonly ActionType Type;

            /// <summary>
            /// The optional arument for the action <see cref="ActionType.Step"/>
            /// </summary>
            public readonly int Argument;

            private Action( ActionType type, int arg )
                : this()
            {
                this.Type = type;
                this.Argument = arg;
            }

            /// <summary>
            /// Creates an <see cref="ActionType.Error"/> typed action.
            /// </summary>
            /// <returns></returns>
            public static Action Error()
            {
                return new Action(ActionType.Error, 0);
            }

            /// <summary>
            /// Creates an <see cref="ActionType.Step"/> typed action.
            /// </summary>
            /// <param name="arg"></param>
            /// <returns></returns>
            public static Action Step( int arg )
            {
                return new Action(ActionType.Step, arg);
            }

            /// <summary>
            /// Creates an <see cref="ActionType.Reduction"/> typed action.
            /// </summary>
            /// <param name="arg"></param>
            /// <returns></returns>
            public static Action Reduction( int arg )
            {
                return new Action(ActionType.Reduction, arg);
            }

            /// <summary>
            /// Creates an <see cref="ActionType.Accept"/> typed action.
            /// </summary>
            /// <returns></returns>
            public static Action Accept()
            {
                return new Action(ActionType.Accept, 0);
            }
        }


        /// <summary>
        /// Creates a new instance with the given dimensions.
        /// </summary>
        /// <param name="state_count">The number of states.</param>
        /// <param name="terminal_count">The number of <see cref="TerminalSymbol"/>s.</param>
        /// <param name="grammatical_count">The number of <see cref="GrammaticalSymbol"/>s.</param>
        /// <exception cref="ArgumentOutOfRangeException"> if any of the parameters is not positive.</exception>
        public ParserTable( int state_count, int terminal_count, int grammatical_count )
        {
            if( state_count <= 0 )
                throw new ArgumentOutOfRangeException("state_count");
            if( terminal_count <= 0 )
                throw new ArgumentOutOfRangeException("terminal_count");
            if( grammatical_count <= 0 )
                throw new ArgumentOutOfRangeException("grammatical_count");

            this.state_count = state_count;
            this.terminal_count = terminal_count;
            this.grammatical_count = grammatical_count;

            this.actions = new Action[state_count, terminal_count];
            for( int i = 0; i < state_count; ++i )
                for( int j = 0; j < terminal_count; ++j )
                    this.actions[i, j] = Action.Error();

            this.gotos = new int[state_count, grammatical_count];
        }

        private int state_count;
        private int terminal_count;
        private int grammatical_count;
        private Action[,] actions;
        private int[,] gotos;

        /// <summary>
        /// Gets the number of states represented in this table.
        /// </summary>
        public int StateCount
        {
            get { return this.state_count; }
        }

        /// <summary>
        /// Gets the number of <see cref="TerminalSymbol"/>s represented in this table.
        /// </summary>
        public int TerminalCount
        {
            get { return this.terminal_count; }
        }

        /// <summary>
        /// Gets the number of <see cref="GrammaticalSymbol"/>s represented in this table.
        /// </summary>
        public int GrammaticalCount
        {
            get { return this.grammatical_count; }
        }

        /// <summary>
        /// Gets what <see cref="Action"/> is associated with the given <paramref name="state_index"/> and <paramref name="terminal_index"/> combination.
        /// </summary>
        /// <param name="state_index">The current state index.</param>
        /// <param name="terminal_index">The terminal's index.s</param>
        /// <returns>The action that must be followed.</returns>
        public Action GetAction( int state_index, int terminal_index )
        {
            return this.actions[state_index, terminal_index];
        }

        /// <summary>
        /// Associating an <see cref="Action"/> with a <paramref name="state_index"/> and <paramref name="terminal_index"/> combination.
        /// </summary>
        /// <param name="state_index">The current state index.</param>
        /// <param name="terminal_index">The terminal's index.</param>
        /// <param name="action">The action.</param>
        public void SetAction( int state_index, int terminal_index, Action action )
        {
            this.actions[state_index, terminal_index] = action;
        }

        /// <summary>
        /// Gets what state to go to after a reduction.
        /// </summary>
        /// <param name="state_index">The current state index.</param>
        /// <param name="grammatical_index">The reducting rule's left hand side's index.</param>
        /// <returns>The state index to set the state-machine to, after a reduction. <c>-1</c> indicating an error.</returns>
        public int GetGoto( int state_index, int grammatical_index )
        {
            return this.gotos[state_index, grammatical_index] - 1;
        }

        /// <summary>
        /// Sets what state to go to after a reduction.
        /// </summary>
        /// <param name="state_index">The current state index.</param>
        /// <param name="grammatical_index">The reducting rule's left hand side's index.</param>
        /// <param name="arg">The state index to set the state-machine to, after a reduction. <c>-1</c> indicating an error.</param>
        public void SetGoto( int state_index, int grammatical_index, int arg )
        {
            this.gotos[state_index, grammatical_index] = arg + 1;
        }
    }
}
