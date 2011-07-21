using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Syntan.SyntacticAnalysis;
using Syntan.SyntacticAnalysis.LR;

namespace Syntan.UnitTests.Fixtures
{
    static class Grammar2
    {
        public static readonly Grammar BaseGrammar;

        public static readonly RestrictedStartSymbolGrammar RestrictedGrammar;

        public static readonly ExtendedGrammar ExtendedGrammar;

        public static readonly ISet<GrammaticalSymbol> EpsilonGrammaticals;

        public static readonly IDictionary<GrammaticalSymbol, ISet<TerminalSymbol>> FirstSets;

        public static readonly IDictionary<GrammaticalSymbol, ISet<TerminalSymbol>> FollowSets;

        public static readonly LR0CanonicalSets LR0CanonicalSets;

        public static readonly ParserTable SLR1ParserTable;

        static Grammar2()
        {
            var terminals = new TerminalSymbol[]
                {
                    new TerminalSymbol("+"),
                    new TerminalSymbol("*"),
                    new TerminalSymbol("("),
                    new TerminalSymbol(")"),
                    new TerminalSymbol("i"),
                };

            var grammaticals = new GrammaticalSymbol[]
                {
                    new GrammaticalSymbol("S"),
                    new GrammaticalSymbol("E"),
                    new GrammaticalSymbol("E'"),
                    new GrammaticalSymbol("T"),
                    new GrammaticalSymbol("T'"),
                    new GrammaticalSymbol("F"),
                };

            var rules = new Rule[]
                {
                    // S->E
                    new Rule(
                        grammaticals[0],
                        new Symbol[] 
                        {
                            grammaticals[1],
                        }),

                    // E->TE'
                    new Rule(
                        grammaticals[1],
                        new Symbol[]
                        {
                            grammaticals[3],
                            grammaticals[2],
                        }),

                    // E'->+TE'
                    new Rule(
                        grammaticals[2],
                        new Symbol[]
                        {
                            terminals[0],
                            grammaticals[3],
                            grammaticals[2],
                        }),

                    // E'->
                    new Rule(
                        grammaticals[2],
                        new Symbol[] { }),

                    // T->FT'
                    new Rule(
                        grammaticals[3],
                        new Symbol[]
                        {
                            grammaticals[5],
                            grammaticals[4],
                        }),

                    // T'->*FT'
                    new Rule(
                        grammaticals[4],
                        new Symbol[]
                        {
                            terminals[1],
                            grammaticals[5],
                            grammaticals[4],
                        }),

                    // T'->
                    new Rule(
                        grammaticals[4],
                        new Symbol[] { }),

                    // F->(E)
                    new Rule(
                        grammaticals[5],
                        new Symbol[]
                        {
                            terminals[2],
                            grammaticals[1],
                            terminals[3],
                        }),

                    // F->i
                    new Rule(
                        grammaticals[5],
                        new Symbol[]
                        {
                            terminals[4],
                        }),
                };

            BaseGrammar = new Grammar(terminals, grammaticals, rules, 0);
            RestrictedGrammar = new RestrictedStartSymbolGrammar(BaseGrammar);
            ExtendedGrammar = new ExtendedGrammar(RestrictedGrammar);

            EpsilonGrammaticals = new HashSet<GrammaticalSymbol>(
                new GrammaticalSymbol[] { grammaticals[2], grammaticals[4] });


            FirstSets = new Dictionary<GrammaticalSymbol, ISet<TerminalSymbol>>();
            // S: (,i
            FirstSets[BaseGrammar.Grammaticals[0]] = new HashSet<TerminalSymbol>(new TerminalSymbol[]
                {
                    BaseGrammar.Terminals[2],
                    BaseGrammar.Terminals[4],
                });

            // E: (,i
            FirstSets[BaseGrammar.Grammaticals[1]] = new HashSet<TerminalSymbol>(new TerminalSymbol[]
                {
                    BaseGrammar.Terminals[2],
                    BaseGrammar.Terminals[4],
                });

            // E': +,Eps
            FirstSets[BaseGrammar.Grammaticals[2]] = new HashSet<TerminalSymbol>(new TerminalSymbol[]
                {
                    BaseGrammar.Terminals[0],
                    EpsilonSymbol.Instance,
                });

            // T: (,i
            FirstSets[BaseGrammar.Grammaticals[3]] = new HashSet<TerminalSymbol>(new TerminalSymbol[]
                {
                    BaseGrammar.Terminals[2],
                    BaseGrammar.Terminals[4],
                });

            // T': *,Eps
            FirstSets[BaseGrammar.Grammaticals[4]] = new HashSet<TerminalSymbol>(new TerminalSymbol[]
                {
                    BaseGrammar.Terminals[1],
                    EpsilonSymbol.Instance,
                });

            // F: (,i
            FirstSets[BaseGrammar.Grammaticals[5]] = new HashSet<TerminalSymbol>(new TerminalSymbol[]
                {
                    BaseGrammar.Terminals[2],
                    BaseGrammar.Terminals[4],
                });

            FollowSets = new Dictionary<GrammaticalSymbol, ISet<TerminalSymbol>>();

            // S:
            FollowSets[ExtendedGrammar.Grammaticals[0]] = new HashSet<TerminalSymbol>();

            // E: ),EoS
            FollowSets[ExtendedGrammar.Grammaticals[1]] = new HashSet<TerminalSymbol>(new TerminalSymbol[] 
                {
                    ExtendedGrammar.Terminals[3],
                    ExtendedGrammar.Terminals[5],
                });

            // E': ),EoS
            FollowSets[ExtendedGrammar.Grammaticals[2]] = new HashSet<TerminalSymbol>(new TerminalSymbol[] 
                {
                    ExtendedGrammar.Terminals[3],
                    ExtendedGrammar.Terminals[5],
                });

            // T: +,),EoS
            FollowSets[ExtendedGrammar.Grammaticals[3]] = new HashSet<TerminalSymbol>(new TerminalSymbol[] 
                {
                    ExtendedGrammar.Terminals[0],
                    ExtendedGrammar.Terminals[3],
                    ExtendedGrammar.Terminals[5],
                });

            // T': +,),EoS
            FollowSets[ExtendedGrammar.Grammaticals[4]] = new HashSet<TerminalSymbol>(new TerminalSymbol[] 
                {
                    ExtendedGrammar.Terminals[0],
                    ExtendedGrammar.Terminals[3],
                    ExtendedGrammar.Terminals[5],
                });

            // F: +,*,),EoS
            FollowSets[ExtendedGrammar.Grammaticals[5]] = new HashSet<TerminalSymbol>(new TerminalSymbol[] 
                {
                    ExtendedGrammar.Terminals[0],
                    ExtendedGrammar.Terminals[1],
                    ExtendedGrammar.Terminals[3],
                    ExtendedGrammar.Terminals[5],
                });

            //TODO: Use real fixture!!
            LR0CanonicalSets = LR0CanonicalSets.Build(RestrictedGrammar);

            //TODO: Use real fixtures!!
            SLR1ParserTable = SLR1ParserTableBuilder.Build(ExtendedGrammar, LR0CanonicalSets, FollowSets);
        }
    }
}
