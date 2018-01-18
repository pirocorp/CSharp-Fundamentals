using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.CottageScraper
{
    class CottageScraper
    {
        static void Main()
        {
            var trees = new Dictionary<string, List<long>>();
            var inputData = Console.ReadLine();

            while (inputData != "chop chop")
            {
                var tokens = inputData.Split(new[] {" -> "}, StringSplitOptions.RemoveEmptyEntries);
                var logsType = tokens[0];
                var lenght = long.Parse(tokens[1]);

                if (!trees.ContainsKey(logsType))
                {
                    trees[logsType] = new List<long>();
                }

                trees[logsType].Add(lenght);
                inputData = Console.ReadLine();
            }

            var neededTreeType = Console.ReadLine();
            var neededHeightType = long.Parse(Console.ReadLine());

            var pricePerMeter = Math.Round((trees.Sum(x => x.Value.Sum()) / (double)trees.Sum(x => x.Value.Count)), 2);
            var usedLogs = trees[neededTreeType].Where(x => x >= neededHeightType).ToList();
            var unUsedLogsOfNeededTreeType = trees[neededTreeType].Where(x => x < neededHeightType).ToList().Sum();
            var usedLogsPrice = Math.Round((usedLogs.Sum() * pricePerMeter), 2);
            var unUsedLogs = trees.Where(x => x.Key != neededTreeType).ToDictionary(x => x.Key, x => x.Value.Sum());
            unUsedLogs[neededTreeType] = unUsedLogsOfNeededTreeType;
            var unUsedLogsSum = unUsedLogs.Sum(x => x.Value);
            var unUsedLogsPrice = Math.Round((unUsedLogsSum * pricePerMeter * 0.25), 2);
            var totalPrice = unUsedLogsPrice + usedLogsPrice;

            Console.WriteLine($"Price per meter: ${pricePerMeter:f2}");
            Console.WriteLine($"Used logs price: ${usedLogsPrice:f2}");
            Console.WriteLine($"Unused logs price: ${unUsedLogsPrice:f2}");
            Console.WriteLine($"CottageScraper subtotal: ${totalPrice:f2}");
        }
    }
}
