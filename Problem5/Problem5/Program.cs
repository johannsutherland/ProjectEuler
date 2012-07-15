using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem5
{
    class Program
    {
        static void Main(string[] args)
        {
            int lastNumber = 20;

            int counter = lastNumber;
            int currentNumber = lastNumber;
            bool found = false;

            while (!found)
            {
                int testNumber = currentNumber * counter;
                bool foundFailedDivisor = false;

                for (int trailDivisor = lastNumber - 1; trailDivisor > 1; trailDivisor--)
                {
                    if (testNumber % trailDivisor != 0)
                    {
                        foundFailedDivisor = true;
                        break;
                    }
                }

                if (!foundFailedDivisor)
                {
                    Console.WriteLine(testNumber);
                    found = true;
                }

                counter++;
            }
            Console.ReadKey();
        }
    }
}
