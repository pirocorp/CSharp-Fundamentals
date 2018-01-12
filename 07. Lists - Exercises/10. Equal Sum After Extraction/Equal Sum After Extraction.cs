using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10.Equal_Sum_After_Extraction
{
    class Program
    {
        static void Main()
        {
            char[] delimeterList = { ' ' };
            var firstList = Console.ReadLine()
                .Split(delimeterList, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            var secondList = Console.ReadLine()
                .Split(delimeterList, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
            
            foreach (var currentElementFirstList in firstList)
            {
                secondList.Remove(currentElementFirstList);
            }

            var sumFirstList = firstList.Sum();
            var sumSecondList = secondList.Sum();

            if (sumFirstList == sumSecondList)
            {
                Console.WriteLine($"Yes. Sum: {sumFirstList}");
            }
            else
            {
                var difference = Math.Abs(sumFirstList - sumSecondList);
                Console.WriteLine($"No. Diff: {difference}");
            }
        }
    }
}
