namespace _18.Football_League
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    class Program
    {
        static void Main()
        {
            var key = Console.ReadLine();
            var inputLine = Console.ReadLine();
            var listOfTeams = new List<Team>();
            var splitRegex = new Regex(@"\s");

            while (inputLine != "final")
            {
                var tokens = splitRegex.Split(inputLine);
                ProcessLine(listOfTeams, key, tokens);


                inputLine = Console.ReadLine();
            }

            listOfTeams = listOfTeams.OrderByDescending(x => x.Score).ThenBy(x => x.Name).ToList();
            var topTeamByGoals = listOfTeams.OrderByDescending(x => x.Goals).ThenBy(x => x.Name).Take(3).ToList();
            Console.WriteLine("League standings:");

            for (var i = 0; i < listOfTeams.Count; i++)
            {
                var currentTeam = listOfTeams[i];
                var currentTeamPlace = i + 1;
                Console.WriteLine($"{currentTeamPlace}. {currentTeam.Name} {currentTeam.Score}");
            }

            Console.WriteLine("Top 3 scored goals:");

            for (var i = 0; i < topTeamByGoals.Count; i++)
            {
                var currentTeam = topTeamByGoals[i];
                Console.WriteLine($"- {currentTeam.Name} -> {currentTeam.Goals}");
            }
        }

        private static void ProcessLine(List<Team> listOfTeams, string key, string[] tokens)
        {
            var cryptedTeam1 = tokens[0];
            var cryptedTeam2 = tokens[1];
            var result = tokens[2].Split(new[] {':'}, StringSplitOptions.RemoveEmptyEntries);
            var decryptedTeam1 = DecryptTeam(key, cryptedTeam1);
            var decryptedTeam2 = DecryptTeam(key, cryptedTeam2);
            var goalsTeam1 = int.Parse(result[0]);
            var goalsTeam2 = int.Parse(result[1]);
            var scoreTeam1 = CalculateTeamPoints(goalsTeam1, goalsTeam2);
            var scoreTeam2 = CalculateTeamPoints(goalsTeam2, goalsTeam1);

            if (string.IsNullOrEmpty(decryptedTeam1) || string.IsNullOrEmpty(decryptedTeam2))
            {
                //throw new Exception("Team Name is string empty");
            }

            if (!listOfTeams.Any(x => x.Name == decryptedTeam1))
            {
                var newTeam = new Team(decryptedTeam1, 0, 0);
                listOfTeams.Add(newTeam);
            }

            if (!listOfTeams.Any(x => x.Name == decryptedTeam2))
            {
                var newTeam = new Team(decryptedTeam2, 0, 0);
                listOfTeams.Add(newTeam);
            }

            AddScoreAndGoalsToTeam(listOfTeams, decryptedTeam1, goalsTeam1, scoreTeam1);
            AddScoreAndGoalsToTeam(listOfTeams, decryptedTeam2, goalsTeam2, scoreTeam2);
        }

        private static void AddScoreAndGoalsToTeam(List<Team> listOfTeams, string teamName, int teamGoals, int teamScore)
        {
            var currentTeam = listOfTeams.First(x => x.Name == teamName);
            currentTeam.Goals += teamGoals;
            currentTeam.Score += teamScore;
        }

        private static int CalculateTeamPoints(int home, int away)
        {
            var result = 0;

            if (home == away)
            {
                result = 1;
            }
            else if (home > away)
            {
                result = 3;
            }
            else if (away > home)
            {
                result = 0;
            }

            return result;
        }

        private static string DecryptTeam(string key, string cryptedTeam)
        {
            var result = string.Empty;
            var indexFirstKey = cryptedTeam.IndexOf(key) + key.Length;
            var indexSecondKey = cryptedTeam.IndexOf(key, indexFirstKey);
            var count = indexSecondKey - indexFirstKey;

            if (count > 0)
            {
                result = cryptedTeam.Substring(indexFirstKey, count);
            }

            result = new string(result.ToUpper().Reverse().ToArray());
            return result;
        }
    }
}