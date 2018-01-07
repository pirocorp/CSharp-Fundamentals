using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.Extract_Middle_Elements
{
    class Program
    {
        static void Main()
        {
            //Input and Processing Data
            string consoleLine = Console.ReadLine();
            char[] delimeterList = {' '};
            string[] inputStrings = consoleLine.Split(delimeterList, StringSplitOptions.RemoveEmptyEntries);
            int[] numbers = inputStrings.Select(int.Parse).ToArray();

            int[] middleElements = ExtractMiddleElements(numbers);

            Console.Write("{");
            Console.Write(" {0},", middleElements[0]);
            for (int i = 1; i < middleElements.Length; i++)
            {
                Console.Write($" {middleElements[i]},");
            }

            Console.WriteLine("\b }");
        }

        private static int[] ExtractMiddleElements(int[] numbers)
        {
            int[] middleElements;
            int n = numbers.Length / 2;
            if (numbers.Length == 1)
            {
                middleElements = new [ ] {numbers[0]};
            }
            else if (numbers.Length % 2 == 0)
            {
                
                middleElements = new [] {numbers[n - 1], numbers[n]};
            }
            else
            {
                middleElements = new [] {numbers[n - 1], numbers[n], numbers[n + 1]};
            }
            return middleElements;
        }
    }
}
