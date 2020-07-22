﻿using System.Collections.Generic;

namespace ByteDev.Collections.Sequences
{
    /// <summary>
    /// Represents a type for creating sequences.
    /// </summary>
    public static class Sequencer
    {
        /// <summary>
        /// Creates the Natural number sequence (1, 2, 3, 4...).
        /// </summary>
        /// <param name="size">Size of the sequence.</param>
        /// <returns>Collection containing the sequence of numbers.</returns>
        public static IList<int> Natural(int size)
        {
            if (size < 1)
                return new List<int>();

            var list = new List<int>(size);

            for (var i = 0; i < size; i++)
            {
                list.Add(i + 1);
            }

            return list;
        }

        /// <summary>
        /// Creates the Integer number sequence
        /// (<paramref name="start" />, +1, +2, +3...).
        /// </summary>
        /// <param name="size">Size of the sequence.</param>
        /// <param name="start">The first number in the sequence.</param>
        /// <returns>Collection containing the sequence of numbers.</returns>
        public static IList<int> Integers(int size, int start = 0)
        {
            if (size < 1)
                return new List<int>();

            var list = new List<int>(size);

            for (var i = 0; i < size; i++)
            {
                list.Add(start + i);
            }

            return list;
        }

        /// <summary>
        /// Creates the Fibonacci number sequence (0, 1, 1, 2, 3, 5...).
        /// </summary>
        /// <param name="size">Size of the sequence.</param>
        /// <returns>Collection containing the sequence of numbers.</returns>
        public static IList<int> Fibonacci(int size)
        {
            if (size < 1)
                return new List<int>();

            var list = new List<int>(size);

            var nextValue = 0;

            for (var i = 0; i < size; i++)
            {
                list.Add(nextValue);

                if (i > 0)
                    nextValue = nextValue + list[i - 1];
                else
                    nextValue = 1;
            }

            return list;
        }

        /// <summary>
        /// Creates the Prime number sequence.
        /// </summary>
        /// <param name="size">Size of the sequence.</param>
        /// <param name="start">The starting point in the sequence.</param>
        /// <returns>Collection containing the sequence of numbers.</returns>
        public static IList<int> Primes(int size, int start = 0)
        {
            if (size < 1)
                return new List<int>();

            var list = new List<int>();

            for (int i = start; i < int.MaxValue; i++)
            {
                if (i.IsPrime())
                {
                    list.Add(i);

                    if (list.Count >= size)
                        return list;
                }
            }

            return list;
        }
    }
}