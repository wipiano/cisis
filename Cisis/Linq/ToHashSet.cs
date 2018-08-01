using System.Collections.Generic;

namespace Cisis.Linq
{
    public static partial class LinqExtensions
    {
        /// <summary>
        /// create <see cref="HashSet{T}"/> from <see cref="IEnumerable{T}"/>
        /// </summary>
        public static HashSet<T> ToHashSet<T>(this IEnumerable<T> source)
        {
            source.ThrowIfArgumentNull(nameof(source));
            
            return new HashSet<T>(source);
        }

        /// <summary>
        /// create <see cref="HashSet{T}"/> from <see cref="IEnumerable{T}"/>
        /// with specified <see cref="IEqualityComparer{T}"/>
        /// </summary>
        public static HashSet<T> ToHashSet<T>(this IEnumerable<T> source, IEqualityComparer<T> comparer)
        {
            source.ThrowIfArgumentNull(nameof(source));
            comparer.ThrowIfArgumentNull(nameof(comparer));
            
            return new HashSet<T>(source, comparer);
        }
    }
}