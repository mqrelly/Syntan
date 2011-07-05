using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Syntan.SyntacticAnalysis
{
    /// <summary>
    /// Representing the no terminal and the empty terminal sequence too.
    /// </summary>
    public sealed class EpsilonSymbol : TerminalSymbol
    {
        /// <summary>
        /// Singleton instance of the class.
        /// </summary>
        public static readonly EpsilonSymbol Instance = new EpsilonSymbol();

        private EpsilonSymbol()
            : base("ε")
        { }
    }
}
