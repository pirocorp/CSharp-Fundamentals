using System;

namespace Megapixels
{
    class Megapixels
    {
        static void Main()
        {
            var width = int.Parse(Console.ReadLine());
            var height = int.Parse(Console.ReadLine());

            long pixels = width * height;
            double megaPixels = pixels / 1000000.0;
            Console.WriteLine($"{width}x{height} => {Math.Round(megaPixels,1)}MP");
        }
    }
}
