using System.Collections.Generic;
using NUnit.Framework;

namespace ByteDev.Collections.UnitTests
{
    [TestFixture]
    public class EnumerableToExtensionsTests
    {
        [TestFixture]
        public class ToDelimitedString
        {
            private const string Delimiter = " ";

            private const string Term1 = "John";
            private const string Term2 = "Peter";

            private List<string> _sut;

            [SetUp]
            public void SetUp()
            {
                _sut = new List<string>();
            }

            [Test]
            public void WhenIsNull_ThenReturnEmpty()
            {
                var result = (null as List<string>).ToDelimitedString(Delimiter);

                Assert.That(result, Is.Empty);
            }

            [Test]
            public void WhenIsEmpty_ThenReturnEmpty()
            {
                var result = _sut.ToDelimitedString(Delimiter);

                Assert.That(result, Is.EqualTo(string.Empty));
            }

            [TestCase(null)]
            [TestCase("")]
            public void WhenDelimiterIsNullOrEmpty_ThenReturnWithoutDelimiter(string delimiter)
            {
                _sut.Add(Term1);
                _sut.Add(Term2);

                var result = _sut.ToDelimitedString(delimiter);

                Assert.That(result, Is.EqualTo(Term1 + Term2));
            }

            [Test]
            public void WhenOneElement_ThenReturnTheElement()
            {
                _sut.Add(Term1);

                var result = _sut.ToDelimitedString(Delimiter);

                Assert.That(result, Is.EqualTo(Term1));
            }

            [Test]
            public void WhenTwoElements_ThenReturnElementsDelimited()
            {
                _sut.Add(Term1);
                _sut.Add(Term2);

                var result = _sut.ToDelimitedString(Delimiter);

                Assert.That(result, Is.EqualTo($"{Term1}{Delimiter}{Term2}"));
            }
        }

        [TestFixture]
        public class ToWrappedString
        {
            private const string Left = "{{";
            private const string Right = "}}";

            private const string Term1 = "John";
            private const string Term2 = "Peter";

            private List<string> _sut;

            [SetUp]
            public void SetUp()
            {
                _sut = new List<string>();
            }

            [Test]
            public void WhenIsNull_ThenReturnEmpty()
            {
                var result = (null as List<string>).ToWrappedString(Left, Right);

                Assert.That(result, Is.Empty);
            }

            [Test]
            public void WhenIsEmpty_ThenReturnEmpty()
            {
                var result = _sut.ToWrappedString(Left, Right);

                Assert.That(result, Is.EqualTo(string.Empty));
            }

            [TestCase(null)]
            [TestCase("")]
            public void WhenLeftRightIsNullOrEmpty_ThenReturnWithoutWrap(string leftRight)
            {
                _sut.Add(Term1);
                _sut.Add(Term2);

                var result = _sut.ToWrappedString(leftRight, leftRight);

                Assert.That(result, Is.EqualTo(Term1 + Term2));
            }

            [Test]
            public void WhenOneElement_ThenReturnElementWrapped()
            {
                _sut.Add(Term1);

                var result = _sut.ToWrappedString(Left, Right);

                Assert.That(result, Is.EqualTo($"{Left}{Term1}{Right}"));
            }

            [Test]
            public void WhenTwoElements_ThenReturnElementsWrapped()
            {
                _sut.Add(Term1);
                _sut.Add(Term2);

                var result = _sut.ToWrappedString(Left, Right);

                Assert.That(result, Is.EqualTo($"{Left}{Term1}{Right}{Left}{Term2}{Right}"));
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
