using System;
using System.Collections.Generic;
using System.Linq;
using ByteDev.Collections.Sequences;
using NUnit.Framework;

namespace ByteDev.Collections.UnitTests.Sequences
{
    [TestFixture]
    public class SequencerTests
    {
        [TestFixture]
        public class Natural
        {
            [TestCase(-1)]
            [TestCase(0)]
            public void WhenSizeIsZeroOrLess_ThenReturnEmpty(int size)
            {
                var result = Sequencer.Natural(size);

                Assert.That(result, Is.Empty);
            }

            [Test]
            public void WhenSizeIsOne_ThenReturnSequence()
            {
                var result = Sequencer.Natural(1);

                Assert.That(result.Single(), Is.EqualTo(1));
            }

            [Test]
            public void WhenSizeIsThree_ThenReturnSequence()
            {
                var result = Sequencer.Natural(3);

                Assert.That(result.Count, Is.EqualTo(3));
                Assert.That(result.First(), Is.EqualTo(1));
                Assert.That(result.Second(), Is.EqualTo(2));
                Assert.That(result.Third(), Is.EqualTo(3));
            }
        }

        [TestFixture]
        public class Whole : SequencerTests
        {
            [TestCase(-1)]
            [TestCase(0)]
            public void WhenSizeIsZeroOrLess_ThenReturnEmpty(int size)
            {
                var result = Sequencer.Whole(size);

                Assert.That(result, Is.Empty);
            }

            [Test]
            public void WhenSizeIsOne_ThenReturnSequence()
            {
                var result = Sequencer.Whole(1);

                Assert.That(result.Single(), Is.EqualTo(0));
            }

            [Test]
            public void WhenSizeIsThree_ThenReturnSequence()
            {
                var result = Sequencer.Whole(3);

                Assert.That(result.Count, Is.EqualTo(3));
                Assert.That(result.First(), Is.EqualTo(0));
                Assert.That(result.Second(), Is.EqualTo(1));
                Assert.That(result.Third(), Is.EqualTo(2));
            }
        }

        [TestFixture]
        public class Integers
        {
            [TestCase(-1)]
            [TestCase(0)]
            public void WhenSizeIsZeroOrLess_ThenReturnEmpty(int size)
            {
                var result = Sequencer.Integers(size);

                Assert.That(result, Is.Empty);
            }

            [TestCase(1)]
            [TestCase(2)]
            [TestCase(3)]
            [TestCase(4)]
            [TestCase(5)]
            public void WhenSizeGreaterThanZero_AndStartIsZero_ThenReturnSequence(int size)
            {
                var result = Sequencer.Integers(size);

                Assert.That(result.Count, Is.EqualTo(size));
                Assert.That(result.Last(), Is.EqualTo(size - 1));
            }

            [TestCase(1)]
            [TestCase(2)]
            [TestCase(3)]
            [TestCase(4)]
            [TestCase(5)]
            public void WhenSizeGreaterThanZero_AndStartIsTwo_ThenReturnSequence(int size)
            {
                var result = Sequencer.Integers(size, 2);

                Assert.That(result.Count, Is.EqualTo(size));
                Assert.That(result.Last(), Is.EqualTo(size + 1));
            }

            [TestCase(1)]
            [TestCase(2)]
            [TestCase(3)]
            [TestCase(4)]
            [TestCase(5)]
            public void WhenSizeGreaterThanZero_AndStartIsMinusTwo_ThenReturnSequence(int size)
            {
                var result = Sequencer.Integers(size, -2);

                Assert.That(result.Count, Is.EqualTo(size));
                Assert.That(result.Last(), Is.EqualTo(size - 3));
            }
        }

        [TestFixture]
        public class Fibonacci
        {
            [TestCase(-1)]
            [TestCase(0)]
            public void WhenSizeIsZeroOrLess_ThenReturnEmpty(int size)
            {
                var result = Sequencer.Fibonacci(size);

                Assert.That(result, Is.Empty);
            }

            [TestCase(1, 0)]
            [TestCase(2, 1)]
            [TestCase(3, 1)]
            [TestCase(4, 2)]
            [TestCase(5, 3)]
            [TestCase(6, 5)]
            [TestCase(7, 8)]
            [TestCase(8, 13)]
            [TestCase(9, 21)]
            public void WhenSizeGreaterThanZero_ThenReturnSequence(int size, int lastValue)
            {
                var result = Sequencer.Fibonacci(size);

                Assert.That(result.Count, Is.EqualTo(size));
                Assert.That(result.Last(), Is.EqualTo(lastValue));
            }
        }

        [TestFixture]
        public class Primes
        {
            [TestCase(-1)]
            [TestCase(0)]
            public void WhenSizeIsZeroOrLess_ThenReturnEmpty(int size)
            {
                var result = Sequencer.Primes(size);

                Assert.That(result, Is.Empty);
            }

            [TestCase(1, 2)]
            [TestCase(2, 3)]
            [TestCase(3, 5)]
            [TestCase(4, 7)]
            [TestCase(5, 11)]
            [TestCase(6, 13)]
            [TestCase(7, 17)]
            [TestCase(8, 19)]
            [TestCase(9, 23)]
            public void WhenSizeGreaterThanZero_AndStartIsZero_ThenReturnSequence(int size, int lastValue)
            {
                var result = Sequencer.Primes(size);

                Assert.That(result.Count, Is.EqualTo(size));
                Assert.That(result.Last(), Is.EqualTo(lastValue));
            }

