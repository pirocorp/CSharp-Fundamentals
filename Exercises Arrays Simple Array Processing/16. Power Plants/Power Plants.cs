using System;
using System.Linq;

namespace _16.Power_Plants
{
    class Program
    {
        static void Main()
        {
            char[] delimeterList = {' '};
            int[] plantsPowerLevel = Console.ReadLine()
                .Split(delimeterList, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int days = 0;

            while (true)
            {
                days += AllDaysInSeason(plantsPowerLevel);
                
                if (IfAllDeath(plantsPowerLevel))
                {
                    break;
                }

                EndOfSeason(plantsPowerLevel);
            }

            int seasons = days / plantsPowerLevel.Length;

            if (days % plantsPowerLevel.Length == 0)
            {
                seasons--;
            }

            var seasonString = SeasonString(seasons);
            Console.WriteLine($"survived {days} days ({seasons} {seasonString})");
        }

        private static int AllDaysInSeason(int[] plantsPowerLevel)
        {
            int days = -1;
            for (int dayInSeason = 0; dayInSeason < plantsPowerLevel.Length; dayInSeason++)
            {
                days++;
                for (int plant = 0; plant < plantsPowerLevel.Length; plant++)
                {
                    if (plant != dayInSeason) plantsPowerLevel[plant]--;
                }

                if (IfAllDeath(plantsPowerLevel)) return days + 1;
            }

            return days + 1;
        }

        private static bool IfAllDeath(int[] plantsPowerLevel)
        {
            bool isAllDeath = true;
            for (int i = 0; i < plantsPowerLevel.Length; i++)
            {
                if (plantsPowerLevel[i] > 0)
                {
                    isAllDeath = false;
                    return isAllDeath;
                }
            }

            return isAllDeath;
        }

        private static void EndOfSeason(int[] plantsPowerLevel)
        {
            for (int plant = 0; plant < plantsPowerLevel.Length; plant++)
            {
                if (plantsPowerLevel[plant] > 0) plantsPowerLevel[plant]++;
            }
        }
        
        private static string SeasonString(int seasons)
        {
            string seasonString = String.Empty;

            if (seasons == 1)
            {
                seasonString = "season";
            }
            else
            {
                seasonString = "seasons";
            }

            return seasonString;
        }
    }
}
