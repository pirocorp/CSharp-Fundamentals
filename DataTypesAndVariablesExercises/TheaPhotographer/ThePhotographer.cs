using System;

namespace ThePhotographer
{
    class ThePhotographer
    {
        static void Main()
        {
            int nPictures = int.Parse(Console.ReadLine());
            int filterInSec = int.Parse(Console.ReadLine());
            double filterFactor = double.Parse(Console.ReadLine()); //filter factor or the percentage of the total pictures that are considered “good” to be uploaded.
            int uploadTimePic = int.Parse(Console.ReadLine());

            filterFactor = filterFactor / 100;
            //Console.WriteLine("filterFactor " + filterFactor);
            int filterPics = (int)Math.Ceiling(nPictures * filterFactor);
            //Console.WriteLine("filterPics " + filterPics);
            long filterPicsTime = nPictures * filterInSec;
            //Console.WriteLine("filterPicsTime " + filterPicsTime);
            long uploadPicsTime = filterPics * uploadTimePic;
            //Console.WriteLine("uploadPicsTime " + uploadPicsTime);
            long totalTime = filterPicsTime + uploadPicsTime;
            //Console.WriteLine("totalTime " + totalTime);

            var seconds = totalTime % 60;
            var minutes = totalTime / 60;
            var hours = minutes / 60;
            var days = hours / 24;
            minutes %= 60;
            hours %= 60;

            Console.WriteLine($"{days}:{hours:d2}:{minutes:d2}:{seconds:d2}");
        }
    }
}
