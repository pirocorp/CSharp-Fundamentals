namespace _06._P_rates
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var towns = new Dictionary<string, City>();

            string input;

            while ((input = Console.ReadLine()) != "Sail")
            {
                var tokens = input.Split("||", StringSplitOptions.RemoveEmptyEntries);

                var townName = tokens[0];
                var citizens = int.Parse(tokens[1]);
                var gold = int.Parse(tokens[2]);

                if (!towns.ContainsKey(townName))
                {
                    var city = new City()
                    {
                        Name = townName,
                        Citizens = citizens,
                        Gold = gold
                    };

                    towns.Add(city.Name, city);
                }
                else
                {
                    towns[townName].Citizens += citizens;
                    towns[townName].Gold += gold;
                }
            }

            while ((input = Console.ReadLine()) != "End")
            {
                var tokens = input.Split("=>");

                var command = tokens[0];
                var town = tokens[1];

                switch (command)
                {
                    case "Plunder":
                        Plunder(tokens, town, towns);

                        break;
                    case "Prosper":
                        Prosper(tokens, towns, town);
                        break;
                }
            }

            var orderedTowns = towns
                .Select(s => s.Value)
                .OrderByDescending(t => t.Gold)
                .ThenBy(t => t.Name)
                .ToList();

            Console.WriteLine($"Ahoy, Captain! There are {orderedTowns.Count} wealthy settlements to go to:");

            foreach (var town in orderedTowns)
            {
                Console.WriteLine($"{town.Name} -> Population: {town.Citizens} citizens, Gold: {town.Gold} kg");
            }

            if (orderedTowns.Count == 0)
            {
                Console.WriteLine($"Ahoy, Captain! All targets have been plundered and destroyed!");
            }
        }

        private static void Prosper(string[] tokens, Dictionary<string, City> towns, string town)
        {
            var gold = int.Parse(tokens[2]);

            if (gold < 0)
            {
                Console.WriteLine($"Gold added cannot be a negative number!");
                return;
            }

            var currentTown = towns[town];
            currentTown.Gold += gold;

            Console.WriteLine($"{gold} gold added to the city treasury. {town} now has {currentTown.Gold} gold.");
        }

        private static void Plunder(string[] tokens, string town, Dictionary<string, City> towns)
        {
            var people = int.Parse(tokens[2]);
            var gold = int.Parse(tokens[3]);

            Console.WriteLine($"{town} plundered! {gold} gold stolen, {people} citizens killed.");

            var currentTown = towns[town];
            currentTown.Gold -= gold;
            currentTown.Citizens -= people;

            if (currentTown.Gold <= 0 || currentTown.Citizens <= 0)
            {
                towns.Remove(currentTown.Name);
                Console.WriteLine($"{town} has been wiped off the map!");
            }
        }

        private class City
        {
            public string Name { get; set; }

            public int Citizens { get; set; }

            public int Gold { get; set; }
        }
    }
}
