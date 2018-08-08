using System.Linq;
using Cisis.Linq;
using Xunit;

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
    }
}