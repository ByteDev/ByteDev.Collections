﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using NUnit.Framework;

namespace ByteDev.Collections.UnitTests;

[TestFixture]
public class CollectionExtensionsTests
{
    [TestFixture]
    public class Fill
    {
        [Test]
        public void WhenIsNull_ThenThrowException()
        {
            Assert.Throws<ArgumentNullException>(() => CollectionExtensions.Fill(null, 1, "Hello"));
        }

        [Test]
        public void WhenIsNotEmpty_ThenThrowException()
        {
            ICollection<string> sut = new List<string> {"John", "Peter"};

            Assert.Throws<InvalidOperationException>(() => sut.Fill(2, "Hello"));
        }

        [Test]
        public void WhenNumberToFillIsLessThanOne_ThenFillNoElements()
        {
            ICollection<string> sut = new List<string>();

            sut.Fill(0, "Hello");

            Assert.That(sut, Is.Empty);
        }

        [Test]
        public void WhenNumberToFillIsTwo_ThenFillTwoElements()
        {
            ICollection<string> sut = new List<string>();
                
            sut.Fill(2, "Hello");
                
            Assert.That(sut.Count, Is.EqualTo(2));
            Assert.That(sut.First(), Is.EqualTo("Hello"));
            Assert.That(sut.Second(), Is.EqualTo("Hello"));
        }
    }

    [TestFixture]
    public class IsIndexValid
    {
        [Test]
        public void WhenSourceIsNull_ThenThrowException()
        {
            Assert.Throws<ArgumentNullException>(() => (null as ICollection<int>).IsIndexValid(0));
        }

        [TestCase(-1)]
        [TestCase(3)]
        public void WhenIndexIsOutOfRange_ThenReturnFalse(int index)
        {
            ICollection<string> sut = new List<string> { "item1", "item2", "item3" };

            var result = sut.IsIndexValid(index);

            Assert.That(result, Is.False);
        }

        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        public void WhenIndexIsInRange_ThenReturnTrue(int index)
        {
            ICollection<string> sut = new List<string> { "item1", "item2", "item3" };

            var result = sut.IsIndexValid(index);

            Assert.That(result, Is.True);
        }
    }

    [TestFixture]
    public class AddRange
    {
        private readonly IEnumerable<int> _itemsToAdd = new[] { 4, 5 };

        [Test]
        public void WhenSourceIsNull_ThenThrowException()
        {
            Assert.Throws<ArgumentNullException>(() => CollectionExtensions.AddRange(null, _itemsToAdd));
        }

        [Test]
        public void WhenItemsIsNull_ThenThrowException()
        {
            ICollection<int> sut = new List<int> { 1, 2, 3 };
                
            Assert.Throws<ArgumentNullException>(() => sut.AddRange(null));
        }

        [Test]
        public void WhenSourceIsReadonly_ThenThrowException()
        {
            var sut = new ReadOnlyCollection<int>(new List<int> { 1, 2, 3 });

            Assert.Throws<NotSupportedException>(() => sut.AddRange(_itemsToAdd));
        }

        [Test]
        public void WhenSourceIsList_ThenAddItems()
        {
            ICollection<int> sut = new List<int>();

            sut.AddRange(_itemsToAdd);

            Assert.That(sut.Count, Is.EqualTo(2));
            Assert.That(sut.First(), Is.EqualTo(4));
            Assert.That(sut.Second(), Is.EqualTo(5));
        }

        [Test]
        public void WhenSourceIsNotList_ThenAddItems()
        {
            ICollection<int> sut = new HashSet<int>();

            sut.AddRange(_itemsToAdd);

            Assert.That(sut.Count, Is.EqualTo(2));
            Assert.That(sut.First(), Is.EqualTo(4));
            Assert.That(sut.Second(), Is.EqualTo(5));
        }

