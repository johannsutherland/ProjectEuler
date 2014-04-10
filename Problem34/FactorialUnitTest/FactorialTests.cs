using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Problem34;
using System.Collections.Generic;

namespace FactorialUnitTest
{
    [TestClass]
    public class FactorialTests
    {
        [TestMethod]
        public void GetDigits()
        {
            int[] digits = new int[4];
            int i = 3;
            int[] expected = { 1, 2, 3, 4 };
            foreach (int d in DigitsManager.GetDigits(1234))
            {
                digits[i] = d;
                Assert.AreEqual(digits[i], expected[i]);
                i--;
            }
        }

        [TestMethod]
        public void CalculateFactorialOf1()
        {
            Factorial f = new Factorial();
            Assert.AreEqual(1, f.CalculateFactorial(1));
        }

        [TestMethod]
        public void CalculateFactorialOf3()
        {
            Factorial f = new Factorial();
            Assert.AreEqual(6, f.CalculateFactorial(3));
        }

        [TestMethod]
        public void CalculateFactorialOf5()
        {
            Factorial f = new Factorial();
            Assert.AreEqual(120, f.CalculateFactorial(5));
        }

        [TestMethod]
        public void CalculateFactorialOf20()
        {
            Factorial f = new Factorial();
            Assert.AreEqual(2432902008176640000, f.CalculateFactorial(20));
        }

        [TestMethod]
        public void CalculateFactorialOf3WithCache()
        {
            Factorial f = new Factorial();
            Assert.AreEqual(6, f.CalculateFactorial(3));
            Assert.AreEqual(6, f.CalculateFactorial(3));
        }
    }
}
