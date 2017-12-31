using System;

namespace WordInPlural
{
    class WordInPlural
    {
        static void Main()
        {
            string noun = Console.ReadLine().ToLower();

            char lastChar = noun[noun.Length - 1];
            char charBeforLast = noun[noun.Length - 2];

            var newNoun = "";
            if (lastChar == 'y')
            {
                newNoun = noun.Substring(0, noun.Length - 1);
                newNoun += "ies";
            }
            else if (lastChar == 'o' || lastChar == 's' || lastChar == 'x' || lastChar == 'z' )
            {
                newNoun = noun;
                newNoun += "es";
            }
            else if (lastChar == 'h' && (charBeforLast == 'c' || charBeforLast == 's'))
            {
                newNoun = noun;
                newNoun += "es";
            }
            else
            {
                newNoun = noun;
                newNoun += "s";
            }

                Console.WriteLine(newNoun);
        }
    }
}
