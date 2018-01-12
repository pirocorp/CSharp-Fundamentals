using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.Remove_Elements_at_Odd_Positions
{
    class Program
    {
        static void Main()
        {
            char[] delimeterList = { ' ' };
            var inputStrings = Console.ReadLine()
                .Split(delimeterList, StringSplitOptions.RemoveEmptyEntries);

            var resultListOfStrings = new List<string>();

            for (int i = 0; i < inputStrings.Length; i++)
            {
                if (i % 2 == 1)
                {
                    resultListOfStrings.Add(inputStrings[i]);
                }
            }

            Console.WriteLine(String.Join(string.Empty, resultListOfStrings));
        }
    }
}
