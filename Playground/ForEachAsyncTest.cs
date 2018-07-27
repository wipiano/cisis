using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Threading.Tasks;
using Cisis.Linq;

namespace Playground
{
    public class ForEachAsyncTest
    {
        public async Task ForEachAsyncShortSequenceTest()
        {
            Console.WriteLine(nameof(ForEachAsyncShortSequenceTest) + " running.");
            
            var list = new ConcurrentBag<int>();

            await Enumerable.Range(1, 100).ForEachAsync(async x =>
            {
                await Task.Delay(x);
                list.Add(x);
            }, 10);
            
            var result = list.OrderBy(x => x).SequenceEqual(Enumerable.Range(1, 100));
            
            Console.WriteLine(result);
        }
        
        public async Task ForEachAsyncLargeSequenceTest()
        {
            Console.WriteLine(nameof(ForEachAsyncLargeSequenceTest) + " running.");
            
            var list = new ConcurrentBag<int>();

            await Enumerable.Range(1, (int)Math.Pow(10, 7))
                .ForEachAsync(async (x) =>
                {
                    if (x % 100000 == 0)
                    {
                        Console.WriteLine(x);
                    }
                    
                    await Task.Delay(10);
                    if (x <= 10)
                    {
                        list.Add(x);
                    }
                }, 1000000);
            
            
            var result = list.OrderBy(x => x).SequenceEqual(Enumerable.Range(1, 10));
            
            Console.WriteLine(string.Join(", ", list.OrderBy(x => x)));
            Console.WriteLine(result);
        }
    }
}