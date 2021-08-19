using System.Linq;
using NUnit.Framework;

namespace ByteDev.Collections.UnitTests
{
    [TestFixture]
    public class GenericExtensionsTests
    {
        [TestFixture]
        public class AsEnumerable : GenericExtensionsTests
        {
            [TestCase(null)]
            [TestCase(1)]
            [TestCase("Test")]
            public void WhenIsCalled_ThenReturnSingleElement(object sut)
            {
                var result = sut.AsEnumerable();

                Assert.That(result.Single(), Is.EqualTo(sut));
            }
        }
    }
}