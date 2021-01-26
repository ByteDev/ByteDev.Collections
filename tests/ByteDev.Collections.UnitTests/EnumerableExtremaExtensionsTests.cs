using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace ByteDev.Collections.UnitTests
{
    [TestFixture]
    public class EnumerableExtremaExtensionsTests
    {
        [TestFixture]
        public class MaxBy : EnumerableExtensionsTests
        {
            [Test]
            public void WhenIsNull_ThenThrowException()
            {
                IList<DummyCustomer> sut = null;

                Assert.Throws<ArgumentNullException>(() => sut.MaxBy(x => x.Age));
            }

            [Test]
            public void WhenIsEmpty_ThenReturnEmpty()
            {
                var sut = new List<DummyCustomer>();

                var result = sut.MaxBy(x => x.Age);

                Assert.That(result, Is.Empty);
            }

            [Test]
            public void WhenContainsSingleElement_ThenReturnElement()
            {
                var sut = new List<DummyCustomer>
                {
                    new DummyCustomer {Age = 10}
                };

                var result = sut.MaxBy(x => x.Age);

                Assert.That(result.Single().Age, Is.EqualTo(10));
            }

            [Test]
            public void WhenThreeDifferentElements_ThenReturnItemWithMax()
            {
                var sut = new List<DummyCustomer>
                {
                    new DummyCustomer { Age = 10 },
                    new DummyCustomer { Age = 30 },
                    new DummyCustomer { Age = 20 }
                };

                var result = sut.MaxBy(x => x.Age);

                Assert.That(result.Single().Age, Is.EqualTo(30));
            }

            [Test]
            public void WhenContainsMultipleMax_ThenReturnAll()
            {
                var sut = new List<DummyCustomer>
                {
                    new DummyCustomer { Age = 10 },
                    new DummyCustomer { Age = 20, Name = "John" },
                    new DummyCustomer { Age = 20, Name = "Peter"},
                    new DummyCustomer { Age = 5 }
                };

                var result = sut.MaxBy(x => x.Age);

                Assert.That(result.Count, Is.EqualTo(2));
                Assert.That(result.First().Name, Is.EqualTo("John"));
                Assert.That(result.Second().Name, Is.EqualTo("Peter"));
            }
        }

        [TestFixture]
        public class MinBy : EnumerableExtensionsTests
        {
            [Test]
            public void WhenIsNull_ThenThrowException()
            {
                IList<DummyCustomer> sut = null;

                Assert.Throws<ArgumentNullException>(() => sut.MinBy(x => x.Age));
            }

            [Test]
            public void WhenIsEmpty_ThenReturnEmpty()
            {
                var sut = new List<DummyCustomer>();

                var result = sut.MinBy(x => x.Age);

                Assert.That(result, Is.Empty);
            }

            [Test]
            public void WhenContainsSingleElement_ThenReturnElement()
            {
                var sut = new List<DummyCustomer>
                {
                    new DummyCustomer {Age = 10}
                };

                var result = sut.MinBy(x => x.Age);

                Assert.That(result.Single().Age, Is.EqualTo(10));
            }

            [Test]
            public void WhenThreeDifferentElements_ThenReturnItemWithMin()
            {
                var sut = new List<DummyCustomer>
                {
                    new DummyCustomer { Age = 10 },
                    new DummyCustomer { Age = 30 },
                    new DummyCustomer { Age = 20 }
                };

                var result = sut.MinBy(x => x.Age);

                Assert.That(result.Single().Age, Is.EqualTo(10));
            }

            [Test]
            public void WhenContainsMultipleMax_ThenReturnAll()
            {
                var sut = new List<DummyCustomer>
                {
                    new DummyCustomer { Age = 10 },
                    new DummyCustomer { Age = 2, Name = "John" },
                    new DummyCustomer { Age = 2, Name = "Peter"},
                    new DummyCustomer { Age = 5 }
                };

                var result = sut.MinBy(x => x.Age);

                Assert.That(result.Count, Is.EqualTo(2));
                Assert.That(result.First().Name, Is.EqualTo("John"));
                Assert.That(result.Second().Name, Is.EqualTo("Peter"));
            }
        }
        
        public class DummyCustomer
        {
            public int Age { get; set; }

            public string Name {get; set; }
        }   
    }
}