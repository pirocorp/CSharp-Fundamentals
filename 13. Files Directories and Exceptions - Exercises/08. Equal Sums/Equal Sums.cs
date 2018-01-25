using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.Equal_Sums
{
    class Program
    {
        static void Main()
        {
            var inputLines = File.ReadAllLines("Input.txt");

            for (int i = 0; i < inputLines.Length; i++)
            {
                var currentOutput = new[] {String.Empty};

                var numbers = inputLines[i]
                    .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                var isFound = false;

                for (int j = 0; j < numbers.Length; j++)
                {
                    var leftSum = LeftSum(j, numbers);
                    var rightSum = RightSum(j, numbers);

                    if (leftSum == rightSum)
                    {
                        currentOutput[0] = j.ToString();
                        isFound = true;
                        break;
                    }
                }

                if (!isFound)
                {
                    currentOutput[0] = "no";
                }

                File.AppendAllLines("Output.txt", currentOutput);
            }
        }

        private static int RightSum(int position, int[] numbers)
        {
            var sum = 0;

            for (int i = numbers.Length - 1; i > position; i--)
            {
                sum += numbers[i];
            }

            return sum;
        }

        private static int LeftSum(int position, int[] numbers)
        {
            var sum = 0;

            for (var i = 0; i < position; i++)
            {
                sum += numbers[i];
            }

            return sum;
        }
    }
}
