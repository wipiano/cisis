using System;
using System.Collections.Generic;

namespace Cisis.Linq
{
    public static partial class LinqExtensions
    {
        public static IEnumerable<Memory<T>> Split<T>(this IEnumerable<T> source, int blockSize)
        {
            IEnumerable<Memory<T>> EnumerateInner()
            {

                using (var e = source.GetEnumerator())
                {
                    var array = new T[blockSize];
                    var i = 0;
                    
                    while (e.MoveNext())
                    {
                        array[i++] = e.Current;

                        if (i == blockSize)
                        {
                            yield return new Memory<T>(array);
                            i = 0;
                            array = new T[blockSize];
                        }
                    }

                    if (i > 0)
                    {
                        yield return new Memory<T>(array, 0, i);
                    }
                }
            }

            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (blockSize < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(blockSize));
            }

            return EnumerateInner();
        }
    }
}