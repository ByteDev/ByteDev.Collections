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
            public void WhenSourceIsNull_ThenThrowException()
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
            public void WhenSourceIsNull_ThenThrowException()
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
        public class Swap : ListExtensionsTests
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
            public void WhenSourceIsNull_ThenThrowException()
            {
                Assert.Throws<ArgumentNullException>(() => ListExtensions.Swap(null as IList<string>, 0, 1));
            }

            [Test]
            public void WhenOriginalIndexIsOutOfRange_ThenThrowExcepton()
            {
                var sut = CreateSut(_customer1, _customer2);

                Assert.Throws<ArgumentOutOfRangeException>(() => sut.Swap(-1, 0));
            }

            [Test]
            public void WhenTargetIndexIsOutOfRange_ThenThrowExcepton()
            {
                var sut = CreateSut(_customer1, _customer2);

                Assert.Throws<ArgumentOutOfRangeException>(() => sut.Swap(0, -1));
            }

            [Test]
            public void WhenTargetAndOriginalIndexAreEqual_ThenDoNothing()
            {
                var sut = CreateSut(_customer1, _customer2);

                sut.Swap(0, 0);

                Assert.That(sut.First().Name, Is.EqualTo(_customer1.Name));
                Assert.That(sut.Second().Name, Is.EqualTo(_customer2.Name));
            }

            [Test]
            public void WhenIndexesAreValid_ThenSwap()
            {
                var sut = CreateSut(_customer1, _customer2);

                sut.Swap(0, 1);
                
                Assert.That(sut.First().Name, Is.EqualTo(_customer2.Name));
                Assert.That(sut.Second().Name, Is.EqualTo(_customer1.Name));
            }

            private static IList<Customer> CreateSut(params Customer[] customers)
            {
                var list = new List<Customer>();
                list.AddRange(customers);
                return list;
            }
        }

        [TestFixture]
        public class SafeGet
        {
            private const int DefaultValue = 10;

            [Test]
            public void WhenIsNull_ThenThrowException()
            {
                Assert.Throws<ArgumentNullException>(() => ListExtensions.SafeGet<int>(null, 0));
            }

            [Test]
            public void WhenListIsEmpty_ThenReturnDefault()
            {
                var sut = new List<int>();

                var result = sut.SafeGet(0, DefaultValue);

                Assert.That(result, Is.EqualTo(DefaultValue));
            }

            [TestCase(-1)]
            [TestCase(3)]
            public void WhenIndexOutOfRange_ThenReturnDefault(int index)
            {
                var sut = new List<int> { 1, 2 };
                
                var result = sut.SafeGet(index, DefaultValue);

                Assert.That(result, Is.EqualTo(DefaultValue));
            }

            [TestCase(0, 1)]
            [TestCase(1, 2)]
            public void WhenIndexInRange_ThenReturnObject(int index, int expected)
            {
                var sut = new List<int> { 1, 2 };
                
                var result = sut.SafeGet(index, DefaultValue);

                Assert.That(result, Is.EqualTo(expected));
            }
        }
    }
}