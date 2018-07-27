using System.Threading.Tasks;

namespace Playground
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var test = new ForEachAsyncTest();
            await test.ForEachAsyncShortSequenceTest();
            await test.ForEachAsyncLargeSequenceTest();
        }
    }
}