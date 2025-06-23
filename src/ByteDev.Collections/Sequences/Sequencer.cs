using System;
using System.Collections.Generic;
using System.Linq;

namespace ByteDev.Collections.Sequences
{
    /// <summary>
    /// Represents a type for creating list sequences.
    /// </summary>
    public static class Sequencer
    {
        /// <summary>
        /// Creates the Natural (AKA Counting) number sequence (1, 2, 3, 4...).
        /// </summary>
        /// <param name="size">Size of the sequence.</param>
        /// <returns>Sequence of numbers.</returns>
        public static IEnumerable<int> Natural(int size)
        {
            return Arithmetic(size, 1, 1);
        }

        /// <summary>
        /// Creates the Whole number sequence (0, 1, 2, 3...).
        /// </summary>
        /// <param name="size">Size of the sequence.</param>
        /// <returns>Sequence of numbers.</returns>
        public static IEnumerable<int> Whole(int size)
        {
            return Integers(size, 0);
        }

        /// <summary>
        /// Creates the Integer number sequence.
        /// </summary>
        /// <param name="size">Size of the sequence.</param>
        /// <param name="start">The first number in the sequence.</param>
        /// <returns>Sequence of numbers.</returns>
        public static IEnumerable<int> Integers(int size, int start)
        {
            return Arithmetic(size, start, 1);
        }

        /// <summary>
        /// Creates a Arithmetic number sequence.
        /// </summary>
        /// <param name="size">Size of the sequence.</param>
        /// <param name="seed">Seed value to start the sequence with.</param>
        /// <param name="difference">The difference between each value in the sequence.</param>
        /// <returns>Sequence of numbers.</returns>
        public static IEnumerable<int> Arithmetic(int size, int seed, int difference)
        {
            if (size < 1)
                yield break;

            for (var i = 0; i < size; i++)
            {
                yield return seed;
                seed += difference;
            }
        }

        /// <summary>
        /// Creates a Geometric number sequence.
        /// </summary>
        /// <param name="size">Size of the sequence.</param>
        /// <param name="seed">Seed value to start the sequence with.</param>
        /// <param name="multiplier">The multiplier to apply each term to create the next.</param>
        /// <returns>Sequence of numbers.</returns>
        public static IEnumerable<int> Geometric(int size, int seed, int multiplier)
        {
            if (seed == 0)
                throw new ArgumentException("Seed cannot be zero.", nameof(seed));

            if (size < 1)
                yield break;
            
            for (var i = 0; i < size; i++)
            {
                yield return seed;
                seed = seed * multiplier;
            }
        }

        /// <summary>
        /// Creates the Fibonacci number sequence (0, 1, 1, 2, 3, 5...).
        /// </summary>
        /// <param name="size">Size of the sequence.</param>
        /// <returns>Sequence of numbers.</returns>
        public static IEnumerable<int> Fibonacci(int size)
        {
            var prev = -1;
            var next = 1;

            for (var i = 0; i < size; i++)
            {
                var value = prev + next;
                
                prev = next;
                next = value;

                yield return value;
            }
        }

        /// <summary>
        /// Creates a Prime number sequence.
        /// </summary>
        /// <param name="size">Size of the sequence.</param>
        /// <param name="seed">Seed value to start the sequence with.</param>
        /// <returns>Sequence of numbers.</returns>
        public static IEnumerable<int> Primes(int size, int seed = 0)
        {
            if (size < 1)
                yield break;

            int count = 0;

            for (var i = seed; i < int.MaxValue; i++)
            {
                if (i.IsPrime())
                {
                    count++;
                    yield return i;

                    if (count >= size)
                        yield break;
                }
            }
        }

        /// <summary>
        /// Creates a Collatz (AKA 3N+1) number sequence starting with the initial seed value.
        /// Sequence will halt when reaching the four known infinite cycles: 1, -1, -5 or -17.
        /// </summary>
        /// <param name="seed">Seed value to start the sequence with.</param>
        /// <returns>Sequence of numbers.</returns>
        /// <exception cref="T:System.ArgumentException"><paramref name="seed" />Seed cannot be zero.</exception>
        public static IEnumerable<int> Collatz(int seed)
        {
            if (seed == 0)
                throw new ArgumentException("Seed cannot be zero.");

            yield return seed;

            while (seed != 1 && seed != -1 && seed != -5 && seed != -17)
            {
                if (seed.IsEven())
                    seed = seed / 2;
                else // Odd
                    seed = (3 * seed) + 1;

                yield return seed;
            }
        }

