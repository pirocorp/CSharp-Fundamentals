using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace _19.User_Logs
{
    class Program
    {
        static void Main()
        {
            var logsData = new Dictionary<string, Dictionary<string, int>>(); //<username, <ip, count>
            var inputData = Console.ReadLine();

            while (inputData != "end")
            {
                var tokens = inputData.Split(' ');
                var ip = tokens[0].Split(new[] {"IP="}, StringSplitOptions.RemoveEmptyEntries).First();
                var user = tokens[2].Split(new[] {"user="}, StringSplitOptions.RemoveEmptyEntries).First();

                if (!logsData.ContainsKey(user))
                {
                    logsData[user] = new Dictionary<string, int>();
                }

                if (!logsData[user].ContainsKey(ip))
                {
                    logsData[user][ip] = 0;
                }

                logsData[user][ip]++;
                inputData = Console.ReadLine();
            }


            logsData.OrderBy(x => x.Key).ToList().ForEach(x =>
            {
                Console.WriteLine($"{x.Key}: ");
                x.Value
                    .ToList()
                    .Take(x.Value.Count - 1)
                    .ToList()
                    .ForEach(y => Console.Write($"{y.Key} => {y.Value}, "));
                x.Value
                    .ToList()
                    .Skip(x.Value.Count - 1)
                    .ToList()
                    .ForEach(z => Console.WriteLine($"{z.Key} => {z.Value}."));
            });
        }
    }
}
