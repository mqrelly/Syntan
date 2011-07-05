using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Syntan.SyntacticAnalysis
{
    public class ForeignSymbolInRuleException : GrammarException
    {
        public ForeignSymbolInRuleException( Rule rule, Symbol symbol )
        {
            this.Rule = rule;
            this.Symbol = symbol;
        }

        public Rule Rule { get; private set; }

        public Symbol Symbol { get; private set; }
    }
}
