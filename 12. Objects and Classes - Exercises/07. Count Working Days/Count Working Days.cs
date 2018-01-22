using System;
using System.Globalization;

namespace _07.Count_Working_Days
{
    class Program
    {
        static void Main()
        {
            var format = "dd-MM-yyyy";
            var startDateString = Console.ReadLine();
            var endDateString = Console.ReadLine();
            var startDate = DateTime.ParseExact(startDateString, format, CultureInfo.InvariantCulture);
            var endDate = DateTime.ParseExact(endDateString, format, CultureInfo.InvariantCulture);



            var workingDaysCounter = 0;

            for (var i = startDate; i <= endDate; i = i.AddDays(1))
            {
                if (!IsHoliday(i))
                {
                    workingDaysCounter++;
                }
            }

            Console.WriteLine(workingDaysCounter);
        }

        public static bool IsHoliday(DateTime date)
        {
            if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday)
            {
                return true;
            }

            DateTime[] officialHolidays =
            {
                new DateTime(2016, 1, 1),
                new DateTime(2016, 3, 3),
                new DateTime(2016, 5, 1),
                new DateTime(2016, 5, 6),
                new DateTime(2016, 5, 24),
                new DateTime(2016, 9, 6),
                new DateTime(2016, 9, 22),
                new DateTime(2016, 11, 1),
                new DateTime(2016, 12, 24), 
                new DateTime(2016, 12, 25), 
                new DateTime(2016, 12, 26), 
            };

            var dateDay = date.Day;
            var dateMonth = date.Month;

            for (int i = 0; i < officialHolidays.Length; i++)
            {
                var currentHolidayDay = officialHolidays[i].Day;
                var currentHolidayMonth = officialHolidays[i].Month;

                if (dateDay == currentHolidayDay && dateMonth == currentHolidayMonth)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
