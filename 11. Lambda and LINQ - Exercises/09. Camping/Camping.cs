using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.Camping
{
    class Camping
    {
        static void Main()
        {
            var campers = new Dictionary<string, Dictionary<string, int>>();
            var inputData = Console.ReadLine();

            while (inputData != "end")
            {
                var tokens = inputData.Split(' ').ToArray();
                var nameOfThePerson = tokens[0];
                var camperModel = tokens[1];
                var timeToStay = int.Parse(tokens[2]);

                if (!campers.ContainsKey(nameOfThePerson))
                {
                    campers[nameOfThePerson] = new Dictionary<string, int>();
                }

                if (!campers[nameOfThePerson].ContainsKey(camperModel))
                {
                    campers[nameOfThePerson][camperModel] = 0;
                }

                campers[nameOfThePerson][camperModel] += timeToStay;

                inputData = Console.ReadLine();
            }

            campers = campers.OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key.Length).ToDictionary(x => x.Key, x => x.Value);

            foreach (var person in campers)
            {
                var personName = person.Key;
                var rvDays = person.Value;
                var rvCount = rvDays.Count;
                Console.WriteLine($"{personName}: {rvCount}");

                foreach (var rv in rvDays)
                {
                    var rvName = rv.Key;
                    Console.WriteLine($"***{rvName}");
                }

                var days = rvDays.Sum(x => x.Value);
                Console.WriteLine("Total stay: {0} nights", days);
            }
        }
    }
}
