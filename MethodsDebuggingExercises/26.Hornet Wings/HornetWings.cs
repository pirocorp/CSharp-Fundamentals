using System;

namespace _26.Hornet_Wings
{
    class HornetWings
    {
        static void Main()
        {
            int wingFlapsToDo = int.Parse(Console.ReadLine());
            decimal distanceTraveldPer1000WingFlaps = decimal.Parse(Console.ReadLine());
            int wingFlapsBeforeRest = int.Parse(Console.ReadLine());

            long timeForRestInSec = 5;
            long hornetFlapsPerSec = 100;

            decimal distanceTraveld = (wingFlapsToDo / 1000.0m) * distanceTraveldPer1000WingFlaps;
            long timeForRest = (wingFlapsToDo / wingFlapsBeforeRest) * timeForRestInSec;
            decimal timeForFlapsInSec = (wingFlapsToDo / (decimal) hornetFlapsPerSec);
            decimal totalTime = timeForRest + timeForFlapsInSec;

            Console.WriteLine($"{distanceTraveld:f2} m.");
            Console.WriteLine($"{totalTime} s.");
        }
    }
}
