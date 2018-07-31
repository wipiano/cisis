using System;
using System.Collections.Generic;

namespace Cisis.Linq
{
    public static partial class LinqExtensions
    {
        /// <summary>
        /// Perform the specified action on each element of the <see cref="List{T}"/>
        /// </summary>
        public static void ForEach<T>(this IEnumerable<T> source, Action<T> action)
        {
            source.ThrowIfArgumentNull(nameof(source));
            action.ThrowIfArgumentNull(nameof(action));
            
            using (var e = source.GetEnumerator())
            {
                while (e.MoveNext())
                {
                    action(e.Current);
                }
            }
        }
    }
}