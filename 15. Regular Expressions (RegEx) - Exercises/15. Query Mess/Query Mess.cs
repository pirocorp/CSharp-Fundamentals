using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _15.Query_Mess
{
    class Program
    {
        static void Main()
        {
            var inputData = Console.ReadLine().Split(new []{'?'}, StringSplitOptions.RemoveEmptyEntries);
            var convertWhiteSpacesRegex = new Regex(@"((%20)|\+)");
            var reduceWhiteSpaceRegex = new Regex(@"\s+");

            while (inputData[0] != "END")
            {
                var kvps = new List<string>();

                foreach (var input in inputData)
                {
                    var currentKvp = input.Split(new[] {'&'}, StringSplitOptions.RemoveEmptyEntries);
                    kvps.AddRange(currentKvp);
                }

                var result = new Dictionary<string, List<string>>();

                for (var i = 0; i < kvps.Count; i++)
                {
                    var currentKvp = kvps[i].Split(new[] {'='}, StringSplitOptions.RemoveEmptyEntries);

                    if (currentKvp.Length < 2)
                    {
                        continue;
                    }

                    var key = currentKvp[0];
                    key = convertWhiteSpacesRegex.Replace(key, " ");
                    key = reduceWhiteSpaceRegex.Replace(key, " ");
                    key = key.Trim();
                    var value = currentKvp[1];
                    value = convertWhiteSpacesRegex.Replace(value, " ");
                    value = reduceWhiteSpaceRegex.Replace(value, " ");
                    value = value.Trim();

                    if (!result.ContainsKey(key))
                    {
                        result[key] = new List<string>();
                    }

                    result[key].Add(value);
                }

                foreach (var item in result)
                {
                    var key = item.Key;
                    var values = item.Value;

                    Console.Write($"{key}=[{string.Join(", ", values)}]");
                }

                Console.WriteLine();

                inputData = Console.ReadLine().Split(new[] { '?' }, StringSplitOptions.RemoveEmptyEntries);
            }
        }
    }
}
