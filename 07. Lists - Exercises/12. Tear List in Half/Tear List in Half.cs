using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12.Tear_List_in_Half
{
    class Program
    {
        static void Main()
        {
            char[] delimeterList = {' '};
            var listOfNumbers = Console.ReadLine()
                .Split(delimeterList, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            var leftHalf = listOfNumbers.GetRange(0, listOfNumbers.Count / 2);
            var rightHalf = listOfNumbers.GetRange(listOfNumbers.Count / 2, listOfNumbers.Count / 2);

            var resultList = new List<int>();

            for (int i = 0; i < leftHalf.Count; i++)
            {
                resultList.Add(rightHalf[i] / 10);
                resultList.Add(leftHalf[i]);
                resultList.Add(rightHalf[i] % 10);
            }

            Console.WriteLine(String.Join(" ", resultList));
        }
    }
}
