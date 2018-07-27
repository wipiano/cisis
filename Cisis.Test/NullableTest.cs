using Xunit;

namespace Cisis.Test
{
    public class NullableTest
    {
        [Theory]
        [InlineData(1, 1, true)]
        [InlineData(null, 0, false)]
        public void TryGetValueTest(int? nullable, int expectedValue, bool expectedReturn)
        {
            nullable.TryGetValue(out int value).Is(expectedReturn);
            value.Is(expectedValue);
        }
    }
}