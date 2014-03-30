using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem29
{
    class Program
    {
        static void Main(string[] args)
        {
            List<double> numbers = new List<double>();

            for (int a = 2; a <= 100; a++)
            {
                for (int b = 2; b <= 100; b++)
                {
                    numbers.Add(Math.Pow(a, b));
                }
            }

            Console.WriteLine(numbers.Distinct().Count());
            Console.ReadKey();
        }
    }
}
