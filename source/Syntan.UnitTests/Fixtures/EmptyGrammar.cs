using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Syntan.SyntacticAnalysis;

namespace Syntan.UnitTests.Fixtures
{
    static class EmptyGrammar
    {
        public static readonly Grammar BaseGrammar;

        public static readonly RestrictedStartSymbolGrammar RestrictedGrammar;

        public static readonly ExtendedGrammar ExtendedGrammar;

        public static readonly ISet<GrammaticalSymbol> EpsilonGrammaticals;

        public static readonly IDictionary<GrammaticalSymbol, ISet<TerminalSymbol>> FirstSets;

        public static readonly IDictionary<GrammaticalSymbol, ISet<TerminalSymbol>> FollowSets;

        public static readonly Syntan.SyntacticAnalysis.LR.LR0CanonicalSets LR0CanonicalSets;

        public static readonly Syntan.SyntacticAnalysis.LR.ParserTable SLR1ParserTable;

        static EmptyGrammar()
        {
            BaseGrammar = Grammar.EmptyGrammar;
            RestrictedGrammar = new RestrictedStartSymbolGrammar(BaseGrammar);
            ExtendedGrammar = new ExtendedGrammar(RestrictedGrammar);

            EpsilonGrammaticals = new HashSet<GrammaticalSymbol>();
            EpsilonGrammaticals.Add(BaseGrammar.StartSymbol);

            FirstSets = new Dictionary<GrammaticalSymbol, ISet<TerminalSymbol>>();
            // S: #,Eps
            FirstSets[BaseGrammar.StartSymbol] = new HashSet<TerminalSymbol>(
                new TerminalSymbol[] 
                { 
                    ExtendedGrammar.EndOfSourceSymbol, 
                    EpsilonSymbol.Instance 
                });

            FollowSets = new Dictionary<GrammaticalSymbol, ISet<TerminalSymbol>>();
            // S: -
            FollowSets[BaseGrammar.StartSymbol] = new HashSet<TerminalSymbol>();

            LR0CanonicalSets = new Syntan.SyntacticAnalysis.LR.LR0CanonicalSets();
            LR0CanonicalSets.Add(new HashSet<Syntan.SyntacticAnalysis.LR.LR0Item>(
                new Syntan.SyntacticAnalysis.LR.LR0Item[]
                {
                    new Syntan.SyntacticAnalysis.LR.LR0Item(BaseGrammar.Rules[0], 0)
                }));

            // SLR1ParserTable
            SLR1ParserTable = new Syntan.SyntacticAnalysis.LR.ParserTable(1, 1, 1);
            SLR1ParserTable.SetAction(0, 0, Syntan.SyntacticAnalysis.LR.ParserTable.Action.Accept());
        }
    }
}
