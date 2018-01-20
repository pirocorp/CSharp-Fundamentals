using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _27.Supermarket_Database
{
    class Program
    {
        static void Main()
        {
            var inputData = Console.ReadLine();
            var inventory = new Dictionary<string, decimal[]>();

            while (inputData != "stocked")
            {
                var tokens = inputData.Split(new []{ ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var item = tokens[0];
                var price = decimal.Parse(tokens[1]);
                var quantaty = int.Parse(tokens[2]);

                if (!inventory.ContainsKey(item))
                {
                    inventory[item] = new decimal [] {0, 0};
                }

                inventory[item][0] = price;
                inventory[item][1] += quantaty;
                inputData = Console.ReadLine();
            }

            foreach (var item in inventory)
            {
                var itemName = item.Key;
                var itemPrice = item.Value[0];
                var itemQuantaty = item.Value[1];
                var total = itemPrice * itemQuantaty;
                Console.WriteLine($"{itemName}: ${itemPrice:f2} * {itemQuantaty} = ${total:f2}");
            }

            Console.WriteLine(new string('-', 30));
            var grandTotal = inventory.Sum(x => x.Value[0] * x.Value[1]);
            Console.WriteLine($"Grand Total: ${grandTotal:F2}");
        }
    }
}
