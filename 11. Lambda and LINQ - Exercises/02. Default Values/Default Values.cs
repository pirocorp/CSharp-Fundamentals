using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace _02.Default_Values
{
    class Program
    {
        static void Main()
        {
            var dict = new Dictionary<string, string>();

            var inputData = Console.ReadLine();

            while (inputData != "end")
            {
                var tokens = inputData.Split(new []{" -> "}, StringSplitOptions.RemoveEmptyEntries).ToArray();
                var key = tokens[0];
                var value = tokens[1];
                dict[key] = value;
                inputData = Console.ReadLine();
            }

            inputData = Console.ReadLine();

            var notNullElements = dict.Where(x => x.Value != "null")
                .OrderByDescending(x => x.Value.Length)
                .ToDictionary(x => x.Key, x => x.Value);

            foreach (var element in notNullElements)
            {
                var key = element.Key;
                var value = element.Value;
                Console.WriteLine($"{key} <-> {value}");
            }

            dict = dict.Where(x => x.Value == "null")
                .OrderByDescending(x => x.Value.Length)
                .ToDictionary(x => x.Key, x => x.Value);

            var nullElements = dict.Select(x => x.Value == "null" ? new KeyValuePair<string, string>(x.Key, inputData) : new KeyValuePair<string, string>(x.Key, x.Value)).ToList();

            foreach (var element in nullElements)
            {
                var key = element.Key;
                var value = element.Value;

                Console.WriteLine($"{key} <-> {value}");
            }
        }
    }
}
