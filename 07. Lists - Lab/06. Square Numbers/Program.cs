using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.Square_Numbers
{
    class Program
    {
        static void Main()
        {
            char[] delimeterList = { ' ' };
            var numbers = Console.ReadLine()
                .Split(delimeterList, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            var result = new List<int>();

            for (int i = 0; i < numbers.Count; i++)
            {
                if (Math.Sqrt(numbers[i]) == (int) Math.Sqrt(numbers[i]))
                {
                    result.Add(numbers[i]);
                }
            }

            result.Sort();
            result.Reverse();
            Console.WriteLine(String.Join(" ", result));
        }
    }
}
