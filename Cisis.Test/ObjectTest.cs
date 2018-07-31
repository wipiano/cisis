using Xunit;

namespace Cisis.Test
{
    public class ObjectTest
    {
        [Fact]
        public void MapTest()
        {
            1.Map(x => x * 2).Is(2);
        }
    }
}