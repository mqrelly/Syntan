using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Syntan.Utils
{
    /// <summary>
    /// Represents the a relation in square matrix form, and provides static methods to calculate
    /// the relation's transitive, or reflexive closure.
    /// </summary>
    public class RelationMatrix
    {
        /// <summary>
        /// Creates a new square matrix of <see cref="bool"/> with the given size.
        /// </summary>
        /// <param name="dimension">The size of the square matrix.</param>
        public RelationMatrix( int dimension )
        {
            this.dim = dimension;
            this.relations = new bool[this.dim, this.dim];
        }

        private int dim;
        private bool[,] relations;

        /// <summary>
        /// Gets the size of this matrix.
        /// </summary>
        public int Dimension
        {
            get { return this.dim; }
        }

        /// <summary>
        /// Gets or sets the represented relation between the two indiced elements.
        /// <c>true</c> symbolizes that the element <paramref name="i"/> is in relation
        /// with <paramref name="j"/>.
        /// </summary>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <returns></returns>
        public bool this[int i, int j]
        {
            get { return this.relations[i, j]; }
            set { this.relations[i, j] = value; }
        }

        /// <summary>
        /// Copies the content of this matrix into the given <paramref name="other"/> one.
        /// The dimensions of the matrices must be the same.
        /// </summary>
        /// <param name="other">The matrix to copy into.</param>
        /// <exception cref="ArgumentNullException"> if <paramref name="other"/> is <c>null</c>.</exception>
        /// <exception cref="ArguemtnException"> if <paramref name="other"/> has not the same dimension as this matrix.</exception>
        public void CopyTo( RelationMatrix other )
        {
            if( other == null )
                throw new ArgumentNullException("other");
            if( this.dim != other.dim )
                throw new ArgumentException("Dimension mismatch.");

            for( int i = 0; i < this.dim; ++i )
                for( int j = 0; j < this.dim; ++j )
                    other.relations[i, j] = this.relations[i, j];
        }

        /// <summary>
        /// Creates and returns a new matrix instance with the contents of this matrix.
        /// </summary>
        /// <returns>A new instance, a copy of this.</returns>
        public RelationMatrix Copy()
        {
            var copy = new RelationMatrix(this.dim);
            this.CopyTo(copy);
            return copy;
        }

        /// <summary>
        /// Tells if this matrix is considered equal to the given one.
        /// </summary>
        /// <param name="other">The other matrix to compare with.</param>
        /// <returns><c>true</c> if the given matrix is equal to this, <c>false</c> otherwise.</returns>
        public bool Equals( RelationMatrix other )
        {
            return other != null &&
                this.dim == other.dim &&
                Array.Equals(this.relations, other.relations);
        }

        public override bool Equals( object obj )
        {
            return this.Equals(obj as RelationMatrix);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            for( int i = 0; i < this.dim; ++i )
            {
                for( int j = 0; j < this.dim; ++j )
                    sb.Append(this.relations[i, j] ? "1" : ".");
                sb.AppendLine();
            }

            return sb.ToString();
        }

        public static void WharshallAlg( RelationMatrix left, RelationMatrix right, RelationMatrix result )
        {
            if( left == null )
                throw new ArgumentNullException("left");
            if( right == null )
                throw new ArgumentNullException("right");
            if( result == null )
                throw new ArgumentNullException("result");
            if( left.Dimension != right.Dimension || left.Dimension != result.Dimension )
                throw new ArgumentException("Dimension mismatch.");

            for( int j = 0; j < left.Dimension; ++j )
                for( int i = 0; i < left.Dimension; ++i )
                    if( left[i, j] )
                        for( int k = 0; k < left.Dimension; ++k )
                            if( right[j, k] )
                                result[i, k] = true;
        }

        public static void TransitiveClosure( RelationMatrix relation, RelationMatrix result )
        {
            var temp = relation.Copy();
            relation.CopyTo(result);

            for( int i = 0; i < relation.Dimension - 1; ++i )
            {
                WharshallAlg(temp, relation, result);
                result.CopyTo(temp);
            }
        }

        public static void ReflexiveClosure( RelationMatrix relation )
        {
            // Set the diagonal to 'true's.
            for( int i = 0; i < relation.Dimension; ++i )
                relation[i, i] = true;
        }
    }
}
