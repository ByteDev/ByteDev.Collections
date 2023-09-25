using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace ByteDev.Collections.UnitTests;

[TestFixture]
public class EnumerableContainsExtensionsTests
{
    [TestFixture]
    public class ContainsAll
    {
        private IEnumerable<string> _sut;

        [SetUp]
        public void SetUp()
        {
            _sut = EnumerableFactory.CreateFrom("Hello", "John", "Smith");
        }

        [Test]
        public void WhenSourceIsNull_ThenThrowException()
        {
            Assert.Throws<ArgumentNullException>(() => EnumerableContainsExtensions.ContainsAll(null, new object()));
        }

        [Test]
        public void WhenValuesIsNull_ThenThrowException()
        {
            Assert.Throws<ArgumentNullException>(() => _sut.ContainsAll(null));
        }

        [Test]
        public void WhenValuesIsEmpty_ThenReturnTrue()
        {
            var result = _sut.ContainsAll();

            Assert.That(result, Is.True);
        }

        [Test]
        public void WhenContainsAll_ThenReturnTrue()
        {
            var result = _sut.ContainsAll("Hello", "Smith");

            Assert.That(result, Is.True);
        }

        [Test]
        public void WhenDoesNotContainAll_ThenReturnFalse()
        {
            var result = _sut.ContainsAll("Hello", "Smith", "NotInCollection");

            Assert.That(result, Is.False);
        }

        [Test]
        public void WhenContainsAllInEnumerable_ThenReturnTrue()
        {
            var result = _sut.ContainsAll(new List<string> { "Hello", "Smith" });

            Assert.That(result, Is.True);
        }
    }

    [TestFixture]
    public class ContainsAny
    {
        private IEnumerable<string> _sut;

        [SetUp]
        public void SetUp()
        {
            _sut = EnumerableFactory.CreateFrom("Hello", "John", "Smith");
        }

        [Test]
        public void WhenSourceIsNull_ThenThrowException()
        {
            Assert.Throws<ArgumentNullException>(() => EnumerableContainsExtensions.ContainsAny(null, new object()));
        }

        [Test]
        public void WhenValuesIsNull_ThenThrowException()
        {
            Assert.Throws<ArgumentNullException>(() => _sut.ContainsAny(null));
        }

        [Test]
        public void WhenValuesIsEmpty_ThenReturnFalse()
        {
            var result = _sut.ContainsAny();

            Assert.That(result, Is.False);
        }

        [Test]
        public void WhenContainsAny_ThenReturnTrue()
        {
            var result = _sut.ContainsAny("Smith");

            Assert.That(result, Is.True);
        }

        [Test]
        public void WhenDoesNotContainAny_ThenReturnFalse()
        {
            var result = _sut.ContainsAny("HelloSomeone", "NotInCollection");

            Assert.That(result, Is.False);
        }

        [Test]
        public void WhenContainsAnyInEnumerable_ThenReturnTrue()
        {
            var result = _sut.ContainsAny(new List<string> { "Hello", "Smith" });

            Assert.That(result, Is.True);
        }
    }
}