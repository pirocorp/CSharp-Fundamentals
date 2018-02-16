using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Dragon_Army
{
    class Program
    {
        static void Main()
        {
            var dragons = new Dictionary<string, SortedDictionary<string, int[]>>(); // <Type, List of DragonData <Name Stats>
            int n = int.Parse(Console.ReadLine());
            
            for (int i = 0; i < n; i++)
            {
                var inputTokens = Console.ReadLine().Split(' ').ToArray();
                var type = inputTokens[0];
                var name = inputTokens[1];
                var dragonStatsStrings = inputTokens.Skip(2).Take(3).ToArray();
                int[] dragonStats = GetDragonStats(dragonStatsStrings);

                if (!dragons.ContainsKey(type))
                {
                    dragons[type] = new SortedDictionary<string, int[]>();
                }

                if (!dragons[type].ContainsKey(name))
                {
                    dragons[type][name] = new int[3];
                }

                dragons[type][name] = dragonStats;
            }

            foreach (var type in dragons)
            {
                var typeAverageDamage = 0.0;
                var typeAverageHealth = 0.0;
                var typeAverageArmor = 0.0;
                var typeList = type.Value;

                foreach (var dragon in typeList)
                {
                    typeAverageDamage += dragon.Value[0];
                    typeAverageHealth += dragon.Value[1];
                    typeAverageArmor += dragon.Value[2];
                }

                typeAverageDamage /= typeList.Count;
                typeAverageHealth /= typeList.Count;
                typeAverageArmor /= typeList.Count;
                var typeName = type.Key;

                Console.WriteLine($"{typeName}::({typeAverageDamage:f2}/{typeAverageHealth:f2}/{typeAverageArmor:f2})");

                foreach (var dragon in typeList)
                {
                    var dragonName = dragon.Key;
                    var dragonStats = dragon.Value;
                    var dragonDamage = dragonStats[0];
                    var dragonHealth = dragonStats[1];
                    var dragonArmor = dragonStats[2];

                    Console.WriteLine($"-{dragonName} -> damage: {dragonDamage}, health: {dragonHealth}, armor: {dragonArmor}");
                }
            }
        }

        private static int[] GetDragonStats(string[] dragonStatsStrings)
        {
            var dragonStatsResult = new int[3];
            int currentStat;

            if (int.TryParse(dragonStatsStrings[0], out currentStat))
            {
                dragonStatsResult[0] = currentStat;
            }
            else
            {
                dragonStatsResult[0] = 45;
            }

            if (int.TryParse(dragonStatsStrings[1], out currentStat))
            {
                dragonStatsResult[1] = currentStat;
            }
            else
            {
                dragonStatsResult[1] = 250;
            }

            if (int.TryParse(dragonStatsStrings[2], out currentStat))
            {
                dragonStatsResult[2] = currentStat;
            }
            else
            {
                dragonStatsResult[2] = 10;
            }

            return dragonStatsResult;
        }
    }
}
