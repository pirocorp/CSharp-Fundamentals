using System;

namespace Hotel
{
    class Hotel
    {
        static void Main()
        {
            var month = Console.ReadLine();
            var nights = int.Parse(Console.ReadLine());

            decimal[,] pricesPerNight = {{50, 65, 75}, {60, 72, 82}, {68, 77, 89}}; // [month,room]

            decimal discountStudio = 1;
            decimal discountDouble = 1;
            decimal discountSuite = 1;
            var studioNights = nights;

            if (nights > 14)
            {
                if (month == "June" || month == "September") discountDouble = 0.9m;
                else if (month == "July" || month == "August" || month == "December") discountSuite = 0.85m;
            }
            else if (nights > 7)
            {
                if (month == "May" || month == "October")
                {
                    discountStudio = 0.95m;
                    if (month == "October") studioNights--;
                }
                else if (month == "September") studioNights--;
            }

            int m = -1;

            if (month == "May" || month == "October")
            {
                m = 0;
            }
            else if (month == "June" || month == "September")
            {
                m = 1;
            }
            else if (month == "July" || month == "August" || month == "December")
            {
                m = 2;
            }

            var priceStudio = pricesPerNight[m, 0] * discountStudio * studioNights;
            var priceDouble = pricesPerNight[m, 1] * discountDouble * nights;
            var priceSuite = pricesPerNight[m, 2] * discountSuite * nights;

            Console.WriteLine($"Studio: {priceStudio:f2} lv.");
            Console.WriteLine($"Double: {priceDouble:f2} lv.");
            Console.WriteLine($"Suite: {priceSuite:f2} lv.");
        }
    }
}
