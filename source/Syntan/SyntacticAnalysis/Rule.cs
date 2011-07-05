using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Syntan.SyntacticAnalysis
{
    /// <summary>
    /// Represents a rule of a grammar. This class is immutable.
    /// </summary>
    public class Rule
    {
        /// <summary>
        /// Creates the rule instances with the given paramaters.
        /// </summary>
        /// <param name="left_hand_side">The <see cref="GrammaticalSymbol"/> on the left hand side.</param>
        /// <param name="right_hand_side">An enumeration of <see cref="Symbol"/>s of the right hand side.</param>
        /// <exception cref="ArgumentNullException"> if either of the parameters is <c>null</c>.</exception>
        /// <exception cref="ArgumentException"> if the <paramref name="right_hand_side"/> 
        ///     contains an <see cref="EpsilonSymbol"/>.</exception>
        /// <exception cref="ArgumentException"> if the <paramref name="right_hand_side"/> 
        ///     contains an <see cref="EndOfSourceSymbol"/> other than at the end.</exception>
        public Rule( GrammaticalSymbol left_hand_side, IEnumerable<Symbol> right_hand_side )
        {
            if( left_hand_side == null )
                throw new ArgumentNullException("left_hand_side");
            if( right_hand_side == null )
                throw new ArgumentNullException("right_hand_side");


            var rhs = new List<Symbol>(right_hand_side);
            if( rhs.Count > 0 )
            {
                if( rhs.IndexOf(EpsilonSymbol.Instance) != -1 )
                    throw new ArgumentException("RightHandSide must not contain Epsilon.");

                // Checking for EndOfSource symbols other then at the end.
                int index = rhs.FindIndex(s => s is EndOfSourceSymbol);
                if( index != -1 && index < rhs.Count - 1 )
                    throw new ArgumentException("RightHandSide must not contain EndOfSource symbol other than at the end.");
            }

            this.lhs = left_hand_side;
            this.rhs = rhs.AsReadOnly();
        }

        private GrammaticalSymbol lhs;
        private IList<Symbol> rhs;

        /// <summary>
        /// Gets the <see cref="GrammaticalSymbol"/> on the left hand side.
        /// </summary>
        public GrammaticalSymbol LeftHandSide
        {
            get { return this.lhs; }
        }

        /// <summary>
        /// Gets a read-only list of the symbols on the right hand side.
        /// </summary>
        public IList<Symbol> RightHandSide
        {
            get { return this.rhs; }
        }

        /// <summary>
        /// Gets whether the right hand side is empty, or not.
        /// </summary>
        public bool IsEpsilonRule
        {
            get { return this.rhs.Count == 0; }
        }

        /// <summary>
        /// Tells if this rule is considered equal to another one.
        /// </summary>
        /// <param name="other">The other rule to compare to.</param>
        /// <returns><c>true</c> if they are equal, <c>false</c> otherwise.</returns>
        public bool Equals( Rule other )
        {
            if( other == null ||
                !this.lhs.Equals(other.lhs) ||
                this.rhs.Count != other.rhs.Count )
                return false;

            for( int i = 0; i < this.rhs.Count; ++i )
                if( !this.rhs[i].Equals(other.rhs[i]) )
                    return false;

            return true;
        }

        public override bool Equals( object obj )
        {
            return this.Equals(obj as Rule);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        //TODO: Maybe cache the string with a weakref (it will not change)?
        public override string ToString()
        {
            return string.Format("{0}->{1}",
                this.lhs.Name,
                string.Join(string.Empty, from s in this.rhs select s.Name));
        }
    }
}
