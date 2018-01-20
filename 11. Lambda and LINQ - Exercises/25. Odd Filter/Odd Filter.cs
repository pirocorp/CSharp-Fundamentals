using System;
using System.Linq;

namespace _25.Odd_Filter
{
    class Program
    {
        static void Main()
        {
            var numbers = Console.ReadLine()
                .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .Where(x => x % 2 == 0)
                .ToList();

            var average = numbers.Average();
            numbers = numbers.Select(x => x <= average ? x - 1 : x + 1).ToList();
            Console.WriteLine(String.Join(" ", numbers));
        }
    }
}
