using System;
using System.Collections.Generic;


namespace _02.Cities_by_Continent_and_Country
{
    class Program
    {
        static void Main()
        {
            var townsInWorld = new Dictionary<string, Dictionary<string, List<string>>>();
            var n = int.Parse(Console.ReadLine());
            // <continent <country, town>>

            for (var i = 0; i < n; i++)
            {
                var tokens = Console.ReadLine().Split(' ');
                var continent = tokens[0];
                var country = tokens[1];
                var town = tokens[2];

                if (!townsInWorld.ContainsKey(continent))
                {
                    townsInWorld[continent] = new Dictionary<string, List<string>>();
                }

                if (!townsInWorld[continent].ContainsKey(country))
                {
                    townsInWorld[continent][country] = new List<string>();
                }

                townsInWorld[continent][country].Add(town);
            }

            foreach (var continent in townsInWorld)
            {
                var continentNam = continent.Key;
                var dictOfCountries = continent.Value;
                Console.WriteLine($"{continentNam}:");
                foreach (var country in dictOfCountries)
                {
                    var countryName = country.Key;
                    var listOfTowns = country.Value;
                    Console.WriteLine($"{countryName} -> {String.Join(", ", listOfTowns)}");
                }
            }
        }
    }
}
