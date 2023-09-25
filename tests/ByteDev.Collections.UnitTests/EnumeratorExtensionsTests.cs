using System;
using System.Collections.Generic;
using System.Linq;
using ByteDev.Collections.Sequences;
using NUnit.Framework;

namespace ByteDev.Collections.UnitTests;

[TestFixture]
public class EnumeratorExtensionsTests
{
    [TestFixture]
    public class MoveNext_Count
    {
        [Test]
        public void WhenIsNull_ThenThrowException()
        {
            Assert.Throws<ArgumentNullException>(() => (null as IEnumerator<int>).MoveNext(1));
        }

        [Test]
        public void WhenIsEmpty_ThenReturnFalse()
        {
            using var sut = Enumerable.Empty<int>().GetEnumerator();

            var result = sut.MoveNext(1);

            Assert.That(result, Is.False);
        }

        [TestCase(-1)]
        [TestCase(0)]
        public void WhenMoveCountLessThanOne_ThenThrowException(int moveCount)
        {
            using var sut = CreateSequence(1).GetEnumerator();

            Assert.Throws<ArgumentOutOfRangeException>(() => _ = sut.MoveNext(moveCount));
        }

        [Test]
        public void WhenSizeOne_AndMoveCountOne_ThenReturnTrue()
        {
            using var sut = CreateSequence(1).GetEnumerator();

            var result = sut.MoveNext(1);

            Assert.That(result, Is.True);
        }

        [Test]
        public void WhenSizeOne_AndMoveCountTwo_ThenReturnFalse()
        {
            using var sut = CreateSequence(1).GetEnumerator();

            var result = sut.MoveNext(2);

            Assert.That(result, Is.False);
        }

        private static IEnumerable<int> CreateSequence(int size)
        {
            return Sequencer.Natural(size);
        }
    }
}