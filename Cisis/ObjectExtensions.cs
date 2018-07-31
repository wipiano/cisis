using System;

namespace Cisis
{
    public static class ObjectExtensions
    {
        /// <summary>
        /// Map T1 to T2
        /// </summary>
        public static T2 Map<T1, T2>(this T1 v, Func<T1, T2> mapper)
            => mapper(v);
    }
}