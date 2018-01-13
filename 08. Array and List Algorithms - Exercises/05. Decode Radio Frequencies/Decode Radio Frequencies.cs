using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Decode_Radio_Frequencies
{
    class Program
    {
        static void Main()
        {
            char[] delimeterList = { ' ' };
            var listOfDoubles = Console.ReadLine()
                .Split(delimeterList, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            var resultListOfStrings = new List<string>();

            for (int i = 0; i < listOfDoubles.Count; i++)
            {
                var currentDouble = listOfDoubles[i].Split('.');
                var intPartOfDouble = int.Parse(currentDouble[0]);
                var floatPartOfDouble = int.Parse(currentDouble[1]);

                if (floatPartOfDouble != 0)
                {
                    var resut = new string((char) floatPartOfDouble, 1);
                    resultListOfStrings.Insert(i, resut);
                }

                if (intPartOfDouble !=0)
                {
                    var resut = new string((char)intPartOfDouble, 1);
                    resultListOfStrings.Insert(i, resut);
                }
            }

            Console.WriteLine(String.Join("", resultListOfStrings));
        }
    }
}
