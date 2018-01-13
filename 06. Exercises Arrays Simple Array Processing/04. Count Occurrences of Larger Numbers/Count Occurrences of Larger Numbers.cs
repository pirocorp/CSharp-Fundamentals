using System;
using System.Linq;

namespace _04.Count_Occurrences_of_Larger_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] delimeterList = {' '};
            double[] numbers = Console.ReadLine()
                .Split(delimeterList, StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToArray();

            double p = double.Parse(Console.ReadLine());

            int count = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] > p) count++;
            }

            Console.WriteLine(count);
        }
    }
}
