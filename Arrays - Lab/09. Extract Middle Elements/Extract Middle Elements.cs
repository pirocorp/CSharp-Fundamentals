using System;
using System.Linq;

namespace _09.Extract_Middle_Elements
{
    class Program
    {
        static void Main()
        {
            //Input and Processing Data
            
            char[] delimeterList = {' '};
            int[] numbers = Console.ReadLine()
                .Split(delimeterList, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[] middleElements = ExtractMiddleElements(numbers);

            //string.Join

            string result = string.Join(", ", middleElements);
            Console.WriteLine("{ " + result + " }");
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
