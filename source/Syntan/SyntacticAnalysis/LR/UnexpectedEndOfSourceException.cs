using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Syntan.SyntacticAnalysis.LR
{
    public class UnexpectedEndOfSourceException : ParserException
    {
        public UnexpectedEndOfSourceException()
            : base()
        { }

        public UnexpectedEndOfSourceException( string message )
            : base(message)
        { }
    }
}
