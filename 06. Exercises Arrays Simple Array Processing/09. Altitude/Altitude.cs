using System;

namespace _09.Altitude
{
    class Altitude
    {
        static void Main()
        {
            char[] delimeterList = {' '};
            string[] commandStrings = Console.ReadLine()
                .Split(delimeterList, StringSplitOptions.RemoveEmptyEntries);

            int altiude = int.Parse(commandStrings[0]);
            int currentAltitude = 0;
            for (int i = 1; i < commandStrings.Length; i +=2)
            {
                if (commandStrings[i] == "up")
                {
                    currentAltitude = 1;
                }
                else
                {
                    currentAltitude = -1;
                }

                currentAltitude *= int.Parse(commandStrings[i + 1]);
                altiude += currentAltitude;
                if (altiude <= 0)
                {
                    Console.WriteLine("crashed");
                    return;
                }
            }

            Console.WriteLine($"got through safely. current altitude: {altiude}m");
        }
    }
}
