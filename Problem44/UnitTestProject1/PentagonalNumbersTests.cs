using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectEuler;
using System.Collections.Generic;
using System.Linq;

namespace UnitTests
{
    [TestClass]
    public class PentagonalNumbersTests
    {
        [TestMethod]
        public void TestGenerateIndividual()
        {
            Assert.AreEqual(1, PentagonalNumbers.GenerateN(1));
            Assert.AreEqual(5, PentagonalNumbers.GenerateN(2));
            Assert.AreEqual(12, PentagonalNumbers.GenerateN(3));
        }

        [TestMethod]
        public void TestGenerateSequence()
        {
            var expected = new List<int> { 1, 5, 12, 22, 35, 51, 70, 92, 117, 145 };
            List<int> actual = PentagonalNumbers.GenerateN(1, 10).ToList();
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestIsPentagonal()
        {
            Assert.IsTrue(PentagonalNumbers.IsPentagonalNumber(117));
            Assert.IsFalse(PentagonalNumbers.IsPentagonalNumber(118));
        }
    }
}