            [TestCase(1, 11)]
            [TestCase(2, 13)]
            [TestCase(3, 17)]
            [TestCase(4, 19)]
            [TestCase(5, 23)]
            [TestCase(6, 29)]
            [TestCase(7, 31)]
            [TestCase(8, 37)]
            [TestCase(9, 41)]
            public void WhenSizeGreaterThanZero_AndStartIsTen_ThenReturnSequence(int size, int lastValue)
            {
                var result = Sequencer.Primes(size, 10);

                Assert.That(result.Count, Is.EqualTo(size));
                Assert.That(result.Last(), Is.EqualTo(lastValue));
            }
        }

        [TestFixture]
        public class Geometric
        {
            [Test]
            public void WhenStartIsZero_ThenThrowException()
            {
                Assert.Throws<ArgumentException>(() => Sequencer.Geometric(10, 0, 2));
            }

            [TestCase(-1)]
            [TestCase(0)]
            public void WhenSizeIsZeroOrLess_ThenReturnEmpty(int size)
            {
                var result = Sequencer.Geometric(size, 1, 2);

                Assert.That(result, Is.Empty);
            }

            [TestCase(1, 1)]
            [TestCase(2, 2)]
            [TestCase(3, 4)]
            [TestCase(4, 8)]
            [TestCase(5, 16)]
            [TestCase(6, 32)]
            [TestCase(7, 64)]
            [TestCase(8, 128)]
            [TestCase(9, 256)]
            public void WhenStartOne_AndMultiplierTwo_ThenReturnSequence(int size, int lastValue)
            {
                var result = Sequencer.Geometric(size, 1, 2);

                Assert.That(result.Count, Is.EqualTo(size));
                Assert.That(result.Last(), Is.EqualTo(lastValue));
            }
        }

        [TestFixture]
        public class Arithmetic
        {
            [TestCase(-1)]
            [TestCase(0)]
            public void WhenSizeIsZeroOrLess_ThenReturnEmpty(int size)
            {
                var result = Sequencer.Arithmetic(size, 1, 2);

                Assert.That(result, Is.Empty);
            }

            [TestCase(1, 1)]
            [TestCase(2, 3)]
            [TestCase(3, 5)]
            [TestCase(4, 7)]
            [TestCase(5, 9)]
            public void WhenStartIsOne_AndDiffTwo_ThenReturnSequence(int size, int lastValue)
            {
                var result = Sequencer.Arithmetic(size, 1, 2);

                Assert.That(result.Count, Is.EqualTo(size));
                Assert.That(result.Last(), Is.EqualTo(lastValue));
            }
        }

        [TestFixture]
        public class Collatz : SequencerTests
        {
            [Test]
            public void WhenSeed0_ThenThrowException()
            {
                Assert.Throws<ArgumentException>(() => _ = Sequencer.Collatz(0));
            }
            
            [Test]
            public void WhenSeed1_ThenReturnSequence()
            {
                var result = Sequencer.Collatz(1);

                Assert.That(result.Single(), Is.EqualTo(1));
            }

            [Test]
            public void WhenSeed2_ThenReturnSequence()
            {
                var result = Sequencer.Collatz(2);

                Assert.That(result.Count, Is.EqualTo(2));
                Assert.That(result.First(), Is.EqualTo(2));
                Assert.That(result.Second(), Is.EqualTo(1));
            }

            [Test]
            public void WhenSeed10_ThenReturnSequence()
            {
                var result = Sequencer.Collatz(10);

                Assert.That(result.Count, Is.EqualTo(7));
                Assert.That(result.First(), Is.EqualTo(10));
                Assert.That(result.Second(), Is.EqualTo(5));
                Assert.That(result.Third(), Is.EqualTo(16));
                Assert.That(result.Fourth(), Is.EqualTo(8));
                Assert.That(result.Fifth(), Is.EqualTo(4));
                Assert.That(result.Sixth(), Is.EqualTo(2));
                Assert.That(result.Seventh(), Is.EqualTo(1));
            }

            [Test]
            public void WhenSeedMinus1_ThenReturnSequence()
            {
                var result = Sequencer.Collatz(-1);

                Assert.That(result.Single(), Is.EqualTo(-1));
            }

            [Test]
            public void WhenSeedMinus2_ThenReturnSequence()
            {
                var result = Sequencer.Collatz(-2);

                Assert.That(result.Count, Is.EqualTo(2));
                Assert.That(result.First(), Is.EqualTo(-2));
                Assert.That(result.Second(), Is.EqualTo(-1));
            }

            [Test]
            public void WhenSeedMinus10_ThenReturnSequence()
            {
                var result = Sequencer.Collatz(-10);

                Assert.That(result.Count, Is.EqualTo(2));
                Assert.That(result.First(), Is.EqualTo(-10));
                Assert.That(result.Second(), Is.EqualTo(-5));
            }
        }

        [TestFixture]
        public class Repeating : SequencerTests
        {
            [TestCase(-1)]
            [TestCase(0)]
            public void WhenSizeIsZeroOrLess_ThenReturnEmpty(int size)
            {
                var result = Sequencer.Repeating(size, 1);

                Assert.That(result, Is.Empty);
            }

            [Test]
            public void WhenSizeIsOne_ThenReturnSequence()
            {
                var result = Sequencer.Repeating(1, 1);

                Assert.That(result.Single(), Is.EqualTo(1));
            }

            [Test]
            public void WhenSizeIsTwo_ThenReturnSequence()
            {
                var result = Sequencer.Repeating(2, 1);

                Assert.That(result.Count, Is.EqualTo(2));
                Assert.That(result.First(), Is.EqualTo(1));
                Assert.That(result.Second(), Is.EqualTo(1));
            }
        }

        private static void PrintSequence(IEnumerable<int> result)
        {
            foreach (var i in result)
            {
                Console.WriteLine(i);
            }
        }
    }
}