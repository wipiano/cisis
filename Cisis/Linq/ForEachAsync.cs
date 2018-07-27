using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Cisis.Linq
{
    public static class LinqEx
    {
        /// <summary>
        /// Perform the specified async action on each element
        /// of the <see cref="List{T}"/> with the specified concurrency.
        /// </summary>
        public static Task ForEachAsync<T>(this IEnumerable<T> source, Func<T, Task> asyncAction, int concurrency,
            CancellationToken cancellationToken = default)
        {
            source.ThrowIfArgumentNull(nameof(source));
            asyncAction.ThrowIfArgumentNull(nameof(asyncAction));
            concurrency.ThrowIfArgumentOutOfRange(1, int.MaxValue, nameof(concurrency));

            async Task ForEachInner()
            {
                int throwedCount = 0;

                void OnFault(Exception e)
                {
                    Interlocked.Add(ref throwedCount, 1);
                    throw e;
                }

                using (var tasks = new TaskSet(concurrency, OnFault))
                {
                    foreach (var x in source)
                    {
                        if (throwedCount > 0) break;
                        cancellationToken.ThrowIfCancellationRequested();

                        await tasks.AddAsync(x, asyncAction).ConfigureAwait(false);
                    }

                    await tasks.WhenAll().ConfigureAwait(false);
                }
            }

            return ForEachInner();
        }

        private sealed class TaskSet : IDisposable
        {
            private readonly Task[] _tasks;
            private readonly ConcurrentStack<int> _unusedIndexes;
            private readonly Action<Exception> _faultedAction;
            private readonly SemaphoreSlim _semaphore;

            public TaskSet(int concurrency, Action<Exception> faulted)
            {
                _tasks = new Task[concurrency];
                _unusedIndexes = new ConcurrentStack<int>(Enumerable.Range(0, concurrency));
                _faultedAction = faulted;
                _semaphore = new SemaphoreSlim(concurrency, concurrency);
            }

            public async Task AddAsync<T>(T arg, Func<T, Task> asyncAction)
            {
                await _semaphore.WaitAsync().ConfigureAwait(false);
                if (!_unusedIndexes.TryPop(out int index)) throw new Exception();

                var task = asyncAction(arg).ContinueWith(t =>
                {
                    _unusedIndexes.Push(index);
                    _semaphore.Release();

                    if (t.IsFaulted)
                    {
                        _faultedAction(t.Exception);
                    }
                });

                _tasks[index] = task;
            }

            public Task WhenAll() => Task.WhenAll(_tasks.Where(t => t != null));

            void IDisposable.Dispose() => _semaphore.Dispose();
        }
    }
}