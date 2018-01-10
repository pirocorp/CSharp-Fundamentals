using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Sum_Adjacent_Equal_Numbers
{
    class Program
    {
        static void Main()
        {
            char[] delimeterList = { ' ' };
            var numbers = Console.ReadLine()
                .Split(delimeterList, StringSplitOptions.RemoveEmptyEntries)
                .Select(decimal.Parse)
                .ToList();

            while (true)
            {
                int indexOfFirstNumber = GetAdjacentIndex(numbers);
                if (indexOfFirstNumber > -1)
                {
                    numbers.RemoveAt(indexOfFirstNumber + 1);
                    numbers[indexOfFirstNumber] += numbers[indexOfFirstNumber];
                }
                else
                {
                    break;
                }
            }

            Console.WriteLine(String.Join(" ", numbers));
        }

        private static int GetAdjacentIndex(List<decimal> numbers)
        {
            for (int i = 0; i < numbers.Count -1; i++)
            {
                if (numbers[i] == numbers[i + 1])
                {
                    return i;
                }
            }

            return -1;
        }
    }
}
