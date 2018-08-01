using System.Linq;
using Cisis.Linq;
using Xunit;

namespace Cisis.Test.Linq
{
    public class SplitTest
    {
        [Fact]
        public void SmallSourceSplitTest()
        {
            var splitted = Enumerable.Range(0, 4).Split(1).ToArray();

            splitted.Length.Is(4);

            for (var i = 0; i < 4; i++)
            {
                var span = splitted[i].Span;
                span.Length.Is(1);
                span[0].Is(i);
            }
        }

        [Fact]
        public void SmallSourceSplitReferenceTypeTest()
        {
            var splitted = Enumerable.Range(0, 4).Select(x => new IntWrapper(x))
                .Split(2).ToArray();
            
            splitted.Length.Is(2);

            for (var i = 0; i < 2; i++)
            {
                for (var j = 0; j < 2; j++)
                {
                    splitted[i].Span[j].Value.Is(i * 2 + j);
                }
            }
        }

        [Fact]
        public void NotSplittedTest()
        {
            var splitted = Enumerable.Range(0, 4).Split(4).ToArray();
            
            splitted.Length.Is(1);
            splitted[0].Span.ToArray().Is(Enumerable.Range(0, 4));
            
            var splitted2 = Enumerable.Range(0, 4).Split(100).ToArray();
            
            splitted2.Length.Is(1);
            splitted2[0].Span.ToArray().Is(Enumerable.Range(0, 4));
        }

        [Fact]
        public void LargeSourceSplitTest()
        {
            var splitted = Enumerable.Range(0, 1000).Split(100).ToArray();
            
            splitted.Length.Is(10);

            foreach (var block in splitted)
            {
                block.Span.Length.Is(100);
            }
            
            splitted.SelectMany(s => s.Span.ToArray()).Is(Enumerable.Range(0, 1000));
        }

        public sealed class IntWrapper
        {
            public int Value { get; }

            public IntWrapper(int value)
            {
                Value = value;
            }
        }
    }
}