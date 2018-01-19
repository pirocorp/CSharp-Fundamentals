using System;
using System.Collections.Generic;
using System.Linq;

namespace _22.Legendary_Farming
{
    class Program
    {
        static void Main()
        {
            var inventory = new Dictionary<string, int>();
            inventory["shards"] = 0;
            inventory["fragments"] = 0;
            inventory["motes"] = 0;

            while (true)
            {
                var inputData = Console.ReadLine().ToLower().Split(' ');
                bool found = false;

                for (int i = 0; i < inputData.Length; i += 2)
                {
                    var quantity = int.Parse(inputData[i]);
                    var material = inputData[i + 1];

                    if (!inventory.ContainsKey(material))
                    {
                        inventory[material] = 0;
                    }

                    inventory[material] += quantity;

                    if (inventory["shards"] >= 250)
                    {
                        inventory["shards"] -= 250;
                        Console.WriteLine($"Shadowmourne obtained!");
                        found = true;
                        break;
                    }
                    else if (inventory["fragments"] >= 250)
                    {
                        inventory["fragments"] -= 250;
                        Console.WriteLine($"Valanyr obtained!");
                        found = true;
                        break;
                    }
                    else if (inventory["motes"] >= 250)
                    {
                        inventory["motes"] -= 250;
                        Console.WriteLine($"Dragonwrath obtained!");
                        found = true;
                        break;
                    }
                }

                if (found)
                {
                    break;
                }
            }

            var result = new Dictionary<string, int>();

            result["shards"] = inventory["shards"];
            inventory.Remove("shards");
            result["fragments"] = inventory["fragments"];
            inventory.Remove("fragments");
            result["motes"] = inventory["motes"];
            inventory.Remove("motes");

            result.OrderByDescending(x => x.Value).ThenBy(y => y.Key).ToList().ForEach(c => Console.WriteLine($"{c.Key}: {c.Value}"));
            inventory.OrderBy(x => x.Key).ToList().ForEach(c => Console.WriteLine($"{c.Key}: {c.Value}"));
        }
    }
}
