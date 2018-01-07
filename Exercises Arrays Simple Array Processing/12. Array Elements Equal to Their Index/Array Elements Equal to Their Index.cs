using System;
using System.Linq;

namespace _12.Array_Elements_Equal_to_Their_Index
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

            string result = string.Empty;
            for (int i = 0; i < numbers.Length; i++)
            {
                if (i == numbers[i])
                    result += i + " ";
            }

            Console.WriteLine(result);
        }
    }
}
