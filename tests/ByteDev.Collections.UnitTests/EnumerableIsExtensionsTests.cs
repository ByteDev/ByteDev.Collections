using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace ByteDev.Collections.UnitTests
{
    [TestFixture]
    public class EnumerableIsExtensionsTests
    {
        [TestFixture]
        public class IsNullOrEmpty
        {
            [Test]
            public void WhenIsNull_ThenReturnTrue()
            {
                var result = (null as IEnumerable<object>).IsNullOrEmpty();

                Assert.That(result, Is.True);
            }

            [Test]
            public void WhenIsEmpty_ThenReturnTrue()
            {
                var sut = Enumerable.Empty<string>();

                var result = sut.IsNullOrEmpty();

                Assert.That(result, Is.True);
            }

            [Test]
            public void WhenNotEmpty_ThenReturnFalse()
            {
                var sut = new[] { 1 };

                var result = sut.IsNullOrEmpty();

                Assert.That(result, Is.False);
            }
        }

        [TestFixture]
        public class IsEmpty
        {
            [Test]
            public void WhenIsNull_ThenReturnFalse()
            {
                Assert.Throws<ArgumentNullException>(() => (null as IEnumerable<object>).IsEmpty());
            }

            [Test]
            public void WhenIsEmpty_ThenReturnTrue()
            {
                var sut = Enumerable.Empty<string>();

                Assert.That(sut.IsEmpty(), Is.True);
            }

            [Test]
            public void WhenIsNotEmpty_ThenReturnFalse()
            {
                var sut = new[] { 1 };

                Assert.That(sut.IsEmpty(), Is.False);
            }
        }

        [TestFixture]
        public class IsSingle
        {
            [Test]
            public void WhenIsNull_ThenThrowException()
            {
                Assert.Throws<ArgumentNullException>(() => (null as IEnumerable<object>).IsSingle());
            }

            [Test]
            public void WhenIsEmpty_ThenReturnFalse()
            {
                var sut = new int[0];

                var result = sut.IsSingle();

                Assert.IsFalse(result);
            }

            [Test]
            public void WhenHasOneItem_ThenReturnTrue()
            {
                var sut = new[] { 1 };

                var result = sut.IsSingle();

                Assert.IsTrue(result);
            }

            [Test]
            public void WhenHasTwoItems_ThenReturnFalse()
            {
                var sut = new[] { 1, 2 };

                var result = sut.IsSingle();

                Assert.IsFalse(result);
            }
        }

        [TestFixture]
        public class IsEquivalentTo
        {
            [Test]
            public void WhenIsNull_ThenThrowException()
            {
                var otherCollection = new[] { 1, 2, 3 };

                Assert.Throws<ArgumentNullException>(() => (null as IEnumerable<int>).IsEquivalentTo(otherCollection));
            }

            [Test]
            public void WhenOtherIsNull_ThenReturnFalse()
            {
                var sut = new[] { 1, 2, 3 };

                var result = sut.IsEquivalentTo(null);

                Assert.That(result, Is.False);
            }

            [Test]
            public void WhenElementsAreSameAndInOrder_ThenReturnTrue()
            {
                var sut = new[] { 1, 2, 3 };
                var otherCollection = new[] { 1, 2, 3 };

                var result = sut.IsEquivalentTo(otherCollection);

                Assert.That(result, Is.True);
            }

            [Test]
            public void WhenElementsAreSameAndInDifferentOrder_ThenReturnTrue()
            {
                var sut = new[] { 1, 2, 3 };
                var otherCollection = new[] { 3, 2, 1 };

                var result = sut.IsEquivalentTo(otherCollection);

                Assert.That(result, Is.True);
            }

            [Test]
            public void WhenElementsAreDifferent_ThenReturnFalse()
            {
                var sut = new[] { 1, 2, 3 };
                var otherCollection = new[] { 1, 2, 4 };

                var result = sut.IsEquivalentTo(otherCollection);

                Assert.That(result, Is.False);
            }

            [Test]
            public void WhenDifferentSizes_ThenReturnFalse()
            {
                var sut = new[] { 1, 2, 3 };
                var otherCollection = new[] { 1, 2 };

                var result = sut.IsEquivalentTo(otherCollection);

                Assert.That(result, Is.False);
            }
        }
    }
}