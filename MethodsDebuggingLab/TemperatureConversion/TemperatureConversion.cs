using System;

namespace TemperatureConversion
{
    class TemperatureConversion
    {
        static void Main()
        {
            //Console.Write("Temperature in Fahrenheit: ");
            double fahrenheit = double.Parse(Console.ReadLine());
            double celsius = FahrenheitToCelsius(fahrenheit);
            //Console.Write("Temperature in Celsius: {0:F2}", celsius);
            Console.WriteLine($"{celsius:f2}");
        }

        static double FahrenheitToCelsius(double degrees)
        {
            double celsius = (degrees - 32) * 5 / 9;
            return celsius;
        }
    }
}
