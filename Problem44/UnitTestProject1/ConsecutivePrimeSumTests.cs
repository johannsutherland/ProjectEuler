using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectEuler;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTests
{
    [TestClass]
    public class ConsecutivePrimeSumTests
    {
        [TestMethod]
        public void TestConsecutivePrimeSumBelow100()
        {
            var cps = new ConsecutivePrimeSum();
            Assert.AreEqual(41, cps.FindConsecutivePrimeSumPrime(100));
        }

        [TestMethod]
        public void TestConsecutivePrimeSumBelow1000()
        {
            var cps = new ConsecutivePrimeSum();
            Assert.AreEqual(953, cps.FindConsecutivePrimeSumPrime(1000));
        }

        [TestMethod]
        public void TestConsecutivePrimeSumBelow1000000()
        {
            var cps = new ConsecutivePrimeSum();
            Assert.AreEqual(997651, cps.FindConsecutivePrimeSumPrime(1000000));
        }
    }
}
