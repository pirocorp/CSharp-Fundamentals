using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _16.A_Miner_Task
{
    class Program
    {
        static void Main()
        {
            var resources = new Dictionary<string, int>();

            while (true)
            {
                var resource = Console.ReadLine();
                if (resource == "stop")
                {
                    break;
                }

                var inputLine = Console.ReadLine();
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

            resources.ToList().ForEach(x=> Console.WriteLine($"{x.Key} -> {x.Value}"));
        }
    }
}
