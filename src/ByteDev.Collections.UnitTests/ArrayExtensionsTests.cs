﻿using System;
using System.Linq;
using NUnit.Framework;

namespace ByteDev.Collections.UnitTests
{
    [TestFixture]
    public class ArrayExtensionsTests
    {
        [TestFixture]
        public class Populate : ArrayExtensionsTests
        {
            private const string SingleValue = "New Value";

            [Test]
            public void WhenSourceIsNull_ThenThrowException()
            {
                string[] sut = null;

                Assert.Throws<ArgumentNullException>(() => sut.Populate(SingleValue));
            }

            [Test]
            public void WhenSourceIsEmpty_ThenDoNothing()
            {
                string[] sut = new string[0];

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
    }
}