using System.Linq;
using Xunit;
using static Cisis.Static;

namespace Cisis.Test.Linq
{
    public class ToHashSetTest
    {
        [Fact]
        public void ToHashSetSimpleTest()
        {
            var seq = Range(0, 4);

            var set = seq.ToHashSet();
            
            set.Count.Is(4);

            foreach (var x in seq)
            {
                set.Contains(x).IsTrue();
            }
        }
    }
}