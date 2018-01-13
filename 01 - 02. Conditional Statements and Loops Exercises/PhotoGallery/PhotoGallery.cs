using System;

namespace PhotoGallery
{
    class PhotoGallery
    {
        static void Main()
        {
            var photoNumber = int.Parse(Console.ReadLine());
            var dayOfPhoto = int.Parse(Console.ReadLine());
            var monthOfPhoto = int.Parse(Console.ReadLine());
            var yearOfPhoto = int.Parse(Console.ReadLine());
            var hoursOfPhoto = int.Parse(Console.ReadLine());
            var minutesOfPhoto = int.Parse(Console.ReadLine());
            var photoSizeInBytes = long.Parse(Console.ReadLine());
            var width = int.Parse(Console.ReadLine());
            var height = int.Parse(Console.ReadLine());

            string size = "";
            string orientation = "";

            var sizeKB = photoSizeInBytes / 1000.0;
            var sizeMB = sizeKB / 1000.0;

            if (sizeMB >= 1) size = $"{Math.Round(sizeMB,1)}MB";
            else if (sizeKB >= 1) size = $"{sizeKB}KB";
            else size = $"{photoSizeInBytes}B";

            if (width > height) orientation = "landscape";
            else if (height > width) orientation = "portrait";
            else orientation = "square";

            Console.WriteLine($"Name: DSC_{photoNumber:D4}.jpg");
            Console.WriteLine($"Date Taken: {dayOfPhoto:D2}/{monthOfPhoto:D2}/{yearOfPhoto} {hoursOfPhoto:D2}:{minutesOfPhoto:D2}");
            Console.WriteLine($"Size: {size}");
            Console.WriteLine($"Resolution: {width}x{height} ({orientation})");
        }
    }
}
