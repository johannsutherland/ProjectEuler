using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Problem28;

namespace NumericSpiralDiagonalTest
{
    [TestClass]
    public class UnitTest1
    {
        /*
         *  73 74 75 76 77 78 79 80 81
            72 43 44 45 46 47 48 49 50
            71 42 21 22 23 24 25 26 51
            70 41 20  7  8  9 10 27 52
            69 40 19  6  1  2 11 28 53
            68 39 18  5  4  3 12 29 54
            67 38 17 16 15 14 13 30 55
            66 37 36 35 34 33 32 31 56
            65 64 63 62 61 60 59 58 57 
         */

        /* 3 x 3 Spiral

         * Level = 1
         * RT = 9 = 1 + 8
         * LT = 7 = 1 + 6
         * LB = 5 = 1 + 4
         * RB = 3 = 1 + 2

        */
        /* 5 x 5 Spiral
         * 
         * Level = 2
         * RT = 25 = 9 + 16
         * LT = 21 = 7 + 14
         * LB = 17 = 5 + 12
         * RB = 13 = 3 + 10

        */

        /* 7 x 7 Spiral
         * 
         * Level = 3
         * RT = 49 = 25 + 24
         * LT = 43 = 21 + 22
         * LB = 37 = 17 + 20
         * RB = 31 = 13 + 18
        */

        /* 9 x 9 Spiral
         * 
         * Level = 4
         * RT = 81 = 49 + 32
         * LT = 73 = 43 + 30
         * LB = 65 = 37 + 28
         * RB = 57 = 31 + 26
        */

        [TestMethod]
        public void GetLevelFromSize3()
        {
            Assert.AreEqual(1, NumericSpiralDiagonal.GetLevelFromSize(3));
        }

        [TestMethod]
        public void GetLevelFromSize5()
        {
            Assert.AreEqual(2, NumericSpiralDiagonal.GetLevelFromSize(5));
        }

        [TestMethod]
        public void GetLevelFromSize7()
        {
            Assert.AreEqual(3, NumericSpiralDiagonal.GetLevelFromSize(7));
        }

        [TestMethod]
        public void GetLevelFromSize9()
        {
            Assert.AreEqual(4, NumericSpiralDiagonal.GetLevelFromSize(9));
        }

        [TestMethod]
        public void GetRightBottomForSize3()
        {
            Assert.AreEqual(3, NumericSpiralDiagonal.GenerateRightBottom(3));
        }

        [TestMethod]
        public void GetRightBottomForSize5()
        {
            Assert.AreEqual(13, NumericSpiralDiagonal.GenerateRightBottom(5));
        }

        [TestMethod]
        public void GetRightBottomForSize7()
        {
            Assert.AreEqual(31, NumericSpiralDiagonal.GenerateRightBottom(7));
        }

        [TestMethod]
        public void GetRightBottomForSize9()
        {
            Assert.AreEqual(57, NumericSpiralDiagonal.GenerateRightBottom(9));
        }

        [TestMethod]
        public void GetLeftBottomForSize3()
        {
            Assert.AreEqual(5, NumericSpiralDiagonal.GenerateLeftBottom(3));
        }

        [TestMethod]
        public void GetLeftBottomForSize5()
        {
            Assert.AreEqual(17, NumericSpiralDiagonal.GenerateLeftBottom(5));
        }

        [TestMethod]
        public void GetLeftBottomForSize7()
        {
            Assert.AreEqual(37, NumericSpiralDiagonal.GenerateLeftBottom(7));
        }

        [TestMethod]
        public void GetLeftBottomForSize9()
        {
            Assert.AreEqual(65, NumericSpiralDiagonal.GenerateLeftBottom(9));
        }

        [TestMethod]
        public void GetLeftTopForSize3()
        {
            Assert.AreEqual(7, NumericSpiralDiagonal.GenerateLeftTop(3));
        }

        [TestMethod]
        public void GetLeftTopForSize5()
        {
            Assert.AreEqual(21, NumericSpiralDiagonal.GenerateLeftTop(5));
        }

        [TestMethod]
        public void GetLeftTopForSize7()
        {
            Assert.AreEqual(43, NumericSpiralDiagonal.GenerateLeftTop(7));
        }

        [TestMethod]
        public void GetLeftTopForSize9()
        {
            Assert.AreEqual(73, NumericSpiralDiagonal.GenerateLeftTop(9));
        }

        [TestMethod]
        public void GetRightTopForSize3()
        {
            Assert.AreEqual(9, NumericSpiralDiagonal.GenerateRightTop(3));
        }

        [TestMethod]
        public void GetRightTopForSize5()
        {
            Assert.AreEqual(25, NumericSpiralDiagonal.GenerateRightTop(5));
        }

        [TestMethod]
        public void GetRightTopForSize7()
        {
            Assert.AreEqual(49, NumericSpiralDiagonal.GenerateRightTop(7));
        }

        [TestMethod]
        public void GetRightTopForSize9()
        {
            Assert.AreEqual(81, NumericSpiralDiagonal.GenerateRightTop(9));
        }

        [TestMethod]
        public void GetCornerTotalForSize1()
        {
            Assert.AreEqual(1, NumericSpiralDiagonal.GenerateCornerTotalForSize(1));
        }

        [TestMethod]
        public void GetCornerTotalForSize3()
        {
            int size = 3;
            Assert.AreEqual(NumericSpiralDiagonal.GenerateLeftBottom(size) 
                + NumericSpiralDiagonal.GenerateLeftTop(size) 
                + NumericSpiralDiagonal.GenerateRightBottom(size) 
                + NumericSpiralDiagonal.GenerateRightTop(size), 

                NumericSpiralDiagonal.GenerateCornerTotalForSize(size));
        }

        [TestMethod]
        public void GetCornerTotalForSize5()
        {
            int size = 5;
            Assert.AreEqual(NumericSpiralDiagonal.GenerateLeftBottom(size)
                + NumericSpiralDiagonal.GenerateLeftTop(size)
                + NumericSpiralDiagonal.GenerateRightBottom(size)
                + NumericSpiralDiagonal.GenerateRightTop(size),

                NumericSpiralDiagonal.GenerateCornerTotalForSize(size));
        }
    }
}
