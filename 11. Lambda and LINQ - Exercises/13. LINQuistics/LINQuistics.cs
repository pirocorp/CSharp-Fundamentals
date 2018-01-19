using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace _13.LINQuistics
{
    class LINQuistics
    {
        static void Main()
        {
            var methods = new Dictionary<string, List<string>>();
            var inputData = Console.ReadLine();

            while (inputData != "exit")
            {
                var tokens = inputData.Split(new[] {"().", ".", "()" }, StringSplitOptions.RemoveEmptyEntries).ToList();

                if (tokens.Count > 1)
                {
                    var collection = tokens[0];
                    tokens.RemoveAt(0);
                    var listOfMethods = tokens;

                    if (!methods.ContainsKey(collection))
                    {
                        methods[collection] = new List<string>();
                    }

                    methods[collection].AddRange(listOfMethods);
                    methods[collection] = methods[collection].Distinct().ToList();
                }
                else
                {
                    var parsed = 0;

                    if (int.TryParse(tokens[0], out parsed))
                    {
                        var result = methods
                            .OrderByDescending(x => x.Value.Count)
                            .First()
                            .Value
                            .OrderBy(x => x.Length)
                            .Take(parsed)
                            .ToList();

                        Console.WriteLine("* " + String.Join($"{Environment.NewLine}* ", result));
                    }
                    else
                    {
                        var collectionName = tokens[0];

                        if (methods.ContainsKey(collectionName))
                        {
                            var result = methods[collectionName]
                                .OrderByDescending(x => x.Length)
                                .ThenByDescending(x => x.Distinct().ToList().Count)
                                .ToList();
                            Console.WriteLine("* " + String.Join($"{Environment.NewLine}* ", result));
                        }
                    }
                }

                inputData = Console.ReadLine();
            }

            inputData = Console.ReadLine();
            var filters = inputData.Split(' ');
            var method = filters[0];
            var selection = filters[1];

            var resultedMethodsDict =
                methods.Where(x => x.Value.Contains(method)).ToDictionary(x => x.Key, x => x.Value);

            if (selection == "all")
            {
                resultedMethodsDict
                    .OrderByDescending(x => x.Value.Count)
                    .ThenByDescending(y => y.Value.Min(z => z.Length))
                    .ToList()
                    .ForEach(x =>
                    {
                        Console.WriteLine($"{x.Key}");
                        Console.WriteLine("* " + String.Join($"{Environment.NewLine}* ", x.Value.OrderByDescending(y => y.Length)));
                    });
            }
            else
            {
                resultedMethodsDict
                    .OrderByDescending(x => x.Value.Count)
                    .ToList()
                    .ForEach(x => Console.WriteLine($"{x.Key}"));
            }
        }
    }
}
