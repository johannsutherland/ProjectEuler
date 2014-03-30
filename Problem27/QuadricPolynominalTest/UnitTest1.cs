using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Problem27;

namespace QuadricPolynominalTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Example1()
        {
            Primes p = new Primes();

            QuadricPolynominal qp = new QuadricPolynominal(1, 41, p);
            Assert.AreEqual(40, qp.FindLength());
        }

        [TestMethod]
        public void Example2()
        {
            Primes p = new Primes();

            QuadricPolynominal qp = new QuadricPolynominal(-79, 1601, p);
            Assert.AreEqual(80, qp.FindLength());
        }

        [TestMethod]
        public void Is1681Prime()
        {
            Primes p = new Primes();
            double number = 1681;
            Assert.IsFalse(p.IsPrime(number));
        }
    }
}
