using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _23.Max_Sequence_of_Equal_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] delimeterList = { ' ' };
            int[] numbers = Console.ReadLine()
                .Split(delimeterList, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int lenth = 1;
            int position = 0;
            int bestLenth = 1;
            int bestPosition = 0;

            for (int i = 1; i < numbers.Length; i++)
            {
                if (numbers[i - 1] < numbers[i])
                {
                    lenth++;
                }
                else
                {
                    position = i;
                    lenth = 1;
                }

                if (lenth > bestLenth)
                {
                    bestLenth = lenth;
                    bestPosition = position;

                }
            }

            for (int i = bestPosition; i < bestPosition + bestLenth; i++)
            {
                Console.Write(numbers[i] + " ");
            }

            Console.WriteLine();
        }
    }
}
