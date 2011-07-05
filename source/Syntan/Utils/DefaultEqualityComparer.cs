using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Syntan.Utils
{
    /// <summary>
    /// Generic euqality comparer class, that compares two object
    /// forst by reference, and then (if not <c>null</c>) by the
    /// object's Equals() method.
    /// </summary>
    /// <typeparam name="T">The type to compare.</typeparam>
    public class DefaultEqualityComparer<T> : IEqualityComparer<T>
    {
        #region IEqualityComparer<T> Members

        /// <summary>
        /// Determinates whether the two object considered equal.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns><c>true</c> if the x and y are considered euqal, <c>false</c>< otherwise./returns>
        public bool Equals( T x, T y )
        {
            return
                (object.ReferenceEquals(x, null) && object.ReferenceEquals(y, null)) ||
                (!object.ReferenceEquals(x, null) && x.Equals(y));
        }

        /// <summary>
        /// Returns the <paramref name="obj"/>'s default hash code.
        /// </summary>
        /// <param name="obj">The object to get the hash code for.</param>
        /// <returns>Object's default hash code.</returns>
        public int GetHashCode( T obj )
        {
            return obj.GetHashCode();
        }

        #endregion
    }
}
