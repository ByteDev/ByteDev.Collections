using System.Linq;
using NUnit.Framework;

namespace ByteDev.Collections.UnitTests
{
    [TestFixture]
    public class EnumerableFactoryTests
    {
        [TestFixture]
        public class CreateFrom
        {
            [Test]
            public void WhenEmptyArgs_ThenReturnEmptySequence()
            {
                var result = EnumerableFactory.CreateFrom<string>();

                Assert.That(result, Is.Empty);
            }

            [TestCase(null)]
            [TestCase(1)]
            [TestCase("Test")]
            public void WhenSingleArg_ThenReturnSingleElementSequence(object arg1)
            {
                var result = EnumerableFactory.CreateFrom(arg1);

                Assert.That(result.Single(), Is.EqualTo(arg1));
            }

            [TestCase(null, null)]
            [TestCase(1, 2)]
            [TestCase("Test", "Something")]
            public void WhenTwoArgParams_ThenReturnTwoElementSequence(object arg1, object arg2)
            {
                var result = EnumerableFactory.CreateFrom(arg1, arg2);

                Assert.That(result.Count(), Is.EqualTo(2));
                Assert.That(result.First(), Is.EqualTo(arg1));
                Assert.That(result.Second(), Is.EqualTo(arg2));
            }
        }
    }
}