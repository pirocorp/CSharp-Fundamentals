using System;
using System.Linq;

namespace _12.Smallest_Element_in_Array
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

            if (numbers.Length <= 0)
            {
                return;
            }

            var smallest = numbers[0];
            for (int i = 1; i < numbers.Length; i++)
            {
                if (numbers[i] < smallest)
                {
                    smallest = numbers[i];
                }

            }

            Console.WriteLine(smallest);

        }
    }
}
