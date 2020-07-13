﻿using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace ByteDev.Collections.UnitTests
{
    [TestFixture]
    public class CollectionExtensionsTests
    {
        [TestFixture]
        public class Fill : ListExtensionsTests
        {
            [Test]
            public void WhenIsNull_ThenThrowException()
            {
                Assert.Throws<ArgumentNullException>(() => CollectionExtensions.Fill(null, 1, "Hello"));
            }

            [Test]
            public void WhenIsNotEmpty_ThenThrowException()
            {
                var sut = new List<string> {"John", "Peter"};

                Assert.Throws<InvalidOperationException>(() => sut.Fill(2, "Hello"));
            }

            [Test]
            public void WhenNumberToFillIsLessThanOne_ThenFillNoElements()
            {
                var sut = new List<string>();

                sut.Fill(0, "Hello");

                Assert.That(sut, Is.Empty);
            }

            [Test]
            public void WhenNumberToFillIsTwo_ThenFillTwoElements()
            {
                var sut = new List<string>();

                sut.Fill(2, "Hello");

                Assert.That(sut.Count, Is.EqualTo(2));
                Assert.That(sut.First(), Is.EqualTo("Hello"));
                Assert.That(sut.Second(), Is.EqualTo("Hello"));
            }
        }

        [TestFixture]
        public class RemoveWhere
        {
            [Test]
            public void WhenSourceIsNull_ThenThrowException()
            {
                Assert.Throws<ArgumentNullException>(() => CollectionExtensions.RemoveWhere(null as List<int>, x => x == 1));
            }

            [Test]
            public void WhenPredicateIsNull_ThenThrowException()
            {
                var sut = new List<int> {1, 2, 3};

                Assert.Throws<ArgumentNullException>(() => sut.RemoveWhere(null));
            }

            [Test]
            public void WhenSourceIsEmpty_ThenRemoveNothing()
            {
                var sut = new List<int>();

                sut.RemoveWhere(x => x == 1);

                Assert.That(sut, Is.Empty);
            }

            [Test]
            public void WhereMatchesCondition_ThenRemoveElements()
            {
                var sut = new List<int> {1, 2, 3, 1, 2};

                sut.RemoveWhere(x => x == 1 || x == 2);

                Assert.That(sut.Single(), Is.EqualTo(3));
            }
        }
    }
}