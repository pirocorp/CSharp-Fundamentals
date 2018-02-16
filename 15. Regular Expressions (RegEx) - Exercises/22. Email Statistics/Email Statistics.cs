namespace _22.Email_Statistics
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    class Program
    {
        static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var emails = new Dictionary<string, List<string>>(); //Domain, userList
            var pattern = @"^(?<username>[A-Za-z]{5,})@(?<domain>[a-z]{3,}(?:\.com|\.bg|\.org))$";
            var regex = new Regex(pattern);

            for (var i = 0; i < n; i++)
            {
                var inputLine = Console.ReadLine();

                if (regex.IsMatch(inputLine))
                {
                    var match = regex.Match(inputLine);
                    var domain = match.Groups["domain"].Value;
                    var username = match.Groups["username"].Value;

                    if (!emails.ContainsKey(domain))
                    {
                        emails[domain] = new List<string>();
                    }

                    if (!emails[domain].Contains(username))
                    {
                        emails[domain].Add(username);
                    }
                }
            }

            emails = emails.OrderByDescending(x => x.Value.Count).ToDictionary(x => x.Key, x => x.Value);

            foreach (var domain in emails)
            {
                var domainName = domain.Key;
                var lisOfUsers = domain.Value;
                Console.WriteLine($"{domainName}:");

                foreach (var user in lisOfUsers)
                {
                    Console.WriteLine($"### {user}");
                }
            }
        }
    }
}