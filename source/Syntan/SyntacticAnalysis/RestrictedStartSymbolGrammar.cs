using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Syntan.SyntacticAnalysis
{
    /// <summary>
    /// This grammar class extends a <see cref="Grammar"/> in a way, that the start-symbol
    /// will only appear on the left hand side of the one start-rule.
    /// This class is immutable.
    /// </summary>
    [Serializable]
    public class RestrictedStartSymbolGrammar : IGrammar, ISerializable
    {
        /// <summary>
        /// Creates a new instance from the given <paramref name="base_grammar"/>.
        /// </summary>
        /// <param name="base_grammar">This grammar will extend on this grammar.</param>
        public RestrictedStartSymbolGrammar( Grammar base_grammar )
        {
            if( base_grammar == null )
                throw new ArgumentNullException("base_grammar");

            this.base_gr = base_grammar;
            this.Initialize();
        }

        private void Initialize()
        {
            var old_start_sym = this.base_gr.StartSymbol;
            var rules = new List<Rule>(this.base_gr.Rules.Count + 1);
            rules.AddRange(this.base_gr.Rules);
            var start_rules = rules.FindAll(r => r.LeftHandSide == old_start_sym);

            if( rules.Find(r => r.RightHandSide.Contains(old_start_sym)) != null ||
                start_rules.Count > 1 )
            {
                // New start symbol, and new start rule
                string new_start_sym_name = "S'";
                while( this.base_gr.Grammaticals.FirstOrDefault(gr => gr.Name == new_start_sym_name) != null )
                    new_start_sym_name += "'";

                var new_start_sym = new GrammaticalSymbol(new_start_sym_name);
                var grammaticals = new List<GrammaticalSymbol>(this.base_gr.Grammaticals.Count + 1);
                grammaticals.Add(new_start_sym);
                grammaticals.AddRange(this.base_gr.Grammaticals);
                this.grammaticals = grammaticals.AsReadOnly();

                var new_start_rule = new Rule(new_start_sym, new Symbol[] { old_start_sym });
                rules.Insert(0, new_start_rule);
                this.rules = rules.AsReadOnly();
            }
            else
            {
                if( this.base_gr.IndexOf(old_start_sym) != 0 )
                {
                    int old_ind = this.base_gr.IndexOf(old_start_sym);
                    var grammaticals = new List<GrammaticalSymbol>(this.base_gr.Grammaticals);
                    grammaticals.RemoveAt(old_ind);
                    grammaticals.Insert(0, old_start_sym);
                    this.grammaticals = grammaticals.AsReadOnly();
                }
                else
                {
                    this.grammaticals = this.base_gr.Grammaticals;
                }

                if( start_rules.Count == 0 )
                {
                    // New epsilon start rule.
                    var new_start_rule = new Rule(old_start_sym, new Symbol[0]);
                    rules.Insert(0, new_start_rule);
                    this.rules = rules.AsReadOnly();
                }
                else if( rules[0] != start_rules[0] )
                {
                    // Reorder to be the first rule.
                    var old_start_rule = start_rules[0];
                    rules.Remove(old_start_rule);
                    rules.Insert(0, old_start_rule);
                    this.rules = rules.AsReadOnly();
                }
                else
                {
                    // Rules are fine.
                    this.rules = this.base_gr.Rules;
                }
            }
        }

        private Grammar base_gr;
        private IList<GrammaticalSymbol> grammaticals;
        private IList<Rule> rules;

        /// <summary>
        /// Gets the <see cref="Grammar"/>, on which this grammar is based.
        /// </summary>
        public Grammar BaseGrammar
        {
            get { return this.base_gr; }
        }

        /// <summary>
        /// Gets the terminals of the grammar as a read-only list of <see cref="TerminalSymbol"/>.
        /// </summary>
        public IList<TerminalSymbol> Terminals
        {
            get { return this.base_gr.Terminals; }
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
        /// Gets the start-symbol of the grammar. The first in <see cref="Grammaticals"/>.
        /// </summary>
        public GrammaticalSymbol StartSymbol
        {
            get { return this.grammaticals[0]; }
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

        RestrictedStartSymbolGrammar( SerializationInfo info, StreamingContext context )
        {
            this.base_gr = (Grammar)info.GetValue("BaseGrammar", typeof(Grammar));
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
