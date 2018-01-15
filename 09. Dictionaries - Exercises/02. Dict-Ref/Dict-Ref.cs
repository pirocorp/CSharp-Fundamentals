using System;
using System.Collections.Generic;

namespace _02.Dict_Ref
{
    class Program
    {
        static void Main()
        {
            var input = Console.ReadLine();
            var result = new Dictionary<string, int>();

            while (input != "end")
            {
                var inputStrings = input.Split('=');
                var key = inputStrings[0].Trim();
                var valueString = inputStrings[1].Trim();
                var success = int.TryParse(valueString, out var value);

                if (success)
                {
                    result[key] = value;
                }
                else
                {
                    if (result.ContainsKey(valueString))
                    {
                    result[key] = result[valueString];
                    }
                }

                input = Console.ReadLine();
            }

            foreach (var value in result)
            {
                Console.WriteLine($"{value.Key} === {value.Value}");
            }
        }
    }
}
