namespace _11.Camera_View
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    class Program
    {
        static void Main()
        {
            var nums = Console.ReadLine().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
            var skip = int.Parse(nums[0]);
            var take = int.Parse(nums[1]);
            var inputString = Console.ReadLine();
            var tokens = Regex.Split(inputString, @"\|<");

            if (tokens.Length <= 1)
            {
                //Console.WriteLine("Nothing found");
                return;
            }

            var results = new List<string>();

            for (var i = 1; i < tokens.Length; i++)
            {
                if (tokens[i].Length > 0)
                {
                    var result = new string(tokens[i].Skip(skip).Take(take).ToArray());
                    results.Add(result);
                }
            }

            results = results.Where(x => x.Length != 0).ToList();
            if (results.Count > 0)
            {
                Console.WriteLine(string.Join(", ", results));
            }
        }
    }
}
