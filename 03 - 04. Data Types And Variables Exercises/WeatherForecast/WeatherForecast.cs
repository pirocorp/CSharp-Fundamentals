using System;

namespace WeatherForecast
{
    class WeatherForecast
    {
        static void Main()
        {
            var inputString = Console.ReadLine();

            try
            {
                long number = long.Parse(inputString);

                if (number >= sbyte.MinValue && number <= sbyte.MaxValue)
                {
                    Console.WriteLine("Sunny");
                }
                else if (number >= int.MinValue && number <= int.MaxValue)
                {
                    Console.WriteLine("Cloudy");
                }
                else if (number >= long.MinValue && number <= long.MaxValue)
                {
                    Console.WriteLine("Windy");
                }
            }
            catch
            {
                Console.WriteLine("Rainy");
            }
        }
    }
}
