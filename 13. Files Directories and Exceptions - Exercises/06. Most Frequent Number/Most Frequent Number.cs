using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.Most_Frequent_Number
{
    class Program
    {
        static void Main()
        {
            var allLines = File.ReadAllLines("Input.txt");

            for (var i = 0; i < allLines.Length ; i++)
            {
                var bestNumber = new [] { $"{BestNumber(allLines[i])}" };
                File.AppendAllLines("Output.txt", bestNumber);
            }
        }

        private static int BestNumber(string inputData)
        {
            var numbers = inputData
                .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            var bestNumber = numbers[0];
            var bestCount = 1;
            for (var i = 0; i < numbers.Length; i++)
            {
                int count = 0;
                for (var j = 0; j < numbers.Length; j++)
                {
                    if (numbers[i] == numbers[j])
                    {
                        count++;
                    }
                }

                if (count > bestCount)
                {
                    bestCount = count;
                    bestNumber = numbers[i];
                }
            }

            return bestNumber;
        }
    }
}
