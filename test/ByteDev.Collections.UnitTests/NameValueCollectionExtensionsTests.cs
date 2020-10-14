using System;
using System.Collections.Specialized;
using System.Linq;
using NUnit.Framework;

namespace ByteDev.Collections.UnitTests
{
    [TestFixture]
    public class NameValueCollectionExtensionsTests
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
        public class AddIfNotContainsKey
        {
            [Test]
            public void WhenSourceIsNull_ThenThrowException()
            {
                Assert.Throws<ArgumentNullException>(() => NameValueCollectionExtensions.AddIfNotContainsKey(null, "key1", "value1"));
            }
            
            [Test]
            public void WhenKeyExists_ThenDoNotAdd()
            {
                var sut = new NameValueCollection
                {
                    {"key1", "value1"}
                };

                sut.AddIfNotContainsKey("key1", "value2");

                Assert.That(sut["key1"], Is.EqualTo("value1"));
            }

            [Test]
            public void WhenKeyDoesNotExist_ThenAdd()
            {
                var sut = new NameValueCollection
                {
                    {"key1", "value1"}
                };

                sut.AddIfNotContainsKey("key2", "value2");

                Assert.That(sut["key1"], Is.EqualTo("value1"));
                Assert.That(sut["key2"], Is.EqualTo("value2"));
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

        [TestFixture]
        public class ToDictionary : NameValueCollectionExtensionsTests
        {
            [Test]
            public void WhenSourceIsNull_ThenThrowException()
            {
                Assert.Throws<ArgumentNullException>(() => NameValueCollectionExtensions.ToDictionary(null));
            }

            [Test]
            public void WhenSourceIsEmpty_ThenReturnEmpty()
            {
                var sut = new NameValueCollection();

                var result = sut.ToDictionary();

                Assert.That(result, Is.Empty);
            }

            [Test]
            public void WhenContainsMultipleKeys_ThenReturnsAsDictionary()
            {
                var sut = new NameValueCollection
                {
                    {"key1", "value1"},
                    {"key2", "value2"}
                };

                var result = sut.ToDictionary();

                Assert.That(result.Count, Is.EqualTo(2));
                Assert.That(result["key1"], Is.EqualTo("value1"));
                Assert.That(result["key2"], Is.EqualTo("value2"));
            }
        }
    }
}