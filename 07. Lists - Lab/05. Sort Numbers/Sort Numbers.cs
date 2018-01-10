using System;
using System.Linq;

namespace _05.Sort_Numbers
{
    class Program
    {
        static void Main()
        {
            char[] delimeterList = { ' ' };
            var numbers = Console.ReadLine()
                .Split(delimeterList, StringSplitOptions.RemoveEmptyEntries)
                .Select(decimal.Parse)
                .ToList();

            numbers.Sort();

            Console.WriteLine($"{String.Join(" <= ", numbers)}");
        }
    }
}
