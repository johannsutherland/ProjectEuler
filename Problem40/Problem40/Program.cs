using System;
using System.Linq;

namespace Problem40
{
    class Program
    {
        static void Main(string[] args)
        {
            SequenceGeneration sg = new SequenceGeneration();

            Console.WriteLine(sg.GetDigit(1)
                * sg.GetDigit(10)
                * sg.GetDigit(100)
                * sg.GetDigit(1000)
                * sg.GetDigit(10000)
                * sg.GetDigit(100000)
                * sg.GetDigit(1000000));

            Console.ReadKey();
        }
    }

    class SequenceGeneration
    {
        char[] number;
        int maximumSize;

        public SequenceGeneration(int maximumSize = 1000000)
        {
            this.maximumSize = maximumSize;
            number = new char[this.maximumSize + 1];
            GenerateNumber();
        }

        private void GenerateNumber()
        {
            int counter = 1;
            int pos = 1;

            while (true)
            {
                char[] str = counter.ToString().ToArray();

                if (pos + str.Length > maximumSize)
                {
                    Array.Copy(str, 0, number, pos, maximumSize + 1 - pos);
                    break;
                }

                Array.Copy(str, 0, number, pos, str.Length);
                counter++;
                pos += str.Length;
            }
        }

        public int GetDigit(int pos)
        {
            return int.Parse(number[pos].ToString());
        }
    }
}
