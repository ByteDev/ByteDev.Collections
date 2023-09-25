using System;

namespace ByteDev.Collections
{
    internal static class IntExtensions
    {
        public static string GetOrdinalName(this int source)
        {
            switch (source)
            {
                case 2:
                    return "second";
                case 3:
                    return "third";
                case 4:
                    return "fourth";
                case 5:
                    return "fifth";
                case 6:
                    return "sixth";
                case 7:
                    return "seventh";
                case 8:
                    return "eighth";
                case 9:
                    return "ninth";
                case 10:
                    return "tenth";
                default:
                    throw new InvalidOperationException($"Ordinal name of: {source} was not handled.");
            }
        }
    }
}