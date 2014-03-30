using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem28
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = 1001;
            double total = 1;

            for (int i = 3; i <= size; i = i + 2)
            {
                total += NumericSpiralDiagonal.GenerateCornerTotalForSize(i);
            }
            Console.WriteLine(total);
            Console.ReadKey();
        }
    }

    public class NumericSpiralDiagonal
    {
        public static double GenerateRightBottom(int size)
        {
            int level = GetLevelFromSize(size);
            return Generate(level, 2);
        }

        public static double GenerateLeftBottom(int size)
        {
            int level = GetLevelFromSize(size);
            return Generate(level, 4);
        }

        public static double GenerateLeftTop(int size)
        {
            int level = GetLevelFromSize(size);
            return Generate(level, 6);
        }

        public static double GenerateRightTop(int size)
        {
            int level = GetLevelFromSize(size);
            return Generate(level, 8);
        }

        private static double Generate(int level, int multiplier)
        {
            if (level == 0)
                return 1;

            return (8 * Enumerable.Range(1, level - 1).Sum()) + (multiplier * level) + 1;
        }

        public static double GenerateCornerTotalForSize(int size)
        {
            int level = GetLevelFromSize(size);
            if (level == 0)
                return 1;

            return (32 * Enumerable.Range(1, level - 1).Sum()) + (20 * level) + 4;
        }

        public static int GetLevelFromSize(int size)
        {
            if (size % 2 == 0)
                throw new Exception("Must be odd size");

            return (size - 1) / 2;
        }
    }
}
