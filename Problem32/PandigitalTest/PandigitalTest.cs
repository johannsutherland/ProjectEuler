using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Problem32;

namespace PandigitalTest
{
    [TestClass]
    public class PandigitalTest
    {
        [TestMethod]
        public void Num1234IsPandigital()
        {
            Assert.IsTrue(Pandigital.IsPandigital(1234));
        }

        [TestMethod]
        public void Num9825IsPandigital()
        {
            Assert.IsTrue(Pandigital.IsPandigital(9825));
        }

        [TestMethod]
        public void Num9885IsNotPandigital()
        {
            Assert.IsFalse(Pandigital.IsPandigital(9885));
        }

        [TestMethod]
        public void Num1234And5678And9IsPandigital()
        {
            Assert.IsTrue(Pandigital.IsPandigital(1234, 5678, 9));
        }

        [TestMethod]
        public void Num9825And134And67IsPandigital()
        {
            Assert.IsTrue(Pandigital.IsPandigital(9825, 134, 67));
        }

        [TestMethod]
        public void Num985And345IsNotPandigital()
        {
            Assert.IsFalse(Pandigital.IsPandigital(985, 345, 123));
        }
    }
}
