using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace ByteDev.Collections.UnitTests
{
    [TestFixture]
    public class EnumerableElementSelectionExtensionsTests
    {
        [TestFixture]
        public class Last_Count : EnumerableElementSelectionExtensionsTests
        {
            [Test]
            public void WhenIsNull_ThenThrowException()
            {
                Assert.Throws<ArgumentNullException>(() => (null as IEnumerable<object>).Last(1));
            }

            [Test]
            public void WhenIsEmpty_ThenReturnEmpty()
            {
                var result = Enumerable.Empty<object>().Last(1);

                Assert.That(result, Is.Empty);
            }

            [TestCase(-1)]
            [TestCase(0)]
            public void WhenCountIsLessThanOne_ThenReturnEmpty(int count)
            {
                var result = Enumerable.Empty<object>().Last(count);

                Assert.That(result, Is.Empty);
            }

            [Test]
            public void WhenCountIsOne_AndSizeIsOne_ThenReturnElement()
            {
                var sut = EnumerableFactory.CreateFrom("1");

                var result = sut.Last(1);

                Assert.That(result.Single(), Is.EqualTo("1"));
            }

            [Test]
            public void WhenCountIsOne_AndSizeIsTwo_ThenReturnLastElement()
            {
                var sut = EnumerableFactory.CreateFrom("1", "2");
                
                var result = sut.Last(1);

                Assert.That(result.Single(), Is.EqualTo("2"));
            }

            [Test]
            public void WhenCountIsTwo_AndSizeIsTwo_ThenReturnAllElements()
            {
                var sut = EnumerableFactory.CreateFrom("1", "2");

                var result = sut.Last(2);

                Assert.That(result.Count(), Is.EqualTo(2));
                Assert.That(result.First(), Is.EqualTo("1"));
                Assert.That(result.Second(), Is.EqualTo("2"));
            }

            [TestCase(2)]
            [TestCase(3)]
            public void WhenCountIsGreaterThanOrEqualSize_ThenReturnAllElements(int count)
            {
                var sut = EnumerableFactory.CreateFrom("1", "2");

                var result = sut.Last(count);

                Assert.That(result.Count(), Is.EqualTo(2));
                Assert.That(result.First(), Is.EqualTo("1"));
                Assert.That(result.Second(), Is.EqualTo("2"));
            }
        }

        [TestFixture]
        public class Second : EnumerableElementSelectionExtensionsTests
        {
            [Test]
            public void WhenIsNull_ThenThrowException()
            {
                Assert.Throws<ArgumentNullException>(() => (null as IEnumerable<object>).Second());
            }

            [Test]
            public void WhenIsEmpty_ThenThrowException()
            {
                var sut = Enumerable.Empty<object>();

                var ex = Assert.Throws<InvalidOperationException>(() => sut.Second());
                Assert.That(ex.Message, Is.EqualTo("Sequence contains no elements."));
            }

            [Test]
            public void WhenHasOneElement_ThenThrowException()
            {
                var sut = EnumerableFactory.CreateFrom("1");

                var ex = Assert.Throws<InvalidOperationException>(() => sut.Second());
                Assert.That(ex.Message, Is.EqualTo("Sequence contains no second element."));
            }

            [Test]
            public void WhenHasTwoElements_ThenReturnSecondElement()
            {
                var sut = EnumerableFactory.CreateFrom("1", "2");

                var result = sut.Second();

                Assert.That(result, Is.EqualTo("2"));
            }

            [Test]
            public void WhenHasThreeElements_ThenReturnSecondElement()
            {
                var sut = EnumerableFactory.CreateFrom("1", "2", "3");

                var result = sut.Second();

                Assert.That(result, Is.EqualTo("2"));
            }
        }

        [TestFixture]
        public class SecondOrDefault : EnumerableElementSelectionExtensionsTests
        {
            [Test]
            public void WhenIsEmpty_ThenReturnDefault()
            {
                var result = Enumerable.Empty<object>().SecondOrDefault();

                Assert.That(result, Is.Null);
            }

            [Test]
            public void WhenHasOneElement_ThenReturnDefault()
            {
                var sut = EnumerableFactory.CreateFrom("1");

                var result = sut.SecondOrDefault();

                Assert.That(result, Is.Null);
            }

            [Test]
            public void WhenHasTwoElements_ThenReturnSecondElement()
            {
                var sut = EnumerableFactory.CreateFrom("1", "2");

                var result = sut.SecondOrDefault();

                Assert.That(result, Is.EqualTo("2"));
            }
        }

        [TestFixture]
        public class Third : EnumerableElementSelectionExtensionsTests
        {
            [Test]
            public void WhenHasTwoElements_ThenThrowException()
            {
                var sut = EnumerableFactory.CreateFrom("1", "2");

                var ex = Assert.Throws<InvalidOperationException>(() => sut.Third());
                Assert.That(ex.Message, Is.EqualTo("Sequence contains no third element."));
            }

            [Test]
            public void WhenHasThreeElements_ThenReturnThirdElement()
            {
                var sut = EnumerableFactory.CreateFrom("1", "2", "3");

                var result = sut.Third();

                Assert.That(result, Is.EqualTo("3"));
            }
        }

        [TestFixture]
        public class ThirdOrDefault : EnumerableElementSelectionExtensionsTests
        {
            [Test]
            public void WhenHasTwoElements_ThenReturnDefault()
            {
                var sut = EnumerableFactory.CreateFrom("1", "2");

                var result = sut.ThirdOrDefault();

                Assert.That(result, Is.Null);
            }

            [Test]
            public void WhenHasThreeElements_ThenReturnThirdElement()
            {
                var sut = EnumerableFactory.CreateFrom("1", "2", "3");

                var result = sut.ThirdOrDefault();

                Assert.That(result, Is.EqualTo("3"));
            }
        }
        
        [TestFixture]
        public class Fourth : EnumerableElementSelectionExtensionsTests
        {
            [Test]
            public void WhenHasThreeElements_ThenThrowException()
            {
                var sut = EnumerableFactory.CreateFrom("1", "2", "3");

                var ex = Assert.Throws<InvalidOperationException>(() => sut.Fourth());
                Assert.That(ex.Message, Is.EqualTo("Sequence contains no fourth element."));
            }

            [Test]
            public void WhenHasFourElements_ThenReturnFourthElement()
            {
                var sut = EnumerableFactory.CreateFrom("1", "2", "3", "4");

                var result = sut.Fourth();

                Assert.That(result, Is.EqualTo("4"));
            }
        }

        [TestFixture]
        public class FourthOrDefault : EnumerableElementSelectionExtensionsTests
        {
            [Test]
            public void WhenHasThreeElements_ThenReturnDefault()
            {
                var sut = EnumerableFactory.CreateFrom("1", "2", "3");

                var result = sut.FourthOrDefault();

                Assert.That(result, Is.Null);
            }

            [Test]
            public void WhenHasFourElements_ThenReturnFourthElement()
            {
                var sut = EnumerableFactory.CreateFrom("1", "2", "3", "4");

                var result = sut.FourthOrDefault();

                Assert.That(result, Is.EqualTo("4"));
            }
        }

        [TestFixture]
        public class Fifth : EnumerableElementSelectionExtensionsTests
        {
            [Test]
            public void WhenHasFourElements_ThenThrowException()
            {
                var sut = EnumerableFactory.CreateFrom("1", "2", "3", "4");

                var ex = Assert.Throws<InvalidOperationException>(() => sut.Fifth());
                Assert.That(ex.Message, Is.EqualTo("Sequence contains no fifth element."));
            }

            [Test]
            public void WhenHasFiveElements_ThenReturnFifthElement()
            {
                var sut = EnumerableFactory.CreateFrom("1", "2", "3", "4", "5");

                var result = sut.Fifth();

                Assert.That(result, Is.EqualTo("5"));
            }
        }

        [TestFixture]
        public class FifthOrDefault : EnumerableElementSelectionExtensionsTests
        {
            [Test]
            public void WhenHasFourElements_ThenReturnDefault()
            {
                var sut = EnumerableFactory.CreateFrom("1", "2", "3", "4");

                var result = sut.FifthOrDefault();

                Assert.That(result, Is.Null);
            }

            [Test]
            public void WhenHasFiveElements_ThenReturnFifthElement()
            {
                var sut = EnumerableFactory.CreateFrom("1", "2", "3", "4", "5");

                var result = sut.FifthOrDefault();

                Assert.That(result, Is.EqualTo("5"));
            }
        }

        [TestFixture]
        public class Sixth : EnumerableElementSelectionExtensionsTests
        {
            [Test]
            public void WhenHasFiveElements_ThenThrowException()
            {
                var sut = EnumerableFactory.CreateFrom("1", "2", "3", "4", "5");

                var ex = Assert.Throws<InvalidOperationException>(() => sut.Sixth());
                Assert.That(ex.Message, Is.EqualTo("Sequence contains no sixth element."));
            }

            [Test]
            public void WhenHasSixElements_ThenReturnSixthElement()
            {
                var sut = EnumerableFactory.CreateFrom("1", "2", "3", "4", "5", "6");
                
                var result = sut.Sixth();

                Assert.That(result, Is.EqualTo("6"));
            }
        }

        [TestFixture]
        public class SixthOrDefault : EnumerableElementSelectionExtensionsTests
        {
            [Test]
            public void WhenHasFiveElements_ThenReturnDefault()
            {
                var sut = EnumerableFactory.CreateFrom("1", "2", "3", "4", "5");

                var result = sut.SixthOrDefault();

                Assert.That(result, Is.Null);
            }

            [Test]
            public void WhenHasSixElements_ThenReturnSixthElement()
            {
                var sut = EnumerableFactory.CreateFrom("1", "2", "3", "4", "5", "6");

                var result = sut.SixthOrDefault();

                Assert.That(result, Is.EqualTo("6"));
            }
        }

        [TestFixture]
        public class Seventh : EnumerableElementSelectionExtensionsTests
        {
            [Test]
            public void WhenHasSixElements_ThenThrowException()
            {
                var sut = EnumerableFactory.CreateFrom("1", "2", "3", "4", "5", "6");

                var ex = Assert.Throws<InvalidOperationException>(() => sut.Seventh());
                Assert.That(ex.Message, Is.EqualTo("Sequence contains no seventh element."));
            }

            [Test]
            public void WhenHasSevenElements_ThenReturnSeventhElement()
            {
                var sut = EnumerableFactory.CreateFrom("1", "2", "3", "4", "5", "6", "7");

                var result = sut.Seventh();

                Assert.That(result, Is.EqualTo("7"));
            }
        }

        [TestFixture]
        public class SeventhOrDefault : EnumerableElementSelectionExtensionsTests
        {
            [Test]
            public void WhenHasSixElements_ThenReturnDefault()
            {
                var sut = EnumerableFactory.CreateFrom("1", "2", "3", "4", "5", "6");

                var result = sut.SeventhOrDefault();

                Assert.That(result, Is.Null);
            }

            [Test]
            public void WhenHasSevenElements_ThenReturnSeventhElement()
            {
                var sut = EnumerableFactory.CreateFrom("1", "2", "3", "4", "5", "6", "7");

                var result = sut.SeventhOrDefault();

                Assert.That(result, Is.EqualTo("7"));
            }
        }

        [TestFixture]
        public class Eighth : EnumerableElementSelectionExtensionsTests
        {
            [Test]
            public void WhenHasSevenElements_ThenThrowException()
            {
                var sut = EnumerableFactory.CreateFrom("1", "2", "3", "4", "5", "6", "7");

                var ex = Assert.Throws<InvalidOperationException>(() => sut.Eighth());
                Assert.That(ex.Message, Is.EqualTo("Sequence contains no eighth element."));
            }

            [Test]
            public void WhenHasEightElements_ThenReturnEighthElement()
            {
                var sut = EnumerableFactory.CreateFrom("1", "2", "3", "4", "5", "6", "7", "8");

                var result = sut.Eighth();

                Assert.That(result, Is.EqualTo("8"));
            }
        }

        [TestFixture]
        public class EighthOrDefault : EnumerableElementSelectionExtensionsTests
        {
            [Test]
            public void WhenHasSevenElements_ThenReturnDefault()
            {
                var sut = EnumerableFactory.CreateFrom("1", "2", "3", "4", "5", "6", "7");

                var result = sut.EighthOrDefault();

                Assert.That(result, Is.Null);
            }

            [Test]
            public void WhenHasEightElements_ThenReturnEighthElement()
            {
                var sut = EnumerableFactory.CreateFrom("1", "2", "3", "4", "5", "6", "7", "8");

                var result = sut.EighthOrDefault();

                Assert.That(result, Is.EqualTo("8"));
            }
        }

        [TestFixture]
        public class Nineth : EnumerableElementSelectionExtensionsTests
        {
            [Test]
            public void WhenHasEightElements_ThenThrowException()
            {
                var sut = EnumerableFactory.CreateFrom("1", "2", "3", "4", "5", "6", "7", "8");

                var ex = Assert.Throws<InvalidOperationException>(() => sut.Ninth());
                Assert.That(ex.Message, Is.EqualTo("Sequence contains no ninth element."));
            }

            [Test]
            public void WhenHasNineElements_ThenReturnNinthElement()
            {
                var sut = EnumerableFactory.CreateFrom("1", "2", "3", "4", "5", "6", "7", "8", "9");

                var result = sut.Ninth();

                Assert.That(result, Is.EqualTo("9"));
            }
        }

        [TestFixture]
        public class NinethOrDefault : EnumerableElementSelectionExtensionsTests
        {
            [Test]
            public void WhenHasEightElements_ThenReturnDefault()
            {
                var sut = EnumerableFactory.CreateFrom("1", "2", "3", "4", "5", "6", "7", "8");

                var result = sut.NinthOrDefault();

                Assert.That(result, Is.Null);
            }

            [Test]
            public void WhenHasNineElements_ThenReturnNinthElement()
            {
                var sut = EnumerableFactory.CreateFrom("1", "2", "3", "4", "5", "6", "7", "8", "9");

                var result = sut.NinthOrDefault();

                Assert.That(result, Is.EqualTo("9"));
            }
        }

        [TestFixture]
        public class Tenth : EnumerableElementSelectionExtensionsTests
        {
            [Test]
            public void WhenHasNineElements_ThenThrowException()
            {
                var sut = EnumerableFactory.CreateFrom("1", "2", "3", "4", "5", "6", "7", "8", "9");

                var ex = Assert.Throws<InvalidOperationException>(() => sut.Tenth());
                Assert.That(ex.Message, Is.EqualTo("Sequence contains no tenth element."));
            }

            [Test]
            public void WhenHasTenElements_ThenReturnTenthElement()
            {
                var sut = EnumerableFactory.CreateFrom("1", "2", "3", "4", "5", "6", "7", "8", "9", "10");

                var result = sut.Tenth();

                Assert.That(result, Is.EqualTo("10"));
            }
        }

        [TestFixture]
        public class TenthOrDefault : EnumerableElementSelectionExtensionsTests
        {
            [Test]
            public void WhenHasNineElements_ThenReturnDefault()
            {
                var sut = EnumerableFactory.CreateFrom("1", "2", "3", "4", "5", "6", "7", "8", "9");

                var result = sut.TenthOrDefault();

                Assert.That(result, Is.Null);
            }

            [Test]
            public void WhenHasTenElements_ThenReturnTenthElement()
            {
                var sut = EnumerableFactory.CreateFrom("1", "2", "3", "4", "5", "6", "7", "8", "9", "10");

                var result = sut.TenthOrDefault();

                Assert.That(result, Is.EqualTo("10"));
            }
        }
    }
}