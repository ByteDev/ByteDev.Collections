﻿using System;
using System.Linq;
using NUnit.Framework;

namespace ByteDev.Collections.UnitTests;

[TestFixture]
public class ArrayTwoDimensionExtensionsTests
{
    [TestFixture]
    public class Populate
    {
        private const string Value = "New Value";

        [Test]
        public void WhenSourceIsNull_ThenThrowException()
        {
            Assert.Throws<ArgumentNullException>(() => ArrayTwoDimensionExtensions.Populate(null, Value));
        }

        [Test]
        public void WhenSourceIsEmpty_ThenDoNothing()
        {
            string[,] sut = new string[0, 0];

            sut.Populate(Value);

            Assert.That(sut, Is.Empty);
        }

        [Test]
        public void WhenValueIsNull_ThenPopulateAllElements()
        {
            string[,] sut = new string[2, 2];

            sut[0, 0] = "John";
            sut[0, 1] = "Peter";
            sut[1, 0] = "Paul";
            sut[1, 1] = "Jim";

            sut.Populate(null);

            Assert.That(sut.Length, Is.EqualTo(4));
            foreach (var element in sut)
            {
                Assert.That(element, Is.Null);
            }
        }

        [Test]
        public void WhenValueIsString_ThenPopulateAllElements()
        {
            string[,] sut = new string[2, 2];

            sut[0, 0] = "John";
            sut[0, 1] = "Peter";
            sut[1, 0] = "Paul";
            sut[1, 1] = "Jim";

            sut.Populate(Value);

            Assert.That(sut.Length, Is.EqualTo(4));
            foreach (var element in sut)
            {
                Assert.That(element, Is.EqualTo(Value));
            }
        }
    }

    [TestFixture]
    public class GetRow
    {
        private string[,] _sut;

        [SetUp]
        public void SetUp()
        {
            _sut = new string[4, 2];
        }

        [Test]
        public void WhenSourceIsNull_ThenThrowException()
        {
            Assert.Throws<ArgumentNullException>(() => (null as string[,]).GetRow(0));
        }

        [Test]
        public void WhenSourceIsEmpty_ThenReturnEmpty()
        {
            var sut = new string[0, 0];

            var result = sut.GetRow(0);

            Assert.That(result, Is.Empty);
        }

        [Test]
        public void WhenRowNumberIsLessThanZero_ThenThrowException()
        {
            Assert.Throws<IndexOutOfRangeException>(() => _sut.GetRow(-1));
        }

        [Test]
        public void WhenRowNumberIsEqualOrGreaterThanRowSize_ThenThrowException()
        {
            Assert.Throws<IndexOutOfRangeException>(() => _sut.GetRow(2));
        }

        [Test]
        public void WhenRowExists_ThenReturnRow()
        {
            const int row = 1;

            _sut[0, row] = "W";
            _sut[1, row] = "X";
            _sut[2, row] = "Y";
            _sut[3, row] = "Z";

            var result = _sut.GetRow(row);

            Assert.That(result.First(), Is.EqualTo("W"));
            Assert.That(result.Second(), Is.EqualTo("X"));
            Assert.That(result.Third(), Is.EqualTo("Y"));
            Assert.That(result.Fourth(), Is.EqualTo("Z"));
        }
    }

    [TestFixture]
    public class GetColumn
    {
        private string[,] _sut;

        [SetUp]
        public void SetUp()
        {
            _sut = new string[2, 3];
        }

        [Test]
        public void WhenSourceIsNull_ThenThrowException()
        {
            Assert.Throws<ArgumentNullException>(() => (null as string[,]).GetColumn(0));
        }

        [Test]
        public void WhenSourceIsEmpty_ThenReturnEmpty()
        {
            var sut = new string[0, 0];

            var result = sut.GetColumn(0);

            Assert.That(result, Is.Empty);
        }

        [Test]
        public void WhenColumnNumberIsLessThanZero_ThenThrowException()
        {
            Assert.Throws<IndexOutOfRangeException>(() => _sut.GetColumn(-1));
        }

