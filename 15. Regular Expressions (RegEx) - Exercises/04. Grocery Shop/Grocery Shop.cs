namespace _04.Grocery_Shop
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    class Program
    {
        static void Main()
        {
            var pattern = @"^(?<product>[A-Z][a-z]+):(?<price>\d+\.\d{2})$";
            var inputLine = Console.ReadLine();
            var inventory = new Dictionary<string, decimal>();

            while (inputLine != "bill")
            {
                var matches = Regex.Matches(inputLine, pattern);

                foreach (Match product in matches)
                {
                    var productName = product.Groups["product"].Value;
                    var productPrice = decimal.Parse(product.Groups["price"].Value);

                    if (!inventory.ContainsKey(productName))
                    {
                        inventory[productName] = 0;
                    }

                    inventory[productName] = productPrice;
                }

                inputLine = Console.ReadLine();
            }

            inventory = inventory.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);

            foreach (var item in inventory)
            {
                Console.WriteLine($"{item.Key} costs {item.Value:F2}");
            }
        }
    }
}
