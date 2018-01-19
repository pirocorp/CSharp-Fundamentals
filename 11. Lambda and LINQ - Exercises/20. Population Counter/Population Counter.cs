using System;
using System.Collections.Generic;
using System.Linq;

namespace _20.Population_Counter
{
    class Program
    {
        static void Main()
        {
            var populationDict = new Dictionary<string, Dictionary<string, long>>();
            var inputData = Console.ReadLine();

            while (inputData != "report")
            {
                var tokens = inputData.Split('|');
                var country = tokens[1];
                var city = tokens[0];
                var population = long.Parse(tokens[2]);

                if (!populationDict.ContainsKey(country))
                {
                    populationDict[country] = new Dictionary<string, long>();
                }

                if (!populationDict[country].ContainsKey(city))
                {
                    populationDict[country][city] = population;
                }

                populationDict[country][city] = population;
                inputData = Console.ReadLine();
            }

            populationDict.OrderByDescending(x => x.Value.Sum(y => y.Value)).ToList().ForEach(x =>
            {
                Console.WriteLine($"{x.Key} (total population: {x.Value.Sum(y => y.Value)})");
                x.Value
                    .ToList()
                    .OrderByDescending(o => o.Value)
                    .ToList()
                    .ForEach(z => Console.WriteLine($"=>{z.Key}: {z.Value}"));
            });

        }
    }
}
