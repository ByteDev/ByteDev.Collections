using System;

namespace ByteDev.Collections
{
    internal static class ExceptionThrower
    {
        public static void SequenceEmpty()
        {
            throw new InvalidOperationException("Sequence contains no elements.");
        }

        public static void SequenceNoElementAt(int index)
        {
            throw new InvalidOperationException($"Sequence contains no {(index + 1).GetOrdinalName()} element.");
        }
    }
}