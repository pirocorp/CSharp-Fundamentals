using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _19.Winecraft
{
    class Winecraft
    {
        static void Main()
        {
            char[] delimeterList = { ' ' };
            var elements = Console.ReadLine()
                .Split(delimeterList, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            int growthDays = int.Parse(Console.ReadLine());
            var elementsMap = new int[elements.Count];

            while (elements.Count >= growthDays)
            {
                for (int i = 0; i < growthDays; i++)
                {
                    elementsMap = MapElements(elements);
                    CalculateResultElements(elements, elementsMap);
                }

                RemoveAllElements(elements, growthDays);
            }

            Console.WriteLine(String.Join(" ", elements));

        }

        private static void RemoveAllElements(List<int> elements, int growthDays)
        {
            for (int i = 0; i < elements.Count; i++)
            {
                if (elements[i] <= growthDays)
                {
                    elements.RemoveAt(i);
                    i--;
                }
            }
        }

        private static void CalculateResultElements(List<int> elements, int[] elementsMap)
        {
            for (int i = 0; i < elements.Count; i++)
            {
                if (elementsMap[i] == 1)
                {
                    elements[i] += 1;
                    if (elements[i - 1] > 0)
                    {
                        elements[i - 1] -= 1;
                        elements[i] += 1;
                    }

                    if (elements[i + 1] > 0)
                    {
                        elements[i + 1] -= 1;
                        elements[i] += 1;
                    }
                }
                else if (elementsMap[i] == 0)
                {
                    elements[i]++;
                }
            }
        }

        private static int[] MapElements(List<int> elements)
        {
            var elementsMap = new int [elements.Count];
            for (int i = 0; i < elements.Count; i++)
            {
                bool leftElementExist = i - 1 >= 0;
                bool rightElementExist = i + 1 < elements.Count;

                if (leftElementExist && rightElementExist && elements[i - 1] < elements[i] &&
                    elements[i + 1] < elements[i])
                {
                    elementsMap[i - 1] = -1;
                    elementsMap[i] = 1;
                    elementsMap[i + 1] = -1;
                }

            }

            return elementsMap;
        }
    }
}
