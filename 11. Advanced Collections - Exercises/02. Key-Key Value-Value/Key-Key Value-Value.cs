using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Key_Key_Value_Value
{
    class Program
    {
        static void Main()
        {
            var globalKey = Console.ReadLine();
            var globalValue = Console.ReadLine();
            var n = int.Parse(Console.ReadLine());
            var dict = new Dictionary<string, List<string>>();

            for (int i = 0; i < n; i++)
            {
                var tokens = Console.ReadLine().Split(new[] {" => "}, StringSplitOptions.RemoveEmptyEntries);
                var key = tokens[0];
                var listOfStrings = tokens[1].Split(';');

                if (!dict.ContainsKey(key))
                {
                    dict[key] = new List<string>();
                }

                dict[key].AddRange(listOfStrings);
            }

            foreach (var shit in dict)
            {
                var key = shit.Key;
                var listOfStrings = shit.Value;
                if (key.Contains(globalKey))
                {
                    Console.WriteLine($"{key}:");
                    for (int i = 0; i < listOfStrings.Count; i++)
                    {
                        var currentString = listOfStrings[i];
                        if (currentString.Contains(globalValue))
                        {
                            Console.WriteLine($"-{currentString}");
                        }
                    }
                }
            }
        }
    }
}
