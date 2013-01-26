using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem19
{
    class Program
    {
        static void Main(string[] args)
        {
            int totalNumberOfSundays = 0;

            for (int year = 1901; year <= 2000; year++)
            {
                DayOfWeek firstDayOfYear = FindFirstDayOfYear(year);

                CheckDate(firstDayOfYear, 1, 1, year);

                if (firstDayOfYear == DayOfWeek.Sunday)
                    totalNumberOfSundays++;

                DayOfWeek lastDayOfMonth = firstDayOfYear - 1;

                for (int month = 2; month <= 12; month++)
                {
                    DayOfWeek firstDayOfMonth = (DayOfWeek)(((int)lastDayOfMonth + 1 + NumberOfDaysInMonth(month - 1, year)) % 7);
                    lastDayOfMonth = firstDayOfMonth - 1;

                    if (firstDayOfMonth == DayOfWeek.Sunday)
                        totalNumberOfSundays++;

                    CheckDate(firstDayOfMonth, 1, month, year);
                }
           }
            Console.WriteLine(totalNumberOfSundays);
            Console.ReadKey();
        }

        private static void CheckDate(DayOfWeek dw, int day, int month, int year)
        {
            DateTime dt = new DateTime(year, month, day);
            if (dt.DayOfWeek != dw)
                Console.WriteLine(dt.DayOfWeek + ", " + dw);
        }

        private static int NumberOfDaysInMonth(int month, int year)
        {
            if ((month == 4)||(month == 6)||(month == 9)||(month == 11))
                return 30;
            if (month == 2)
            {
                if ((year % 4 == 0) && ((year % 100 != 0) || (year % 400 == 0)))
                    return 29;
                else
                    return 28;
            }
            else
                return 31;
        }

        private static int NumberSundaysInJanuary(DayOfWeek firstDay)
        {
            return (int)(((((int)firstDay + 1.0) % 7.0) + 31.0) / 7.0);
        }

        private static DayOfWeek FindFirstDayOfYear(int year)
        {
            if (year == 1900)
                return DayOfWeek.Monday;

            int startingDay = 1; // Monday for 1900
            int diff = year - 1900; // Number of years
            int numberOfLeapYears = (int)Math.Floor((diff - 1) / 4.0); // Number of leap years to add

            return (DayOfWeek)((startingDay + diff + numberOfLeapYears) % 7);
        }
    }
}
