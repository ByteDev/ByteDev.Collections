using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace ByteDev.Collections.UnitTests
{
    [TestFixture]
    public class EnumerableElementSelectionExtensionsTest
    {
        private IList<string> _sut;

        [SetUp]
        public void SetUp()
        {
            _sut = new List<string>();
        }

        [TestFixture]
        public class Second : EnumerableElementSelectionExtensionsTest
        {
            [Test]
            public void WhenIsNull_ThenThrowException()
            {
                IEnumerable<object> sut = null;

                Assert.Throws<ArgumentNullException>(() => sut.Second());
            }

            [Test]
            public void WhenIsEmpty_ThenThrowException()
            {
                var ex = Assert.Throws<InvalidOperationException>(() => _sut.Second());
                Assert.That(ex.Message, Is.EqualTo("Sequence contains no elements."));
            }

            [Test]
            public void WhenHasOneElement_ThenThrowException()
            {
                _sut.Add("John");

                var ex = Assert.Throws<InvalidOperationException>(() => _sut.Second());
                Assert.That(ex.Message, Is.EqualTo("Sequence contains no second element."));
            }

            [Test]
            public void WhenHasTwoElements_ThenReturnSecondElement()
            {
                const string expected = "Peter";

                _sut.Add("John");
                _sut.Add(expected);

                var result = _sut.Second();

                Assert.That(result, Is.EqualTo(expected));
            }
        }

        [TestFixture]
        public class Third : EnumerableElementSelectionExtensionsTest
        {
            [Test]
            public void WhenHasTwoElements_ThenThrowException()
            {
                _sut.Fill(2, "John");

                var ex = Assert.Throws<InvalidOperationException>(() => _sut.Third());
                Assert.That(ex.Message, Is.EqualTo("Sequence contains no third element."));
            }

            [Test]
            public void WhenHasThreeElements_ThenReturnThirdElement()
            {
                const string expected = "Peter";

                _sut.Fill(2, "John");
                _sut.Add(expected);

                var result = _sut.Third();

                Assert.That(result, Is.EqualTo(expected));
            }
        }

        [TestFixture]
        public class Fourth : EnumerableElementSelectionExtensionsTest
        {
            [Test]
            public void WhenHasThreeElements_ThenThrowException()
            {
                _sut.Fill(3, "John");

                var ex = Assert.Throws<InvalidOperationException>(() => _sut.Fourth());
                Assert.That(ex.Message, Is.EqualTo("Sequence contains no fourth element."));
            }

            [Test]
            public void WhenHasFourElements_ThenReturnFourthElement()
            {
                const string expected = "Peter";

                _sut.Fill(3, "John");
                _sut.Add(expected);

                var result = _sut.Fourth();

                Assert.That(result, Is.EqualTo(expected));
            }
        }

        [TestFixture]
        public class Fifth : EnumerableElementSelectionExtensionsTest
        {
            [Test]
            public void WhenHasFourElements_ThenThrowException()
            {
                _sut.Fill(4, "John");

                var ex = Assert.Throws<InvalidOperationException>(() => _sut.Fifth());
                Assert.That(ex.Message, Is.EqualTo("Sequence contains no fifth element."));
            }

            [Test]
            public void WhenHasFiveElements_ThenReturnFifthElement()
            {
                const string expected = "Peter";

                _sut.Fill(4, "John");
                _sut.Add(expected);

                var result = _sut.Fifth();

                Assert.That(result, Is.EqualTo(expected));
            }
        }

        [TestFixture]
        public class Sixth : EnumerableElementSelectionExtensionsTest
        {
            [Test]
            public void WhenHasFiveElements_ThenThrowException()
            {
                _sut.Fill(5, "John");

                var ex = Assert.Throws<InvalidOperationException>(() => _sut.Sixth());
                Assert.That(ex.Message, Is.EqualTo("Sequence contains no sixth element."));
            }

            [Test]
            public void WhenHasSixElements_ThenReturnSixthElement()
            {
                const string expected = "Peter";

                _sut.Fill(5, "John");
                _sut.Add(expected);
                
                var result = _sut.Sixth();

                Assert.That(result, Is.EqualTo(expected));
            }
        }

        [TestFixture]
        public class Seventh : EnumerableElementSelectionExtensionsTest
        {
            [Test]
            public void WhenHasSixElements_ThenThrowException()
            {
                _sut.Fill(6, "John");

                var ex = Assert.Throws<InvalidOperationException>(() => _sut.Seventh());
                Assert.That(ex.Message, Is.EqualTo("Sequence contains no seventh element."));
            }

            [Test]
            public void WhenHasSevenElements_ThenReturnSeventhElement()
            {
                const string expected = "Peter";

                _sut.Fill(6, "John");
                _sut.Add(expected);

                var result = _sut.Seventh();

                Assert.That(result, Is.EqualTo(expected));
            }
        }

        [TestFixture]
        public class Eighth : EnumerableElementSelectionExtensionsTest
        {
            [Test]
            public void WhenHasSevenElements_ThenThrowException()
            {
                _sut.Fill(7, "John");

                var ex = Assert.Throws<InvalidOperationException>(() => _sut.Eighth());
                Assert.That(ex.Message, Is.EqualTo("Sequence contains no eighth element."));
            }

            [Test]
            public void WhenHasEightElements_ThenReturnEighthElement()
            {
                const string expected = "Peter";

                _sut.Fill(7, "John");
                _sut.Add(expected);

                var result = _sut.Eighth();

                Assert.That(result, Is.EqualTo(expected));
            }
        }

        [TestFixture]
        public class Nineth : EnumerableElementSelectionExtensionsTest
        {
            [Test]
            public void WhenHasEightElements_ThenThrowException()
            {
                _sut.Fill(8, "John");

                var ex = Assert.Throws<InvalidOperationException>(() => _sut.Ninth());
                Assert.That(ex.Message, Is.EqualTo("Sequence contains no ninth element."));
            }

            [Test]
            public void WhenHasNineElements_ThenReturnNinthElement()
            {
                const string expected = "Peter";

                _sut.Fill(8, "John");
                _sut.Add(expected);

                var result = _sut.Ninth();

                Assert.That(result, Is.EqualTo(expected));
            }
        }

        [TestFixture]
        public class Tenth : EnumerableElementSelectionExtensionsTest
        {
            [Test]
            public void WhenHasNineElements_ThenThrowException()
            {
                _sut.Fill(9, "John");

                var ex = Assert.Throws<InvalidOperationException>(() => _sut.Tenth());
                Assert.That(ex.Message, Is.EqualTo("Sequence contains no tenth element."));
            }

            [Test]
            public void WhenHasTenElements_ThenReturnTenthElement()
            {
                const string expected = "Peter";

                _sut.Fill(9, "John");
                _sut.Add(expected);

                var result = _sut.Tenth();

                Assert.That(result, Is.EqualTo(expected));
            }
        }
    }
}