using System.Collections.Generic;
using NUnit.Framework;

namespace ByteDev.Collections.PackageTester.Net461
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void RunTests()
        {
            var sut = new List<int> { 1,2,3,4,5,6,7,8,9,10 };

            var result = sut.Tenth();

            Assert.That(result, Is.EqualTo(10));
        }
    }
}