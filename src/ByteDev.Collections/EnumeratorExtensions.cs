using System.Collections.Generic;

namespace ByteDev.Collections
{
    internal static class EnumeratorExtensions
    {
        public static bool MoveNext<T>(this IEnumerator<T> source, int numberMoves)
        {
            for (int i = 0; i < numberMoves; i++)
            {
                if (source.MoveNext() == false)
                    return false;
            }

            return true;
        }
    }
}