using System.Linq;
using ByteDev.Collections.Sequences;
using NUnit.Framework;

namespace ByteDev.Collections.UnitTests.Sequences
{
    [TestFixture]
    public class SequenceFactoryTests
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
    }
}