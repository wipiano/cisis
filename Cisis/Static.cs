namespace Cisis
{
    /// <summary>
    /// Helper functions
    /// </summary>
    public static class Static
    {
        /// <summary>
        /// return null as T
        /// </summary>
        public static T Null<T>()
            where T : class
            => null;
    }
}