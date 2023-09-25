using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace ByteDev.Collections.UnitTests;

[TestFixture]
public class ListReplaceExtensionsTests
{
    [TestFixture]
    public class ReplaceAt
    {
        [Test]
        public void WhenSourceIsNull_ThenThrowException()
        {
            Assert.Throws<ArgumentNullException>(() => ListReplaceExtensions.ReplaceAt(null, 0, "newValue"));
        }

        [Test]
        public void WhenSourceIsEmpty_ThenThrowException()
        {
            var sut = new List<int>();

            Assert.Throws<ArgumentOutOfRangeException>(() => sut.ReplaceAt(0, 50));
        }

        [Test]
        public void WhenIndexIsGreaterThanCount_ThenThrowException()
        {
            var sut = new List<int> {10, 20};

            Assert.Throws<ArgumentOutOfRangeException>(() => sut.ReplaceAt(2, 50));
        }

        [Test]
        public void WhenIndexIsLessThanZero_ThenThrowException()
        {
            var sut = new List<int> {10, 20};

            Assert.Throws<ArgumentOutOfRangeException>(() => sut.ReplaceAt(-1, 50));
        }

        [Test]
        public void WhenIndexValid_ThenReplaceElementAtIndex()
        {
            var sut = new List<int> {10, 20};

            sut.ReplaceAt(0, 50);

            Assert.That(sut.First(), Is.EqualTo(50));
            Assert.That(sut.Second(), Is.EqualTo(20));
        }
    }

    [TestFixture]
    public class ReplaceAll_OriginalValue
    {
        [Test]
        public void WhenSourceIsNull_ThenThrowException()
        {
            Assert.Throws<ArgumentNullException>(() => ListReplaceExtensions.ReplaceAll(null, 1, 2));
        }

        [Test]
        public void WhenSourceIsEmpty_ThenDoNothing()
        {
            var sut = new List<int>();

            sut.ReplaceAll(10, 20);
                
            Assert.That(sut, Is.Empty);
        }
            
        [Test]
        public void WhenOriginalDoesNotExist_ThenReplaceNothing()
        {
            var sut = new List<int> { 10, 20, 10 };

            sut.ReplaceAll(30, 50);

            Assert.That(sut.First(), Is.EqualTo(10));
            Assert.That(sut.Second(), Is.EqualTo(20));
            Assert.That(sut.Third(), Is.EqualTo(10));
        }

        [Test]
        public void WhenOriginalExistsTwice_ThenReplaceBoth()
        {
            var sut = new List<int> {10, 20, 10};

            sut.ReplaceAll(10, 50);
                
            Assert.That(sut.First(), Is.EqualTo(50));
            Assert.That(sut.Second(), Is.EqualTo(20));
            Assert.That(sut.Third(), Is.EqualTo(50));
        }
    }

    [TestFixture]
    public class ReplaceAll_Predicate
    {
        [Test]
        public void WhenSourceIsNull_ThenThrowException()
        {
            Assert.Throws<ArgumentNullException>(() => ListReplaceExtensions.ReplaceAll(null, i => i == 10, 50));
        }

        [Test]
        public void WhenPredicateIsNull_ThenThrowException()
        {
            var sut = new List<int> {10, 20, 10};

            Assert.Throws<ArgumentNullException>(() => sut.ReplaceAll(null, 50));
        }

        [Test]
        public void WhenPredicateIsAllFalse_ThenReplaceNothing()
        {
            var sut = new List<int> {10, 20, 10};

            sut.ReplaceAll(i => i == 30, 50);

            Assert.That(sut.First(), Is.EqualTo(10));
            Assert.That(sut.Second(), Is.EqualTo(20));
            Assert.That(sut.Third(), Is.EqualTo(10));
        }

        [Test]
        public void WhenPredicateIsTrue_ThenReplaceValues()
        {
            var sut = new List<int> {10, 20, 10};

            sut.ReplaceAll(i => i == 10, 50);

            Assert.That(sut.First(), Is.EqualTo(50));
            Assert.That(sut.Second(), Is.EqualTo(20));
            Assert.That(sut.Third(), Is.EqualTo(50));
        }
    }
}