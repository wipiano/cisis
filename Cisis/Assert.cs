using System;

namespace Cisis
{
    public static class Assert
    {
        /// <summary>
        /// Throw ArgumentNullException if obj is null.
        /// </summary>
        public static void ThrowIfArgumentNull(this object obj, string paramName)
        {
            if (obj == null) throw new ArgumentNullException(paramName);
        }

        /// <summary>
        /// Throw ArgumentOutOfRangeException if value is less than min value or greater than max value.
        /// </summary>
        public static void ThrowIfArgumentOutOfRange(this int value, int min, int max, string name)
        {
            if (value < min) throw new ArgumentOutOfRangeException(name, value, "input value is too small");
            if (value > max) throw new ArgumentOutOfRangeException(name, value, "input value is too large");
        }
    }
}