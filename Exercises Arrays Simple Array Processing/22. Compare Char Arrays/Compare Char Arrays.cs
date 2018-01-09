using System;
using System.Linq;

namespace _22.Compare_Char_Arrays
{
    class Program
    {
        static void Main()
        {
            char[] array1 = Console.ReadLine()
                .Split(' ')
                .Select(char.Parse)
                .ToArray();

            char[] array2 = Console.ReadLine()
                .Split(' ')
                .Select(char.Parse)
                .ToArray();
            int minLength = Math.Min(array1.Length, array2.Length);
            bool allLetersEqual = true;
            for (int i = 0; i < minLength; i++)
            {
                if (array1[i] < array2[i])
                {
                    PrintArrays(array1, array2);
                    allLetersEqual = false;
                    return;
                }
                else if (array2[i] < array1[i])
                {
                    PrintArrays(array2, array1);
                    allLetersEqual = false;
                    return;
                }
            }

            if (array1.Length < array2.Length)
            {
                PrintArrays(array1, array2);
            }
            else
            {
                PrintArrays(array2, array1);
            }
        }

        private static void PrintArrays(char[] array2, char[] array1)
        {
            string string1 = new string(array2);
            string string2 = new string(array1);
            Console.WriteLine(string1);
            Console.WriteLine(string2);
        }
    }
}
