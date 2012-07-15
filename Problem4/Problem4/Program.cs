using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem4
{
    class Program
    {
        static void Main(string[] args)
        {
            MatrixGenerator mg = new MatrixGenerator(100, 999);
            List<int> palindromes = new List<int>();

            while (mg.Products.Count > 0 || mg.GenerateNextProducts())
            {
                Product p = mg.Products.Dequeue();
                int number = p.x * p.y;

                if (isPalindromic(number))
                    palindromes.Add(number);
            }
            Console.WriteLine(palindromes.Max());
            Console.ReadKey();
        }

        static bool isPalindromic(int number)
        {
            string forward = number.ToString();

            for (int i = 0; i < forward.Length / 2; i++)
            {
                if (!(forward.Substring(i, 1).CompareTo(forward.Substring(forward.Length - 1 - i, 1)) == 0))
                    return false;
            }

            return true;
        }
    }

    struct Product
    {
        public int x;
        public int y;
    }

    class MatrixGenerator
    {
        private int lowerLimit, upperLimit;
        private int currentPosition;

        public Queue<Product> Products;

        public MatrixGenerator(int lowerLimit, int upperLimit)
        {
            this.lowerLimit = lowerLimit;
            this.upperLimit = upperLimit;
            this.currentPosition = upperLimit;
            this.Products = new Queue<Product>();
        }

        public bool GenerateNextProducts()
        {
            for (int i = this.currentPosition; i >= this.lowerLimit; i--)
                this.Products.Enqueue(new Product { x = this.currentPosition, y = i });

            currentPosition--;

            if (currentPosition < this.lowerLimit)
                return false;
            else
                return true;
        }
    }
}
