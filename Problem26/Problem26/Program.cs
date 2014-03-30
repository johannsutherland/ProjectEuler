using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem26
{
    class Program
    {
        static void Main(string[] args)
        {
            int maxCycle = 0;
            int maxD = 0;

            for (int d = 2; d <= 1000; d++)
            {
                int quotient = 10 / d;
                int remainder = 10 % d;
                int count = 1;
                int[] remaindersFound = new int[d];

                while (remaindersFound[remainder] == 0)
                {
                    remaindersFound[remainder] = count;
                    remainder = remainder * 10 % d;
                    count++;
                }
                count--;

                Console.WriteLine("{0}'s period is {1}", d, count);
                if (count > maxCycle)
                {
                    maxCycle = count;
                    maxD = d;
                }
            }
            Console.WriteLine("The maximum is {0}", maxD);
            Console.ReadKey();
        }
    }
}
