using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.Array_Data
{
    class Program
    {
        static void Main()
        {
            var numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            var command = Console.ReadLine();

            numbers = numbers.Where(x => x >= numbers.Average()).ToList();

            switch (command)
            {
                case "Min":
                    Console.WriteLine($"{numbers.Min()}");
                    break;
                case "Max":
                    Console.WriteLine($"{numbers.Max()}");
                    break;
                case "All":
                    Console.WriteLine($"{String.Join(" ", numbers.OrderBy(x => x))}");
                    break;
            }
        }
    }
}
