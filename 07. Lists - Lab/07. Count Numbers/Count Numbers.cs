using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.Count_Numbers
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

            numbers.Sort();
            int count = 1;
            for (int i = 0; i < numbers.Count-1; i++)
            {
                if (numbers[i] == numbers[i+1] && i < numbers.Count -1)
                {
                    count++;
                }
                else
                {
                    Console.WriteLine($"{numbers[i]} -> {count}");
                    count = 1;
                }
            }

            Console.WriteLine($"{numbers[numbers.Count - 1]} -> {count}");
        }
    }
}
