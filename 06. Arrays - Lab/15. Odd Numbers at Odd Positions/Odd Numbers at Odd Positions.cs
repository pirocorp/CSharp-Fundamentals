using System;
using System.Linq;

namespace _15.Odd_Numbers_at_Odd_Positions
{
    class Program
    {
        static void Main()
        {
            char[] delimeterList = {' '};
            var numbers = Console.ReadLine()
                .Split(delimeterList, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            for (int i = 0; i < numbers.Length; i++)
            {
                if (i % 2 == 1 && Math.Abs(numbers[i] % 2) == 1)
                {
                    Console.WriteLine($"Index {i} -> {numbers[i]}");
                }
            }
        }
    }
}
