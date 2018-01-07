using System;

namespace _01.Largest_Element_in_Array
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int[] numbers = new int[n];

            int largest = int.MinValue;
            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = int.Parse(Console.ReadLine());
                if (largest < numbers[i])
                {
                    largest = numbers[i];
                }
            }

            Console.WriteLine(largest);
        }
    }
}
