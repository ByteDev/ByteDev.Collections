using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace ByteDev.Collections.UnitTests
{
    [TestFixture]
    public class DictionaryExtensionsTest
    {
        private Dictionary<string, string> _sut;

        [SetUp]
        public void SetUp()
        {
            _sut = new Dictionary<string, string>();
        }

        [TestFixture]
        public class AddRange : DictionaryExtensionsTest
        {
            [Test]
            public void WhenItemsToAddIsNull_ThenThrowException()
            {
                Assert.Throws<ArgumentNullException>(() => _sut.AddRange(null));
            }

            [Test]
            public void WhenItemsToAddIsEmpty_ThenAddNothing()
            {
                _sut.AddRange(new KeyValuePair<string, string>[0]);

                Assert.That(_sut.Count, Is.EqualTo(0));
            }

            [Test]
            public void WhenTwoItemsToAdd_ThenAddTwoItems()
            {
                IList<KeyValuePair<string, string>> keyValuePairs = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("key1", "value1"),
                    new KeyValuePair<string, string>("key2", "value2")
                };

                _sut.AddRange(keyValuePairs);

                Assert.That(_sut.Count, Is.EqualTo(2));
            }

            [Test]
            public void WhenItemToAdd_AndKeyAlreadyInDictionary_ThenThrowException()
            {
                _sut.Add("key1", "value1");

                IList<KeyValuePair<string, string>> keyValuePairs = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("key1", "value2")
                };

                Assert.Throws<ArgumentException>(() => _sut.AddRange(keyValuePairs));
            }
        }

        [TestFixture]
        public class AddOrUpdateRange : DictionaryExtensionsTest
        {
            [Test]
            public void WhenItemsToAddIsNull_ThenThrowException()
            {
                Assert.Throws<ArgumentNullException>(() => _sut.AddOrUpdateRange(null));
            }

            [Test]
            public void WhenItemsToAddIsEmpty_ThenAddNothing()
            {
                _sut.AddOrUpdateRange(new KeyValuePair<string, string>[0]);

                Assert.That(_sut.Count, Is.EqualTo(0));
            }

            [Test]
            public void WhenTwoItemsToAdd_ThenAddTwoItems()
            {
                IList<KeyValuePair<string, string>> keyValuePairs = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("key1", "value1"),
                    new KeyValuePair<string, string>("key2", "value2")
                };

                _sut.AddOrUpdateRange(keyValuePairs);

                Assert.That(_sut.Count, Is.EqualTo(2));
            }

            [Test]
            public void WhenItemToAddOrUpdate_AndKeyAlreadyInDictionary_ThenUpdateExistingKeysValue()
            {
                _sut.Add("key1", "value1");
                _sut.Add("key2", "value1");

                IList<KeyValuePair<string, string>> keyValuePairs = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("key1", "value2")
                };

                _sut.AddOrUpdateRange(keyValuePairs);

                Assert.That(_sut["key1"], Is.EqualTo("value2"));
                Assert.That(_sut["key2"], Is.EqualTo("value1"));
            }
        }

        [TestFixture]
        public class GetValueIgnoreKeyCase : DictionaryExtensionsTest
        {
            [Test]
            public void WhenKeyIsNull_ThenThrowException()
            {
                Assert.Throws<ArgumentException>(() => _sut.GetValueIgnoreKeyCase(null));
            }

            [Test]
            public void WhenKeyIsEmpty_ThenThrowException()
            {
                Assert.Throws<ArgumentException>(() => _sut.GetValueIgnoreKeyCase(string.Empty));
            }

            [Test]
            public void WhenKeyIsNotPresent_ThenReturnDefault()
            {
                var result = _sut.GetValueIgnoreKeyCase("someKey");

                Assert.That(result, Is.Null);
            }

            [Test]
            public void WhenKeyPresent_ThenReturnValue()
            {
                _sut.Add("someKey", "someValue");

                var result = _sut.GetValueIgnoreKeyCase("someKey");

                Assert.That(result, Is.EqualTo("someValue"));
            }

            [Test]
            public void WhenKeyPresentButDifferentCase_ThenReturnValue()
            {
                _sut.Add("someKey", "someValue");

                var result = _sut.GetValueIgnoreKeyCase("SOMEKEY");

                Assert.That(result, Is.EqualTo("someValue"));
            }
        }
    }
}