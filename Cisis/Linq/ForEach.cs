using System;
using System.Collections.Generic;

namespace Cisis.Linq
{
    public static class LinqExtensions
    {
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