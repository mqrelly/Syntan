using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Syntan.SyntacticAnalysis
{
    /// <summary>
    /// Represents a terminal symbol.
    /// This class is immutable.
    /// </summary>
    [Serializable]
    public class TerminalSymbol : Symbol
    {
        /// <summary>
        /// Creates a new instance with the given <paramref name="name"/>.
        /// </summary>
        /// <param name="name">The human readably name of this symbol.</param>
        public TerminalSymbol( string name )
            : base(name)
        { }
    }
}
