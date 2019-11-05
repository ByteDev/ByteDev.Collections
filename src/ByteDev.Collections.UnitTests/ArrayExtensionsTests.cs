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
        public class Populate : ArrayExtensionsTests
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
    }
}