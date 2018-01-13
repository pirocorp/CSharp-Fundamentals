using System;

namespace BeerKegs
{
    class BeerKegs
    {
        static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            string biggestModel = "";
            double biggestModelVolume = -1;
            for (int i = 0; i < n; i++)
            {
                var currentModel = Console.ReadLine();
                var currentRadius = double.Parse(Console.ReadLine());
                var currentHeight = double.Parse(Console.ReadLine());
                var currentVolume = Math.PI * currentRadius * currentRadius * currentHeight;
                if (currentVolume > biggestModelVolume)
                {
                    biggestModelVolume = currentVolume;
                    biggestModel = currentModel;
                }
            }

            Console.WriteLine(biggestModel);
        }
    }
}
