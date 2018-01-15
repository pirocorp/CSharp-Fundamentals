using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Exam_Shopping
{
    class Program
    {
        static void Main()
        {

            var input = Console.ReadLine();
            var inventory = new Dictionary<string, int>();
            while (input != "shopping time")
            {
                var inputStrings = input.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
                //var command = inputStrings[0];
                var key = inputStrings[1];
                var value = int.Parse(inputStrings[2]);

                if (!inventory.ContainsKey(key))
                {
                    inventory.Add(key, 0);
                }

                inventory[key] += value;
                input = Console.ReadLine();
            }

            input = Console.ReadLine();

            while (input != "exam time")
            {
                var inputStrings = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                //var command = inputStrings[0];
                var product = inputStrings[1];
                var value = int.Parse(inputStrings[2]);

                if (!inventory.ContainsKey(product))
                {
                    Console.WriteLine($"{product} doesn't exist");
                    input = Console.ReadLine();
                    continue;
                }

                if (inventory[product] == 0)
                {
                    Console.WriteLine($"{product} out of stock");
                    input = Console.ReadLine();
                    continue;
                }

                var result = inventory[product] - value;
                inventory[product] = Math.Max(result, 0);
                input = Console.ReadLine();
            }

            foreach (var product in inventory)
            {
                if (product.Value > 0)
                {
                    Console.WriteLine($"{product.Key} -> {product.Value}");
                }
            }
        }
    }
}
