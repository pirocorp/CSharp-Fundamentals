using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15.Integer_Insertion
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

            string inputString = Console.ReadLine();

            while (inputString != "end")
            {
                string indexOfInsertString = new string(inputString[0], 1);
                int indexOfInsert = int.Parse(indexOfInsertString);
                listOfIntegers.Insert(indexOfInsert, int.Parse(inputString));
                inputString = Console.ReadLine();
            }

            Console.WriteLine(String.Join(" ", listOfIntegers));
        }
    }
}
