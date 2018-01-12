using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _17.Ununion_Lists
{
    class Program
    {
        static void Main()
        {
            char[] delimeterList = { ' ' };
            var primalList = Console.ReadLine()
                .Split(delimeterList, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            var n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var integersList = Console.ReadLine()
                    .Split(delimeterList, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToList();
                
                for (int j = 0; j < integersList.Count; j++)
                {
                    var currentItemOfIntegersList = integersList[j];
                    if (primalList.Contains(currentItemOfIntegersList))
                    {
                        primalList.RemoveAll(x => x == currentItemOfIntegersList);
                    }
                    else
                    {
                        primalList.Add(currentItemOfIntegersList);
                    }
                }
            }

            primalList.Sort();
            Console.WriteLine(String.Join(" ", primalList));
        }
    }
}
