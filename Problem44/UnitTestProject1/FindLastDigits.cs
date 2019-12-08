using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectEuler;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTests
{
    [TestClass]
    public class FindLastDigits
    {
        [TestMethod]
        public void FindLastDigitsOfSeries()
        {
            Assert.AreEqual(405071317, LastDigitFinder.GetLastDigits(1, 10, 10));
        }
    }
}
