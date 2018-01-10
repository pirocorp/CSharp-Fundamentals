using System;
using System.Linq;

namespace _01.Remove_Negatives_and_Reverse
{
    class Program
    {
        static void Main()
        {
            char[] delimeterList = {' '};
            var numbers = Console.ReadLine()
                .Split(delimeterList, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            numbers.RemoveAll(IsNegative);
            numbers.Reverse();
            if (numbers.Count == 0)
            {
                Console.WriteLine("empty");
            }
            else
            {
                Console.WriteLine(String.Join(" ", numbers));
            }
        }

        private static bool IsNegative(int number)
        {
            if (number < 0)
            {
                return true;
            }
            return false;
        }
    }
}
