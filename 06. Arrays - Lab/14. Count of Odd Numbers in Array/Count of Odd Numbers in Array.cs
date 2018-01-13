using System;
using System.Linq;

namespace _14.Count_of_Odd_Numbers_in_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] delimeterList = {' '};
            int[] numbers = Console.ReadLine()
                    .Split(delimeterList, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
            int count = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                if (Math.Abs(numbers[i] % 2) == 1)
                {
                    count++;
                }
            }

            Console.WriteLine(count);
        }
    }
}
