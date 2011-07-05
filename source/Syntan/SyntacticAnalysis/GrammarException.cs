using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Syntan.SyntacticAnalysis
{
    /// <summary>
    /// Base class of all exceptinos that are thrown in case an <see cref="IGrammar"/>
    /// implementation got invalid arguments.
    /// </summary>
    public class GrammarException : Exception
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
        public GrammarException()
        { }

        /// <summary>
        /// Constracutor that takes a string message.
        /// </summary>
        /// <param name="message">The message string.</param>
        public GrammarException( string message )
            : base(message)
        { }
    }
}
