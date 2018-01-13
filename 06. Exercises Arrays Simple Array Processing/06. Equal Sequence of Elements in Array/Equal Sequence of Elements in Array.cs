using System;
using System.Linq;

namespace _06.Equal_Sequence_of_Elements_in_Array
{
    class Program
    {
        static void Main()
        {
            char[] delimeterList = {' '};
            int[] numbers = Console.ReadLine()
                .Split(delimeterList, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            bool isFromEqualElements = true;
            for (int i = 0; i < numbers.Length; i++)
            {
                for (int j = 0; j < numbers.Length; j++)
                {
                    if (numbers[i] != numbers[j])
                    {
                        isFromEqualElements = false;
                        break;
                    }
                }

            }

            if (isFromEqualElements)
            {
                Console.WriteLine("Yes");
            }
            else
            {
                Console.WriteLine("No");
            }
        }
    }
}
