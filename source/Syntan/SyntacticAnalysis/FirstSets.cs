using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Syntan.Utils;

namespace Syntan.SyntacticAnalysis
{
    /// <summary>
    /// Calculates the first sets for all grammaticals of a <see cref="ExtendedGrammar"/>.
    /// </summary>
    public static class FirstSets
    {
        /// <summary>
        /// Calculates the first sets of all grammaticals of the given <paramref name="grammar"/>.
        /// </summary>
        /// <param name="grammar">The grammaticals which are to examen, are in this grammar.</param>
        /// <param name="epsilon_grammaticals">Set of the epsilon capable grammaticals of the given 
        /// <paramref name="grammar"/>. (see <see cref="EpsilonGrammaticals"/>)</param>
        /// <returns>The first sets for all the grammaticals of the given <paramref name="grammar"/>.</returns>
        /// <exception cref="ArgumentNullException"> if any of the parameters is <c>null</c>.</exception>
        public static IDictionary<GrammaticalSymbol, ISet<TerminalSymbol>> Build(
            ExtendedGrammar grammar, ISet<GrammaticalSymbol> epsilon_grammaticals )
        {
            if( grammar == null )
                throw new ArgumentNullException("grammar");
            if( epsilon_grammaticals == null )
                throw new ArgumentNullException("epsilon_grammaticals");

            // Relation matrix
            var f_plus = new RelationMatrix(grammar.Terminals.Count + grammar.Grammaticals.Count);
            RelationMatrix.TransitiveClosure(F_Relation(grammar), f_plus);

            // Build the first_sets
            var first_sets = new Dictionary<GrammaticalSymbol, ISet<TerminalSymbol>>();
            foreach( var gr in grammar.Grammaticals )
            {
                int gr_index = grammar.GlobalIndexOf(gr);

                // Put all terminals being in relation with gr into gr's first_set
                var first_set = new HashSet<TerminalSymbol>();
                foreach( var tr in grammar.Terminals )
                    if( f_plus[gr_index, grammar.GlobalIndexOf(tr)] )
                        first_set.Add(tr);

                if( epsilon_grammaticals.Contains(gr) )
                    first_set.Add(EpsilonSymbol.Instance);

                first_sets.Add(gr, first_set);
            }

            return first_sets;
        }

        internal static RelationMatrix F_Relation( IGrammar grammar )
        {
            var relation = new RelationMatrix(grammar.Terminals.Count + grammar.Grammaticals.Count);
            foreach( var rule in grammar.Rules )
                if( rule.RightHandSide.Count > 0 )
                    relation[
                        grammar.GlobalIndexOf(rule.LeftHandSide),
                        grammar.GlobalIndexOf(rule.RightHandSide[0])] = true;

            return relation;
        }
    }
}
