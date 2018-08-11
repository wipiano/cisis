using System.Collections.Generic;
using System.Linq;

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

            if (source is IReadOnlyCollection<T> rc) return rc.Count;

            return null;
        }

        public static bool CountLt<T>(this IEnumerable<T> source, int value)
        {
            source.ThrowIfArgumentNull(nameof(source));
            value.ThrowIfArgumentOutOfRange(1, int.MaxValue, nameof(value));

            if (source.CountIfPossible().TryGetValue(out var c))
            {
                return c < value;
            }

            int count = 0;

            using (var enumerator = source.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    count++;

                    if (count >= value)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public static bool CountLe<T>(this IEnumerable<T> source, int value)
        {
            source.ThrowIfArgumentNull(nameof(source));
            value.ThrowIfArgumentOutOfRange(0, int.MaxValue, nameof(value));

            if (source.CountIfPossible().TryGetValue(out var c))
            {
                return c <= value;
            }

            int count = 0;

            using (var enumerator = source.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    count++;

                    if (count > value)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public static bool CountGt<T>(this IEnumerable<T> source, int value)
        {
            source.ThrowIfArgumentNull(nameof(source));
            value.ThrowIfArgumentOutOfRange(0, int.MaxValue, nameof(value));

            if (source.CountIfPossible().TryGetValue(out var c))
            {
                return c > value;
            }

            int count = 0;

            using (var enumerator = source.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    count++;

                    if (count > value)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public static bool CountGe<T>(this IEnumerable<T> source, int value)
        {
            source.ThrowIfArgumentNull(nameof(source));
            value.ThrowIfArgumentOutOfRange(0, int.MaxValue, nameof(value));

            if (source.CountIfPossible().TryGetValue(out var c))
            {
                return c >= value;
            }

            int count = 0;

            using (var enumerator = source.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    count++;

                    if (count >= value)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public static bool CountEq<T>(this IEnumerable<T> source, int value)
        {
            source.ThrowIfArgumentNull(nameof(source));
            value.ThrowIfArgumentOutOfRange(0, int.MaxValue, nameof(value));

            if (source.CountIfPossible().TryGetValue(out var c))
            {
                return c == value;
            }

            int count = 0;

            using (var enumerator = source.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    count++;

                    if (count > value)
                    {
                        return false;
                    }
                }
            }

            return count == value;
        }
    }
}