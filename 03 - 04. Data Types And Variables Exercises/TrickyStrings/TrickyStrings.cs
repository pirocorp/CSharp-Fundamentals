using System;

namespace TrickyStrings
{
    class TrickyStrings
    {
        static void Main()
        {
            string delimeter = Console.ReadLine();
            int n = int.Parse(Console.ReadLine());

            string resultString = "";

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                resultString += input + delimeter;
            }

            int lenght = resultString.Length - delimeter.Length;

            resultString = resultString.Substring(0, lenght);
            Console.WriteLine(resultString);
        }
    }
}
