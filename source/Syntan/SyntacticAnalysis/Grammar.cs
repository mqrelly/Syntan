using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Syntan.SyntacticAnalysis
{
    /// <summary>
    /// A basic implementation of <see cref="IGrammar"/>.
    /// This class is immutable.
    /// </summary>
    [Serializable]
    public class Grammar : ISerializable, IGrammar
    {
        #region Static Empty grammar instance

        /// <summary>
        /// Empty grammar instance, the minimal grammar. It still has 1 start symbol and 1 rule S-> epsilon.
        /// </summary>
        public static readonly Grammar EmptyGrammar;

        static Grammar()
        {
            var start_sym = new GrammaticalSymbol("S");
            EmptyGrammar = new Grammar(
                new TerminalSymbol[0],
                new GrammaticalSymbol[] { start_sym },
                new Rule[] { new Rule(start_sym, new Symbol[0]) },
                0);
        }

        #endregion

        /// <summary>
        /// Creates a new grammar instance from the given symbols and rules.
        /// There must be at least a start-symbol and a start-rule.
        /// </summary>
        /// <param name="terminals">The terminals of the grammar.</param>
        /// <param name="grammaticals">The grammaticals of the grammar. The first one will be the start-symbol.</param>
        /// <param name="rules">The rules of the grammar.</param>
        /// <param name="start_symbol_index">The index of selected grammatical to be the <see cref="StartSymbol"/></param>
        /// <exception cref="ArgumentNullException"> if any of the arguments is <c>null</c>.</exception>
        /// <exception cref="InvalidEndOfSourceSymbolException"> if <paramref name="terminals"/> 
        /// contain an <see cref="EndOfSourceSymbol"/>.</exception>
        /// <exception cref="MissingStartSymbolException"> if <paramref name="grammaticals"/> is empty.</exception>
        /// <exception cref="MissingStartRuleException"> if <paramref name="rules"/> is empty.</exception>
        /// <exception cref="ForeignSymbolInRuleException"> if a rule contains a <see cref="Symbol"/> 
        /// other than one from this grammar.</exception>
        /// <exception cref="ArgumentOutOfRangeException"> if <paramref name="start_symbol_index"/> is less than <c>0</c>
        /// or equal or greater than <c>grammatical.Count</c>.</exception>
        public Grammar(
            IEnumerable<TerminalSymbol> terminals,
            IEnumerable<GrammaticalSymbol> grammaticals,
            IEnumerable<Rule> rules,
            int start_symbol_index )
        {
            if( object.ReferenceEquals(terminals, null) )
                throw new ArgumentNullException("terminals");
            if( object.ReferenceEquals(grammaticals, null) )
                throw new ArgumentNullException("grammaticals");
            if( object.ReferenceEquals(rules, null) )
                throw new ArgumentNullException("rules");


            this.terminals = new List<TerminalSymbol>(terminals).AsReadOnly();
            this.grammaticals = new List<GrammaticalSymbol>(grammaticals).AsReadOnly();
            this.start_symb_ind = start_symbol_index;
            this.rules = new List<Rule>(rules).AsReadOnly();

            // Consistency checking

            if( this.terminals.FirstOrDefault(tr => tr is EndOfSourceSymbol) != null )
                throw new InvalidEndOfSourceSymbolException();

            if( this.grammaticals.Count == 0 )
                throw new MissingStartSymbolException();

            if( this.start_symb_ind < 0 || this.start_symb_ind >= this.grammaticals.Count )
                throw new ArgumentOutOfRangeException("start_symbol_index");

            if( this.rules.Count == 0 )
                throw new MissingStartRuleException();

            // Check if rules only contain symbols of this grammar
            foreach( var rule in this.rules )
            {
                if( this.grammaticals.IndexOf(rule.LeftHandSide) == -1 )
                    throw new ForeignSymbolInRuleException(rule, rule.LeftHandSide);

                foreach( var symb in rule.RightHandSide )
                    if( symb is GrammaticalSymbol )
                    {
                        if( this.grammaticals.IndexOf((GrammaticalSymbol)symb) == -1 )
                            throw new ForeignSymbolInRuleException(rule, symb);
                    }
                    else
                    {
                        if( this.terminals.IndexOf((TerminalSymbol)symb) == -1 )
                            throw new ForeignSymbolInRuleException(rule, symb);
                    }
            }
        }

        private IList<TerminalSymbol> terminals;
        private IList<GrammaticalSymbol> grammaticals;
        private IList<Rule> rules;
        private int start_symb_ind;

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
            get { return this.grammaticals; }
        }

        /// <summary>
        /// Gets the rules of the grammar as a read-only list of <see cref="Rule"/>.
        /// </summary>
        public IList<Rule> Rules
        {
            get { return this.rules; }
        }

        /// <summary>
        /// Gets the start-symbol of the grammar.
        /// </summary>
        public GrammaticalSymbol StartSymbol
        {
            get { return this.grammaticals[this.start_symb_ind]; }
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

        [Serializable]
        private struct SymbolRep
        {
            public bool IsGrammatical;
            public int Index;
        }

        [Serializable]
        private class RuleRep
        {
            public int LhsIndex;
            public SymbolRep[] RhsSymbols;
        }

        Grammar( SerializationInfo info, StreamingContext context )
        {
            this.grammaticals = (IList<GrammaticalSymbol>)info.GetValue("Grammaticals", typeof(IList<GrammaticalSymbol>));
            this.start_symb_ind = info.GetInt32("StartSymbolInd");
            this.terminals = (IList<TerminalSymbol>)info.GetValue("Terminals", typeof(IList<TerminalSymbol>));

            var rules_rep = (List<RuleRep>)info.GetValue("Rules", typeof(List<RuleRep>));
            var rules_ = new List<Rule>(rules_rep.Count);
            this.rules = rules_.AsReadOnly();
            foreach( var rule_rep in rules_rep )
                rules_.Add(new Rule(
                    this.grammaticals[rule_rep.LhsIndex],
                    rule_rep.RhsSymbols.Select(
                       symbol_rep => symbol_rep.IsGrammatical ?
                           (Symbol)this.grammaticals[symbol_rep.Index] :
                           (Symbol)this.terminals[symbol_rep.Index])));
        }

        /// <summary>
        /// Custom serialization code.
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        public void GetObjectData( SerializationInfo info, StreamingContext context )
        {
            info.AddValue("Grammaticals", this.grammaticals);
            info.AddValue("StartSymbolInd", this.start_symb_ind);
            info.AddValue("Terminals", this.terminals);

            var rules_rep = new List<RuleRep>(this.rules.Count);
            foreach( var rule in this.rules )
                rules_rep.Add(new RuleRep()
                    {
                        LhsIndex = this.Grammaticals.IndexOf(rule.LeftHandSide),
                        RhsSymbols = rule.RightHandSide.Select(
                            symbol => new SymbolRep()
                            {
                                IsGrammatical = symbol is GrammaticalSymbol,
                                Index = symbol is GrammaticalSymbol
                                        ? this.IndexOf((GrammaticalSymbol)symbol)
                                        : this.IndexOf((TerminalSymbol)symbol)
                            }).ToArray(),
                    });

            info.AddValue("Rules", rules_rep);
        }

        #endregion
    }
}
