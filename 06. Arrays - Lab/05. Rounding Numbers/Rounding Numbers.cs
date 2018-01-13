using System;

namespace _05.Rounding_Numbers
{
    class Program
    {
        static void Main()
        {
            string values = Console.ReadLine();
            char[] delimeterList = { ' ' };
            string[] numberStrings = values.Split(delimeterList, StringSplitOptions.RemoveEmptyEntries);
            double[] numbers = new double[numberStrings.Length];

            for (int i = 0; i < numberStrings.Length; i++)
            {
                numbers[i] = double.Parse(numberStrings[i]);
            }

            for (int i = 0; i < numbers.Length; i++)
            {
                Console.WriteLine($"{numberStrings[i]} => {Math.Round(numbers[i], MidpointRounding.AwayFromZero)}");
            }

        }
    }
}
