using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectEuler;
using System.Collections.Generic;
using System.Linq;

namespace UnitTests
{
    [TestClass]
    public class GoldbachsOtherConjectureTests
    {
        [TestMethod]
        public void TestGoldbachsOtherConjecture()
        {
            var goldbachsOtherConjecture = new GoldbachsOtherConjecture();
            Assert.IsTrue(goldbachsOtherConjecture.HoldsFor(9));
            Assert.IsTrue(goldbachsOtherConjecture.HoldsFor(15));
            Assert.IsTrue(goldbachsOtherConjecture.HoldsFor(21));
            Assert.IsTrue(goldbachsOtherConjecture.HoldsFor(25));
            Assert.IsTrue(goldbachsOtherConjecture.HoldsFor(27));
            Assert.IsTrue(goldbachsOtherConjecture.HoldsFor(33));
        }
    }
}
