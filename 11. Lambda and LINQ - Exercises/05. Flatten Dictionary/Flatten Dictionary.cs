using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Flatten_Dictionary
{
    class Program
    {
        static void Main()
        {
            var dict = new Dictionary <string, Dictionary <string, string>>();
            var result = new Dictionary<string, Dictionary<string, string>>();

            var inputData = Console.ReadLine();

            while (inputData != "end")
            {
                var tokens = inputData.Split(' ');
                if (tokens.Length == 2)
                {
                    var command = tokens[0];
                    var argument = tokens[1];

                    if (command == "flatten")
                    {
                        result = dict.Where(x => x.Key == argument).ToDictionary(x => x.Key, x => x.Value);
                        result[argument] = result[argument].ToDictionary(x => x.Key + x.Value, x => string.Empty);
                        dict.Remove(argument);
                        dict[argument] = result[argument];
                    }
                }
                else
                {
                    var key = tokens[0];
                    var innerKey = tokens[1];
                    var innerValue = tokens[2];

                    if (!dict.ContainsKey(key))
                    {
                        dict[key] = new Dictionary<string, string>();
                    }

                    if (!dict[key].ContainsKey(innerKey))
                    {
                        dict[key][innerKey] = innerValue;
                    }

                    dict[key][innerKey] = innerValue;
                }

                inputData = Console.ReadLine();
            }

            dict = dict.OrderByDescending(x => x.Key.Length).ToDictionary(x => x.Key, x => x.Value);

            foreach (var element in dict)
            {
                var key = element.Key;
                var innerDict = element.Value;
                Console.WriteLine(key);
                var innerDictOnlyNotEmptyValue = innerDict.Where(x => x.Value != string.Empty).OrderBy(x => x.Key.Length);
                var count = 0;

                foreach (var kvp in innerDictOnlyNotEmptyValue)
                {
                    count++;
                    var innerKey = kvp.Key;
                    var innerValue = kvp.Value;
                    Console.WriteLine($"{count}. {innerKey} - {innerValue}");
                }

                var innerDictOnlyEmptyValues = innerDict.Where(x => x.Value == string.Empty);

                foreach (var kvp in innerDictOnlyEmptyValues)
                {
                    count++;
                    var innerKey = kvp.Key;
                    Console.WriteLine($"{count}. {innerKey}");
                }
            }
        }
    }
}
