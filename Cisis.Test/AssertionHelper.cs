using System;

namespace Cisis.Test
{
    public static class AssertionHelper
    {
        public static void Throws<T>(this Action action)
            where T : Exception
        {
            Xunit.Assert.Throws<T>(action);
        }

        public static void NotThrows(this Action action)
        {
            action();
        }

        public static void NotThrows<T>(this Action action)
            where T : Exception
        {
            try
            {
                action();
            }
            catch (Exception e) when (!(e is T))
            {
                
            }
        }
    }
}