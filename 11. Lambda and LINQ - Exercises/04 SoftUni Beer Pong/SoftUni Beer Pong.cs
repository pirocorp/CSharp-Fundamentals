using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_SoftUni_Beer_Pong
{
    class Program
    {
        static void Main()
        {
            var teamPoints = new Dictionary<string, Dictionary<string, long>>(); //<TeamName<PlayerName, PointsMade>>
            var inputData = Console.ReadLine();

            while (inputData != "stop the game")
            {
                var tokens = inputData.Split('|').ToArray();
                var playerName = tokens[0];
                var teamName = tokens[1];
                var points = long.Parse(tokens[2]);

                if (!teamPoints.ContainsKey(teamName))
                {
                    teamPoints[teamName] = new Dictionary<string, long>();
                }

                if (teamPoints[teamName].Count < 3)
                {
                    teamPoints[teamName][playerName] = points;
                }
                
                inputData = Console.ReadLine();
            }
            
            teamPoints = teamPoints
                .Where(x => x.Value.Count == 3)
                .ToDictionary(x => x.Key, x => x.Value);
            var result = teamPoints
                .OrderByDescending(x => x.Value.Values.Sum())
                .ToDictionary(x => x.Key, x => x.Value);
            var count = 0;

            foreach (var team in result)
            {
                count++;
                var teamName = team.Key;
                var teamPlayersList = team.Value;
                teamPlayersList = teamPlayersList
                    .OrderByDescending(x => x.Value)
                    .ToDictionary(x => x.Key, x => x.Value);
                Console.WriteLine($"{count}. {teamName}; Players:");

                foreach (var player in teamPlayersList)
                {
                    var playerName = player.Key;
                    var playerScore = player.Value;
                    Console.WriteLine($"###{playerName}: {playerScore}");
                }
            }
        }
    }
}
