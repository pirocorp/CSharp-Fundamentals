using System;
using System.Linq;

namespace _11.Multiply_an_Array_of_Doubles
{
    class Program
    {
        static void Main()
        {
            char[] delimeterList = { ' ' };
            double[] arrayOfDoubles = Console.ReadLine()
                .Split(delimeterList, StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToArray();

            var p = double.Parse(Console.ReadLine());
            for (int i = 0; i < arrayOfDoubles.Length; i++)
            {
                arrayOfDoubles[i] *= p;
            }

            for (int i = 0; i < arrayOfDoubles.Length; i++)
            {
                Console.Write(arrayOfDoubles[i] + " ");
            }

            Console.WriteLine();
        }
    }
}
