using System.Collections.Generic;

namespace Cisis.Linq
{
    public static partial class LinqExtensions
    {
        /// <summary>
        /// Get count if source is <see cref="ICollection{T}"/>
        /// </summary>
        public static int? CountIfPossible<T>(this IEnumerable<T> source)
        {
            source.ThrowIfArgumentNull(nameof(source));

            if (source is ICollection<T> c) return c.Count;

            return null;
        }
    }
}