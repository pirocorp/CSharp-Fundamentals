using System;

namespace GameNumbers
{
    class GameNumbers
    {
        static void Main()
        {
            var start = int.Parse(Console.ReadLine());
            var end = int.Parse(Console.ReadLine());
            var magicNumber = int.Parse(Console.ReadLine());

            var combinations = 0;
            bool no = true;
            var lastI = 0;
            var lastJ = 0;

            for (int i = start; i <= end; i++)
            {
                for (int j = start; j <= end; j++)
                {
                    combinations++;
                    if (magicNumber == i + j)
                    {
                        no = false;
                        lastI = i;
                        lastJ = j;
                    }
                }
            }

            if (no)
            {
                Console.WriteLine($"{combinations} combinations - neither equals {magicNumber}");
            }
            else
            {
                Console.WriteLine($"Number found! {lastI} + {lastJ} = {magicNumber}");
            }
        }
    }
}
