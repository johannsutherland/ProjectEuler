using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectEuler;

namespace Solutions
{
    [TestClass]
    public partial class Solutions
    {
        [TestMethod]
        public void Problem_44()
        {
            Assert.AreEqual(5482660, PentagonalNumbers.FindPentagonalPairs());
        }

        [TestMethod]
        public void Problem_45()
        {
            Assert.AreEqual(1533776805, HexagonalNumbers.FindCorrespondingPentagonalNumber());
        }

        [TestMethod]
        public void Problem_46()
        {
            var goldbachsOtherConjecture = new GoldbachsOtherConjecture();
            Assert.AreEqual(5777, goldbachsOtherConjecture.FindFirstFalse());
        }

        [TestMethod]
        public void Problem_47()
        {
            var distinctPrimeCounter = new DistinctPrimeCounter();
            Assert.AreEqual(134043, distinctPrimeCounter.GetFirstNumbersWithNDistinctPrimes(4));
        }
    }
}
