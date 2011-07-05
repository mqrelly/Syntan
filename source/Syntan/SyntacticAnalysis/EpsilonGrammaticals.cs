using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Syntan.SyntacticAnalysis
{
    /// <summary>
    /// Calculates from which grammaticals can the epsilon be derived.
    /// </summary>
    public static class EpsilonGrammaticals
    {
        /// <summary>
        /// Collects and returns the grammaticals, from which the epsilon can be derived, in a list.
        /// </summary>
        /// <param name="grammar">The grammar to examen.</param>
        /// <returns>The list of <see cref="GrammaticalSymbol"/>s which epsilon can be derived from.</returns>
        /// <exception cref="ArgumentNullException"> if <paramref name="grammar"/> is <c>null</c>.</exception>
        public static ISet<GrammaticalSymbol> Build( IGrammar grammar )
        {
            if( grammar == null )
                throw new ArgumentNullException("grammar");


            var result = new HashSet<GrammaticalSymbol>();

            // Put all direct-epsilon-rules' left hand side into results
            foreach( var rule in grammar.Rules )
                if( rule.IsEpsilonRule )
                    result.Add(rule.LeftHandSide);

            // Iterate on it, while it changes
            bool changed = true;
            while( changed )
            {
                changed = false;

                foreach( var rule in grammar.Rules )
                {
                    // Only examen symboles not already in the result set
                    if( result.Contains(rule.LeftHandSide) )
                        continue;

                    bool ok = true;

                    // Does the rule's right hand side only contains grammatical symboles already in the result?
                    foreach( var symbol in rule.RightHandSide )
                        if( !(symbol is GrammaticalSymbol) || !result.Contains(symbol) )
                        {
                            ok = false;
                            break;
                        }

                    // ... If so, add it to the result
                    if( ok )
                    {
                        result.Add(rule.LeftHandSide);
                        changed = true;
                    }
                }
            }


            return result;
        }
    }
}
