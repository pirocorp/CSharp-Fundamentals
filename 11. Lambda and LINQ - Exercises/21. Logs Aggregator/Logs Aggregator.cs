using System;
using System.Collections.Generic;
using System.Linq;

namespace _21.Logs_Aggregator
{
    class Program
    {
        static void Main()
        {
            var ipLogs = new Dictionary<string, Dictionary<string, int>>();
            var n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var tokens = Console.ReadLine().Split(' ');
                var user = tokens[1];
                var ip = tokens[0];
                var duration = int.Parse(tokens[2]);

                if (!ipLogs.ContainsKey(user))
                {
                    ipLogs[user] = new Dictionary<string, int>();
                }

                if (!ipLogs[user].ContainsKey(ip))
                {
                    ipLogs[user][ip] = 0;
                }

                ipLogs[user][ip] += duration;
            }

            ipLogs.OrderBy(x => x.Key).ToList().ForEach(x =>
            {
                Console.Write($"{x.Key}: {x.Value.Sum(s => s.Value)} [");
                x.Value.ToList().OrderBy(o => o.Key).Take(x.Value.Count - 1).ToList().ForEach(v => Console.Write($"{v.Key}, "));
                x.Value.ToList().OrderBy(o => o.Key).Skip(x.Value.Count - 1).ToList().ForEach(v => Console.Write($"{v.Key}]"));
                Console.WriteLine();
            });
        }
    }
}
