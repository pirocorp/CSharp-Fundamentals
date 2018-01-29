using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace _12.String_Commander
{
    class Program
    {
        static void Main()
        {
            var inputString = Console.ReadLine();
            var inputData = Console.ReadLine();

            while (inputData != "end")
            {
                var tokens = inputData.Split(' ');
                var command = tokens[0];

                switch (command)
                {
                    case "Left":
                        var count = int.Parse(tokens[1]);
                        count = count % inputString.Length;
                        inputString = Left(inputString, count);
                        break;
                    case "Right":
                        count = int.Parse(tokens[1]);
                        count = count % inputString.Length;
                        inputString = Right(inputString, count);
                        break;
                    case "Insert":
                        var index = int.Parse(tokens[1]);
                        var str = tokens[2];
                        inputString = inputString.Insert(index, str);
                        break;
                    case "Delete":
                        var startIndex = int.Parse(tokens[1]);
                        var endIndex = int.Parse(tokens[2]);
                        count = (endIndex - startIndex) + 1;
                        inputString = inputString.Remove(startIndex, count);
                        break;
                }

                inputData = Console.ReadLine();
            }

            Console.WriteLine(inputString);
        }

        private static string Right(string inputString, int count)
        {
            var result = inputString;

            for (int i = 0; i < count; i++)
            {
                var lastElement = result[result.Length - 1];
                result = lastElement + result.Substring(0, result.Length - 1);
            }

            return result;
        }

        private static string Left(string inputString, int count)
        {
            var result = inputString;

            for (int i = 0; i < count; i++)
            {
                result = result.Substring(1);
                var firstElement = inputString[i];
                result = result + firstElement;
            }

            return result;
        }
    }
}