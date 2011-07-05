using System;

namespace Syntan.SyntacticAnalysis.LR
{
    /// <summary>
    /// Represents a phases for the <see cref="Parser"/>.
    /// </summary>
    public enum ParsingPhase
    {
        /// <summary>
        /// Not parsing.
        /// </summary>
        NotParsing,

        /// <summary>
        /// The input has syntactic error in it.
        /// </summary>
        Error,

        /// <summary>
        /// The input was successfuly parsed.
        /// </summary>
        Accept,

        /// <summary>
        /// A step is to be made next.
        /// </summary>
        Step1,

        /// <summary>
        /// The step is made, arrived to a new state.
        /// </summary>
        Step2,

        /// <summary>
        /// A reduction is to be made next.
        /// </summary>
        Reduction1,

        /// <summary>
        /// The right hand side of the reducting <see cref="Rule"/> is removed from the stack.
        /// </summary>
        Reduction2,

        /// <summary>
        /// Goto performed, and new state push onto stack.
        /// </summary>
        Reduction3,
    }
}