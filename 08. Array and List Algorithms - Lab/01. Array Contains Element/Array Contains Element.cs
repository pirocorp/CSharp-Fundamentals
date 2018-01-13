using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Array_Contains_Element
{
    class Program
    {
        static void Main()
        {
            var arr = Console.ReadLine()
                .Split().Select(int.Parse).ToArray();
            var element = int.Parse(Console.ReadLine());


            var containsElement = false;
            for (int i = 0; i < arr.Length; i++)
                if (arr[i] == element)
                {
                    containsElement = true; break;
                }

            if (containsElement)
                Console.WriteLine("yes");
            else
                Console.WriteLine("no");

        }
    }
}
