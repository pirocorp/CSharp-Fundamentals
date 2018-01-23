using System;
using System.Collections.Generic;
using System.Linq;

namespace _15.Teamwork_Projects
{
    class Program
    {
        static void Main()
        {
            var teams = new List<Team>();
            var n = int.Parse(Console.ReadLine());

            //Team Creation Phaise
            for (var i = 0; i < n; i++)
            {
                var tokens = Console.ReadLine().Split(new[] {'-'}, StringSplitOptions.RemoveEmptyEntries);
                var creatorName = tokens[0];
                var teamName = tokens[1];
                AddNewTeam(teams, creatorName, teamName);
            }

            var inputData = Console.ReadLine();

            while (inputData != "end of assignment")
            {
                var tokens = inputData.Split(new[] {"->"}, StringSplitOptions.RemoveEmptyEntries);
                var user = tokens[0];
                var teamName = tokens[1];
                AddUserToTeam(teams, user, teamName);
                inputData = Console.ReadLine();
            }

            /*var confirmedTeams = */teams
                .OrderByDescending(x => x.TeamMembers.Count)
                .ThenBy(b => b.TeamName)
                .Where(c => c.TeamMembers.Count > 0)
                .ToList().ForEach(x =>
                {
                    Console.WriteLine($"{x.TeamName}");
                    Console.WriteLine($"- {x.Creator}");
                    x.TeamMembers.OrderBy(o => o).ToList().ForEach(p =>
                    {
                        Console.WriteLine($"-- {p}");
                    });
                });

            Console.WriteLine("Teams to disband:");
            teams.Where(x => x.TeamMembers.Count == 0).OrderBy(x => x.TeamName).ToList().ForEach(x =>
            {
                Console.WriteLine(x.TeamName);
            });


        }

        private static void AddUserToTeam(List<Team> teams, string user, string teamName)
        {
            if (!teams.Any(x => x.TeamName == teamName))
            {
                Console.WriteLine($"Team {teamName} does not exist!");
                return;
            }

            if (teams.Any(x => x.TeamMembers.Contains(user)))
            {
                Console.WriteLine($"Member {user} cannot join team {teamName}!");
                return;
            }

            if (teams.Any(x => x.Creator == user))
            {
                Console.WriteLine($"Member {user} cannot join team {teamName}!");
                return;
            }

            var currentTeam = teams.Where(x => x.TeamName == teamName).First();
            currentTeam.TeamMembers.Add(user);
        }

        private static void AddNewTeam(List<Team> teams, string creatorName, string teamName)
        {
            if (teams.Any(x => x.TeamName == teamName))
            {
                Console.WriteLine($"Team {teamName} was already created!");
                return;
            }

            if (teams.Any(x => x.Creator == creatorName))
            {
                Console.WriteLine($"{creatorName} cannot create another team!");
                return;
            }

            var newTeam = new Team()
            {
                TeamName = teamName,
                Creator = creatorName,
                TeamMembers = new List<string>()
            };

            teams.Add(newTeam);
            Console.WriteLine($"Team {teamName} has been created by {creatorName}!");
        }
    }
}
