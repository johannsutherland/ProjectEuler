using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Problem33;

namespace FractionTests
{
    [TestClass]
    public class FractionTest
    {
        [TestMethod]
        public void TestValueIsDecimal()
        {
            Fraction f = new Fraction(1, 2);
            Assert.AreEqual(0.5M, f.Value());
        }

        [TestMethod]
        public void TestValueIsRepeatingDecimal()
        {
            Fraction f = new Fraction(1, 3);
            Assert.AreEqual(1M / 3M, f.Value());
        }

        [TestMethod]
        public void HasIdenticalDigit()
        {
            Fraction f = new Fraction(13, 43);
            Assert.AreEqual('3', f.HasIdenticalDigit());
        }

        [TestMethod]
        public void NoIdenticalDigit()
        {
            Fraction f = new Fraction(15, 43);
            Assert.AreEqual(null, f.HasIdenticalDigit());
        }

        [TestMethod]
        public void NoIdenticalDigit2()
        {
            Fraction f = new Fraction(94, 11);
            Assert.AreEqual(null, f.HasIdenticalDigit());
        }

        [TestMethod]
        public void RemoveDigit()
        {
            Fraction f = new Fraction(13, 43);
            Fraction newf = f.RemoveDigit('3');
            Assert.AreEqual(1, newf.Nominator);
            Assert.AreEqual(4, newf.Denominator);
        }

        [TestMethod]
        public void Equality()
        {
            Fraction f1 = new Fraction(1, 2);
            Fraction f2 = new Fraction(2, 4);
            Assert.IsTrue(f1.Equals(f2));
        }
    }
}
