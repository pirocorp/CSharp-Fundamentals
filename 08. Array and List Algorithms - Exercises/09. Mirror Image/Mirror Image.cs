using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.Mirror_Image
{
    class Program
    {
        static void Main()
        {
            char[] delimeterList = { ' ' };
            var listOfElements = Console.ReadLine()
                .Split(delimeterList, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            string command = Console.ReadLine();
            while (command != "Print")
            {
                var index = int.Parse(command);
                ReverseListOfElementsByN(index, listOfElements);
                command = Console.ReadLine();
            }

            Console.WriteLine(String.Join(" ", listOfElements));
        }

        private static void ReverseListOfElementsByN(int reverseDelimiter, List<string> listOfElements)
        {
            for (int i = 0; i < reverseDelimiter / 2; i++)
            {
                string swap = listOfElements[i];
                listOfElements[i] = listOfElements[reverseDelimiter - 1 - i];
                listOfElements[reverseDelimiter - 1 - i] = swap;
            }

            var midpoint = (listOfElements.Count - reverseDelimiter + 1) / 2;
            midpoint += reverseDelimiter;
            var count = 0;

            for (int i = reverseDelimiter + 1; i < midpoint; i++)
            {
                string swap = listOfElements[i];
                listOfElements[i] = listOfElements[listOfElements.Count - 1 - count];
                listOfElements[listOfElements.Count - 1 - count] = swap;
                count++;
            }
        }
    }
}
