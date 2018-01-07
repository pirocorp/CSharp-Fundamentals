using System;
using System.Linq;

namespace _15.Char_Rotation
{
    class Program
    {
        static void Main()
        {
            char[] delimeterList = {' '};
            string inputString = Console.ReadLine();
            int[] numbers = Console.ReadLine()
                .Split(delimeterList, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            char[] result = new char[inputString.Length];
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] % 2 == 0)
                {
                    result[i] = (char)(inputString[i] - numbers[i]);
                }
                else
                {
                    result[i] = (char)(inputString[i] + numbers[i]);
                }
            }

            for (int i = 0; i < result.Length; i++)
            {
                Console.Write(result[i]);
            }

            Console.WriteLine();
        }
    }
}
