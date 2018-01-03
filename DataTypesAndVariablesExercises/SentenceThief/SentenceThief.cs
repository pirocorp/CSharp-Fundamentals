using System;

namespace SentenceThief
{
    class SentenceThief
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

            long yearsInPrison;

            if (thief >= 0)
            {
                yearsInPrison = (long)Math.Ceiling(thief / 127.0);
            }
            else
            {
                yearsInPrison = (long)Math.Ceiling(thief / -128.0);
            }

            string years = yearsInPrison > 1 ? "years" : "year";

            //if (yearsInPrison > 1) years = "years";
            //else years = "year";

            Console.WriteLine($"Prisoner with id {thief} is sentenced to {yearsInPrison} {years}");
        }
    }
}
