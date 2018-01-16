using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Group_Continents__Countries_and_Cities
{
    class Program
    {
        static void Main()
        {
            var townsInWorld = new SortedDictionary<string, SortedDictionary<string, SortedSet<string>>>();
            var n = int.Parse(Console.ReadLine());
            //<continent <country, town>>
            for (int i = 0; i < n; i++)
            {
                var tokens = Console.ReadLine().Split(' ');
                var continent = tokens[0];
                var country = tokens[1];
                var town = tokens[2];

                if (! townsInWorld.ContainsKey(continent))
                {
                    townsInWorld[continent] = new SortedDictionary<string, SortedSet<string>>();
                }

                if (! townsInWorld[continent].ContainsKey(country))
                {
                    townsInWorld[continent][country] = new SortedSet<string>();
                }

                townsInWorld[continent][country].Add(town);
            }

            foreach (var continent in townsInWorld)
            {
                var continentName = continent.Key;
                var countryDict = continent.Value;
                Console.WriteLine($"{continentName}:");

                foreach (var country in countryDict)
                {
                    var countryName = country.Key;
                    var townSortedSet = country.Value;
                    Console.WriteLine($"{countryName} -> {String.Join(", ", townSortedSet)}");
                }
            }
        }
    }
}
