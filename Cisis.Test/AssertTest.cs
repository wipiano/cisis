using System;
using Xunit;

namespace Cisis.Test
{
    public class AssertTest
    {
        [Fact]
        public void ThrowIfArgumentNullTest()
        {
            Action ThrowIfArgumentNull(object obj)
            {
                return () => obj.ThrowIfArgumentNull("paramName");
            }
            
            // do nothing
            ThrowIfArgumentNull(new object()).NotThrows();
            
            // throws ArgumentNullException
            ThrowIfArgumentNull(null).Throws<ArgumentNullException>();
        }

        [Fact]
        public void ThrowIfArgumentOutOfRangeTest()
        {
            Action ThrowIfArgumentOutOfRange(int value, int min, int max)
                => () => value.ThrowIfArgumentOutOfRange(min, max, "paramName");
            
            ThrowIfArgumentOutOfRange(4, 1, 6).NotThrows();
            
            // equals min value
            ThrowIfArgumentOutOfRange(1, 1, 6).NotThrows();
            
            // equals max value
            ThrowIfArgumentOutOfRange(6, 1, 6).NotThrows();
            
            // less than min value
            ThrowIfArgumentOutOfRange(0, 1, 6).Throws<ArgumentOutOfRangeException>();
            
            // greater than max value
            ThrowIfArgumentOutOfRange(7, 1, 6).Throws<ArgumentOutOfRangeException>();
        }
        
    }
}