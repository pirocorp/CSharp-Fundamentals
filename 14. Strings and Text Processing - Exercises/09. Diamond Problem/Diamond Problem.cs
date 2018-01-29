using System;
using System.Linq;

namespace _09.Diamond_Problem
{
    class Program
    {
        static void Main()
        {
            var inputString = Console.ReadLine();
            var currentIndex = -1;
            bool noDimond = true;

            while (currentIndex < inputString.Length)
            {
                currentIndex++;
                var startIndex = inputString.IndexOf("<", currentIndex);
                var endIndex = inputString.IndexOf(">", currentIndex);

                if (startIndex < endIndex && startIndex >= 0 && endIndex >= 0)
                {
                    var currentDimond = inputString.Substring(startIndex, endIndex - startIndex);
                    var dimondValue = GetValue(currentDimond);
                    noDimond = false;
                    Console.WriteLine($"Found {dimondValue} carat diamond");
                    currentIndex = endIndex + 1;
                }
            }

            if (noDimond)
            {
                Console.WriteLine("Better luck next time");
            }

        }

        private static object GetValue(string currentDimond)
        {
            var value = currentDimond.Where(x => Char.IsDigit(x)).Select(x => int.Parse(new string(x, 1))).Sum();
            return value;
        }
    }
}
