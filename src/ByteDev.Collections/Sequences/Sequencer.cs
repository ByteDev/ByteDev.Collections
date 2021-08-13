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
        /// Creates the Whole number sequence (0, 1, 2, 3...).
        /// </summary>
        /// <param name="size">Size of the sequence.</param>
        /// <returns>Collection containing the sequence of numbers.</returns>
        public static IList<int> Whole(int size)
        {
            return Integers(size);
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
        /// <param name="seed">Seed value to start the sequence with.</param>
        /// <param name="commonDifference">The difference between each value in the sequence.</param>
        /// <returns>Collection containing the sequence of numbers.</returns>
        public static IList<int> Arithmetic(int size, int seed, int commonDifference)
        {
            if (size < 1)
                return new List<int>();

            var list = new List<int>(size);

            for (var i = 0; i < size; i++)
            {
                list.Add(seed);
                seed += commonDifference;
            }

            return list;
        }

        /// <summary>
        /// Creates a Geometric number sequence.
        /// </summary>
        /// <param name="size">Size of the sequence.</param>
        /// <param name="seed">Seed value to start the sequence with.</param>
        /// <param name="multiplier">The multiplier to apply each term to create the next.</param>
        /// <returns>Collection containing the sequence of numbers.</returns>
        public static IList<int> Geometric(int size, int seed, int multiplier)
        {
            if (size < 1)
                return new List<int>();

            if (seed == 0)
                throw new ArgumentException("Seed cannot be zero.", nameof(seed));

            var list = new List<int>(size);

            while(list.Count < size)
            {
                list.Add(seed);
                seed = seed * multiplier;
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

            var value = 0;

            for (var i = 0; i < size; i++)
            {
                list.Add(value);

                if (i > 0)
                    value = value + list[i - 1];
                else
                    value = 1;
            }

            return list;
        }

        /// <summary>
        /// Creates a Prime number sequence.
        /// </summary>
        /// <param name="size">Size of the sequence.</param>
        /// <param name="seed">Seed value to start the sequence with.</param>
        /// <returns>Collection containing the sequence of numbers.</returns>
        public static IList<int> Primes(int size, int seed = 0)
        {
            if (size < 1)
                return new List<int>();

            var list = new List<int>(size);

            for (int i = seed; i < int.MaxValue; i++)
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
        /// Creates a Collatz (AKA 3N+1) sequence starting with the initial seed value.
        /// Sequence will halt when reaching the four known infinite cycles: 1, -1, -5 or -17.
        /// </summary>
        /// <param name="seed">Seed value to start the sequence with.</param>
        /// <returns>Collection containing the sequence of numbers.</returns>
        /// <exception cref="T:System.ArgumentException"><paramref name="seed" />Seed cannot be zero.</exception>
        public static IList<int> Collatz(int seed)
        {
            if (seed == 0)
                throw new ArgumentException("Seed cannot be zero.");

            var list = new List<int> { seed };
            
            while (seed != 1 && seed != -1 && seed != -5 && seed != -17)
            {
                if (seed % 2 == 0)          // Even
                    seed = seed / 2;
                else                        // Odd
                    seed = (3 * seed) + 1;

                list.Add(seed);
            }

            return list;
        }
    }
}