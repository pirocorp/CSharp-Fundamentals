using System;
using System.Linq;

namespace _10.Sum_Array_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            var numberOfElements = int.Parse(Console.ReadLine());
            var array = new int[numberOfElements];

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = int.Parse(Console.ReadLine());
            }

            var sum = 0;
            for (int i = 0; i < array.Length; i++)
            {
                sum += array[i];
            }

            sum = array.Sum();
            Console.WriteLine(sum);

        }
    }
}
