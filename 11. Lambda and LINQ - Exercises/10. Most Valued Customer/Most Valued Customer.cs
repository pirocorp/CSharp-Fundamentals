using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.Most_Valued_Customer
{
    class Program
    {
        static void Main()
        {
            var inventory = new Dictionary<string, decimal>();
            var inputData = Console.ReadLine();

            while (inputData != "Shop is open")
            {
                var tokens = inputData.Split(' ');
                var product = tokens[0];
                var price = decimal.Parse(tokens[1]);

                if (!inventory.ContainsKey(product))
                {
                    inventory[product] = price;
                }

                inventory[product] = price;
                inputData = Console.ReadLine();
            }

            inputData = Console.ReadLine();
            var clients = new Dictionary<string, List<string>>();

            while (inputData != "Print")
            {
                var tokens = inputData.Split(new[] {": "}, StringSplitOptions.RemoveEmptyEntries);

                if (tokens.Length > 1)
                {
                    var clientName = tokens[0];
                    var productsBuyed = tokens[1].Split(new[] {", "}, StringSplitOptions.RemoveEmptyEntries).ToList();

                    if (!clients.ContainsKey(clientName))
                    {
                        clients[clientName] = new List<string>();
                    }

                    foreach (var product in productsBuyed)
                    {
                        if (inventory.ContainsKey(product))
                        {
                            clients[clientName].Add(product);
                        }
                    }
                }
                else
                {
                    var result = inventory
                        .OrderByDescending(x => x.Value)
                        .Take(3)
                        .ToDictionary(x => x.Key, x => x.Value * 0.9m);

                    inventory = result
                        .Concat(inventory.OrderByDescending(x => x.Value)
                        .Skip(3)).ToDictionary(x => x.Key, x => x.Value);
                }

                inputData = Console.ReadLine();
            }
            
            var max = clients.Max(x => x.Value.Sum(y => inventory[y]));
            var Biggest = clients
                .Where(x => x.Value.Sum(y => inventory[y]) == max)
                .First();
            var biggestSpender = Biggest.Key;

            Console.WriteLine($"Biggest spender: {biggestSpender}");
            Console.WriteLine("^Products bought:");
            clients[biggestSpender]
                .Distinct()
                .OrderByDescending(x => inventory[x])
                .ToList()
                .ForEach(x => Console.WriteLine($"^^^{x}: {inventory[x]:f2}"));
            Console.WriteLine($"Total: {max:f2}");
        }
    }
}
