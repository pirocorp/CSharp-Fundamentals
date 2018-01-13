using System;

namespace StringConcatenation
{
    class StringConcatenation
    {
        static void Main()
        {
            var delimiter = Console.ReadLine();
            var numberType = Console.ReadLine();
            var n = int.Parse(Console.ReadLine());

            var resultString = "";

            for (int i = 1; i <= n; i++)
            {
                var stringInput = Console.ReadLine();
                if (numberType == "odd")
                {
                    if (i % 2 == 1) resultString += stringInput + delimiter;
                }
                else
                {
                    if (i % 2 == 0) resultString += stringInput + delimiter;
                }
            }

            resultString = resultString.Remove((resultString.Length) -1);
            Console.WriteLine(resultString);
        }
    }
}
