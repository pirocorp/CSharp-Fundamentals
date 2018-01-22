using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Websites
{
    class Websites
    {
        public class Website
        {
            public string Host { get; set; }
            public string Domain { get; set; }
            public List<string> Queries { get; set; }

            public static Website Parse(string inputData)
            {
                var tokens = inputData.Split(new[] { '|' }, StringSplitOptions.RemoveEmptyEntries).Select(x => x.Trim()).ToArray();
                var host = tokens[0];
                var domain = tokens[1];
                var queries = new List<string>();

                if (tokens.Length > 2)
                {
                    queries = tokens[2].Split(new []{ ',' }, StringSplitOptions.RemoveEmptyEntries).Select(x => x.Trim()).ToList();
                }

                var result = new Website()
                {
                    Host = host,
                    Domain = domain,
                    Queries = queries
                };

                return result;
            }
        }

        static void Main()
        {
            var inputData = Console.ReadLine();
            var websites = new List<Website>();

            while (inputData != "end")
            {
                websites.Add(Website.Parse(inputData));
                inputData = Console.ReadLine();
            }

            foreach (var website in websites)
            {
                if (website.Queries.Count > 0)
                {
                    var queries = website.Queries.Select(x => $"[{x}]").ToList();
                    Console.WriteLine($"https://www.{website.Host}.{website.Domain}/query?={String.Join("&", queries)}");
                }
                else
                {
                    Console.WriteLine($"https://www.{website.Host}.{website.Domain}");
                }
                
            }
        }
    }
}
