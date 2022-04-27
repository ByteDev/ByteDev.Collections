using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace ByteDev.Collections.UnitTests
{
    [TestFixture]
    public class EnumerableElementSelectionExtensionsTests
    {
        private IList<string> _sut;

        [SetUp]
        public void SetUp()
        {
            _sut = new List<string>();
        }

        [TestFixture]
        public class Last_Count : EnumerableElementSelectionExtensionsTests
        {
            [Test]
            public void WhenIsNull_ThenThrowException()
            {
                Assert.Throws<ArgumentNullException>(() => (null as IEnumerable<object>).Last(1));
            }

            [TestCase(-1)]
            [TestCase(0)]
            public void WhenCountIsLessThanOne_ThenReturnEmpty(int count)
            {
                var result = _sut.Last(count);

                Assert.That(result, Is.Empty);
            }

            [Test]
            public void WhenCountIsOne_ThenReturnLastElement()
            {
                _sut.Add("item1");
                _sut.Add("item2");

                var result = _sut.Last(1);

                Assert.That(result.Single(), Is.EqualTo("item2"));
            }

            [Test]
            public void WhenCountIsTwo_AndSizeIsTwo_ThenReturnAllElements()
            {
                _sut.Add("item1");
                _sut.Add("item2");

                var result = _sut.Last(2);

                Assert.That(result.Count(), Is.EqualTo(2));
                Assert.That(result.First(), Is.EqualTo("item1"));
                Assert.That(result.Second(), Is.EqualTo("item2"));
            }

            [TestCase(1)]
            [TestCase(2)]
            [TestCase(3)]
            [TestCase(4)]
            public void WhenCountIsGreaterThanOrEqualSize_ThenReturnAllElements(int count)
            {
                _sut.Add("item1");

                var result = _sut.Last(count);

                Assert.That(result.Single(), Is.EqualTo("item1"));
            }
        }

        [TestFixture]
        public class Second : EnumerableElementSelectionExtensionsTests
        {
            [Test]
            public void WhenIsNull_ThenThrowException()
            {
                Assert.Throws<ArgumentNullException>(() => EnumerableElementSelectionExtensions.Second(null as IEnumerable<object>));
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
        public class SecondOrDefault : EnumerableElementSelectionExtensionsTests
        {
            [Test]
            public void WhenIsEmpty_ThenReturnDefault()
            {
                var result = _sut.SecondOrDefault();

                Assert.That(result, Is.Null);
            }

            [Test]
            public void WhenHasOneElement_ThenReturnDefault()
            {
                _sut.Add("John");

                var result = _sut.SecondOrDefault();

                Assert.That(result, Is.Null);
            }

            [Test]
            public void WhenHasTwoElements_ThenReturnSecondElement()
            {
                const string expected = "Peter";

                _sut.Add("John");
                _sut.Add(expected);

                var result = _sut.SecondOrDefault();

                Assert.That(result, Is.EqualTo(expected));
            }
        }

        [TestFixture]
        public class Third : EnumerableElementSelectionExtensionsTests
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
        public class ThirdOrDefault : EnumerableElementSelectionExtensionsTests
        {
            [Test]
            public void WhenHasTwoElements_ThenReturnDefault()
            {
                _sut.Fill(2, "John");

                var result = _sut.ThirdOrDefault();

                Assert.That(result, Is.Null);
            }

            [Test]
            public void WhenHasThreeElements_ThenReturnThirdElement()
            {
                const string expected = "Peter";

                _sut.Fill(2, "John");
                _sut.Add(expected);

                var result = _sut.ThirdOrDefault();

                Assert.That(result, Is.EqualTo(expected));
            }
        }
        
        [TestFixture]
        public class Fourth : EnumerableElementSelectionExtensionsTests
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
        public class FourthOrDefault : EnumerableElementSelectionExtensionsTests
        {
            [Test]
            public void WhenHasThreeElements_ThenReturnDefault()
            {
                _sut.Fill(3, "John");

                var result = _sut.FourthOrDefault();

                Assert.That(result, Is.Null);
            }

            [Test]
            public void WhenHasFourElements_ThenReturnFourthElement()
            {
                const string expected = "Peter";

                _sut.Fill(3, "John");
                _sut.Add(expected);

                var result = _sut.FourthOrDefault();

                Assert.That(result, Is.EqualTo(expected));
            }
        }

        [TestFixture]
        public class Fifth : EnumerableElementSelectionExtensionsTests
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
        public class FifthOrDefault : EnumerableElementSelectionExtensionsTests
        {
            [Test]
            public void WhenHasFourElements_ThenReturnDefault()
            {
                _sut.Fill(4, "John");

                var result = _sut.FifthOrDefault();

                Assert.That(result, Is.Null);
            }

            [Test]
            public void WhenHasFiveElements_ThenReturnFifthElement()
            {
                const string expected = "Peter";

                _sut.Fill(4, "John");
                _sut.Add(expected);

                var result = _sut.FifthOrDefault();

                Assert.That(result, Is.EqualTo(expected));
            }
        }

        [TestFixture]
        public class Sixth : EnumerableElementSelectionExtensionsTests
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
        public class SixthOrDefault : EnumerableElementSelectionExtensionsTests
        {
            [Test]
            public void WhenHasFiveElements_ThenReturnDefault()
            {
                _sut.Fill(5, "John");

                var result = _sut.SixthOrDefault();

                Assert.That(result, Is.Null);
            }

            [Test]
            public void WhenHasSixElements_ThenReturnSixthElement()
            {
                const string expected = "Peter";

                _sut.Fill(5, "John");
                _sut.Add(expected);

                var result = _sut.SixthOrDefault();

                Assert.That(result, Is.EqualTo(expected));
            }
        }

        [TestFixture]
        public class Seventh : EnumerableElementSelectionExtensionsTests
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
        public class SeventhOrDefault : EnumerableElementSelectionExtensionsTests
        {
            [Test]
            public void WhenHasSixElements_ThenReturnDefault()
            {
                _sut.Fill(6, "John");

                var result = _sut.SeventhOrDefault();

                Assert.That(result, Is.Null);
            }

            [Test]
            public void WhenHasSevenElements_ThenReturnSeventhElement()
            {
                const string expected = "Peter";

                _sut.Fill(6, "John");
                _sut.Add(expected);

                var result = _sut.SeventhOrDefault();

                Assert.That(result, Is.EqualTo(expected));
            }
        }

        [TestFixture]
        public class Eighth : EnumerableElementSelectionExtensionsTests
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
        public class EighthOrDefault : EnumerableElementSelectionExtensionsTests
        {
            [Test]
            public void WhenHasSevenElements_ThenReturnDefault()
            {
                _sut.Fill(7, "John");

                var result = _sut.EighthOrDefault();

                Assert.That(result, Is.Null);
            }

            [Test]
            public void WhenHasEightElements_ThenReturnEighthElement()
            {
                const string expected = "Peter";

                _sut.Fill(7, "John");
                _sut.Add(expected);

                var result = _sut.EighthOrDefault();

                Assert.That(result, Is.EqualTo(expected));
            }
        }

        [TestFixture]
        public class Nineth : EnumerableElementSelectionExtensionsTests
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
        public class NinethOrDefault : EnumerableElementSelectionExtensionsTests
        {
            [Test]
            public void WhenHasEightElements_ThenReturnDefault()
            {
                _sut.Fill(8, "John");

                var result = _sut.NinthOrDefault();

                Assert.That(result, Is.Null);
            }

            [Test]
            public void WhenHasNineElements_ThenReturnNinthElement()
            {
                const string expected = "Peter";

                _sut.Fill(8, "John");
                _sut.Add(expected);

                var result = _sut.NinthOrDefault();

                Assert.That(result, Is.EqualTo(expected));
            }
        }

        [TestFixture]
        public class Tenth : EnumerableElementSelectionExtensionsTests
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

        [TestFixture]
        public class TenthOrDefault : EnumerableElementSelectionExtensionsTests
        {
            [Test]
            public void WhenHasNineElements_ThenReturnDefault()
            {
                _sut.Fill(9, "John");

                var result = _sut.TenthOrDefault();

                Assert.That(result, Is.Null);
            }

            [Test]
            public void WhenHasTenElements_ThenReturnTenthElement()
            {
                const string expected = "Peter";

                _sut.Fill(9, "John");
                _sut.Add(expected);

                var result = _sut.TenthOrDefault();

                Assert.That(result, Is.EqualTo(expected));
            }
        }
    }
}