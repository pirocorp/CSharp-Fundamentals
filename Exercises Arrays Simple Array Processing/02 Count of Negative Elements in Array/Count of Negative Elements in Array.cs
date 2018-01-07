using System;

namespace _01.Largest_Element_in_Array
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int[] numbers = new int[n];
            
            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = int.Parse(Console.ReadLine());
            }

            int count = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] < 0) count++;
            }

            Console.WriteLine(count);
        }
    }
}
