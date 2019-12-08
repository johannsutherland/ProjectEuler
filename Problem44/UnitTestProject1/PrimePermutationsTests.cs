using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectEuler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnitTests
{
    [TestClass]
    public class PrimePermutationsTests
    {
        [TestMethod]
        public void Test1DigitPermutations()
        {
            var permutations = new PrimePermutations().GetPermutations(1);
            CollectionAssert.AreEqual(new List<int>() { 1 }, permutations);
        }

        [TestMethod]
        public void Test2DigitPermutations()
        {
            var permutations = new PrimePermutations().GetPermutations(12);
            CollectionAssert.AreEqual(new List<int>() { 12, 21 }, permutations);
        }

        [TestMethod]
        public void Test3DigitPermutations()
        {
            var permutations = new PrimePermutations().GetPermutations(123);
            CollectionAssert.AreEqual(new List<int>() { 123, 132, 213, 231, 312, 321 }, permutations);
        }
    }
}
