using System;
using System.Linq;
using NUnit.Framework;

namespace ByteDev.Collections.UnitTests;

[TestFixture]
public class ArrayExtensionsTests
{
    [TestFixture]
    public class Populate
    {
        private const string SingleValue = "New Value";

        [Test]
        public void WhenSourceIsNull_ThenThrowException()
        {
            Assert.Throws<ArgumentNullException>(() => ArrayExtensions.Populate(null, SingleValue));
        }

        [Test]
        public void WhenSourceIsEmpty_ThenDoNothing()
        {
            string[] sut = Array.Empty<string>();

            sut.Populate(SingleValue);

            Assert.That(sut, Is.Empty);
        }

        [Test]
        public void WhenSingleValueIsNull_ThenPopulateAllElements()
        {
            string[] sut = {"X", "Y"};

            sut.Populate(null);

            Assert.That(sut.Length, Is.EqualTo(2));
            Assert.That(sut.First(), Is.Null);
            Assert.That(sut.Second(), Is.Null);
        }

        [Test]
        public void WhenSingleValueIsString_ThenPopulateAllElements()
        {
            string[] sut = {"X", "Y"};

            sut.Populate(SingleValue);

            Assert.That(sut.Length, Is.EqualTo(2));
            Assert.That(sut.First(), Is.EqualTo(SingleValue));
            Assert.That(sut.Second(), Is.EqualTo(SingleValue));
        }

        [Test]
        public void WhenLessValuesThanSutLength_ThenPopulateAllElements()
        {
            string[] sut = { "X", "Y", "Z" };

            sut.Populate("A", "B");

            Assert.That(sut.Length, Is.EqualTo(3));
            Assert.That(sut.First(), Is.EqualTo("A"));
            Assert.That(sut.Second(), Is.EqualTo("B"));
            Assert.That(sut.Third(), Is.EqualTo("A"));
        }

        [Test]
        public void WhenMoreValuesThanSutLength_ThenPopulateAllElements()
        {
            string[] sut = { "X", "Y", "Z" };

            sut.Populate("A", "B", "C", "D");

            Assert.That(sut.Length, Is.EqualTo(3));
            Assert.That(sut.First(), Is.EqualTo("A"));
            Assert.That(sut.Second(), Is.EqualTo("B"));
            Assert.That(sut.Third(), Is.EqualTo("C"));
        }
    }

    [TestFixture]
    public class SafeLength
    {
        [Test]
        public void WhenIsNull_ThenReturnZero()
        {
            string[] sut = null;

            var result = sut.SafeLength();

            Assert.That(result, Is.EqualTo(0));
        }

        [TestCase(0)]
        [TestCase(1)]
        public void WhenIsNotNull_ThenReturnLength(int length)
        {
            string[] sut = new string[length];

            var result = sut.SafeLength();

            Assert.That(result, Is.EqualTo(length));
        }
    }
}