using System.Collections.Generic;
using NUnit.Framework;

namespace ByteDev.Collections.UnitTests
{
    [TestFixture]
    public class EnumerableToExtensionsTest
    {
        [TestFixture]
        public class ToDelimitedString
        {
            private const string Delimiter = " ";

            private List<object> _sut;

            [SetUp]
            public void SetUp()
            {
                _sut = new List<object>();
            }

            [Test]
            public void WhenIsNull_ThenReturnEmpty()
            {
                var result = (null as List<object>).ToDelimitedString(Delimiter);

                Assert.That(result, Is.Empty);
            }

            [Test]
            public void WhenIsEmpty_ThenReturnEmpty()
            {
                var result = _sut.ToDelimitedString(Delimiter);

                Assert.That(result, Is.EqualTo(string.Empty));
            }

            [Test]
            public void WhenOneElement_ThenReturnTheElement()
            {
                const string expected = "John";

                _sut.Add(expected);

                var result = _sut.ToDelimitedString(Delimiter);

                Assert.That(result, Is.EqualTo(expected));
            }

            [Test]
            public void WhenTwoElements_ThenReturnElementsSeparatedWithSpace()
            {
                const string term1 = "John";
                const string term2 = "Peter";

                var expected = $"{term1}{Delimiter}{term2}";

                _sut.Add(term1);
                _sut.Add(term2);

                var result = _sut.ToDelimitedString(Delimiter);

                Assert.That(result, Is.EqualTo(expected));
            }

            [Test]
            public void WhenTwoElements_AndNullDelimiter_ThenReturnElementsNotSeparated()
            {
                const string term1 = "John";
                const string term2 = "Peter";
                var expected = term1 + term2;

                _sut.Add(term1);
                _sut.Add(term2);

                var result = _sut.ToDelimitedString(null);

                Assert.That(result, Is.EqualTo(expected));
            }
        }

        [TestFixture]
        public class ToCsv
        {
            private List<object> _sut;

            [SetUp]
            public void SetUp()
            {
                _sut = new List<object>();
            }

            [Test]
            public void WhenIsNull_ThenReturnEmpty()
            {
                var result = (null as IEnumerable<string>).ToCsv();

                Assert.That(result, Is.Empty);
            }

            [Test]
            public void WhenHasNoElements_ThenReturnEmpty()
            {
                var result = _sut.ToCsv();

                Assert.That(result, Is.Empty);
            }

            [Test]
            public void WhenOneElement_ThenReturnElement()
            {
                const string expected = "John";

                _sut.Add(expected);

                var result = _sut.ToCsv();

                Assert.That(result, Is.EqualTo(expected));
            }

            [Test]
            public void WhenTwoElements_ThenReturnElementsAsCsv()
            {
                const string item1 = "John";
                const string item2 = "Peter";

                _sut.Add(item1);
                _sut.Add(item2);

                var expected = $"{item1},{item2}";

                var result = _sut.ToCsv();

                Assert.That(result, Is.EqualTo(expected));
            }

            [Test]
            public void WhenThreeElements_ThenReturnElementsAsCsv()
            {
                const string item1 = "John";
                const string item2 = "Peter";
                const string item3 = "Paul";

                _sut.Add(item1);
                _sut.Add(item2);
                _sut.Add(item3);

                var expected = $"{item1},{item2},{item3}";

                var result = _sut.ToCsv();

                Assert.That(result, Is.EqualTo(expected));
            }

            [Test]
            public void WhenElementIsUserObject_ThenReturnToStringOfUserObject()
            {
                const string expected = "John,Dave";

                var sut = new List<Dummy>
                {
                    new Dummy("John"),
                    new Dummy("Dave")
                };

                var result = sut.ToCsv();

                Assert.That(result, Is.EqualTo(expected));
            }
        }

        internal class Dummy
        {
            private readonly string _name;

            public Dummy(string name)
            {
                _name = name;
            }

            public override string ToString()
            {
                return _name;
            }
        }
    }
}
