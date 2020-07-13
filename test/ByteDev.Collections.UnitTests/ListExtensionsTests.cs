using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace ByteDev.Collections.UnitTests
{
    [TestFixture]
    public class ListExtensionsTests
    {
        public class Customer
        {
            public string Name { get; set; }
        }

        [TestFixture]
        public class NullToEmpty
        {
            [Test]
            public void WhenIsNull_ThenReturnEmpty()
            {
                var result = ListExtensions.NullToEmpty(null as IList<string>);

                Assert.That(result, Is.Empty);
            }

            [Test]
            public void WhenIsNotNull_ThenReturnSame()
            {
                IList<string> sut = new List<string>();

                var result = sut.NullToEmpty();

                Assert.That(result, Is.SameAs(sut));
            }
        }

        [TestFixture]
        public class Fill : ListExtensionsTests
        {
            [Test]
            public void WhenIsNull_ThenThrowException()
            {
                Assert.Throws<ArgumentNullException>(() => ListExtensions.Fill(null, 1, "Hello"));
            }

            [Test]
            public void WhenIsNotEmpty_ThenThrowException()
            {
                var sut = new List<string> {"John", "Peter"};

                Assert.Throws<InvalidOperationException>(() => sut.Fill(2, "Hello"));
            }

            [Test]
            public void WhenNumberToFillIsLessThanOne_ThenFillNoElements()
            {
                var sut = new List<string>();

                sut.Fill(0, "Hello");

                Assert.That(sut, Is.Empty);
            }

            [Test]
            public void WhenNumberToFillIsTwo_ThenFillTwoElements()
            {
                var sut = new List<string>();

                sut.Fill(2, "Hello");

                Assert.That(sut.Count, Is.EqualTo(2));
                Assert.That(sut.First(), Is.EqualTo("Hello"));
                Assert.That(sut.Second(), Is.EqualTo("Hello"));
            }
        }

        [TestFixture]
        public class MoveToFirst
        {
            private Customer _customer1;
            private Customer _customer2;

            [SetUp]
            public void SetUp()
            {
                _customer1 = new Customer {Name = "John"};
                _customer2 = new Customer {Name = "Peter"};
            }

            [Test]
            public void WhenListIsNull_ThenThrowException()
            {
                Assert.Throws<ArgumentNullException>(() => ListExtensions.MoveToFirst(null, _customer1));
            }

            [Test]
            public void WhenItemIsNull_ThenThrowException()
            {
                var sut = CreateSut();

                Assert.Throws<ArgumentNullException>(() => sut.MoveToFirst(null));
            }

            [Test]
            public void WhenListIsEmpty_ThenLeaveListEmpty()
            {
                var sut = CreateSut();

                sut.MoveToFirst(_customer1);

                Assert.That(sut.Count, Is.EqualTo(0));
            }

            [Test]
            public void WhenItemDoesNotExist_ThenNotChangeList()
            {
                var sut = CreateSut(_customer2, _customer2);

                sut.MoveToFirst(_customer1);

                Assert.That(sut.Count, Is.EqualTo(2));
                Assert.That(sut.First(), Is.SameAs(_customer2));
                Assert.That(sut.Second(), Is.SameAs(_customer2));
            }

            [Test]
            public void WhenItemExists_ThenMoveToFirst()
            {
                var sut = CreateSut(_customer1, _customer2);

                sut.MoveToFirst(_customer2);

                Assert.That(sut.Count, Is.EqualTo(2));
                Assert.That(sut.First(), Is.SameAs(_customer2));
                Assert.That(sut.Second(), Is.SameAs(_customer1));
            }

            [Test]
            public void WhenItemExistsTwice_ThenMoveFirstInstanceToFirst()
            {
                var sut = CreateSut(_customer1, _customer2, _customer1, _customer2);

                sut.MoveToFirst(_customer2);

                Assert.That(sut.Count, Is.EqualTo(4));
                Assert.That(sut.First(), Is.SameAs(_customer2));
                Assert.That(sut.Second(), Is.SameAs(_customer1));
                Assert.That(sut.Third(), Is.SameAs(_customer1));
                Assert.That(sut.Fourth(), Is.SameAs(_customer2));
            }

            private static IList<Customer> CreateSut(params Customer[] customers)
            {
                var list = new List<Customer>();
                list.AddRange(customers);
                return list;
            }
        }

        [TestFixture]
        public class MoveToLast : ListExtensionsTests
        {
            private Customer _customer1;
            private Customer _customer2;

            [SetUp]
            public void SetUp()
            {
                _customer1 = new Customer { Name = "John" };
                _customer2 = new Customer { Name = "Peter" };
            }

            [Test]
            public void WhenListIsNull_ThenThrowException()
            {
                Assert.Throws<ArgumentNullException>(() => ListExtensions.MoveToLast(null, _customer1));
            }

            [Test]
            public void WhenItemIsNull_ThenThrowException()
            {
                var sut = CreateSut();

                Assert.Throws<ArgumentNullException>(() => sut.MoveToLast(null));
            }

            [Test]
            public void WhenListIsEmpty_ThenLeaveListEmpty()
            {
                var sut = CreateSut();

                sut.MoveToLast(_customer1);

                Assert.That(sut.Count, Is.EqualTo(0));
            }

            [Test]
            public void WhenItemDoesNotExist_ThenNotChangeList()
            {
                var sut = CreateSut(_customer2, _customer2);

                sut.MoveToLast(_customer1);

                Assert.That(sut.Count, Is.EqualTo(2));
                Assert.That(sut.First(), Is.SameAs(_customer2));
                Assert.That(sut.Second(), Is.SameAs(_customer2));
            }

            [Test]
            public void WhenItemExists_ThenMoveToLast()
            {
                var sut = CreateSut(_customer1, _customer2);

                sut.MoveToLast(_customer1);

                Assert.That(sut.Count, Is.EqualTo(2));
                Assert.That(sut.First(), Is.SameAs(_customer2));
                Assert.That(sut.Second(), Is.SameAs(_customer1));
            }

            [Test]
            public void WhenItemExistsTwice_ThenMoveFirstInstanceToLast()
            {
                var sut = CreateSut(_customer1, _customer2, _customer1, _customer2);

                sut.MoveToLast(_customer1);

                Assert.That(sut.Count, Is.EqualTo(4));
                Assert.That(sut.First(), Is.SameAs(_customer2));
                Assert.That(sut.Second(), Is.SameAs(_customer1));
                Assert.That(sut.Third(), Is.SameAs(_customer2));
                Assert.That(sut.Fourth(), Is.SameAs(_customer1));
            }

            private static IList<Customer> CreateSut(params Customer[] customers)
            {
                var list = new List<Customer>();
                list.AddRange(customers);
                return list;
            }
        }

        [TestFixture]
        public class RemoveWhere
        {
            [Test]
            public void WhenSourceIsNull_ThenThrowException()
            {
                Assert.Throws<ArgumentNullException>(() => ListExtensions.RemoveWhere(null as List<int>, x => x == 1));
            }

            [Test]
            public void WhenPredicateIsNull_ThenThrowException()
            {
                var sut = new List<int> {1, 2, 3};

                Assert.Throws<ArgumentNullException>(() => sut.RemoveWhere(null));
            }

            [Test]
            public void WhenSourceIsEmpty_ThenRemoveNothing()
            {
                var sut = new List<int>();

                sut.RemoveWhere(x => x == 1);

                Assert.That(sut, Is.Empty);
            }

            [Test]
            public void WhereMatchesCondition_ThenRemoveElements()
            {
                var sut = new List<int> {1, 2, 3, 1, 2};

                sut.RemoveWhere(x => x == 1 || x == 2);

                Assert.That(sut.Single(), Is.EqualTo(3));
            }
        }
    }
}
    