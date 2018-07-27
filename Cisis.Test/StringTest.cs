using Xunit;

namespace Cisis.Test
{
    public class StringTest
    {
        #region null or empty check
        [Theory]
        [InlineData(null, true)]
        [InlineData("", true)]
        [InlineData(" ", false)]
        [InlineData("foo", false)]
        public void IsNullOrEmptyTest(string s, bool expected)
        {
            s.IsNullOrEmpty().Is(expected);
        }

        [Theory]
        [InlineData(null, true)]
        [InlineData("", true)]
        [InlineData(" ", true)]
        [InlineData("foo", false)]
        public void IsNullOrWhiteSpaceTest(string s, bool expected)
        {
            s.IsNullOrWhiteSpace().Is(expected);
        }
        
        [Theory]
        [InlineData(null, false)]
        [InlineData("", false)]
        [InlineData(" ", true)]
        [InlineData("foo", true)]
        public void IsNotNullAndNotEmptyTest(string s, bool expected)
        {
            s.IsNotNullAndNotEmpty().Is(expected);
        }
        
        [Theory]
        [InlineData(null, false)]
        [InlineData("", false)]
        [InlineData(" ", false)]
        [InlineData("foo", true)]
        public void IsNotNullAndNotWhiteSpaceTest(string s, bool expected)
        {
            s.IsNotNullAndNotWhiteSpace().Is(expected);
        }
        #endregion
        
        #region convert to primitive types
        // TODO
        #endregion
    }
}