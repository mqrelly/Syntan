using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Syntan.SyntacticAnalysis
{
    /// <summary>
    /// Extends the given <see cref="RestrictedStartSymbolGrammar"/> with an <see cref="EndOfSourceSymbol"/>;
    /// and changes the start-rule to end with this new EoS symbol.
    /// </summary>
    [Serializable]
    public class ExtendedGrammar : IGrammar, ISerializable
    {
        /// <summary>
        /// Creates a new instance with the given <paramref name="grammar"/> as the base grammar.
        /// </summary>
        /// <param name="grammar">The grammar to extend.</param>
        public ExtendedGrammar( RestrictedStartSymbolGrammar grammar )
        {
            if( grammar == null )
                throw new ArgumentNullException("grammar");

            this.base_gr = grammar;
            this.Initialize();
        }

        private void Initialize()
        {
            this.eos = new EndOfSourceSymbol();
            var terminals = new List<TerminalSymbol>(this.base_gr.Terminals);
            terminals.Add(this.eos);
            this.terminals = terminals.AsReadOnly();

            var start_rule_rhs = new List<Symbol>(this.base_gr.StartRule.RightHandSide.Count + 1);
            start_rule_rhs.AddRange(this.base_gr.StartRule.RightHandSide);
            start_rule_rhs.Add(this.eos);

            var rules = new List<Rule>(this.base_gr.Rules);
            rules[0] = new Rule(this.base_gr.StartSymbol, start_rule_rhs);
            this.rules = rules.AsReadOnly();
        }

        private RestrictedStartSymbolGrammar base_gr;

        private IList<TerminalSymbol> terminals;
        private IList<Rule> rules;
        private EndOfSourceSymbol eos;

        /// <summary>
        /// Gets the basic grammar used to build this one.
        /// </summary>
        public RestrictedStartSymbolGrammar RestrictedGrammar
        {
            get { return this.base_gr; }
        }

        /// <summary>
        /// Gets the terminals of the grammar as a read-only list of <see cref="TerminalSymbol"/>.
        /// </summary>
        public IList<TerminalSymbol> Terminals
        {
            get { return this.terminals; }
        }

        /// <summary>
        /// Gets the grammaticals of the grammar as a read-only list of <see cref="GrammaticalSymbol"/>.
        /// </summary>
        public IList<GrammaticalSymbol> Grammaticals
        {
            get { return this.base_gr.Grammaticals; }
        }

        /// <summary>
        /// Gets the rules of the grammar as a read-only list of <see cref="Rule"/>.
        /// </summary>
        public IList<Rule> Rules
        {
            get { return this.rules; }
        }

        /// <summary>
        /// Gets the EoS symbol in this grammar.
        /// </summary>
        public EndOfSourceSymbol EndOfSourceSymbol
        {
            get { return this.eos; }
        }

        /// <summary>
        /// Gets the start-symbol of the grammar. Usuly the first in <see cref="Grammaticals"/>.
        /// </summary>
        public GrammaticalSymbol StartSymbol
        {
            get { return this.base_gr.StartSymbol; }
        }

        /// <summary>
        /// Gets the start-rule of the grammar. That is the only rule,
        /// that has the <see cref="StartRule"/> as the left hand side.
        /// The first in <see cref="Rules"/>.
        /// </summary>
        public Rule StartRule
        {
            get { return this.rules[0]; }
        }

        /// <summary>
        /// Returns the index og the given <paramref name="symbol"/>.
        /// </summary>
        /// <param name="symbol"></param>
        /// <returns>The index of the given grammatical, or <c>-1</c> if the symbol is not part of this grammar.</returns>
        public int IndexOf( GrammaticalSymbol symbol )
        {
            return this.Grammaticals.IndexOf(symbol);
        }

        /// <summary>
        /// Returns the index og the given <paramref name="symbol"/>.
        /// </summary>
        /// <param name="symbol"></param>
        /// <returns>The index of the given terminal, or <c>-1</c> if the symbol is not part of this grammar.</returns>
        public int IndexOf( TerminalSymbol symbol )
        {
            return this.Terminals.IndexOf(symbol);
        }

        /// <summary>
        /// Returns an index unique among symbols from the same grammar.
        /// (terminals first, grammaticals second)
        /// </summary>
        /// <param name="symbol"></param>
        /// <returns>The index of the given symbol, <c>-1</c> if symbol not part of this grammar.</returns>
        public int GlobalIndexOf( Symbol symbol )
        {
            if( symbol is TerminalSymbol )
                return this.Terminals.IndexOf((TerminalSymbol)symbol);
            else
                return this.Terminals.Count + this.Grammaticals.IndexOf((GrammaticalSymbol)symbol);
        }

        /// <summary>
        /// Returns an index unique among symbols from the same grammar.
        /// (terminals first, grammaticals second)
        /// </summary>
        /// <param name="symbol"></param>
        /// <returns>The index of the given symbol, <c>-1</c> if symbol not part of this grammar.</returns>
        public int GlobalIndexOf( GrammaticalSymbol symbol )
        {
            return this.Terminals.Count + this.Grammaticals.IndexOf((GrammaticalSymbol)symbol);
        }

        /// <summary>
        /// Returns an index unique among symbols from the same grammar.
        /// (terminals first, grammaticals second)
        /// </summary>
        /// <param name="symbol"></param>
        /// <returns>The index of the given symbol, <c>-1</c> if symbol not part of this grammar.</returns>
        public int GlobalIndexOf( TerminalSymbol symbol )
        {
            return this.Terminals.IndexOf(symbol);
        }

        #region ISerializable Members

        ExtendedGrammar( SerializationInfo info, StreamingContext context )
        {
            this.base_gr = (RestrictedStartSymbolGrammar)info.GetValue("BaseGrammar", typeof(RestrictedStartSymbolGrammar));
            this.Initialize();
        }

        /// <summary>
        /// Custom serialization code.
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        public void GetObjectData( SerializationInfo info, StreamingContext context )
        {
            info.AddValue("BaseGrammar", this.base_gr);
        }

        #endregion
    }
}
