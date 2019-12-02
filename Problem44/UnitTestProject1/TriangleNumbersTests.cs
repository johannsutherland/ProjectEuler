using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectEuler;
using System.Collections.Generic;
using System.Linq;

namespace UnitTests
{
    [TestClass]
    public class TriangleNumbersTests
    {
        [TestMethod]
        public void TestGenerateIndividual()
        {
            Assert.AreEqual(1, TriangleNumbers.GenerateN(1));
            Assert.AreEqual(3, TriangleNumbers.GenerateN(2));
            Assert.AreEqual(6, TriangleNumbers.GenerateN(3));
        }

        [TestMethod]
        public void TestGenerateSequence()
        {
            var expected = new List<int> { 1, 3, 6, 10, 15 };
            List<int> actual = TriangleNumbers.GenerateN(1, 5).ToList();
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestIsTriangle()
        {
            Assert.IsTrue(TriangleNumbers.IsTriangleNumber(40755));
            Assert.IsFalse(TriangleNumbers.IsTriangleNumber(40756));
        }
    }
}
