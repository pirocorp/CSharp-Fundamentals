using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Shellbound
{
    class Shellbound
    {
        static void Main()
        {
            var inputData = Console.ReadLine();
            var townsData = new Dictionary<string, HashSet<int>>();

            while (inputData != "Aggregate")
            {
                var tokens = inputData.Split(' ');
                var city = tokens[0];
                var shell = int.Parse(tokens[1]);

                if (!townsData.ContainsKey(city))
                {
                    townsData[city] = new HashSet<int>();
                }

                townsData[city].Add(shell);
                inputData = Console.ReadLine();
            }

            foreach (var town in townsData)
            {
                var townNam = town.Key;
                var sumOfAllShells = town.Value.Sum();
                var countOfShells = town.Value.Count;
                var giantShell = sumOfAllShells - (sumOfAllShells / countOfShells);
                Console.WriteLine($"{townNam} -> {String.Join(", ", town.Value)} ({giantShell})");
            }
        }
    }
}
