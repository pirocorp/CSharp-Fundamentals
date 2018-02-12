namespace _08.Commits
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    class Commits
    {
        public static void Main()
        {
            var inputLine = Console.ReadLine();
            var pattern = @"^https:\/\/github\.com\/(?<user>[a-zA-Z0-9\-]+)\/(?<repo>[a-zA-Z\-_]+)\/commit\/(?<commit>[a-fA-F0-9]{40}\,.+?,\d+,\d+)$";
            var users = new SortedDictionary<string, SortedDictionary<string, List<Commit>>>(); //<user, <repo, commits>>

            while (inputLine != "git push")
            {
                var match = Regex.Match(inputLine, pattern);
                var user = match.Groups["user"].Value;
                var repo = match.Groups["repo"].Value;
                var commitString = match.Groups["commit"].Value;

                if (commitString == string.Empty)
                {
                    inputLine = Console.ReadLine();
                    continue;
                }

                var commit = Commit.Parse(commitString);

                if (!users.ContainsKey(user))
                {
                    users[user] = new SortedDictionary<string, List<Commit>>();
                }

                if (!users[user].ContainsKey(repo))
                {
                    users[user][repo] = new List<Commit>();
                }

                users[user][repo].Add(commit);
                inputLine = Console.ReadLine();
            }

            foreach (var user in users)
            {
                var username = user.Key;
                var repos = user.Value;
                Console.WriteLine($"{username}:");

                foreach (var repo in repos)
                {
                    var repoName = repo.Key;
                    var commits = repo.Value;
                    Console.WriteLine($"  {repoName}:");

                    foreach (var commit in commits)
                    {
                        var hash = commit.HashMessage;
                        var message = commit.Message;
                        var additionsCount = commit.Additions;
                        var deletionsCount = commit.Deletions;
                        Console.WriteLine($"    commit {hash}: {message} ({additionsCount} additions, {deletionsCount} deletions)");
                    }

                    var totalAdditionsCount = commits.Sum(x => x.Additions);
                    var totalDeletionsCount = commits.Sum(x => x.Deletions);
                    Console.WriteLine($"    Total: {totalAdditionsCount} additions, {totalDeletionsCount} deletions");
                }
            }
        }
    }
}
