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

        [TestFixture]
        public class Triangular : SequencerTests
        {
            [TestCase(-1)]
            [TestCase(0)]
            public void WhenSizeIsZeroOrLess_ThenReturnEmpty(int size)
            {
                var result = Sequencer.Triangular(size);

                Assert.That(result, Is.Empty);
            }

            [Test]
            public void WhenSizeIs1_ThenReturnSequence()
            {
                var result = Sequencer.Triangular(1);

                Assert.That(result.Single(), Is.EqualTo(1));
            }

            [Test]
            public void WhenSizeIs8_ThenReturnSequence()
            {
                var result = Sequencer.Triangular(8);

                Assert.That(result.Count, Is.EqualTo(8));
                Assert.That(result.First(), Is.EqualTo(1));
                Assert.That(result.Second(), Is.EqualTo(3));
                Assert.That(result.Third(), Is.EqualTo(6));
                Assert.That(result.Fourth(), Is.EqualTo(10));
                Assert.That(result.Fifth(), Is.EqualTo(15));
                Assert.That(result.Sixth(), Is.EqualTo(21));
                Assert.That(result.Seventh(), Is.EqualTo(28));
                Assert.That(result.Eighth(), Is.EqualTo(36));
            }
        }

        [TestFixture]
        public class Square : SequencerTests
        {
            [TestCase(-1)]
            [TestCase(0)]
            public void WhenSizeIsZeroOrLess_ThenReturnEmpty(int size)
            {
                var result = Sequencer.Square(size);

                Assert.That(result, Is.Empty);
            }

            [Test]
            public void WhenSizeIs1_ThenReturnSequence()
            {
                var result = Sequencer.Square(1);

                Assert.That(result.Single(), Is.EqualTo(0));
            }

            [Test]
            public void WhenSizeIs8_ThenReturnSequence()
            {
                var result = Sequencer.Square(8);

                Assert.That(result.Count, Is.EqualTo(8));
                Assert.That(result.First(), Is.EqualTo(0));
                Assert.That(result.Second(), Is.EqualTo(1));
                Assert.That(result.Third(), Is.EqualTo(4));
                Assert.That(result.Fourth(), Is.EqualTo(9));
                Assert.That(result.Fifth(), Is.EqualTo(16));
                Assert.That(result.Sixth(), Is.EqualTo(25));
                Assert.That(result.Seventh(), Is.EqualTo(36));
                Assert.That(result.Eighth(), Is.EqualTo(49));
            }
        }

        [TestFixture]
        public class PowerOfTwo : SequencerTests
        {
            [TestCase(-1)]
            [TestCase(0)]
            public void WhenSizeIsZeroOrLess_ThenReturnEmpty(int size)
            {
                var result = Sequencer.PowerOfTwo(size);

                Assert.That(result, Is.Empty);
            }

            [Test]
            public void WhenSizeIs1_ThenReturnSequence()
            {
                var result = Sequencer.PowerOfTwo(1);

                Assert.That(result.Single(), Is.EqualTo(2));
            }

            [Test]
            public void WhenSizeIs8_ThenReturnSequence()
            {
                var result = Sequencer.PowerOfTwo(8);

                Assert.That(result.Count, Is.EqualTo(8));
                Assert.That(result.First(), Is.EqualTo(2));
                Assert.That(result.Second(), Is.EqualTo(4));
                Assert.That(result.Third(), Is.EqualTo(8));
                Assert.That(result.Fourth(), Is.EqualTo(16));
                Assert.That(result.Fifth(), Is.EqualTo(32));
                Assert.That(result.Sixth(), Is.EqualTo(64));
                Assert.That(result.Seventh(), Is.EqualTo(128));
                Assert.That(result.Eighth(), Is.EqualTo(256));
            }
        }

        [TestFixture]
        public class Even : SequencerTests
        {
            [TestCase(-1)]
            [TestCase(0)]
            public void WhenSizeIsZeroOrLess_ThenReturnEmpty(int size)
            {
                var result = Sequencer.Even(size);

                Assert.That(result, Is.Empty);
            }

            [Test]
            public void WhenSizeIs1_ThenReturnSequence()
            {
                var result = Sequencer.Even(1);

                Assert.That(result.Single(), Is.EqualTo(0));
            }

            [Test]
            public void WhenSizeIs8_ThenReturnSequence()
            {
                var result = Sequencer.Even(8);

                Assert.That(result.Count, Is.EqualTo(8));
                Assert.That(result.First(), Is.EqualTo(0));
                Assert.That(result.Second(), Is.EqualTo(2));
                Assert.That(result.Third(), Is.EqualTo(4));
                Assert.That(result.Fourth(), Is.EqualTo(6));
                Assert.That(result.Fifth(), Is.EqualTo(8));
                Assert.That(result.Sixth(), Is.EqualTo(10));
                Assert.That(result.Seventh(), Is.EqualTo(12));
                Assert.That(result.Eighth(), Is.EqualTo(14));
            }

            [TestCase(-1)]
            [TestCase(1)]
            public void WhenSeedIsNotEven_ThenThrowException(int seed)
            {
                Assert.Throws<ArgumentException>(() => Sequencer.Even(1, seed));
            }

            [Test]
            public void WhenSeedIsEven_ThenReturnSequence()
            {
                var result = Sequencer.Even(8, 4);

                Assert.That(result.Count, Is.EqualTo(8));
                Assert.That(result.First(), Is.EqualTo(4));
                Assert.That(result.Second(), Is.EqualTo(6));
                Assert.That(result.Third(), Is.EqualTo(8));
                Assert.That(result.Fourth(), Is.EqualTo(10));
                Assert.That(result.Fifth(), Is.EqualTo(12));
                Assert.That(result.Sixth(), Is.EqualTo(14));
                Assert.That(result.Seventh(), Is.EqualTo(16));
                Assert.That(result.Eighth(), Is.EqualTo(18));
            }

            [Test]
            public void WhenSeedIsMinusEven_ThenReturnSequence()
            {
                var result = Sequencer.Even(8, -4);

                Assert.That(result.Count, Is.EqualTo(8));
                Assert.That(result.First(), Is.EqualTo(-4));
                Assert.That(result.Second(), Is.EqualTo(-2));
                Assert.That(result.Third(), Is.EqualTo(0));
                Assert.That(result.Fourth(), Is.EqualTo(2));
                Assert.That(result.Fifth(), Is.EqualTo(4));
                Assert.That(result.Sixth(), Is.EqualTo(6));
                Assert.That(result.Seventh(), Is.EqualTo(8));
                Assert.That(result.Eighth(), Is.EqualTo(10));
            }
        }

        [TestFixture]
        public class Odd : SequencerTests
        {
            [TestCase(-1)]
            [TestCase(0)]
            public void WhenSizeIsZeroOrLess_ThenReturnEmpty(int size)
            {
                var result = Sequencer.Odd(size);

                Assert.That(result, Is.Empty);
            }

            [Test]
            public void WhenSizeIs1_ThenReturnSequence()
            {
                var result = Sequencer.Odd(1);

                Assert.That(result.Single(), Is.EqualTo(1));
            }

            [Test]
            public void WhenSizeIs8_ThenReturnSequence()
            {
                var result = Sequencer.Odd(8);

                Assert.That(result.Count, Is.EqualTo(8));
                Assert.That(result.First(), Is.EqualTo(1));
                Assert.That(result.Second(), Is.EqualTo(3));
                Assert.That(result.Third(), Is.EqualTo(5));
                Assert.That(result.Fourth(), Is.EqualTo(7));
                Assert.That(result.Fifth(), Is.EqualTo(9));
                Assert.That(result.Sixth(), Is.EqualTo(11));
                Assert.That(result.Seventh(), Is.EqualTo(13));
                Assert.That(result.Eighth(), Is.EqualTo(15));
            }

            [TestCase(-2)]
            [TestCase(0)]
            [TestCase(2)]
            public void WhenSeedIsNotOdd_ThenThrowException(int seed)
            {
                Assert.Throws<ArgumentException>(() => Sequencer.Odd(1, seed));
            }

            [Test]
            public void WhenSeedIsEven_ThenReturnSequence()
            {
                var result = Sequencer.Odd(8, 3);

                Assert.That(result.Count, Is.EqualTo(8));
                Assert.That(result.First(), Is.EqualTo(3));
                Assert.That(result.Second(), Is.EqualTo(5));
                Assert.That(result.Third(), Is.EqualTo(7));
                Assert.That(result.Fourth(), Is.EqualTo(9));
                Assert.That(result.Fifth(), Is.EqualTo(11));
                Assert.That(result.Sixth(), Is.EqualTo(13));
                Assert.That(result.Seventh(), Is.EqualTo(15));
                Assert.That(result.Eighth(), Is.EqualTo(17));
            }

            [Test]
            public void WhenSeedIsMinusEven_ThenReturnSequence()
            {
                var result = Sequencer.Odd(8, -3);

                Assert.That(result.Count, Is.EqualTo(8));
                Assert.That(result.First(), Is.EqualTo(-3));
                Assert.That(result.Second(), Is.EqualTo(-1));
                Assert.That(result.Third(), Is.EqualTo(1));
                Assert.That(result.Fourth(), Is.EqualTo(3));
                Assert.That(result.Fifth(), Is.EqualTo(5));
                Assert.That(result.Sixth(), Is.EqualTo(7));
                Assert.That(result.Seventh(), Is.EqualTo(9));
                Assert.That(result.Eighth(), Is.EqualTo(11));
            }
        }

        [TestFixture]
        public class Tetrahedral : SequencerTests
        {
            [TestCase(-1)]
            [TestCase(0)]
            public void WhenSizeIsZeroOrLess_ThenReturnEmpty(int size)
            {
                var result = Sequencer.Tetrahedral(size);

                Assert.That(result, Is.Empty);
            }

            [Test]
            public void WhenSizeIs1_ThenReturnSequence()
            {
                var result = Sequencer.Tetrahedral(1);

                Assert.That(result.Single(), Is.EqualTo(1));
            }

            [Test]
            public void WhenSizeIs8_ThenReturnSequence()
            {
                var result = Sequencer.Tetrahedral(8);
                
                Assert.That(result.Count, Is.EqualTo(8));
                Assert.That(result.First(), Is.EqualTo(1));
                Assert.That(result.Second(), Is.EqualTo(4));
                Assert.That(result.Third(), Is.EqualTo(10));
                Assert.That(result.Fourth(), Is.EqualTo(20));
                Assert.That(result.Fifth(), Is.EqualTo(35));
                Assert.That(result.Sixth(), Is.EqualTo(56));
                Assert.That(result.Seventh(), Is.EqualTo(84));
                Assert.That(result.Eighth(), Is.EqualTo(120));
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