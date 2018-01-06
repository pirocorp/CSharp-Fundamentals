﻿using System;

namespace _01.Day_of_Week
{
    class DayOfWeek
    {
        static void Main()
        {
            string[] days = {
                "Monday",
                "Tuesday",
                "Wednesday",
                "Thursday",
                "Friday",
                "Saturday",
                "Sunday"
            };

            int day = int.Parse(Console.ReadLine());

            if (day >= 1 && day <= 7)
                Console.WriteLine(days[day - 1]);
            else
                Console.WriteLine("Invalid day!");

        }
    }
}
