using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Travel_Company
{
    class Program
    {
        static void Main()
        {
            var travelData = new Dictionary<string, Dictionary<string, int>>();
            var inputData = Console.ReadLine();

            while (inputData != "ready")
            {
                var tokens = inputData.Split(':');
                var city = tokens[0];
                var vehicalsCapacity = tokens[1].Split(',');

                if (!travelData.ContainsKey(city))
                {
                    travelData[city] = new Dictionary<string, int>();
                }

                for (int i = 0; i < vehicalsCapacity.Length; i++)
                {
                    var currentElement = vehicalsCapacity[i].Split('-');
                    var vehical = currentElement[0];
                    var capacity = int.Parse(currentElement[1]);

                    if (!travelData[city].ContainsKey(vehical))
                    {
                        travelData[city][vehical] = 0;
                    }

                    travelData[city][vehical] = capacity;
                }

                inputData = Console.ReadLine();
            }

            inputData = Console.ReadLine();

            while (inputData != "travel time!")
            {
                var tokens = inputData.Split(' ');
                var city = tokens[0];
                var turists = int.Parse(tokens[1]);
                var transportCapacities = GetTransportCapacity(travelData, city);
                if (turists <= transportCapacities)
                {
                    Console.WriteLine($"{city} -> all {turists} accommodated");
                }
                else
                {
                    Console.WriteLine($"{city} -> all except {turists - transportCapacities} accommodated");
                }

                inputData = Console.ReadLine();
            }
        }

        private static int GetTransportCapacity(Dictionary<string, Dictionary<string, int>> travelData, string city)
        {
            var sum = 0;

            foreach (var vehical in travelData[city])
            {
                sum += vehical.Value;
            }

            return sum;
        }
    }
}
