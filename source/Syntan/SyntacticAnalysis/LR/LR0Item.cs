using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Syntan.SyntacticAnalysis.LR
{
    /// <summary>
    /// Represents an LR(0)-item with a rule and a cursor-position.
    /// This class is immutable.
    /// </summary>
    public class LR0Item
    {
        /// <summary>
        /// Creates a new isntance with the given parameters.
        /// </summary>
        /// <param name="rule">The base of the LR(0)-item.</param>
        /// <param name="cursor_position">The position of the special point (.)
        /// symbol. Must be in range [0,rule.RightHandSide.Count].</param>
        /// <exception cref="ArgumentNullException"> if <paramref name="rule"/>
        /// is <c>null</c>.</exception>
        /// <exception cref="ArgumentOutOfRangeException"> if 
        /// <paramref name="cursor_position"/> is negative, or greater than the
        /// symbol count of the <paramref name="rule" />'s right hand side.
        /// </exception>
        public LR0Item( Rule rule, int cursor_position )
        {
            if( rule == null )
                throw new ArgumentNullException("rule");
            if( cursor_position < 0 || cursor_position > rule.RightHandSide.Count )
                throw new ArgumentOutOfRangeException("cursor_position");

            this.rule = rule;
            this.cursor_pos = cursor_position;
        }

        private Rule rule;
        private int cursor_pos;

        /// <summary>
        /// Gets the <see cref="Rule"/> of this LR(0)-item.
        /// </summary>
        public Rule Rule
        {
            get { return this.rule; }
        }

        /// <summary>
        /// Gets the position of the special point (.) symbol int this LR(0)-item.
        /// </summary>
        public int CursorPosition
        {
            get { return this.cursor_pos; }
        }

        public bool Equals( LR0Item other )
        {
            return !object.ReferenceEquals(other, null) &&
                this.rule.Equals(other.rule) &&
                this.cursor_pos == other.cursor_pos;
        }

        public override bool Equals( object obj )
        {
            return this.Equals(obj as LR0Item);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        /// <summary>
        /// Converts the LR(0)-item to a human readable string.
        /// </summary>
        /// <returns>The string representation of this LR(0)-item.</returns>
        public override string ToString()
        {
            int cursor_ind = this.rule.LeftHandSide.Name.Length + 2;
            for( int i = 0; i < this.cursor_pos; ++i )
                cursor_ind += this.rule.RightHandSide[i].Name.Length;

            return this.rule.ToString().Insert(cursor_ind, ".");
        }
    }
}
