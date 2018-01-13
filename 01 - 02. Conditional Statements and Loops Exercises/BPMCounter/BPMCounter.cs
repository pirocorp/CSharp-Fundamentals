using System;

namespace BPMCounter
{
    class BPMCounter
    {
        static void Main()
        {
            int bpm = int.Parse(Console.ReadLine());
            double nBeats = double.Parse(Console.ReadLine());

            var bars = Math.Round(nBeats / 4.0, 1);
            double timeMin = nBeats / bpm;
            double timeSec = timeMin - Math.Truncate(timeMin);
            timeMin = Math.Truncate(timeMin);
            timeSec *= 60;
            timeSec = Math.Floor(timeSec);
            Console.WriteLine($"{bars} bars - {timeMin}m {timeSec}s");
        }
    }
}
