namespace _05.Points_Counter
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            var inputData = Console.ReadLine();
            var teams = new List<Team>();

            while (inputData != "Result")
            {
                var tokens = inputData.Split(new[] {"|"}, StringSplitOptions.RemoveEmptyEntries);
                tokens = FilterProhibitedSymbols(tokens);
                tokens = OrderTokens(tokens); //Order By Team Player Points
                var teamName = tokens[0];
                var playerName = tokens[1];
                var points = int.Parse(tokens[2]);
                var currentPlayer = new Player(playerName, points);
                var currentPlayerList = new List<Player>();
                currentPlayerList.Add(currentPlayer);
                var currentTeam = new Team(teamName, currentPlayerList);

                if (!teams.Any(x => x.TeamName == teamName))
                {
                    teams.Add(currentTeam);
                }
                else
                {
                    currentTeam = teams.Where(x => x.TeamName == teamName).First();

                    if (!currentTeam.Players.Any(x => x.PlayerName == currentPlayer.PlayerName))
                    {
                        currentTeam.Players.Add(currentPlayer);
                    }
                    else
                    {
                        var thisPlayer = currentTeam.Players.Where(x => x.PlayerName == currentPlayer.PlayerName).First();
                        thisPlayer.Points = currentPlayer.Points;
                    }
                }

                inputData = Console.ReadLine();
            }

            teams = teams.OrderByDescending(x => x.Players.Sum(z => z.Points)).ToList();

            foreach (var team in teams)
            {
                var totalSumOfPoints = team.Players.Sum(x => x.Points);
                var firstPlayer = team.Players.OrderByDescending(x => x.Points).First();
                Console.WriteLine($"{team.TeamName} => {totalSumOfPoints}");
                Console.WriteLine($"Most points scored by {firstPlayer.PlayerName}");
            }
        }

        private static string[] OrderTokens(string[] tokens)
        {
            if (tokens[0].All(x => Char.IsUpper(x)))
            {
                return tokens;
            }
            else
            {
                var swap = tokens[0];
                tokens[0] = tokens[1];
                tokens[1] = swap;
                return tokens;
            }
        }

        private static string[] FilterProhibitedSymbols(string[] tokens)
        {
            var prohibitedSymbols = new[] {"@", "%", "$", "*"};

            for (int i = 0; i < tokens.Length; i++)
            {
                for (int j = 0; j < prohibitedSymbols.Length; j++)
                {
                    tokens[i] = tokens[i].Replace(prohibitedSymbols[j], string.Empty);
                }
            }

            return tokens;
        }
    }
}
