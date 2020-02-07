using System;
using System.Collections.Specialized;
using NUnit.Framework;

namespace ByteDev.Collections.UnitTests
{
    [TestFixture]
    public class NameValueCollectionExtensionsTest
    {
        [TestFixture]
        public class AddOrUpdate
        {
            [Test]
            public void WhenSourceIsNull_ThenThrowException()
            {
                Assert.Throws<ArgumentNullException>(() => NameValueCollectionExtensions.AddOrUpdate(null, "key1", "value1"));
            }

            [Test]
            public void WhenSourceDoesNotContainName_ThenAddPair()
            {
                var sut = new NameValueCollection();

                sut.AddOrUpdate("key1", "value1");

                Assert.That(sut["key1"], Is.EqualTo("value1"));
            }

            [Test]
            public void WhenSourceContainsName_ThenUpdatePair()
            {
                const string expected = "newvalue";

                var sut = new NameValueCollection
                {
                    {"key1", "value1"}
                };

                sut.AddOrUpdate("key1", expected);

                Assert.That(sut["key1"], Is.EqualTo(expected));
            }
        }

        [TestFixture]
        public class ContainsKey
        {
            [Test]
            public void WhenSourceIsNull_ThenThrowException()
            {
                Assert.Throws<ArgumentNullException>(() => NameValueCollectionExtensions.ContainsKey(null, "key1"));
            }

            [Test]
            public void WhenSourceIsEmpty_ThenReturnFalse()
            {
                var sut = new NameValueCollection();

                var result = sut.ContainsKey("key1");

                Assert.That(result, Is.False);
            }

            [Test]
            public void WhenKeyIsNull_ThenReturnFalse()
            {
                var sut = new NameValueCollection
                {
                    {"key1", "value1"}
                };

                var result = sut.ContainsKey(null);

                Assert.That(result, Is.False);
            }

            [Test]
            public void WhenKeyIsNotNull_AndDoesNotExist_ThenReturnFalse()
            {
                var sut = new NameValueCollection
                {
                    {"key1", "value1"}
                };

                var result = sut.ContainsKey("key2");

                Assert.That(result, Is.False);
            }

            [Test]
            public void WhenKeyExists_ThenReturnTrue()
            {
                var sut = new NameValueCollection
                {
                    {"key1", "value1"}
                };

                var result = sut.ContainsKey("key1");

                Assert.That(result, Is.True);
            }
        }
    }
}