using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Append_Lists
{
    class Program
    {
        static void Main()
        {
            char[] delimeterList = { '|' };
            char[] delimeterList2 = { ' ' };
            var stringsOfLists = Console.ReadLine()
                .Split(delimeterList, StringSplitOptions.RemoveEmptyEntries);
            List <List<int>> listOfLists = new List<List<int>>();

            for (int i = stringsOfLists.Length - 1; i >= 0; i--)
            {
                listOfLists.Add(stringsOfLists[i].Split(delimeterList2, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList());
            }

            string result = String.Empty;

            for (int i = 0; i < listOfLists.Count; i++)
            {
                result += String.Join(" ", listOfLists[i]);
                result += " ";
            }

            Console.WriteLine(result);
        }
    }
}
