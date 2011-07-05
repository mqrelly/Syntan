using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Syntan.SyntacticAnalysis.LR
{
    /// <summary>
    /// This exception should not occure. It was used for development purposes.
    /// The internal checking codes are still there in DEBUG builds.
    /// </summary>
    public class InternalParserException : ParserException
    {
        /// <summary>
        /// Constructor that takes a string message.
        /// </summary>
        /// <param name="message">The message string.</param>
        public InternalParserException( string message )
            : base(message)
        { }

        /// <summary>
        /// Constructor that takes a string message and an inner exception.
        /// </summary>
        /// <param name="message">The message string.</param>
        /// <param name="inner_exception">The inner exception to wrap.</param>
        public InternalParserException( string message, Exception inner_exception )
            : base(message, inner_exception)
        { }
    }
}
