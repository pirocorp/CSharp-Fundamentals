using System;

namespace PracticeIntegers
{
    class ConvertSpeedUnits
    {
        static void Main()
        {
            float distanceInMeters = float.Parse(Console.ReadLine());
            int hours = int.Parse(Console.ReadLine());
            int minutes = int.Parse(Console.ReadLine());
            int seconds = int.Parse(Console.ReadLine());

            float timeInSeconds = hours * 3600 + minutes * 60 + seconds;
            float speedInMetersPerSecond = distanceInMeters / timeInSeconds;
            //If i use speedInMetersPerSecond / 3.6 to convert in KMpH i recive sometimes difrent results
            //If i input 200 000, 2, 5, 0 i get 95.99999 now i get 96 
            float speedInKmPersHour = (distanceInMeters / 1000) / (timeInSeconds / 3600); 
            float milesPerHour = speedInKmPersHour / 1.6089999f;

            Console.WriteLine(speedInMetersPerSecond);
            Console.WriteLine(speedInKmPersHour);
            Console.WriteLine(milesPerHour);
        }
    }
}
