using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.Flip_List_Sides
{
    class Program
    {
        static void Main()
        {
            char[] delimeterList = { ' ' };
            var list = Console.ReadLine()
                .Split(delimeterList, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            for (int i = 1; i < list.Count / 2; i++)
            {
                int swap = list[i];
                list[i] = list[list.Count - 1 - i];
                list[list.Count - 1 - i] = swap;
            }

            Console.WriteLine(String.Join(" ", list));
        }
    }
}
