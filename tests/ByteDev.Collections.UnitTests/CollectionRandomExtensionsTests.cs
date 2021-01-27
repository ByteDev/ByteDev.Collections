using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace ByteDev.Collections.UnitTests
{
    [TestFixture]
    public class CollectionRandomExtensionsTests
    {
        [TestFixture]
        public class GetRandom : EnumerableExtensionsTests
        {
            [Test]
            public void WhenSourceIsNull_ThenThrowException()
            {
                Assert.Throws<ArgumentNullException>(() => CollectionRandomExtensions.GetRandom(null as ICollection<int>));
            }

            [Test]
            public void WhenSourceIsEmpty_ThenThrowException()
            {
                ICollection<int> sut = new List<int>();

                Assert.Throws<ArgumentException>(() => sut.GetRandom());
            }

            [Test]
            public void WhenHasOneElements_ThenReturnElement()
            {
                ICollection<int> sut = new List<int> { 1 };

                var result = sut.GetRandom();

                Assert.That(result, Is.EqualTo(1));
            }

            [Test]
            public void WhenHasThreeElements_ThenReturnRandomElement()
            {
                ICollection<int> sut = new List<int> { 1, 5, 10 };

                var result = sut.GetRandom();

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
                    var result = sut.GetRandom();

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
        public class GetRandomOrDefault : CollectionRandomExtensionsTests
        {
            private const int Default = 100;

            [Test]
            public void WhenSourceIsNull_ThenReturnDefault()
            {
                ICollection<int> sut = null;

                var result = sut.GetRandomOrDefault(Default);

                Assert.That(result, Is.EqualTo(Default));
            }

            [Test]
            public void WhenSourceIsEmpty_ThenReturnDefault()
            {
                ICollection<int> sut = new List<int>();

                var result = sut.GetRandomOrDefault(Default);

                Assert.That(result, Is.EqualTo(Default));
            }

            [Test]
            public void WhenHasOneElements_ThenReturnElement()
            {
                ICollection<int> sut = new List<int> { 1 };

                var result = sut.GetRandomOrDefault(Default);

                Assert.That(result, Is.EqualTo(1));
            }

            [Test]
            public void WhenHasThreeElements_ThenReturnRandomElement()
            {
                ICollection<int> sut = new List<int> { 1, 5, 10 };

                var result = sut.GetRandomOrDefault(Default);

                Assert.That(result, Is.EqualTo(1).Or.EqualTo(5).Or.EqualTo(10));
            }
        }
    }
}