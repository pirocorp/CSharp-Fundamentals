using System;
using System.Linq;

namespace _34.Heists
{
    class Heists
    {
        static void Main()
        {
            char[] delimeterList = { ' ' };
            long[] numbers = Console.ReadLine() // jewels - % gold - $
                .Split(delimeterList, StringSplitOptions.RemoveEmptyEntries)
                .Select(long.Parse)
                .ToArray();

            string[] command = Console.ReadLine()
                .Split(delimeterList, StringSplitOptions.RemoveEmptyEntries);
            long totalExpenses = 0;
            long totalIncome = 0;

            while (command[0] != "Jail" && command[1] != "Time")
            {
                totalExpenses += long.Parse(command[1]);
                 
                for (int i = 0; i < command[0].Length; i++)
                {
                    if (command[0][i] == '%')
                    {
                        totalIncome += numbers[0];
                    }
                    else if (command[0][i] == '$')
                    {
                        totalIncome += numbers[1];
                    }
                }

                command = Console.ReadLine()
                    .Split(delimeterList, StringSplitOptions.RemoveEmptyEntries);
            }

            if (totalIncome >= totalExpenses)
            {
                long total = totalIncome - totalExpenses;
                Console.WriteLine($"Heists will continue. Total earnings: {total}.");
            }
            else
            {
                long lost = totalExpenses - totalIncome;
                Console.WriteLine($"Have to find another job. Lost: {lost}.");
            }
        }
    }
}
