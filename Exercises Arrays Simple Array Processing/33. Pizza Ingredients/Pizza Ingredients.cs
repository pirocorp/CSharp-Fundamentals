using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _33.Pizza_Ingredients
{
    class Program
    {
        static void Main()
        {
            char[] delimeterList = { ' ' };
            string[] array = Console.ReadLine()
                .Split(delimeterList, StringSplitOptions.RemoveEmptyEntries);

            int length = int.Parse(Console.ReadLine());
            int ingridiants = 0;
            string stringResult = string.Empty;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i].Length == length)
                {
                    Console.WriteLine($"Adding {array[i]}.");
                    ingridiants++;
                    stringResult += array[i] + " ";
                    if (ingridiants == 10)
                    {
                        break;
                    }
                }
            }

            string[] result = stringResult.Split(delimeterList, StringSplitOptions.RemoveEmptyEntries);
            string resultedString = String.Join(", ", result);
            Console.WriteLine($"Made pizza with total of {ingridiants} ingredients.");
            Console.WriteLine($"The ingredients are: {resultedString}.");
        }
    }
}
