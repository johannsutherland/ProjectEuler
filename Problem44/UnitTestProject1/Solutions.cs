using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectEuler;
using System.Collections.Generic;

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

        [TestMethod]
        public void Problem_48()
        {
            Assert.AreEqual(9110846700, LastDigitFinder.GetLastDigits(1, 1000, 10));
        }

        [TestMethod]
        public void Problem_49()
        {
            var pp = new PrimePermutations();
            var primePermutations = pp.GetPrimePermutation(4);
            CollectionAssert.AreEqual(new List<int>() { 2969, 6299, 9629, 1487, 4817, 8147 }, primePermutations);
        }
    }
}
