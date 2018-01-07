using System;
using System.Linq;

namespace _06.Reverse_Array_of_Strings
{
    class Program
    {
        static void Main()
        {
            string consoleLine = Console.ReadLine();
            char[] delimeterList = {' '};
            string[] inputStrings = consoleLine.Split(delimeterList, StringSplitOptions.RemoveEmptyEntries);
            string[] reverseStrings = new string[inputStrings.Length];

            for (int i = 0; i < inputStrings.Length; i++)
            {
                reverseStrings[inputStrings.Length - i - 1] = inputStrings[i];
            }

            for (int i = 0; i < reverseStrings.Length; i++)
            {
                Console.Write(reverseStrings[i] + " ");
            }

            Console.WriteLine();

            var reverse = inputStrings.Reverse();

            for (int i = 0; i < reverse.Count(); i++)
            {
                Console.Write(reverse.ElementAt(i) + " ");
            }

            Console.WriteLine();

            for (int i = 0; i < inputStrings.Length / 2; i++)
            {
                var x = inputStrings[i];
                inputStrings[i] = inputStrings[inputStrings.Length - 1 - i];
                inputStrings[inputStrings.Length - 1 - i] = x;
            }

            for (int i = 0; i < inputStrings.Length; i++)
            {
                Console.Write(inputStrings[i] + " ");
            }

            Console.WriteLine();
        }
    }
}
