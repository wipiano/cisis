namespace Cisis
{
    public static class NullableExtensions
    {
        public static bool TryGetValue<T>(this T? nullable, out T value)
            where T : struct
        {
            value = nullable ?? default;
            return nullable.HasValue;
        }
    }
}