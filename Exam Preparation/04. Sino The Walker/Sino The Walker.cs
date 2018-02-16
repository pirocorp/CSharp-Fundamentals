namespace _04.Sino_The_Walker
{
    using System;
    using System.Globalization;

    class Program
    {
        static void Main()
        {
            const string format = @"HH:mm:ss";
            var inputData = Console.ReadLine();
            var timeOfDeparture = DateTime.ParseExact(inputData, format, CultureInfo.InvariantCulture);
            var stepsToHome = long.Parse(Console.ReadLine());
            var secondsPerStep = long.Parse(Console.ReadLine());
            var totalElpasedSeconds = stepsToHome * secondsPerStep;
            var secondsLeft = totalElpasedSeconds % 60;
            var totalElpasedMinutes = totalElpasedSeconds / 60;
            var minutesLeft = totalElpasedMinutes % 60;
            var hours = totalElpasedMinutes / 60;
            var hoursLeft = hours % 24;
            var timeOfArrival = timeOfDeparture.AddSeconds(secondsLeft);
            timeOfArrival = timeOfArrival.AddMinutes(minutesLeft);
            timeOfArrival = timeOfArrival.AddHours(hoursLeft);
            Console.WriteLine($"Time Arrival: {timeOfArrival.Hour:D2}:{timeOfArrival.Minute:D2}:{timeOfArrival.Second:D2}");
        }
    }
}
