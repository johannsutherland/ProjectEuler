using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem6
{
    class Program
    {
        static void Main(string[] args)
        {
            int upperLimit = 100;
            int squareOfSums = (int)Math.Pow(Enumerable.Range(1, upperLimit).Aggregate((y, x) => y + x), 2);
            int sumOfSquares = Enumerable.Range(1, upperLimit).Aggregate((y, x) => y + (int)Math.Pow(x, 2));
            Console.WriteLine(squareOfSums - sumOfSquares);
            Console.ReadKey();
        }
    }
}
