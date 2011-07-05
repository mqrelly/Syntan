using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Syntan.SyntacticAnalysis.LR
{
    /// <summary>
    /// Builds a SLR(1) <see cref="ParserTable"/> for the givin <see cref="ExtendedGrammar"/>.
    /// The result than can be used with <see cref="Parser"/> for syntactic parsing.
    /// </summary>
    public static class SLR1ParserTableBuilder
    {
        /// <summary>
        /// Builds and return an SLR(1) <see cref="ParserTable"/> based on the given paramaters.
        /// </summary>
        /// <param name="grammar">The grammar.</param>
        /// <param name="canonical_sets">LR(0) canonical sets generated from the <paramref name="grammar"/>.</param>
        /// <param name="follow_sets">Follow sets of all the <paramref name="grammar"/>'s grammaticals
        /// (see <see cref="FollowSets"/>).</param>
        /// <returns>An SLR(1) parser table.</returns>
        public static ParserTable Build( ExtendedGrammar grammar, LR0CanonicalSets canonical_sets,
            IDictionary<GrammaticalSymbol, ISet<TerminalSymbol>> follow_sets )
        {
            if( object.ReferenceEquals(grammar, null) )
                throw new ArgumentNullException("grammar");
            if( object.ReferenceEquals(canonical_sets, null) )
                throw new ArgumentNullException("canonical_sets");
            if( object.ReferenceEquals(follow_sets, null) )
                throw new ArgumentNullException("follow_sets");


            var table = new ParserTable(canonical_sets.Sets.Count, grammar.Terminals.Count, grammar.Grammaticals.Count);

            for( int state_index = 0; state_index < canonical_sets.Sets.Count; ++state_index )
            {
                // Steps
                foreach( var term in grammar.Terminals )
                {
                    int next_state_index = canonical_sets.GetTransition(state_index, term);
                    if( next_state_index != -1 )
                    {
                        if( table.GetAction(state_index, grammar.IndexOf(term)).Type != ParserTable.ActionType.Error )
                            throw new ArgumentException("Grammar is not SLR(1)."); //TODO: custom exception with conflict info

                        table.SetAction(state_index, grammar.IndexOf(term), ParserTable.Action.Step(next_state_index));
                    }
                }

                // Gotos
                foreach( var gram in grammar.Grammaticals )
                {
                    int next_state_index = canonical_sets.GetTransition(state_index, gram);
                    if( next_state_index != -1 )
                    {
                        if( table.GetGoto(state_index, grammar.IndexOf(gram)) != -1 )
                            throw new ArgumentException("Grammar is not SLR(1)."); //TODO: custom exception with conflict info

                        table.SetGoto(state_index, grammar.IndexOf(gram), next_state_index);
                    }
                }

                // Reductions
                foreach( var item in canonical_sets.Sets[state_index] )
                    if( item.CursorPosition == item.Rule.RightHandSide.Count )
                    {
                        // Is it [S'->S.] ?
                        if( item.Rule.LeftHandSide == grammar.StartSymbol )
                        {
                            if( table.GetAction(state_index, grammar.IndexOf(grammar.EndOfSourceSymbol)).Type != ParserTable.ActionType.Error )
                                throw new ArgumentException("Grammar is not SLR(1)."); //TODO: custom exception with conflict info

                            table.SetAction(
                                state_index,
                                grammar.IndexOf(grammar.EndOfSourceSymbol),
                                ParserTable.Action.Accept());
                        }

                        // ... no, it's [A->alpha.]
                        else
                        {
                            int rule_index = grammar.Rules.IndexOf(item.Rule);
                            foreach( var follow_term in follow_sets[item.Rule.LeftHandSide] )
                            {
                                if( table.GetAction(state_index, grammar.IndexOf(follow_term)).Type != ParserTable.ActionType.Error )
                                    throw new ArgumentException("Grammar is not SLR(1)."); //TODO: custom exception with conflict info

                                table.SetAction(
                                    state_index,
                                    grammar.IndexOf(follow_term),
                                    ParserTable.Action.Reduction(rule_index));
                            }
                        }
                    }
            }

            return table;
        }
    }
}
