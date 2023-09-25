using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace ByteDev.Collections.UnitTests;

[TestFixture]
public class CollectionRandomExtensionsTests
{
    [TestFixture]
    public class TakeRandom : EnumerableExtensionsTests
    {
        [Test]
        public void WhenSourceIsNull_ThenThrowException()
        {
            Assert.Throws<ArgumentNullException>(() => (null as ICollection<int>).TakeRandom());
        }

        [Test]
        public void WhenSourceIsEmpty_ThenThrowException()
        {
            ICollection<int> sut = new List<int>();

            Assert.Throws<InvalidOperationException>(() => sut.TakeRandom());
        }

        [Test]
        public void WhenHasOneElements_ThenReturnElement()
        {
            ICollection<int> sut = new List<int> { 1 };

            var result = sut.TakeRandom();

            Assert.That(result, Is.EqualTo(1));
        }

        [Test]
        public void WhenHasThreeElements_ThenReturnRandomElement()
        {
            ICollection<int> sut = new List<int> { 1, 5, 10 };

            var result = sut.TakeRandom();

            Assert.That(result, Is.EqualTo(1).Or.EqualTo(5).Or.EqualTo(10));
        }

        [Test]
        public void WhenRunEnoughTimes_ThenReturnAllPossiblities()
        {
            ICollection<int> sut = new List<int> { 1, 5, 10 };

            bool oneFound = false;
            bool fiveFound = false;
            bool tenFound = false;

            for (var i = 0; i < 100; i++)
            {
                var result = sut.TakeRandom();

                switch (result)
                {
                    case 1: oneFound = true; break;
                    case 5: fiveFound = true; break;
                    case 10: tenFound = true; break;
                }
            }

            Assert.That(oneFound, Is.True);
            Assert.That(fiveFound, Is.True);
            Assert.That(tenFound, Is.True);
        }
    }

    [TestFixture]
    public class TakeRandom_Count : CollectionRandomExtensionsTests
    {
        [Test]
        public void WhenSourceIsNull_ThenThrowException()
        {
            Assert.Throws<ArgumentNullException>(() => (null as ICollection<int>).TakeRandom(1));
        }

        [TestCase(-1)]
        [TestCase(0)]
        public void WhenCountIsLessThanOne_ThenReturnEmpty(int count)
        {
            ICollection<int> sut = new List<int>();

            var result = sut.TakeRandom(count);

            Assert.That(result, Is.Empty);
        }

        [Test]
        public void WhenSourceIsEmpty_AndEvalResult_ThenThrowException()
        {
            ICollection<int> sut = new List<int>();

            var result = sut.TakeRandom(1);

            Assert.Throws<ArgumentOutOfRangeException>(() => _ = result.First());
        }

        [Test]
        public void WhenHasOneElement_AndCountOne_ThenReturnSequence()
        {
            ICollection<int> sut = new List<int> { 10 };

            var result = sut.TakeRandom(1);

            Assert.That(result.Single(), Is.EqualTo(10));
        }

        [Test]
        public void WhenHasThreeElements_AndCountTwo_ThenReturnSequence()
        {
            ICollection<int> sut = new List<int> { 1, 5, 10 };

            var result = sut.TakeRandom(2);

            Assert.That(result.Count(), Is.EqualTo(2));
            Assert.That(result.First(), Is.EqualTo(1).Or.EqualTo(5).Or.EqualTo(10));
            Assert.That(result.Second(), Is.EqualTo(1).Or.EqualTo(5).Or.EqualTo(10));
        }
    }

    [TestFixture]
    public class RemoveRandom : CollectionRandomExtensionsTests
    {
        [Test]
        public void WhenSourceIsNull_ThenThrowException()
        {
            Assert.Throws<ArgumentNullException>(() => (null as ICollection<int>).RemoveRandom());
        }

        [Test]
        public void WhenIsEmpty_ThenThrowException()
        {
            ICollection<int> sut = new List<int>();

            Assert.Throws<InvalidOperationException>(() => sut.RemoveRandom());
        }

        [Test]
        public void WhenHasSingleElement_ThenReturnElmentAndRemove()
        {
            ICollection<int> sut = new List<int> { 1 };
                
            var result = sut.RemoveRandom();

            Assert.That(result, Is.EqualTo(1));
            Assert.That(sut, Is.Empty);
        }

        [Test]
        public void WhenHasThreeElements_ThenReturnRandomElement()
        {
            ICollection<int> sut = new List<int> { 1, 5, 10 };

            var result = sut.RemoveRandom();

            Assert.That(result, Is.EqualTo(1).Or.EqualTo(5).Or.EqualTo(10));
            Assert.That(sut.Count, Is.EqualTo(2));
        }

        [Test]
        public void WhenHasTwoElements_AndCalledTwice_ThenRemove()
        {
            ICollection<int> sut = new List<int> { 1, 5 };

            sut.RemoveRandom();
            sut.RemoveRandom();

            Assert.That(sut, Is.Empty);
        }
    }
}