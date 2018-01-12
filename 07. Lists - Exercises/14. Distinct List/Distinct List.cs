using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14.Distinct_List
{
    class Program
    {
        static void Main()
        {
            char[] delimeterList = { ' ' };
            var listOfIntegers = Console.ReadLine()
                .Split(delimeterList, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            List <int> disticntListOfIntegers = listOfIntegers.Distinct().ToList();
            Console.WriteLine(String.Join(" ", disticntListOfIntegers));
        }
    }
}
