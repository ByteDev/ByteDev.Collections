using System;
using System.Linq;
using NUnit.Framework;

namespace ByteDev.Collections.UnitTests
{
    [TestFixture]
    public class EnumerableStringExtensionsTests
    {
        [TestFixture]
        public class FirstLongest : EnumerableStringExtensionsTests
        {
            [Test]
            public void WhenIsNull_ThenThrowException()
            {
                Assert.Throws<ArgumentNullException>(() => EnumerableStringExtensions.FirstLongest(null));
            }

            [Test]
            public void WhenIsEmpty_ThenReturnNull()
            {
                var sut = Enumerable.Empty<string>();

                var result = sut.FirstLongest();

                Assert.That(result, Is.Null);
            }

            [Test]
            public void WhenHasOneElement_ThenReturnElement()
            {
                var sut = new[] {"A"};

                var result = sut.FirstLongest();

                Assert.That(result, Is.EqualTo("A"));
            }

            [Test]
            public void WhenHasDifferentLengthElements_ThenReturnLongest()
            {
                var sut = new[] {"A", "BBB", "CC"};

                var result = sut.FirstLongest();

                Assert.That(result, Is.EqualTo("BBB"));
            }

            [Test]
            public void WhenHasJointLongestElements_ThenReturnFirstLongest()
            {
                var sut = new[] { "A", "BB", "CC" };

                var result = sut.FirstLongest();

                Assert.That(result, Is.EqualTo("BB"));
            }

            [Test]
            public void WhenHasNullElement_ThenReturnLongest()
            {
                var sut = new[] { "A", null, "CC" };

                var result = sut.FirstLongest();

                Assert.That(result, Is.EqualTo("CC"));
            }

            [Test]
            public void WhenOnlyNullElements_ThenReturnNull()
            {
                string[] sut = { null, null };
                
                var result = sut.FirstLongest();

                Assert.That(result, Is.Null);
            }
        }

        [TestFixture]
        public class FirstShortest : EnumerableStringExtensionsTests
        {
            [Test]
            public void WhenIsNull_ThenThrowException()
            {
                Assert.Throws<ArgumentNullException>(() => EnumerableStringExtensions.FirstShortest(null));
            }

            [Test]
            public void WhenIsEmpty_ThenReturnNull()
            {
                var sut = Enumerable.Empty<string>();

                var result = sut.FirstShortest();

                Assert.That(result, Is.Null);
            }

            [Test]
            public void WhenHasOneElement_ThenReturnElement()
            {
                var sut = new[] { "A" };

                var result = sut.FirstShortest();

                Assert.That(result, Is.EqualTo("A"));
            }

            [Test]
            public void WhenHasDifferentLengthElements_ThenReturnShortest()
            {
                var sut = new[] { "AAA", "B", "CC" };

                var result = sut.FirstShortest();

                Assert.That(result, Is.EqualTo("B"));
            }

            [Test]
            public void WhenHasJointShortestElements_ThenReturnFirstShortest()
            {
                var sut = new[] { "AA", "B", "C" };

                var result = sut.FirstShortest();

                Assert.That(result, Is.EqualTo("B"));
            }

            [Test]
            public void WhenHasNullElement_ThenReturnShortest()
            {
                var sut = new[] { "A", null, "CC" };

                var result = sut.FirstShortest();

                Assert.That(result, Is.SameAs("A"));
            }

            [Test]
            public void WhenOnlyNullElements_ThenReturnNull()
            {
                string[] sut = { null, null };

                var result = sut.FirstShortest();

                Assert.That(result, Is.Null);
            }
        }
    }
}