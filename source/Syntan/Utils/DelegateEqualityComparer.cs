using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Syntan.Utils
{
    /// <summary>
    /// This class implenets a equality comparer, that delegates the comparing and hash calculating
    /// functions via <see cref="Delegate"/>s.
    /// </summary>
    /// <typeparam name="T">The type to compare.</typeparam>
    public class DelegateEqualityComparer<T> : IEqualityComparer<T>
    {
        /// <summary>
        /// Constructor that takes the delegates.
        /// </summary>
        /// <param name="comparer">Determinates whether two objects of <typeparamref name="T"/> are equal.</param>
        /// <param name="hash_code">Calculates the hash code for a given <typeparamref name="T"/> object.</param>
        public DelegateEqualityComparer( Func<T, T, bool> comparer, Func<T, int> hash_code )
        {
            this.comparer = comparer;
            this.hash_code = hash_code;
        }

        private readonly Func<T, T, bool> comparer;
        private readonly Func<T, int> hash_code;

        #region IEqualityComparer<T> Members

        public bool Equals( T x, T y )
        {
            return this.comparer(x, y);
        }

        public int GetHashCode( T obj )
        {
            return this.hash_code(obj);
        }

        #endregion
    }
}
