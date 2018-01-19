using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12.Ordered_Banking_System
{
    class Program
    {
        static void Main()
        {
            var banks = new Dictionary<string, Dictionary<string, decimal>>();
            var inputData = Console.ReadLine();

            while (inputData != "end")
            {
                var tokens = inputData.Split(new[] {" -> "}, StringSplitOptions.RemoveEmptyEntries);
                var bankName = tokens[0];
                var account = tokens[1];
                var balance = decimal.Parse(tokens[2]);

                if (!banks.ContainsKey(bankName))
                {
                    banks[bankName] = new Dictionary<string, decimal>();
                }

                if (!banks[bankName].ContainsKey(account))
                {
                    banks[bankName][account] = 0;
                }

                banks[bankName][account] += balance;
                inputData = Console.ReadLine();
            }

            banks = banks
                .OrderByDescending(x => x.Value.Values.Sum())
                .ThenByDescending(y => y.Value.Values.Max())
                .ToDictionary(x => x.Key, x => x.Value);

            banks
                .ToList()
                .ForEach(x => x.Value
                    .OrderByDescending(y => y.Value)
                    .ToList()
                    .ForEach(y => Console.WriteLine($"{y.Key} -> {y.Value} ({x.Key})")));
        }
    }
}
