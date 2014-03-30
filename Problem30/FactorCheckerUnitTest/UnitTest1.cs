using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Problem30;
using System.Collections.Generic;

namespace FactorCheckerUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void GetDigitsFor1234()
        {
            int number = 1234;
            int expected = 4321;
            int result = 0;
            foreach (int d in FactorChecker.GetDigits(number))
            {
                result = result * 10 + d;
            }
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Example1634()
        {
            int number = 1634;
            int power = 4;

            Assert.AreEqual(number, FactorChecker.RaiseDigitsToPower(number, power));
        }

        [TestMethod]
        public void Example1635()
        {
            int number = 1635;
            int power = 4;

            Assert.AreNotEqual(number, FactorChecker.RaiseDigitsToPower(number, power));
        }

        [TestMethod]
        public void Example8208()
        {
            int number = 8208;
            int power = 4;

            Assert.AreEqual(number, FactorChecker.RaiseDigitsToPower(number, power));
        }

        [TestMethod]
        public void Example9474()
        {
            int number = 9474;
            int power = 4;

            Assert.AreEqual(number, FactorChecker.RaiseDigitsToPower(number, power));
        }
    }
}
