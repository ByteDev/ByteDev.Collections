using System;

namespace ByteDev.Collections.Sequences
{
    internal static class IntExtensions
    {
        public static bool IsPrime(this int source)
        {
            if (source < 2) 
                return false;

            if (source == 2) 
                return true;

            if (source % 2 == 0) 
                return false;

            var boundary = (int)Math.Floor(Math.Sqrt(source));

            for (long i = 3; i <= boundary; i += 2)
            {
                if (source % i == 0)
                    return false;
            }
            
            return true;        
        }

        public static bool IsEven(this int source)
        {
            return source.IsMultipleOf(2);
        }

        public static bool IsOdd(this int source)
        {
            return !IsEven(source);
        }

        public static bool IsMultipleOf(this int source, int value)
        {
            if (value == 0)
                return true;
            
            return source % value == 0;
        }
    }
}