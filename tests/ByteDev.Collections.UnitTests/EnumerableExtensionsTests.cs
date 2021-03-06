﻿using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace ByteDev.Collections.UnitTests
{
    [TestFixture]
    public class EnumerableExtensionsTests
    {
        [TestFixture]
        public class NullToEmpty
        {
            [Test]
            public void WhenIsNull_ThenReturnEmpty()
            {
                var result = EnumerableExtensions.NullToEmpty(null as IEnumerable<string>);

                Assert.That(result, Is.Empty);
            }

            [Test]
            public void WhenIsNotNull_ThenReturnSame()
            {
                IEnumerable<string> sut = new List<string>();

                var result = sut.NullToEmpty();

                Assert.That(result, Is.SameAs(sut));
            }
        }

        [TestFixture]
        public class ForEach
        {
            [Test]
            public void WhenSourceIsNull_ThenThrowNullException()
            {
                var counter = 0;
                int[] sut = null;

                Assert.Throws<ArgumentNullException>(() => sut.ForEach(i => counter += + i));
            }

            [Test]
            public void WhenActionIsNull_ThenThrowException()
            {
                var sut = new[] { 1, 2, 3 };

                Assert.Throws<ArgumentNullException>(() => sut.ForEach(null));
            }

            [Test]
            public void WhenNoItemsExist_ThenNotCall()
            {
                var counter = 0;
                var sut = new int[0];

                sut.ForEach(i => counter += + i);

                Assert.That(counter, Is.EqualTo(0));
            }

            [Test]
            public void WhenItemExist_ThenCallForEachItem()
            {
                var counter = 0;
                var sut = new[] { 1, 2, 3 };

                sut.ForEach(x => counter = counter + x);

                Assert.That(counter, Is.EqualTo(6));
            }
        }

        [TestFixture]
        public class Find
        {
            private IEnumerable<string> _sut;

            [SetUp]
            public void SetUp()
            {
                _sut = new[] { "Hello", "John", "Smith" };
            }

            [Test]
            public void WhenSourceIsNull_ThenThrowException()
            {
                IEnumerable<string> sut = null;

                Assert.Throws<ArgumentNullException>(() => sut.Find(x => x == "Hello"));
            }

            [Test]
            public void WhenPredicateIsNull_ThenThrowException()
            {
                Assert.Throws<ArgumentNullException>(() => Act(null));
            }

            [Test]
            public void WhenItemFound_ThenReturnItem()
            {
                var result = Act(x => x == "John");

                Assert.That(result, Is.SameAs(_sut.Second()));
            }

            [Test]
            public void WhenItemNotFound_ThenReturnItemDefault()
            {
                var result = Act(x => x == "Peter");

                Assert.That(result, Is.EqualTo(default(string)));
            }

            private string Act(Predicate<string> predicate)
            {
                return _sut.Find(predicate);
            }
        }

        [TestFixture]
        public class AllUnique : EnumerableExtensionsTests
        {
            [Test]
            public void WhenIsNull_ThenThrowException()
            {
                Assert.Throws<ArgumentNullException>(() => EnumerableExtensions.AllUnique(null as IEnumerable<int>));
            }

            [Test]
            public void WhenIsEmpty_ThenReturnTrue()
            {
                IEnumerable<int> sut = Enumerable.Empty<int>();

                var result = sut.AllUnique();

                Assert.That(result, Is.True);
            }

            [Test]
            public void WhenIsSingle_ThenReturnTrue()
            {
                IEnumerable<int> sut = new[] {1};

                var result = sut.AllUnique();

                Assert.That(result, Is.True);
            }

            [Test]
            public void WhenIsMultipleUniqueElements_ThenReturnTrue()
            {
                IEnumerable<int> sut = new[] {1,2,3};

                var result = sut.AllUnique();

                Assert.That(result, Is.True);
            }

            [Test]
            public void WhenHasDuplicates_ThenReturnFalse()
            {
                IEnumerable<int> sut = new[] {1,2,3,2};

                var result = sut.AllUnique();

                Assert.That(result, Is.False);
            }
        }
    }
}
