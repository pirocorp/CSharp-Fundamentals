using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Append_Lists
{
    class Program
    {
        static void Main()
        {
            var input = Console.ReadLine()
                .Split(new[] { '|' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => x.Trim())
                .ToArray();

            var result = new List<int>();

            Array.Reverse(input);

            foreach (var token in input)
            {
                var numbers = token
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(x => x.Trim())
                    .Select(int.Parse)
                    .ToArray();

                foreach (var item in numbers)
                {
                    result.Add(item);
                }
            }

            Console.WriteLine(string.Join(" ", result));
        }
    }
}
