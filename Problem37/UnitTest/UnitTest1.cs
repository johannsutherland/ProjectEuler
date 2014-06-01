using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Problem37;
using System.Collections.Generic;
using System.Linq;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void RemoveDigitFromLeft()
        {
            List<int> digits = new List<int>();
            int number = 123456;
            List<int> expectedDigits = new List<int> { 23456, 3456, 456, 56, 6 };

            foreach (int digit in Program.RemoveDigit(number, Program.Side.Left))
            {
                digits.Add(digit);
            }

            Assert.IsTrue(digits.SequenceEqual(expectedDigits));
        }

        [TestMethod]
        public void RemoveDigitFromRight()
        {
            List<int> digits = new List<int>();
            int number = 123456;
            List<int> expectedDigits = new List<int> { 12345, 1234, 123, 12, 1 };

            foreach (int digit in Program.RemoveDigit(number, Program.Side.Right))
            {
                digits.Add(digit);
            }

            Assert.IsTrue(digits.SequenceEqual(expectedDigits));
        }

        [TestMethod]
        public void AddDigitToRight()
        {
            List<int> digits = new List<int> { 2, 3, 4, 5, 6 };
            int startNumber = 1;
            List<int> expectedNumbers = new List<int> { 12, 13, 14, 15, 16 };
            List<int> numbers = new List<int>();

            foreach (int number in Program.AddDigit(startNumber, digits, Program.Side.Right))
            {
                numbers.Add(number);
            }

            Assert.IsTrue(numbers.SequenceEqual(expectedNumbers));
        }

        [TestMethod]
        public void AddDigitToLeft()
        {
            List<int> digits = new List<int> { 2, 3, 4, 5, 6 };
            int startNumber = 1;
            List<int> expectedNumbers = new List<int> { 21, 31, 41, 51, 61 };
            List<int> numbers = new List<int>();

            foreach (int number in Program.AddDigit(startNumber, digits, Program.Side.Left))
            {
                numbers.Add(number);
            }

            Assert.IsTrue(numbers.SequenceEqual(expectedNumbers));
        }
    }
}
