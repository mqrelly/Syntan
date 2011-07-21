using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Syntan.SyntacticAnalysis;

namespace Syntan.UnitTests.Fixtures
{
    static class Grammar3
    {
        public static readonly Grammar BaseGrammar;

        public static readonly RestrictedStartSymbolGrammar RestrictedGrammar;

        public static readonly ExtendedGrammar ExtendedGrammar;

        public static readonly ISet<GrammaticalSymbol> EpsilonGrammaticals;

        public static readonly IDictionary<GrammaticalSymbol, ISet<TerminalSymbol>> FollowSets;

        static Grammar3()
        {
            var terminals = new TerminalSymbol[]
                {
                    new TerminalSymbol("a"),
                    new TerminalSymbol("b"),
                };

            var grammaticals = new GrammaticalSymbol[]
                {
                    new GrammaticalSymbol("S"),
                    new GrammaticalSymbol("A"),
                    new GrammaticalSymbol("B"),
                };

            var rules = new Rule[]
                {
                    // S->AB
                    new Rule(
                        grammaticals[0],
                        new Symbol[]
                        {
                            grammaticals[1],
                            grammaticals[2],
                        }),
                    
                    // S->aSbS
                    new Rule(
                        grammaticals[1],
                        new Symbol[]
                        {
                            terminals[0],
                            grammaticals[0],
                            terminals[1],
                            grammaticals[0],
                        }),

                    // A->
                    new Rule(
                        grammaticals[1],
                        new Symbol[0]),

                    // B->
                    new Rule(
                        grammaticals[2],
                        new Symbol[0]),
                };

            BaseGrammar = new Grammar(terminals, grammaticals, rules, 0);
            RestrictedGrammar = new RestrictedStartSymbolGrammar(BaseGrammar);
            ExtendedGrammar = new ExtendedGrammar(RestrictedGrammar);

            EpsilonGrammaticals = new HashSet<GrammaticalSymbol>(ExtendedGrammar.Grammaticals);

            FollowSets = new Dictionary<GrammaticalSymbol, ISet<TerminalSymbol>>();
            // S': -
            FollowSets[ExtendedGrammar.StartSymbol] = new HashSet<TerminalSymbol>();
            // S: b,#
            FollowSets[ExtendedGrammar.Grammaticals[1]] = new HashSet<TerminalSymbol>(
                new TerminalSymbol[]{
                    ExtendedGrammar.Terminals[1],
                    ExtendedGrammar.EndOfSourceSymbol,
                });
            // A: b,#
            FollowSets[ExtendedGrammar.Grammaticals[2]] = FollowSets[ExtendedGrammar.Grammaticals[1]];
            // B: b,#
            FollowSets[ExtendedGrammar.Grammaticals[3]] = FollowSets[ExtendedGrammar.Grammaticals[1]];
        }
    }
}
