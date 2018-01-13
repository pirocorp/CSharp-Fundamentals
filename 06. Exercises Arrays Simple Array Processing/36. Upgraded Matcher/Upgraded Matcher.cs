using System;
using System.Linq;

namespace _36.Upgraded_Matcher
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

            string[] product = Console.ReadLine()
                .Split(delimeterList, StringSplitOptions.RemoveEmptyEntries);

            while (product[0] != "done")
            {
                long index = Array.IndexOf(names, product[0]);
                long currentQuantaty = long.Parse(product[1]);

                if (index >= quantities.Length || index < 0)
                {
                    Console.WriteLine($"We do not have enough {product[0]}");
                }
                else
                {
                    if (quantities[index] < currentQuantaty)
                    {
                        Console.WriteLine($"We do not have enough {product[0]}");
                    }
                    else
                    {
                        quantities[index] -= currentQuantaty;
                        decimal price = currentQuantaty * prices[index];
                        Console.WriteLine($"{product[0]} x {currentQuantaty} costs {price:f2}");
                    }
                }
                product = Console.ReadLine()
                    .Split(delimeterList, StringSplitOptions.RemoveEmptyEntries);
            }
        }
    }
}
