using System.Linq;
using NUnit.Framework;

namespace ByteDev.Collections.UnitTests
{
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
        public class AsEnumerable_Params
        {
            [TestCase(null, null)]
            [TestCase(1, 2)]
            [TestCase("Test", "Something")]
            public void WhenSingeParam_ThenReturnTwoElementSequence(object sut, object param1)
            {
                var result = sut.AsEnumerable(param1);

                Assert.That(result.Count(), Is.EqualTo(2));
                Assert.That(result.First(), Is.EqualTo(sut));
                Assert.That(result.Second(), Is.EqualTo(param1));
            }

            [TestCase(null, null, null)]
            [TestCase(1, 2, 3)]
            [TestCase("Test", "Something", "Else")]
            public void WhenSingeParam_ThenReturnTwoElementSequence(object sut, object param1, object param2)
            {
                var result = sut.AsEnumerable(param1, param2);

                Assert.That(result.Count(), Is.EqualTo(3));
                Assert.That(result.First(), Is.EqualTo(sut));
                Assert.That(result.Second(), Is.EqualTo(param1));
                Assert.That(result.Third(), Is.EqualTo(param2));
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
}