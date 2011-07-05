using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Syntan.SyntacticAnalysis
{
    /// <summary>
    /// Meta terminal symbol. Represents the end of the source (or input).
    /// All instances will have the spacial name #.
    /// This class is immutable.
    /// </summary>
    public sealed class EndOfSourceSymbol : TerminalSymbol
    {
        /// <summary>
        /// Creates a new instance.
        /// </summary>
        public EndOfSourceSymbol()
            : base("#")
        { }
    }
}
