using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Dict_Ref_Advanced
{
    class Program
    {
        static void Main()
        {
            var inputData = Console.ReadLine();
            var personsData = new Dictionary<string, List<int>>();

            while (inputData != "end")
            {
                var tokens = inputData.Split(new[] {" -> "}, StringSplitOptions.RemoveEmptyEntries);
                var key = tokens[0];
                var valuesStrings = tokens[1].Split(new[] {", "}, StringSplitOptions.RemoveEmptyEntries);
                var values = new List<int>();

                if (valuesStrings.Length == 1)
                {
                    int value = 0;
                    if (int.TryParse(valuesStrings[0], out value))
                    {
                        values.Add(value);
                    }
                    else
                    {
                        var element = valuesStrings[0];
                        if (personsData.ContainsKey(element))
                        {
                            if (!personsData.ContainsKey(key))
                            {
                                personsData[key] = new List<int>();
                            }
                            personsData[key].AddRange(personsData[element]);
                        }

                        inputData = Console.ReadLine();
                        continue;
                    }
                }
                else
                {
                    values = valuesStrings.Select(int.Parse).ToList();
                }

                if (!personsData.ContainsKey(key))
                {
                    personsData[key] = new List<int>();
                }

                personsData[key].AddRange(values);
                inputData = Console.ReadLine();
            }

            foreach (var person in personsData)
            {
                var personName = person.Key;
                var personDataList = person.Value;

                Console.WriteLine($"{personName} === {String.Join(", ", personDataList)}");
            }
        }
    }
}
