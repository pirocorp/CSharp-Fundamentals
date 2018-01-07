using System;

namespace _11.Last_3_Consecutive_Equal_Strings
{
    class Program
    {
        static void Main()
        {
            char[] delimeterList = {' '};
            string[] words = Console.ReadLine()
                .Split(delimeterList, StringSplitOptions.RemoveEmptyEntries);

            string lastFoundString = string.Empty;
            string preveusWord = words[0];
            int count = 1;
            for (int i = 1; i < words.Length; i++)
            {
                if (preveusWord == words[i])
                {
                    count++;
                    if (count >= 3)
                    {
                        lastFoundString = words[i];
                        preveusWord = words[i];
                    }
                }
                else
                {
                    count = 1;
                    preveusWord = words[i];
                }
            }

            Console.WriteLine($"{lastFoundString} {lastFoundString} {lastFoundString}");
        }
    }
}
