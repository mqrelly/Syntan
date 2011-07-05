using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Syntan.SyntacticAnalysis
{
    /// <summary>
    /// Common interface for all grammars.
    /// The grammar that implements this interface supposed to be immutable.
    /// </summary>
    public interface IGrammar
    {
        /// <summary>
        /// Gets the terminals of the grammar as a read-only list of <see cref="TerminalSymbol"/>.
        /// </summary>
        IList<TerminalSymbol> Terminals { get; }

        /// <summary>
        /// Gets the grammaticals of the grammar as a read-only list of <see cref="GrammaticalSymbol"/>.
        /// </summary>
        IList<GrammaticalSymbol> Grammaticals { get; }

        /// <summary>
        /// Gets the rules of the grammar as a read-only list of <see cref="Rule"/>.
        /// </summary>
        IList<Rule> Rules { get; }

        /// <summary>
        /// Gets the start-symbol of the grammar. Usuly the first in <see cref=" IGrammar.Grammaticals"/>.
        /// </summary>
        GrammaticalSymbol StartSymbol { get; }

        /// <summary>
        /// Returns the index og the given <paramref name="symbol"/>.
        /// </summary>
        /// <param name="symbol"></param>
        /// <returns>The index of the given grammatical, or <c>-1</c> if the symbol is not part of this grammar.</returns>
        int IndexOf( GrammaticalSymbol symbol );

        /// <summary>
        /// Returns the index og the given <paramref name="symbol"/>.
        /// </summary>
        /// <param name="symbol"></param>
        /// <returns>The index of the given terminal, or <c>-1</c> if the symbol is not part of this grammar.</returns>
        int IndexOf( TerminalSymbol symbol );

        /// <summary>
        /// Returns an index unique among symbols from the same grammar.
        /// (terminals first, grammaticals second)
        /// </summary>
        /// <param name="symbol"></param>
        /// <returns>The index of the given symbol, or <c>-1</c> if the symbol is not part of this grammar.</returns>
        int GlobalIndexOf( Symbol symbol );

        /// <summary>
        /// Returns an index unique among symbols from the same grammar.
        /// (terminals first, grammaticals second)
        /// </summary>
        /// <param name="symbol"></param>
        /// <returns>The index of the given symbol, <c>-1</c> if symbol not part of this grammar.</returns>
        int GlobalIndexOf( GrammaticalSymbol symbol );

        /// <summary>
        /// Returns an index unique among symbols from the same grammar.
        /// (terminals first, grammaticals second)
        /// </summary>
        /// <param name="symbol"></param>
        /// <returns>The index of the given symbol, <c>-1</c> if symbol not part of this grammar.</returns>
        int GlobalIndexOf( TerminalSymbol symbol );
    }
}
