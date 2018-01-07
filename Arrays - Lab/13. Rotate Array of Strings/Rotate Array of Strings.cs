using System;
using System.Linq;

namespace _13.Rotate_Array_of_Strings
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] delimeterList = {' '};
            var array = Console.ReadLine()
                .Split(delimeterList, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            var rotatedArray = new string[array.Length];

            for (int i = 0; i < array.Length - 1; i++)
            {
                rotatedArray[i + 1] = array[i];
            }

            var lastElement = array[rotatedArray.Length - 1];
            rotatedArray[0] = lastElement;
            
            Console.WriteLine(string.Join(" ", rotatedArray));
        }
    }
}
