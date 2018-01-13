using System;
using System.Linq;

namespace _03_Count_of_Given_Element_in_Array
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

            int x = int.Parse(Console.ReadLine());
            int count = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] == x) count++;
            }

            Console.WriteLine(count);
        }
    }
}
