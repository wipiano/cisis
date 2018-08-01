using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Cisis
{
    /// <summary>
    /// Helper functions
    /// </summary>
    public static class Static
    {
        /// <summary>
        /// return null as T
        /// </summary>
        public static T Null<T>()
            where T : class
            => null;

        /// <summary>
        /// get range sequence
        /// </summary>
        public static IEnumerable<int> Range(int start, int count)
            => Enumerable.Range(start, count);

        /// <summary>
        /// Get empty array
        /// </summary>
        public static T[] Empty<T>() => Array.Empty<T>();
        
        /// <summary>
        /// repeat the specified value
        /// </summary>
        public static IReadOnlyCollection<T> Repeat<T>(T value, int count)
            => new RepeatCollection<T>(value, count);

        private sealed class RepeatCollection<T> : IReadOnlyCollection<T>
        {
            internal readonly T _value;
            
            public int Count { get; }

            public RepeatCollection(T value, int count)
            {
                _value = value;
                Count = count;
            }
            
            public IEnumerator<T> GetEnumerator()
            {
                return new RepeatCollectionEnumerator<T>(this);
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
        }

        private sealed class RepeatCollectionEnumerator<T> : IEnumerator<T>
        {
            private readonly RepeatCollection<T> _collection;
            private int _counter = 0;

            public RepeatCollectionEnumerator(RepeatCollection<T> collection)
            {
                _collection = collection;
            }
            
            public bool MoveNext()
            {
                return _counter++ < _collection.Count;
            }

            public void Reset()
            {
                _counter = 0;
            }

            public T Current => _collection._value;

            object IEnumerator.Current => Current;

            public void Dispose()
            {
            }
        }
    }
}