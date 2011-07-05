using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Syntan.Utils;

namespace Syntan.SyntacticAnalysis
{
    /// <summary>
    /// Calculates the follow sets for all grammaticals of a <see cref="ExtendedGrammar"/>.
    /// </summary>
    public static class FollowSets
    {
        /// <summary>
        /// Calculates the follow sets of all grammaticals of the given <paramref name="grammar"/>.
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

            int symbol_count = grammar.Terminals.Count + grammar.Grammaticals.Count;

            var f_star = new RelationMatrix(symbol_count);
            RelationMatrix.TransitiveClosure(FirstSets.F_Relation(grammar), f_star);
            RelationMatrix.ReflexiveClosure(f_star);

            var l_star = new RelationMatrix(symbol_count);
            RelationMatrix.TransitiveClosure(L_Relations(grammar, epsilon_grammaticals), l_star);
            RelationMatrix.ReflexiveClosure(l_star);

            var b = B_Relation(grammar, epsilon_grammaticals);

            var tmp = new RelationMatrix(symbol_count);
            var lbf = new RelationMatrix(symbol_count);
            RelationMatrix.WharshallAlg(l_star, b, tmp);
            RelationMatrix.WharshallAlg(tmp, f_star, lbf);

            // Build the follow_sets
            var follow_sets = new Dictionary<GrammaticalSymbol, ISet<TerminalSymbol>>();
            foreach( var gr in grammar.Grammaticals )
            {
                int gr_index = grammar.GlobalIndexOf(gr);

                // Put all terminals being in relation with gr into gr's follow_set
                var follow_set = new HashSet<TerminalSymbol>();
                foreach( var tr in grammar.Terminals )
                    if( lbf[gr_index, grammar.GlobalIndexOf(tr)] )
                        follow_set.Add(tr);

                follow_sets.Add(gr, follow_set);
            }

            return follow_sets;
        }

        private static RelationMatrix B_Relation( IGrammar grammar, ISet<GrammaticalSymbol> epsilon_grammaticals )
        {
            var relation = new RelationMatrix(grammar.Terminals.Count + grammar.Grammaticals.Count);
            foreach( var rule in grammar.Rules )
                for( int i = 1; i < rule.RightHandSide.Count; ++i )
                {
                    relation[
                        grammar.GlobalIndexOf(rule.RightHandSide[i - 1]),
                        grammar.GlobalIndexOf(rule.RightHandSide[i])] = true;

                    for( int j = i + 1; j < rule.RightHandSide.Count; ++j )
                        if( rule.RightHandSide[j - 1] is GrammaticalSymbol &&
                            epsilon_grammaticals.Contains((GrammaticalSymbol)rule.RightHandSide[j - 1]) )
                        {
                            relation[
                                grammar.GlobalIndexOf(rule.RightHandSide[i - 1]),
                                grammar.GlobalIndexOf(rule.RightHandSide[j])] = true;
                        }
                        else
                        {
                            break;
                        }
                }

            return relation;
        }

        private static RelationMatrix L_Relations( IGrammar grammar, ISet<GrammaticalSymbol> epsilon_grammaticals )
        {
            var relation = new RelationMatrix(grammar.Terminals.Count + grammar.Grammaticals.Count);
            foreach( var rule in grammar.Rules )
                if( rule.RightHandSide.Count > 0 )
                {
                    relation[
                        grammar.GlobalIndexOf(rule.RightHandSide[rule.RightHandSide.Count - 1]),
                        grammar.GlobalIndexOf(rule.LeftHandSide)] = true;

                    for( int i = rule.RightHandSide.Count - 2; i >= 0; --i )
                        if( rule.RightHandSide[i + 1] is GrammaticalSymbol &&
                            epsilon_grammaticals.Contains((GrammaticalSymbol)rule.RightHandSide[i + 1]) )
                        {
                            relation[
                                grammar.GlobalIndexOf(rule.RightHandSide[i]),
                                grammar.GlobalIndexOf(rule.LeftHandSide)] = true;
                        }
                        else
                        {
                            break;
                        }
                }

            return relation;
        }
    }
}
