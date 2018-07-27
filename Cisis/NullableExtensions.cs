using System;
namespace Cisis
{
    public static class NullableExtensions
    {
        /// <summary>
        /// Attempts to get the value from <see cref="Nullable{T}"/>
        /// </summary>
        public static bool TryGetValue<T>(this T? nullable, out T value)
            where T : struct
        {
            value = nullable ?? default;
            return nullable.HasValue;
        }
    }
}