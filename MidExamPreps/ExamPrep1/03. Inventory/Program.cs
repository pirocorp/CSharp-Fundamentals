namespace _03._Inventory
{
    using System;
    using System.Linq;

    public static class Program
    {
        public static void Main()
        {
            var inventory = Console.ReadLine()
                .Split(", ")
                .ToList();

            string input;

            while ((input = Console.ReadLine()) != "Craft!")
            {
                var tokens = input.Split(" - ", StringSplitOptions.RemoveEmptyEntries);
                var command = tokens[0];

                switch (command)
                {
                    case "Collect":
                        var item = tokens[1];
                        if (!inventory.Contains(item))
                        {
                            inventory.Add(item);
                        }
                        break;
                    case "Drop":
                        item = tokens[1];
                        inventory.Remove(item);
                        break;
                    case "Combine Items":
                        var combo = tokens[1].Split(":", StringSplitOptions.RemoveEmptyEntries);
                        var oldItem = combo[0];
                        var newItem = combo[1];
                        var index = inventory.IndexOf(oldItem);
                        if (index >= 0)
                        {
                            inventory.Insert(index + 1, newItem);
                        }
                        break;
                    case "Renew":
                        item = tokens[1];
                        var success = inventory.Remove(item);
                        if (success)
                        {
                            inventory.Add(item);
                        }
                        break;
                }
            }

            Console.WriteLine(string.Join(", ", inventory));
        }
    }
}
