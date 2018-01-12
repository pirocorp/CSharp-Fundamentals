using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13.Stuck_Zipper
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] delimeterList = { ' ' };
            var listOne = Console.ReadLine()
                .Split(delimeterList, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
            var listTwo = Console.ReadLine()
                .Split(delimeterList, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            int minDigitsOfListOne = MinDigits(listOne);
            int minDigitsOfListTwo = MinDigits(listTwo);
            int minDigits = Math.Min(minDigitsOfListOne, minDigitsOfListTwo);

            RemoveNumbersWithMoreDigits(listOne, minDigits);
            RemoveNumbersWithMoreDigits(listTwo, minDigits);

            var resultList = ZipLists(listOne, listTwo);

            Console.WriteLine(String.Join(" ", resultList));
        }

        private static List<int> ZipLists(List<int> listOne, List<int> listTwo)
        {
            var resultList = new List<int>();
            int resultListParameters = listOne.Count + listTwo.Count;
            int listOneIndex = 0;
            int listTwoIndex = 0;
            bool listOneIsShorter = false;
            bool listTwoIsShorter = false;

            for (int i = 0; i < resultListParameters; i++)
            {
                if (i % 2 == 0)
                {
                    if (listTwoIndex < listTwo.Count)
                    {
                        resultList.Add(listTwo[listTwoIndex]);
                        listTwoIndex++;
                    }
                    else
                    {
                        listTwoIsShorter = true;
                        break;
                    }
                }
                else
                {
                    if (listOneIndex < listOne.Count)
                    {
                        resultList.Add(listOne[listOneIndex]);
                        listOneIndex++;
                    }
                    else
                    {
                        listOneIsShorter = true;
                        break;
                    }

                }
            }

            if (listOneIsShorter && !listTwoIsShorter)
            {
                int countLeft = listTwo.Count - listOne.Count;

                for (int i = 1; i < countLeft; i++)
                {
                    resultList.Add(listTwo[listTwoIndex]);
                    listTwoIndex++;
                }
            }
            else if (listTwoIsShorter && !listOneIsShorter)
            {
                int countLeft = listOne.Count - listTwo.Count;

                for (int i = 0; i < countLeft; i++)
                {
                    resultList.Add(listOne[listOneIndex]);
                    listOneIndex++;
                }
            }

            return resultList;
        }

        private static void RemoveNumbersWithMoreDigits(List<int> list, int digits)
        {
            for (int i = 0; i < list.Count; i++)
            {
                int currentElement = list[i];
                double limitOfElementsPositiveSide = Math.Pow(10, digits);
                double limitOfElementsNegativeSide = -limitOfElementsPositiveSide;

                if (currentElement >= limitOfElementsPositiveSide || currentElement <= limitOfElementsNegativeSide)
                {
                    list.RemoveAt(i);
                    i--;
                }
            }
        }

        private static int MinDigits(List<int> list)
        {
            int minDigits = int.MaxValue;
            for (int i = 0; i < list.Count; i++)
            {
                int currentElement = list[i];
                int currentDigits = 0;

                while (currentElement != 0)
                {
                    currentElement /= 10;
                    currentDigits++;
                }

                if (currentDigits < minDigits)
                {
                    minDigits = currentDigits;
                }
            }

            return minDigits;
        }
    }
}
