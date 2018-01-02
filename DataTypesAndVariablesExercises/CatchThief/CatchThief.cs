using System;

namespace CatchThief
{
    class CatchThief
    {
        static void Main()
        {
            string numericType = Console.ReadLine();
            long n = int.Parse(Console.ReadLine());

            long maxValue = 0;

            switch (numericType)
            {
                case "sbyte": maxValue = sbyte.MaxValue; break;
                case "int": maxValue = int.MaxValue; break;
                case "long": maxValue = long.MaxValue; break;
                default: break;
            }

            long thief = long.MinValue;

            for (int i = 0; i < n; i++)
            {
                long currentId = long.Parse(Console.ReadLine());

                if (currentId > thief && currentId <= maxValue)
                {
                    thief = currentId;
                }
            }

            Console.WriteLine(thief);
        }
    }
}
