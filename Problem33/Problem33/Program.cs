using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem33
{
    public class Fraction : IEquatable<Fraction>
    {
        public int Nominator { get; set; }
        public int Denominator { get; set; }

        public Fraction(int Nominator, int Denominator)
        {
            this.Nominator = Nominator;
            this.Denominator = Denominator;
        }

        public decimal Value()
        {
            if (this.Denominator != 0)
                return (decimal)this.Nominator / (decimal)this.Denominator;
            else
                return decimal.MaxValue;
        }

        public char? HasIdenticalDigit()
        {
            string nominator = this.Nominator.ToString();
            foreach (char c in nominator)
            {
                if (nominator.Where(s => s == c).Count() > 1)
                    continue;

                if (this.Denominator.ToString().Where(s => s == c).Count() == 1)
                    return c;
            }

            return null;
        }

        public Fraction RemoveDigit(char c)
        {
            return new Fraction(int.Parse(this.Nominator.ToString().Replace(c.ToString(), String.Empty)),
                int.Parse(this.Denominator.ToString().Replace(c.ToString(), String.Empty)));
        }

        public override string ToString()
        {
            return this.Nominator + "/" + this.Denominator;
        }

        public bool Equals(Fraction other)
        {
            return this.Value() == other.Value();
        }

        public bool IsValid()
        {
            return !((this.Denominator == this.Nominator) || (this.Denominator % 10 == 0) || (this.Nominator % 10 == 0));
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Fraction> fractions = new List<Fraction>();

            for (int n = 10; n < 100; n++)
            {
                for (int d = 10; d < 100; d++)
                {
                    Fraction f = new Fraction(n, d);

                    if (!f.IsValid())
                        continue;

                    char? c = f.HasIdenticalDigit();
                    if (c.HasValue)
                    {
                        Fraction newF = f.RemoveDigit(c.Value);
                        if (f.Equals(newF) && newF.Value() < 1)
                        {
                            Console.WriteLine(f);
                            fractions.Add(f);
                        }
                    }
                }
            }

            Console.WriteLine(fractions.Aggregate(1M, (product, f) => product *= f.Value()));

            Console.ReadKey();
        }
    }
}
