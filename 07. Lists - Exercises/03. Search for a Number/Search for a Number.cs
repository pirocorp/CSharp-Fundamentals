using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Search_for_a_Number
{
    class Program
    {
        static void Main()
        {
            char[] delimeterList = { ' ' };
            var numbers = Console.ReadLine()
                .Split(delimeterList, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            var command = Console.ReadLine()
                .Split(delimeterList, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            List<int> sublist = numbers.GetRange(0, command[0]);

            while (command[1] > 0)
            {
                sublist.RemoveAt(command[1] -1);
                command[1]--;
            }

            if (sublist.Exists(x => x == command[2]))
            {
                Console.WriteLine("YES!");
            }
            else
            {
                Console.WriteLine("NO!");
            }
        }
    }
}
