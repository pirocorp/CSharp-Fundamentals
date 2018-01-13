using System;

public class Substring
{
    public static void Main()
    {
        string text = Console.ReadLine();
        int count = int.Parse(Console.ReadLine());

        const char searchedChar = 'p';
        bool charIsFound = false;

        for (int i = 0; i < text.Length; i++)
        {
            if (text[i] == searchedChar)
            {
                charIsFound = true;
                int lenght = count + 1;
                if (lenght + i > text.Length - 1)
                {
                    lenght -= (lenght + i - text.Length);
                }

                string matchedString = text.Substring(i, lenght);
                Console.WriteLine(matchedString);

                i += lenght -1;
            }
        }

        if (!charIsFound)
        {
            Console.WriteLine("no");
        }
    }
}