        [Test]
        public void WhenColumnNumberIsEqualOrGreaterThanRowSize_ThenThrowException()
        {
            Assert.Throws<IndexOutOfRangeException>(() => _sut.GetColumn(2));
        }

        [Test]
        public void WhenColumnExists_ThenReturnRow()
        {
            const int column = 1;

            _sut[column, 0] = "W";
            _sut[column, 1] = "X";
            _sut[column, 2] = "Y";

            var result = _sut.GetColumn(column);

            Assert.That(result.First(), Is.EqualTo("W"));
            Assert.That(result.Second(), Is.EqualTo("X"));
            Assert.That(result.Third(), Is.EqualTo("Y"));
        }
    }

    [TestFixture]
    public class GetRowCount
    {
        [Test]
        public void WhenIsNull_ThenThrowException()
        {
            Assert.Throws<ArgumentNullException>(() => (null as string[,]).GetRowCount());
        }

        [Test]
        public void WhenIsEmpty_ThenReturnZero()
        {
            var sut = new string[0, 0];

            var result = sut.GetRowCount();

            Assert.That(result, Is.EqualTo(0));
        }

        [Test]
        public void WhenArrayHasRows_ThenReturnRowCount()
        {
            var sut = new string[4, 2];

            var result = sut.GetRowCount();

            Assert.That(result, Is.EqualTo(2));
        }
    }

    [TestFixture]
    public class GetColumnCount
    {
        [Test]
        public void WhenIsNull_ThenThrowException()
        {
            Assert.Throws<ArgumentNullException>(() => (null as string[,]).GetColumnCount());
        }

        [Test]
        public void WhenIsEmpty_ThenReturnZero()
        {
            var sut = new string[0, 0];

            var result = sut.GetColumnCount();

            Assert.That(result, Is.EqualTo(0));
        }

        [Test]
        public void WhenArrayHasColumns_ThenReturnColumnCount()
        {
            var sut = new string[4, 2];

            var result = sut.GetColumnCount();

            Assert.That(result, Is.EqualTo(4));
        }
    }

    [TestFixture]
    public class ToSingleDimension
    {
        [Test]
        public void WhenIsNull_ThenThrowException()
        {
            Assert.Throws<ArgumentNullException>(() => ArrayTwoDimensionExtensions.ToSingleDimension<string>(null));
        }

        [Test]
        public void WhenIsEmpty_ThenReturnEmpty()
        {
            var sut = new string[0, 0];

            var result = sut.ToSingleDimension();

            Assert.That(result, Is.Empty);
        }

        [Test]
        public void WhenHasColumnsAndRows_ThenReturnSingleDimArray()
        {
            var sut = new string[3, 2];

            sut[0, 0] = "R0-C0";
            sut[1, 0] = "R0-C1";
            sut[2, 0] = "R0-C2";

            sut[0, 1] = "R1-C0";
            sut[1, 1] = "R1-C1";
            sut[2, 1] = "R1-C2";

            var result = sut.ToSingleDimension();

            Assert.That(result.Length, Is.EqualTo(6));

            Assert.That(result.First(), Is.EqualTo("R0-C0"));
            Assert.That(result.Second(), Is.EqualTo("R0-C1"));
            Assert.That(result.Third(), Is.EqualTo("R0-C2"));

            Assert.That(result.Fourth(), Is.EqualTo("R1-C0"));
            Assert.That(result.Fifth(), Is.EqualTo("R1-C1"));
            Assert.That(result.Sixth(), Is.EqualTo("R1-C2"));
        }
    }

    [TestFixture]
    public class SafeLength
    {
        [Test]
        public void WhenIsNull_ThenReturnZero()
        {
            string[,] sut = null;

            var result = sut.SafeLength();

            Assert.That(result, Is.EqualTo(0));
        }

        [TestCase(0, 0)]
        [TestCase(1, 1)]
        [TestCase(2, 4)]
        public void WhenIsNotNull_ThenReturnLength(int length, int expected)
        {
            string[,] sut = new string[length, length];

            var result = sut.SafeLength();

            Assert.That(result, Is.EqualTo(expected));
        }
    }
}