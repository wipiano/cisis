using System.Linq;
using Cisis.Linq;
using Xunit;
using static Cisis.Static;

namespace Cisis.Test.Linq
{
    public class CountTest
    {
        [Fact]
        public void CountIfPossibleTest()
        {
            new int[3].CountIfPossible().Is(3);

            Enumerable.Range(0, 4).Where(x => x < 2).CountIfPossible().IsNull();
        }

        [Theory]
        [InlineData(1, 2, true)]
        [InlineData(2, 2, false)]
        [InlineData(3, 2, false)]
        public void CountLtTest(int sourceLength, int maxLength, bool expected)
        {
            Range(0, sourceLength).CountLt(maxLength).Is(expected);
            new int[sourceLength].CountLt(maxLength).Is(expected);
        }

        [Theory]
        [InlineData(1, 2, true)]
        [InlineData(2, 2, true)]
        [InlineData(3, 2, false)]
        public void CountLeTest(int sourceLength, int maxLength, bool expected)
        {
            Range(0, sourceLength).CountLe(maxLength).Is(expected);
            new int[sourceLength].CountLe(maxLength).Is(expected);
        }
        
        [Theory]
        [InlineData(1, 2, false)]
        [InlineData(2, 2, false)]
        [InlineData(3, 2, true)]
        public void CountGtTest(int sourceLength, int minLength, bool expected)
        {
            Range(0, sourceLength).CountGt(minLength).Is(expected);
            new int[sourceLength].CountGt(minLength).Is(expected);
        }
        
        [Theory]
        [InlineData(1, 2, false)]
        [InlineData(2, 2, true)]
        [InlineData(3, 2, true)]
        public void CountGeTest(int sourceLength, int minLength, bool expected)
        {
            Range(0, sourceLength).CountGe(minLength).Is(expected);
            new int[sourceLength].CountGe(minLength).Is(expected);
        }
    }
}