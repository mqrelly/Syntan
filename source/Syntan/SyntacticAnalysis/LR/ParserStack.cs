using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Syntan.SyntacticAnalysis.LR
{
    /// <summary>
    /// Implements a double-stack for LR parsers (i.e. <see cref="Parser"/>).
    /// </summary>
    [Serializable]
    public class ParserStack : System.Runtime.Serialization.ISerializable
    {
        /// <summary>
        /// Creates a new empty instance.
        /// </summary>
        public ParserStack()
        {
            this.states = new List<int>();
            this.States = this.states.AsReadOnly();
            this.symbols = new List<Symbol>();
            this.Symbols = this.symbols.AsReadOnly();
        }

        ParserStack( System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context )
        {
            this.states = (List<int>)info.GetValue("States", typeof(List<int>));
            this.States = this.states.AsReadOnly();
            this.symbols = (List<Symbol>)info.GetValue("Symbols", typeof(List<Symbol>));
            this.Symbols = this.symbols.AsReadOnly();
        }

        private List<int> states;
        private List<Symbol> symbols;

        /// <summary>
        /// Gets the number of element pairs in this stack.
        /// </summary>
        public int Count
        {
            get { return this.states.Count; }
        }

        /// <summary>
        /// Gets a read-only list of state indices in this stack.
        /// Indexing starts from the bottom of the stack.
        /// </summary>
        public IList<int> States { get; private set; }

        /// <summary>
        /// Gets a read-only list of <see cref="Symbol"/>s in this stack.
        /// Indexing starts from the bottom of the stack.
        /// </summary>
        public IList<Symbol> Symbols { get; private set; }

        /// <summary>
        /// Gets the <see cref="Symbol"/> from the top of this stack.
        /// </summary>
        /// <exception cref="IndexOutOfRangeException"> if the stack is empty.</exception>
        public Symbol TopSymbol
        {
            get { return this.symbols[this.symbols.Count - 1]; }
        }

        /// <summary>
        /// Gets the top state index from the top of this stack.
        /// </summary>
        /// <exception cref="IndexOutOfRangeException"> if the stack is empty.</exception>
        public int TopState
        {
            get { return this.states[this.states.Count - 1]; }
        }

        /// <summary>
        /// Puts a new element pair on the top of this stack.
        /// </summary>
        /// <param name="state">The state index.</param>
        /// <param name="symbol">The symbol.</param>
        public void Push( int state, Symbol symbol )
        {
            this.states.Add(state);
            this.symbols.Add(symbol);
        }

        /// <summary>
        /// Removes the top elemnt pair from this stack.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException"> if the stack is empty.</exception>
        public void Pop()
        {
            this.states.RemoveAt(this.states.Count - 1);
            this.symbols.RemoveAt(this.symbols.Count - 1);
        }

        /// <summary>
        /// Removes all elemet pairs from this stack.
        /// </summary>
        public void Clear()
        {
            this.states.Clear();
            this.symbols.Clear();
        }

        #region ISerializable Members

        /// <summary>
        /// Custom serialization code.
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        public void GetObjectData( System.Runtime.Serialization.SerializationInfo info, 
            System.Runtime.Serialization.StreamingContext context )
        {
            info.AddValue("States", this.states);
            info.AddValue("Symbols", this.symbols);
        }

        #endregion
    }
}
