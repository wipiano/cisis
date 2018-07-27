using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cisis.Linq;
using Xunit;
using static System.Array;

namespace Cisis.Test.Linq
{
    public class ForEachAsyncTest
    {
        [Fact]
        public void ForEachAsyncArgumentCheckTest()
        {
            Action ForEachAsync(IEnumerable<int> source, Func<int, Task> action, int concurrency)
                => () => source.ForEachAsync(action, concurrency);

            // source is null
            ForEachAsync(null, Task.Delay, 100).Throws<ArgumentNullException>();
            
            // action is null
            ForEachAsync(Empty<int>(), null, 100).Throws<ArgumentNullException>();
            
            // concurrency is zero
            ForEachAsync(Empty<int>(), Task.Delay, 0).Throws<ArgumentOutOfRangeException>();
            
            // concurrency is negative
            ForEachAsync(Empty<int>(), Task.Delay, -1).Throws<ArgumentOutOfRangeException>();
        }

        [Fact]
        public async Task ForEachAsyncShortSequenceTest()
        {
            var list = new ConcurrentBag<int>();

            await Enumerable.Range(1, 100).ForEachAsync(async x =>
            {
                await Task.Delay(x);
                list.Add(x);
            }, 10);
            
            list.OrderBy(x => x).Is(Enumerable.Range(1, 100));
        }

        [Fact(Skip = "this test wastes long time.")]
        public async Task ForEachAsyncLargeSequenceTest()
        {
            var list = new ConcurrentBag<int>();

            await Enumerable.Range(1, (int)Math.Pow(10, 7))
                .ForEachAsync(async (x) =>
                {
                    await Task.Delay(10);
                    if (x <= 10)
                    {
                        list.Add(x);
                    }
                }, 1000000);
            
            
            list.OrderBy(x => x).Is(Enumerable.Range(1, 10));
        }
    }
}