using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Syntan.SyntacticAnalysis
{
    public class MissingStartSymbolException : GrammarException
    {
        public MissingStartSymbolException()
        { }
    }
}
