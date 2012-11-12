using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem17
{
    class Program
    {
        private static Dictionary<int, string> dictionary = new Dictionary<int, string> { 
            { 0, "" },
            { 1, "one" },
            { 2, "two" }, 
            { 3, "three" },
            { 4, "four" },
            { 5, "five" },
            { 6, "six" },
            { 7, "seven" },
            { 8, "eight" },
            { 9, "nine" },
            { 10, "ten" },
            { 11, "eleven" },
            { 12, "twelve" }, 
            { 13, "thirteen" },
            { 14, "fourteen" },
            { 15, "fifteen" },
            { 16, "sixteen" },
            { 17, "seventeen" },
            { 18, "eighteen" },
            { 19, "nineteen" },
            { 20, "twenty" }, 
            { 30, "thirty" }, 
            { 40, "forty" },
            { 50, "fifty" }, 
            { 60, "sixty" }, 
            { 70, "seventy" }, 
            { 80, "eighty" }, 
            { 90, "ninety" }, 
            { 100, "hundred" },
            { 1000, "thousand" }
        };

        private static string NumberToWord(int number)
        {
            if (number >= 1000000)
                throw new Exception("Only numbers smaller than a million");

            StringBuilder sb = new StringBuilder();

            if (number <= 20)
                sb.Append(dictionary[number]);

            if ((number > 20) && (number <= 99))
                sb.Append(dictionary[(int)(number / 10.0) * 10] + " " + dictionary[(number % 10)]);

            if ((number >= 100) && (number <= 999))
                sb.Append(dictionary[(int)(number / 100.0)] + " hundred " + ((number % 100) != 0 ? "and " + NumberToWord(number % 100) : ""));

            if ((number >= 1000) && (number <= 999999))
                sb.Append(NumberToWord((int)(number / 1000.0)) + " thousand " + NumberToWord(number % 1000));

            return sb.ToString();
        }

        static void Main(string[] args)
        {
            /*
            Console.WriteLine(NumberToWord(15));
            Console.WriteLine(NumberToWord(63));
            Console.WriteLine(NumberToWord(305));
            Console.WriteLine(NumberToWord(115));
            Console.WriteLine(NumberToWord(467));
            Console.WriteLine(NumberToWord(203));
            Console.WriteLine(NumberToWord(342));
            Console.WriteLine(NumberToWord(1203));
            Console.WriteLine(NumberToWord(5219));
            Console.WriteLine(NumberToWord(135219));
             */
            StringBuilder sb = new StringBuilder();

            for (int i = 1; i <= 1000; i++)
            {
                sb.Append(NumberToWord(i));
            }
            Console.WriteLine(sb.Replace(" ", "").Length);
            Console.ReadKey();
        }
    }
}