        [Test]
        public void WhenCollectionNotEmpty_ThenAddItems()
        {
            ICollection<int> sut = new List<int> {1, 2, 3};

            sut.AddRange(_itemsToAdd);

            Assert.That(sut.Count, Is.EqualTo(5));
            Assert.That(sut.First(), Is.EqualTo(1));
            Assert.That(sut.Second(), Is.EqualTo(2));
            Assert.That(sut.Third(), Is.EqualTo(3));
            Assert.That(sut.Fourth(), Is.EqualTo(4));
            Assert.That(sut.Fifth(), Is.EqualTo(5));
        }
    }

    [TestFixture]
    public class AddIfNotContains
    {
        [Test]
        public void WhenSourceIsNull_ThenThrowException()
        {
            Assert.Throws<ArgumentNullException>(() => CollectionExtensions.AddIfNotContains(null, 1));
        }

        [TestCase(null)]
        [TestCase("1")]
        [TestCase("2")]
        public void WhenContains_ThenDoNotAdd(string item)
        {
            ICollection<string> sut = new List<string> { null, "1", "2" };

            var result = sut.AddIfNotContains(item);

            Assert.That(result, Is.False);
            Assert.That(sut.Count, Is.EqualTo(3));
            Assert.That(sut.First(), Is.EqualTo(null));
            Assert.That(sut.Second(), Is.EqualTo("1"));
            Assert.That(sut.Third(), Is.EqualTo("2"));
        }

        [TestCase(null)]
        [TestCase("3")]
        public void WhenDoesNotContain_ThenAdd(string item)
        {
            ICollection<string> sut = new List<string> { "1", "2" };

            var result = sut.AddIfNotContains(item);

            Assert.That(result, Is.True);
            Assert.That(sut.Count, Is.EqualTo(3));
            Assert.That(sut.First(), Is.EqualTo("1"));
            Assert.That(sut.Second(), Is.EqualTo("2"));
            Assert.That(sut.Third(), Is.EqualTo(item));
        }
    }

    [TestFixture]
    public class RemoveWhere
    {
        [Test]
        public void WhenSourceIsNull_ThenThrowException()
        {
            Assert.Throws<ArgumentNullException>(() => CollectionExtensions.RemoveWhere(null as ICollection<int>, x => x == 1));
        }

        [Test]
        public void WhenPredicateIsNull_ThenThrowException()
        {
            ICollection<int> sut = new List<int> { 1, 2, 3 };

            Assert.Throws<ArgumentNullException>(() => sut.RemoveWhere(null));
        }

        [Test]
        public void WhenSourceIsEmpty_ThenRemoveNothing()
        {
            ICollection<int> sut = new List<int>();

            sut.RemoveWhere(x => x == 1);

            Assert.That(sut, Is.Empty);
        }

        [Test]
        public void WhereMatchesCondition_ThenRemoveElements()
        {
            ICollection<int> sut = new List<int> { 1, 2, 3, 1, 2 };

            sut.RemoveWhere(x => x == 1 || x == 2);

            Assert.That(sut.Single(), Is.EqualTo(3));
        }
    }

    [TestFixture]
    public class AddIfNotNull
    {
        [Test]
        public void WhenSourceIsNull_ThenThrowException()
        {
            Assert.Throws<ArgumentNullException>(() => CollectionExtensions.AddIfNotNull(null, new object()));
        }

        [Test]
        public void WhenItemIsNull_ThenDoNotAdd()
        {
            ICollection<string> sut = new List<string> { "Hello", "World" };

            var result = sut.AddIfNotNull(null);

            Assert.That(result, Is.False);
            Assert.That(sut.Count, Is.EqualTo(2));
        }

        [Test]
        public void WhenItemIsNotNull_ThenAdd()
        {
            ICollection<string> sut = new List<string> { "Hello", "World" };

            var result = sut.AddIfNotNull("John");

            Assert.That(result, Is.True);
            Assert.That(sut.Count, Is.EqualTo(3));
        }
    }
}