        /// <summary>
        /// Creates a sequence of repeating values.
        /// </summary>
        /// <param name="size">Size of the sequence.</param>
        /// <param name="value">Value of each element.</param>
        /// <returns>Sequence of numbers.</returns>
        public static IEnumerable<int> Repeating(int size, int value)
        {
            if (size < 1)
                yield break;

            for (var i = 0; i < size; i++)
                yield return value;
        }

        /// <summary>
        /// Creates the Triangular number sequence (1, 3, 6, 10, 15 ...).
        /// </summary>
        /// <param name="size">Size of the sequence.</param>
        /// <returns>Sequence of numbers.</returns>
        public static IEnumerable<int> Triangular(int size)
        {
            if (size < 1)
                yield break;

            var value = 0;

            for (var i = 1; i <= size; i++)
            {
                value += i;
                yield return value;
            }
        }

        /// <summary>
        /// Creates a sequence of the Natural numbers squared (1, 4, 9, 16, 25 ...).
        /// </summary>
        /// <param name="size">Size of the sequence.</param>
        /// <returns>Sequence of numbers.</returns>
        public static IEnumerable<int> Square(int size)
        {
            if (size < 1)
                yield break;

            for (var i = 1; i <= size; i++)
                yield return i * i;
        }

        /// <summary>
        /// Creates a sequence of the Natural numbers cubed (1, 8, 27, 64, 125 ...).
        /// </summary>
        /// <param name="size">Size of the sequence.</param>
        /// <returns>Sequence of numbers.</returns>
        public static IEnumerable<int> Cube(int size)
        {
            if (size < 1)
                yield break;

            for (var i = 1; i <= size; i++)
                 yield return i * i * i;
        }

        /// <summary>
        /// Creates the power of 2 (AKA 2 to the power of n) number sequence (2, 4, 8, 16, 32, 64, 128 ...).
        /// </summary>
        /// <param name="size">Size of the sequence.</param>
        /// <returns>Sequence of numbers.</returns>
        public static IEnumerable<int> PowerOfTwo(int size)
        {
            if (size < 1)
                yield break;

            for (var i = 1; i <= size; i++)
                yield return (int)Math.Pow(2, i);
        }

        /// <summary>
        /// Creates the even number sequence.
        /// </summary>
        /// <param name="size">Size of the sequence.</param>
        /// <param name="seed">Seed value to start the sequence with. By default seed is 0.</param>
        /// <returns>Sequence of even numbers.</returns>
        /// <exception cref="T:System.ArgumentException"><paramref name="seed" /> is not an even number.</exception>
        public static IEnumerable<int> Even(int size, int seed = 0)
        {
            if (!seed.IsEven())
                throw new ArgumentException("Seed was not an even number.");

            if (size <= 0)
                yield break;

            for (int i = seed; i < (size * 2) + seed; i++)
            {
                if (i.IsEven())
                    yield return i;
            }
        }

        /// <summary>
        /// Creates the odd number sequence.
        /// </summary>
        /// <param name="size">Size of the sequence.</param>
        /// <param name="seed">Seed value to start the sequence with. By default seed is 1.</param>
        /// <returns>List containing the sequence of numbers.</returns>
        /// <exception cref="T:System.ArgumentException"><paramref name="seed" /> is not an odd number.</exception>
        public static IEnumerable<int> Odd(int size, int seed = 1)
        {
            if (!seed.IsOdd())
                throw new ArgumentException("Seed was not an odd number.");

            if (size <= 0)
                yield break;

            for (int i = seed; i < (size * 2) + seed; i++)
            {
                if (i.IsOdd())
                    yield return i;
            }
        }

        /// <summary>
        /// Creates the Tetrahedral number sequence (1, 4, 10, 20, 35 ...).
        /// </summary>
        /// <param name="size">Size of the sequence.</param>
        /// <returns>Sequence of numbers.</returns>
        public static IEnumerable<int> Tetrahedral(int size)
        {
            if (size < 1)
                yield break;
            
            var triangularNumber = 0;
            var value = 0;

            for (var i = 1; i <= size; i++)
            {
                triangularNumber += i;
                value += triangularNumber;
                yield return value;
            }
        }
    }
}