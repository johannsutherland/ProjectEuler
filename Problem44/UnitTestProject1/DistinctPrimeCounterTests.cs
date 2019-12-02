using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectEuler;
using System.Collections.Generic;
using System.Linq;

namespace UnitTests
{
    [TestClass]
    public class DistinctPrimeCounterTests
    {
        [TestMethod]
        public void TestDistinctPrimeCounter()
        {
            var distinctPrimeCounter = new DistinctPrimeCounter();
            Assert.AreEqual(14, distinctPrimeCounter.GetFirstNumbersWithNDistinctPrimes(2));
            Assert.AreEqual(644, distinctPrimeCounter.GetFirstNumbersWithNDistinctPrimes(3));
        }
    }
}
