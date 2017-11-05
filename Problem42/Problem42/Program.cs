using System;
using System.IO;
using System.Linq;

namespace Problem42
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            for (int i = 1; i <= 10; i++)
            {
                Console.WriteLine(GetTriangleNumber(i));
            }

            var rawWords = File.ReadAllText(@"p042_words.txt");
            var words = rawWords.Substring(1, rawWords.Length - 2).Split("\",\"");

            Console.WriteLine(words.First());
            Console.WriteLine(words.Last());

            Console.WriteLine(CalculateWordValue("SKY"));

            int numberOfTriangleWords = 0;

            Console.WriteLine("Triangle Words:");

            foreach (var word in words)
            {
                var isTriangleNumber = IsTriangleNumber(word);
                if (isTriangleNumber)
                {
                    Console.WriteLine($"{word} ({CalculateWordValue(word)})? {isTriangleNumber}");
                    numberOfTriangleWords++;
                }
            }

            Console.WriteLine($"Triangle words: {numberOfTriangleWords}");
            Console.ReadKey();
        }

        static bool IsTriangleNumber(string word)
        {
            int value = CalculateWordValue(word);

            /* Brute force:
             * Limit the maximum triangle value to the sqrt of the word value
             * 
            int maxTriangleValue = (int)Math.Sqrt(value * 2);
            for (int i = 1; i <= maxTriangleValue; i++)
            {
                if (value == GetTriangleNumber(i))
                {
                    return true;
                }
            }
            return false;
            */

            // Using the inverse function and completing the square, we can get the discriminant of the original quadratic function
            // If the result is an integer, it is a triangle number
            double possibleTriangleValue = (Math.Sqrt(1 + 8 * value) - 1.0) / 2.0;
            return (possibleTriangleValue == (int)possibleTriangleValue);
        }

        static int GetTriangleNumber(int i)
        {
            return (int)(0.5 * (i) * (i + 1));
        }

        static int CalculateWordValue(string word)
        {
            int value = 0;
            foreach (char c in word)
            {
                value += (int)c - 64;
            }
            return value;
        }
    }
}
