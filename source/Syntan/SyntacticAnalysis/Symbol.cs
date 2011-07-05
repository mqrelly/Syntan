using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Syntan.SyntacticAnalysis
{
    /// <summary>
    /// The abstract base class of all symbols. This class is immutable.
    /// </summary>
    [Serializable]
    public abstract class Symbol
    {
        public Symbol( string name )
        {
            this.name = name;
        }

        private string name;

        /// <summary>
        /// Human readably name of the symbol.
        /// </summary>
        public string Name
        {
            get { return this.name; }
        }

        /// <summary>
        /// Tells if this symbol is considered equal to another one.
        /// </summary>
        /// <param name="other">The other symbol to compare to.</param>
        /// <returns><c>true</c> if they are equal, <c>false</c> otherwise.</returns>
        public bool Equals( Symbol other )
        {
            return other != null && this.GetType() == other.GetType() && this.Name == other.Name;
        }

        public override bool Equals( object obj )
        {
            return this.Equals(obj as Symbol);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
