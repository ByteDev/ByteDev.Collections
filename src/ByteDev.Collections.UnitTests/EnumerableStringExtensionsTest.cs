using System;
using System.Linq;
using NUnit.Framework;

namespace ByteDev.Collections.UnitTests
{
    [TestFixture]
    public class EnumerableStringExtensionsTest
    {
        [TestFixture]
        public class GetLongest : EnumerableStringExtensionsTest
        {
            [Test]
            public void WhenIsNull_ThenThrowException()
            {
                Assert.Throws<ArgumentNullException>(() => EnumerableStringExtensions.GetLongest(null));
            }

            [Test]
            public void WhenIsEmpty_ThenReturnNull()
            {
                var sut = Enumerable.Empty<string>();

                var result = sut.GetLongest();

                Assert.That(result, Is.Null);
            }

            [Test]
            public void WhenHasOneElement_ThenReturnElement()
            {
                var sut = new[] {"A"};

                var result = sut.GetLongest();

                Assert.That(result, Is.SameAs(sut[0]));
            }

            [Test]
            public void WhenHasDifferentLengthElements_ThenReturnLongest()
            {
                var sut = new[] {"A", "BBB", "CC"};

                var result = sut.GetLongest();

                Assert.That(result, Is.SameAs(sut[1]));
            }

            [Test]
            public void WhenHasJointLongestElements_ThenReturnFirstLongest()
            {
                var sut = new[] { "A", "BB", "CC" };

                var result = sut.GetLongest();

                Assert.That(result, Is.SameAs(sut[1]));
            }

            [Test]
            public void WhenHasNullElement_ThenReturnLongest()
            {
                var sut = new[] { "A", null, "CC" };

                var result = sut.GetLongest();

                Assert.That(result, Is.SameAs(sut[2]));
            }

            [Test]
            public void WhenOnlyNullElements_ThenReturnNull()
            {
                string[] sut = { null, null };
                
                var result = sut.GetLongest();

                Assert.That(result, Is.Null);
            }
        }

        [TestFixture]
        public class GetShortest : EnumerableStringExtensionsTest
        {
            [Test]
            public void WhenIsNull_ThenThrowException()
            {
                Assert.Throws<ArgumentNullException>(() => EnumerableStringExtensions.GetShortest(null));
            }

            [Test]
            public void WhenIsEmpty_ThenReturnNull()
            {
                var sut = Enumerable.Empty<string>();

                var result = sut.GetShortest();

                Assert.That(result, Is.Null);
            }

            [Test]
            public void WhenHasOneElement_ThenReturnElement()
            {
                var sut = new[] { "A" };

                var result = sut.GetShortest();

                Assert.That(result, Is.SameAs(sut[0]));
            }

            [Test]
            public void WhenHasDifferentLengthElements_ThenReturnShortest()
            {
                var sut = new[] { "A", "BBB", "CC" };

                var result = sut.GetShortest();

                Assert.That(result, Is.SameAs(sut[0]));
            }

            [Test]
            public void WhenHasJointShortestElements_ThenReturnFirstShortest()
            {
                var sut = new[] { "AA", "B", "C" };

                var result = sut.GetShortest();

                Assert.That(result, Is.SameAs(sut[1]));
            }

            [Test]
            public void WhenHasNullElement_ThenReturnShortest()
            {
                var sut = new[] { "A", null, "CC" };

                var result = sut.GetShortest();

                Assert.That(result, Is.SameAs(sut[0]));
            }

            [Test]
            public void WhenOnlyNullElements_ThenReturnNull()
            {
                string[] sut = { null, null };

                var result = sut.GetShortest();

                Assert.That(result, Is.Null);
            }
        }
    }
}