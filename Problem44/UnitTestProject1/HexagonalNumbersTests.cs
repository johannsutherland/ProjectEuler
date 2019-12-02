using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectEuler;
using System.Collections.Generic;
using System.Linq;

namespace UnitTests
{
    [TestClass]
    public class HexagonalNumbersTests
    {
        [TestMethod]
        public void TestGenerateIndividual()
        {
            Assert.AreEqual(1, HexagonalNumbers.GenerateN(1));
            Assert.AreEqual(6, HexagonalNumbers.GenerateN(2));
            Assert.AreEqual(15, HexagonalNumbers.GenerateN(3));
        }

        [TestMethod]
        public void TestGenerateSequence()
        {
            var expected = new List<int> { 1, 6, 15, 28, 45 };
            List<int> actual = HexagonalNumbers.GenerateN(1, 5).ToList();
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestIsHexagonal()
        {
            Assert.IsTrue(HexagonalNumbers.IsHexagonalNumber(40755));
            Assert.IsFalse(HexagonalNumbers.IsHexagonalNumber(40756));
        }
    }
}
