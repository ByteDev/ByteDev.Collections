using System.Linq;
using NUnit.Framework;

namespace ByteDev.Collections.UnitTests;

[TestFixture]
public class GenericExtensionsTests
{
    [TestFixture]
    public class AsEnumerable
    {
        [TestCase(null)]
        [TestCase(1)]
        [TestCase("Test")]
        public void WhenIsCalled_ThenReturnSingleElementSequence(object sut)
        {
            var result = sut.AsEnumerable();

            Assert.That(result.Single(), Is.EqualTo(sut));
        }
    }

    [TestFixture]
    public class AsList
    {
        [TestCase(null)]
        [TestCase(1)]
        [TestCase("Test")]
        public void WhenIsCalled_ThenReturnSingleElementList(object sut)
        {
            var result = sut.AsList();

            Assert.That(result.Single(), Is.EqualTo(sut));
        }
    }
}