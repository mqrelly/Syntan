using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Syntan.SyntacticAnalysis
{
    /// <summary>
    /// Represents a grammatical symbol.
    /// This class is immutable.
    /// </summary>
    [Serializable]
    public class GrammaticalSymbol : Symbol
    {
        /// <summary>
        /// Creates a new instance with the given <paramref name="name"/>.
        /// </summary>
        /// <param name="name">The human readably name of this symbol.</param>
        public GrammaticalSymbol( string name )
            : base(name)
        { }
    }
}
