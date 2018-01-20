using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace _01.Day_of_Week
{
    class Program
    {
        static void Main()
        {
            string dateAsText = Console.ReadLine();
            DateTime date = DateTime.ParseExact(
                dateAsText, "d-M-yyyy",
                CultureInfo.InvariantCulture);
            Console.WriteLine(date.DayOfWeek);

        }
    }
}
