using System;
using System.Linq;

namespace _32.Grab_and_Go
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] delimeterList = { ' ' };
            long[] numbers = Console.ReadLine()
                .Split(delimeterList, StringSplitOptions.RemoveEmptyEntries)
                .Select(long.Parse)
                .ToArray();

            long lastOccurr = long.Parse(Console.ReadLine());
            int lastOccurIndex = Array.LastIndexOf(numbers, lastOccurr);
            if (lastOccurIndex > 0)
            {
                var newArray = numbers.Take(lastOccurIndex).ToArray();
                var sumOfElements = newArray.Sum();
                Console.WriteLine(sumOfElements);
            }
            else
            {
                Console.WriteLine("No occurrences were found!");
            }
        }
    }
}
