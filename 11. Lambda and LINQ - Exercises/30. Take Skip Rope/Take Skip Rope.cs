using System;
using System.Collections.Generic;
using System.Linq;

namespace _30.Take_Skip_Rope
{
    class Program
    {
        static void Main()
        {
            var input = Console.ReadLine();

            var digits = input.Where(c => char.IsDigit(c)).Select(x => int.Parse(x.ToString())).ToList();
            var stringToDecode = new string(input.Where(c => !(char.IsDigit(c))).ToArray());
            var takeList = new List<int>();
            var skipList = new List<int>();

            for (int i = 0; i < digits.Count; i += 2)
            {
                takeList.Add(digits[i]);
                skipList.Add(digits[i + 1]);
            }

            var result = string.Empty;
            var skip =  0;
            var take = 0;

            for (int i = 0; i < takeList.Count; i++)
            {
                int currentSkip = skipList[i];
                take = takeList[i];
                result += new string (stringToDecode.Skip(skip).Take(take).ToArray());
                skip += currentSkip + take;
            }

            Console.WriteLine(result);
        }
    }
}
