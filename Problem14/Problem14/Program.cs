using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem14
{
    class Program
    {
        static void Main(string[] args)
        {
            SequenceGenerator gs = new SequenceGenerator();
            int upperLimit = 1000000;
            int highestChainNumber = 0;

            for (int i = 1; i <= upperLimit; i++)
            {
                int chains = gs.GenerateSequence(i);
                if (chains > highestChainNumber)
                {
                    highestChainNumber = chains;
                    Console.WriteLine(i + ":" + highestChainNumber);
                }
            }
            Console.ReadKey();
        }
    }

    class SequenceGenerator
    {
        Dictionary<long, int> LookUps = new Dictionary<long, int>();
        long originalNumber;

        public int GenerateSequence(long number)
        {
            int chains = 1;
            originalNumber = number;

            while (true)
            {
                if (LookUps.ContainsKey(number))
                    return chains + LookUps[number];

                if (number == 1)
                {
                    LookUps.Add(originalNumber, chains);
                    return chains;
                }

                if (number % 2 == 0)
                {
                    number = number / 2;
                    chains++;
                }
                else
                {
                    number = 3 * number + 1;
                    chains++;
                }
            }
        }
    }
}
