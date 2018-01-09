using System;
using System.Linq;

namespace _29.Array_Statistics
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] delimeterList = { ' ' };
            int[] numbers = Console.ReadLine()
                .Split(delimeterList, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int minValue = numbers.Min();
            int maxValue = numbers.Max();
            int sum = numbers.Sum();
            double average = numbers.Average();

            Console.WriteLine($"Min = {minValue}");
            Console.WriteLine($"Max = {maxValue}");
            Console.WriteLine($"Sum = {sum}");
            Console.WriteLine($"Average = {average}");
        }
    }
}