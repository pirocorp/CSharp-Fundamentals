using System;
using System.Linq;

namespace _35.Inventory_Matcher
{
    class Program
    {
        static void Main()
        {
            char[] delimeterList = { ' ' };

            string[] names = Console.ReadLine()
                .Split(delimeterList, StringSplitOptions.RemoveEmptyEntries);

            long[] quantities = Console.ReadLine()
                .Split(delimeterList, StringSplitOptions.RemoveEmptyEntries)
                .Select(long.Parse)
                .ToArray();

            decimal[] prices = Console.ReadLine()
                .Split(delimeterList, StringSplitOptions.RemoveEmptyEntries)
                .Select(decimal.Parse)
                .ToArray();

            string product = Console.ReadLine();

            while (product != "done")
            {
                int index = Array.IndexOf(names, product);
                Console.WriteLine($"{product} costs: {prices[index]}; Available quantity: {quantities[index]}");
                product = Console.ReadLine();
            }
        }
    }
}
