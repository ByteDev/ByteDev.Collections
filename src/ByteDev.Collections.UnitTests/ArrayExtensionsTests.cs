using System;
using System.Linq;
using NUnit.Framework;

namespace ByteDev.Collections.UnitTests
{
    [TestFixture]
    public class ArrayExtensionsTests
    {
        private const string Value = "New Value";

        [TestFixture]
        public class Populate_OneDimArray : ArrayExtensionsTests
        {
            [Test]
            public void WhenSourceIsNull_ThenThrowException()
            {
                string[] sut = null;

                Assert.Throws<ArgumentNullException>(() => sut.Populate(Value));
            }

            [Test]
            public void WhenSourceIsEmpty_ThenDoNothing()
            {
                string[] sut = new string[0];

                sut.Populate(Value);

                Assert.That(sut, Is.Empty);
            }

            [Test]
            public void WhenValueIsNull_ThenPopulateAllElements()
            {
                string[] sut = {"John", "Peter"};

                sut.Populate(null);

                Assert.That(sut.Length, Is.EqualTo(2));
                Assert.That(sut.First(), Is.Null);
                Assert.That(sut.Second(), Is.Null);
            }

            [Test]
            public void WhenValueIsString_ThenPopulateAllElements()
            {
                string[] sut = {"John", "Peter"};

                sut.Populate(Value);

                Assert.That(sut.Length, Is.EqualTo(2));
                Assert.That(sut.First(), Is.EqualTo(Value));
                Assert.That(sut.Second(), Is.EqualTo(Value));
            }
        }

        [TestFixture]
        public class Populate_TwoDimArray : ArrayExtensionsTests
        {
            [Test]
            public void WhenSourceIsNull_ThenThrowException()
            {
                string[,] sut = null;

                Assert.Throws<ArgumentNullException>(() => sut.Populate(Value));
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
    }
}