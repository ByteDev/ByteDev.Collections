﻿using System;
using System.Collections.Generic;
using System.Linq;
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
        public class AddOrUpdate : DictionaryExtensionsTest
        {
            [Test]
            public void WhenSourceIsNull_ThenThrowException()
            {
                Dictionary<string, string> sut = null;

                Assert.Throws<ArgumentNullException>(() => sut.AddOrUpdate("key1", "value1"));
            }

            [Test]
            public void WhenKeyIsNull_ThenThrowException()
            {
                Assert.Throws<ArgumentNullException>(() => _sut.AddOrUpdate(null, "value1"));
            }

            [Test]
            public void WhenValueIsNull_ThenAdd()
            {
                _sut.AddOrUpdate("key1", null);

                Assert.That(_sut["key1"], Is.Null);
            }

            [Test]
            public void WhenDoesNotHaveKey_ThenAdd()
            {
                _sut.AddOrUpdate("key1", "value1");

                Assert.That(_sut["key1"], Is.EqualTo("value1"));
            }

            [Test]
            public void WhenHasKey_ThenUpdate()
            {
                _sut.Add("key1", "value1");
                _sut.AddOrUpdate("key1", "value2");

                Assert.That(_sut["key1"], Is.EqualTo("value2"));
            }
        }

        [TestFixture]
        public class AddOrUpdate_WithPredicate : DictionaryExtensionsTest
        {
            [Test]
            public void WhenSourceIsNull_ThenThrowException()
            {
                Dictionary<string, string> sut = null;

                Assert.Throws<ArgumentNullException>(() => sut.AddOrUpdate("key1", "value1", v => v == "value1"));
            }

            [Test]
            public void WhenKeyIsNull_ThenThrowException()
            {
                Assert.Throws<ArgumentNullException>(() => _sut.AddOrUpdate(null, "value1", v => v == "value1"));
            }

            [Test]
            public void WhenPredicateIsNull_ThenThrowException()
            {
                Assert.Throws<ArgumentNullException>(() => _sut.AddOrUpdate("key1", "value1", null));
            }

            [Test]
            public void WhenValueIsNull_ThenAdd()
            {
                _sut.AddOrUpdate("key1", null, v => v == "value1");

                Assert.That(_sut["key1"], Is.Null);
            }

            [Test]
            public void WhenDoesNotHaveKey_ThenAdd()
            {
                _sut.AddOrUpdate("key1", "value1", v => v == "value1");

                Assert.That(_sut["key1"], Is.EqualTo("value1"));
            }

            [Test]
            public void WhenHasKey_AndPredicateMatches_ThenUpdate()
            {
                _sut.Add("key1", "value1");
                _sut.AddOrUpdate("key1", "value2", v => v == "value1");

                Assert.That(_sut["key1"], Is.EqualTo("value2"));
            }

            [Test]
            public void WhenHasKey_AndPredicateDoesNotMatch_ThenDoesNotUpdate()
            {
                _sut.Add("key1", "value1");
                _sut.AddOrUpdate("key1", "value2", v => v == "not value1");

                Assert.That(_sut["key1"], Is.EqualTo("value1"));
            }
        }

        [TestFixture]
        public class AddRange : DictionaryExtensionsTest
        {
            [Test]
            public void WhenSourceIsNull_ThenThrowException()
            {
                Dictionary<string, string> sut = null;

                Assert.Throws<ArgumentNullException>(() => sut.AddRange(new KeyValuePair<string, string>[0]));
            }

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

                var ex = Assert.Throws<ArgumentException>(() => _sut.AddRange(keyValuePairs));
                Assert.That(ex.Message, Is.EqualTo("An item with the same key has already been added. Key: key1"));
            }
        }

        [TestFixture]
        public class AddOrUpdateRange : DictionaryExtensionsTest
        {
            [Test]
            public void WhenSourceIsNull_ThenThrowException()
            {
                Dictionary<string, string> sut = null;

                Assert.Throws<ArgumentNullException>(() => sut.AddOrUpdateRange(new KeyValuePair<string, string>[0]));
            }

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
        public class GetValuesIgnoreKeyCase : DictionaryExtensionsTest
        {
            [Test]
            public void WhenSourceIsNull_ThenThrowException()
            {
                Dictionary<string, string> sut = null;

                Assert.Throws<ArgumentNullException>(() => sut.GetValuesIgnoreKeyCase("SomeKey"));
            }

            [Test]
            public void WhenKeyIsNull_ThenThrowException()
            {
                Assert.Throws<ArgumentException>(() => _sut.GetValuesIgnoreKeyCase(null));
            }

            [Test]
            public void WhenKeyIsEmpty_ThenThrowException()
            {
                Assert.Throws<ArgumentException>(() => _sut.GetValuesIgnoreKeyCase(string.Empty));
            }

            [Test]
            public void WhenKeyIsNotPresent_ThenReturnDefault()
            {
                var result = _sut.GetValuesIgnoreKeyCase("someKey");

                Assert.That(result, Is.Empty);
            }

            [Test]
            public void WhenKeyPresentOnce_ThenReturnValue()
            {
                _sut.Add("key", "someValue");
                _sut.Add("key2", "someValue2");

                var result = _sut.GetValuesIgnoreKeyCase("key");
                
                Assert.That(result.Single(), Is.EqualTo("someValue"));
            }

            [Test]
            public void WhenKeyPresentOnceButDifferentCase_ThenReturnValue()
            {
                _sut.Add("someKey", "someValue");
                _sut.Add("someKey2", "someValue2");

                var result = _sut.GetValuesIgnoreKeyCase("SOMEKEY");

                Assert.That(result.Single(), Is.EqualTo("someValue"));
            }

            [Test]
            public void WhenKeyPresentTwiceButDifferentCase_ThenReturnValues()
            {
                _sut.Add("someKey", "someValue");
                _sut.Add("SomeKey", "Somevalue");
                _sut.Add("Somekey2", "someValue2");

                var result = _sut.GetValuesIgnoreKeyCase("SOMEKEY");

                Assert.That(result.Count, Is.EqualTo(2));
                Assert.That(result.First(), Is.EqualTo("someValue"));
                Assert.That(result.Second(), Is.EqualTo("Somevalue"));
            }
        }

        [TestFixture]
        public class GetFirstValueIgnoreKeyCase : DictionaryExtensionsTest
        {
            [Test]
            public void WhenSourceIsNull_ThenThrowException()
            {
                Dictionary<string, string> sut = null;

                Assert.Throws<ArgumentNullException>(() => sut.GetFirstValueIgnoreKeyCase("key1"));
            }

            [Test]
            public void WhenKeyIsNull_ThenThrowException()
            {
                Assert.Throws<ArgumentException>(() => _sut.GetFirstValueIgnoreKeyCase(null));
            }

            [Test]
            public void WhenKeyIsEmpty_ThenThrowException()
            {
                Assert.Throws<ArgumentException>(() => _sut.GetFirstValueIgnoreKeyCase(string.Empty));
            }

            [Test]
            public void WhenKeyIsNotPresent_ThenReturnDefault()
            {
                var result = _sut.GetFirstValueIgnoreKeyCase("key1");

                Assert.That(result, Is.Null);
            }

            [Test]
            public void WhenKeyPresent_ThenReturnValue()
            {
                _sut.Add("key", "value1");
                _sut.Add("key2", "value2");

                var result = _sut.GetFirstValueIgnoreKeyCase("key");

                Assert.That(result, Is.EqualTo("value1"));
            }

            [Test]
            public void WhenKeyPresentButDifferentCase_ThenReturnValue()
            {
                _sut.Add("key", "value1");
                _sut.Add("key2", "value2");

                var result = _sut.GetFirstValueIgnoreKeyCase("KEY");

                Assert.That(result, Is.EqualTo("value1"));
            }

            [Test]
            public void WhenKeyPresentTwiceButDifferentCase_ThenReturnFirstValue()
            {
                _sut.Add("key", "value1");
                _sut.Add("Key", "value2");
                _sut.Add("key2", "value3");

                var result = _sut.GetFirstValueIgnoreKeyCase("KEY");
                
                Assert.That(result, Is.EqualTo("value1"));
            }
        }
    }
}