using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Syntan.SyntacticAnalysis;
using Syntan.SyntacticAnalysis.LR;

namespace Syntan.UnitTests.Fixtures
{
    static class Grammar1
    {
        public static readonly Grammar BaseGrammar;

        public static readonly RestrictedStartSymbolGrammar RestrictedGrammar;

        public static readonly ExtendedGrammar ExtendedGrammar;

        public static readonly ISet<GrammaticalSymbol> EpsilonGrammaticals;

        public static readonly IDictionary<GrammaticalSymbol, ISet<TerminalSymbol>> FirstSets;

        public static readonly IDictionary<GrammaticalSymbol, ISet<TerminalSymbol>> FollowSets;

        static Grammar1()
        {
            var terminals = new TerminalSymbol[]
                {
                    new TerminalSymbol("a"),
                };

            var grammaticals = new GrammaticalSymbol[]
                {
                    new GrammaticalSymbol("S"),
                };

            var rules = new Rule[]
                {
                    // S->aS
                    new Rule(
                        grammaticals[0],
                        new Symbol[]
                        {
                            terminals[0],
                            grammaticals[0],
                        }),

                    // S->
                    new Rule(
                        grammaticals[0],
                        new Symbol[0]),
                };

            BaseGrammar = new Grammar(terminals, grammaticals, rules);
            RestrictedGrammar = new RestrictedStartSymbolGrammar(BaseGrammar);
            ExtendedGrammar = new ExtendedGrammar(RestrictedGrammar);

            EpsilonGrammaticals = new HashSet<GrammaticalSymbol>(RestrictedGrammar.Grammaticals);

            FirstSets = new Dictionary<GrammaticalSymbol, ISet<TerminalSymbol>>();
            // S': a,Eps
            FirstSets[ExtendedGrammar.StartSymbol] = new HashSet<TerminalSymbol>(BaseGrammar.Terminals);
            FirstSets[ExtendedGrammar.StartSymbol].Add(EpsilonSymbol.Instance);
            // S: a,Eps
            FirstSets[BaseGrammar.StartSymbol] = new HashSet<TerminalSymbol>(BaseGrammar.Terminals);
            FirstSets[BaseGrammar.StartSymbol].Add(EpsilonSymbol.Instance);

            FollowSets = new Dictionary<GrammaticalSymbol, ISet<TerminalSymbol>>();
            // S': 
            FollowSets[ExtendedGrammar.Grammaticals[0]] = new HashSet<TerminalSymbol>();
            // S: #
            FollowSets[ExtendedGrammar.Grammaticals[1]] = new HashSet<TerminalSymbol>();
            FollowSets[ExtendedGrammar.Grammaticals[1]].Add(ExtendedGrammar.EndOfSourceSymbol);
        }
    }
}
