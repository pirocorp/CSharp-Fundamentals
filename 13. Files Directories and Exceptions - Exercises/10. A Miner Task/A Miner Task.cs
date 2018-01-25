using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10.A_Miner_Task
{
    class Program
    {
        static void Main()
        {
            var resources = new Dictionary<string, long>();
            var allLines = File.ReadAllLines("Input.txt");

            for (int i = 0; i < allLines.Length; i += 2)
            {
                var resource = allLines[i];

                if (resource == "stop")
                {
                    break;
                }

                var inputLine = allLines[i + 1];
                var quantity = 0;

                if (!int.TryParse(inputLine, out quantity))
                {
                    break;
                }

                if (!resources.ContainsKey(resource))
                {
                    resources[resource] = 0;
                }

                resources[resource] += quantity;
            }

            resources.ToList().ForEach(x => File.AppendAllLines("Output.txt", new []{ $"{x.Key} -> {x.Value}" }));
        }
    }
}
