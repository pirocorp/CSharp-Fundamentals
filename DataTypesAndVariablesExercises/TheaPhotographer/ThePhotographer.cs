using System;

namespace ThePhotographer
{
    class ThePhotographer
    {
        static void Main()
        {
            long nPictures = int.Parse(Console.ReadLine());
            long filterInSec = int.Parse(Console.ReadLine());
            long filterFactor = int.Parse(Console.ReadLine()); 
            long uploadTimePic = int.Parse(Console.ReadLine());

            int filterPics = (int)Math.Ceiling(nPictures * (filterFactor / 100.0));
            long filterPicsTime = nPictures * filterInSec;
            long uploadPicsTime = filterPics * uploadTimePic;
            long totalTime = filterPicsTime + uploadPicsTime;

            var seconds = totalTime % 60;
            var minutes = totalTime / 60;
            var hours = minutes / 60;
            var days = hours / 24;
            minutes %= 60;
            hours %= 24;

            Console.WriteLine($"{days}:{hours:d2}:{minutes:d2}:{seconds:d2}");
        }
    }
}
