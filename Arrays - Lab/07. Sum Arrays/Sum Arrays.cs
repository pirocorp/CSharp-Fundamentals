using System;
using System.Linq;

namespace _07.Sum_Arrays
{
    class Program
    {
        static void Main()
        {
            // Input and processing Data
            string consoleLine = Console.ReadLine();
            char[] delimeterList = {' '};
            string[] elements = consoleLine.Split(delimeterList, StringSplitOptions.RemoveEmptyEntries);
            int[] arrayOfNumbers1 = elements.Select(int.Parse).ToArray();
            consoleLine = Console.ReadLine();
            elements = consoleLine.Split(delimeterList, StringSplitOptions.RemoveEmptyEntries);
            int[] arrayOfNumbers2 = elements.Select(int.Parse).ToArray();

            //Calculations
            int[] sumOfArrays = SumArrays(arrayOfNumbers1, arrayOfNumbers2);

            //Output
            for (int i = 0; i < sumOfArrays.Length; i++)
            {
                Console.Write($"{sumOfArrays[i]} ");
            }

            Console.WriteLine();
        }

        private static int[] SumArrays(int[] arrayOfNumbers1, int[] arrayOfNumbers2)
        {
            if (arrayOfNumbers2.Length > arrayOfNumbers1.Length)
            {
                int[] arraySwap = arrayOfNumbers1;
                arrayOfNumbers1 = arrayOfNumbers2;
                arrayOfNumbers2 = arraySwap;
            }

            int[] sumOfArrays = new int[arrayOfNumbers1.Length];

            for (int i = 0; i < sumOfArrays.Length; i++)
            {
                sumOfArrays[i] = arrayOfNumbers1[i] + arrayOfNumbers2[i % arrayOfNumbers2.Length];
            }

            return sumOfArrays;
        }
    }
}
