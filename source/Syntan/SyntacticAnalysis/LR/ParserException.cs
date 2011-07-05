using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Syntan.SyntacticAnalysis.LR
{
    /// <summary>
    /// Derived exceptions are thrown from the <see cref="Parser"/>.
    /// </summary>
    public class ParserException : Exception
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
        public ParserException()
            : base()
        { }

        /// <summary>
        /// Constructor that takes a string message.
        /// </summary>
        /// <param name="message">The message string.</param>
        public ParserException( string message )
            : base(message)
        { }

        /// <summary>
        /// Constructor that takes a string message, and an <paramref name="inner_exception"/>.
        /// </summary>
        /// <param name="message">The message string.</param>
        /// <param name="inner_exception"></param>
        public ParserException( string message, Exception inner_exception )
            : base(message, inner_exception)
        { }
    }
}
