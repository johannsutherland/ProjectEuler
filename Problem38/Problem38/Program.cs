using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem38
{
    class Program
    {
        static void Main(string[] args)
        {
            const int MaxNumber = 10000;
            List<int> pandigitalNumbers = new List<int>();

            for (int i = 0; i < MaxNumber; i++)
            {
                List<int> results = new List<int>();
                for (int n = 1; n < MaxNumber; n++)
                {
                    int result = i * n;
                    if (Pandigital.IsPandigital(result))
                    {
                        results.Add(result);
                        Pandigital p = new Pandigital(results);
                        if (p.IsPandigital())
                        {
                            if (p.IsComplete())
                            {
                                pandigitalNumbers.Add(p.Number());
                            }
                        }
                        else
                        {
                            break;
                        }
                    }
                    else
                    {
                        break;
                    }
                }
            }

            Console.WriteLine(pandigitalNumbers.Max());
            Console.ReadKey();
        }
    }

    public class Pandigital
    {
        string bigNumber;

        public Pandigital(List<int> numbers)
        {
            bigNumber = numbers.Aggregate("", (result, element) => result + element.ToString());
        }

        public bool IsPandigital()
        {
            if (bigNumber.Length > 9)
                return false;

            if (bigNumber.Contains('0'))
                return false;

            int concatenatedNumber = int.Parse(bigNumber.ToString());

            return IsPandigital(concatenatedNumber);
        }

        public bool IsComplete()
        {
            return (bigNumber.Length == 9);
        }

        public int Number()
        {
            return int.Parse(bigNumber);
        }

        public static bool IsPandigital(int number)
        {
            string num = number.ToString();
            if (num.Contains('0'))
                return false;

            if (num.Length > 9)
                return false;

            int[] usedDigits = new int[10];

            while (num.Length > 0)
            {
                int digit = int.Parse(num[0].ToString());
                if (usedDigits[digit] > 0)
                {
                    return false;
                }
                else
                {
                    num = num.Substring(1);
                    usedDigits[digit]++;
                }
            }
            return true;
        }
    }
}
