using System;
using System.Collections.Generic;

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
            return Arithmetic(size, 1, 1);
        }

        /// <summary>
        /// Creates the Integer number sequence.
        /// </summary>
        /// <param name="size">Size of the sequence.</param>
        /// <param name="start">The first number in the sequence.</param>
        /// <returns>Collection containing the sequence of numbers.</returns>
        public static IList<int> Integers(int size, int start = 0)
        {
            return Arithmetic(size, start, 1);
        }

        /// <summary>
        /// Creates a Arithmetic number sequence.
        /// </summary>
        /// <param name="size">Size of the sequence.</param>
        /// <param name="start">The starting point in the sequence.</param>
        /// <param name="commonDifference">The difference between each value in the sequence.</param>
        /// <returns>Collection containing the sequence of numbers.</returns>
        public static IList<int> Arithmetic(int size, int start, int commonDifference)
        {
            if (size < 1)
                return new List<int>();

            var list = new List<int>(size);
            var value = start;

            for (var i = 0; i < size; i++)
            {
                list.Add(value);
                value = value + commonDifference;
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
        /// Creates a Prime number sequence.
        /// </summary>
        /// <param name="size">Size of the sequence.</param>
        /// <param name="start">The starting point in the sequence.</param>
        /// <returns>Collection containing the sequence of numbers.</returns>
        public static IList<int> Primes(int size, int start = 0)
        {
            if (size < 1)
                return new List<int>();

            var list = new List<int>(size);

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

        /// <summary>
        /// Creates a Geometric number sequence.
        /// </summary>
        /// <param name="size">Size of the sequence.</param>
        /// <param name="start">The starting point in the sequence.</param>
        /// <param name="multiplier">The multiplier to apply each term to create the next.</param>
        /// <returns>Collection containing the sequence of numbers.</returns>
        public static IList<int> Geometric(int size, int start, int multiplier)
        {
            if (size < 1)
                return new List<int>();

            if (start == 0)
                throw new ArgumentException("Start cannot be zero.", nameof(start));

            var list = new List<int>(size);
            var value = start;

            while(list.Count < size)
            {
                if (list.Count > 0)
                    value = value * multiplier;

                list.Add(value);
            }

            return list;
        }
    }
}