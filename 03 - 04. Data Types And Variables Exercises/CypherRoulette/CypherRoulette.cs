using System;

namespace CypherRoulette
{
    class CypherRoulette
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            string resultString = "";
            bool appendedAtTheStart = false;
            string lastString = "";

            for (int i = 0; i < n; i++)
            {
                string currentString = Console.ReadLine();

                if (currentString == "spin")
                {
                    appendedAtTheStart = !appendedAtTheStart;
                    i--;

                    if (lastString == currentString)
                    {
                        resultString = "";
                        appendedAtTheStart = !appendedAtTheStart;
                    }

                    lastString = currentString;
                    continue;
                }

                if (appendedAtTheStart)
                {
                    resultString = currentString + resultString;
                }
                else
                {
                    resultString += currentString;
                }

                if (lastString == currentString)
                {
                    resultString = "";
                }

                lastString = currentString;
            }

            Console.WriteLine(resultString);
        }
    }
}
