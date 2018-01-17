using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Largest_3_Numbers
{
    class Program
    {
        static void Main()
        {
            string[] strings = Console.ReadLine().Split(' ');

            List<int> nums = strings
                .Select(int.Parse)
                .ToList();

            var sortedNums = nums.OrderByDescending(x => x);
            var largest3Nums = sortedNums.Take(3);

            Console.WriteLine(string.Join(" ", largest3Nums));

        }
    }
}
