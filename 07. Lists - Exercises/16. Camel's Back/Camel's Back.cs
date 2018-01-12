using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _16.Camel_s_Back
{
    class Program
    {
        static void Main()
        {
            char[] delimeterList = { ' ' };
            var listOfIntegers = Console.ReadLine()
                .Split(delimeterList, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            int camelbackSize = int.Parse(Console.ReadLine());
            int breakingDown = listOfIntegers.Count - camelbackSize;

            if (breakingDown == 0)
            {
                Console.WriteLine($"already stable: {String.Join(" ", listOfIntegers)}");
                return;
            }

            int rounds = breakingDown / 2;
            for (int i = 0; i < rounds; i++)
            {
                listOfIntegers.RemoveAt(0);
                listOfIntegers.RemoveAt(listOfIntegers.Count - 1);
            }

            Console.WriteLine($"{rounds} rounds");
            Console.WriteLine($"remaining: {String.Join(" ", listOfIntegers)}");
        }
    }
}
