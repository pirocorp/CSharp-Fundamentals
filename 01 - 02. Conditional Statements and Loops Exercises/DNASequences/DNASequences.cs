using System;

namespace DNASequences
{
    class DNASequences
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            string dNA = "OACGTX";

            for (int acid1 = 1; acid1  <= 4; acid1 ++)
            {
                for (int acid2 = 1; acid2 <= 4; acid2++)
                {
                    for (int acid3 = 1; acid3 <= 4; acid3++)
                    {
                        if (acid1 + acid2 + acid3 >= n) Console.Write($"{dNA[0]}{dNA[acid1]}{dNA[acid2]}{dNA[acid3]}{dNA[0]} ");
                        else Console.Write($"{dNA[5]}{dNA[acid1]}{dNA[acid2]}{dNA[acid3]}{dNA[5]} ");
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}
