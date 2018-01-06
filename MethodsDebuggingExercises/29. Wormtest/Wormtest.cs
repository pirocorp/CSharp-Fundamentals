using System;

namespace _29.Wormtest
{
    class Wormtest
    {
        static void Main()
        {
            long lengthInMeters = long.Parse(Console.ReadLine());
            decimal widthInCentimeters = decimal.Parse(Console.ReadLine());

            decimal widthInMeters = widthInCentimeters / 100;

            decimal remainder = 0;
            if (widthInMeters > 0 && lengthInMeters > 0)
            {
                remainder = lengthInMeters % widthInMeters;
            }

            if (remainder == 0)
            {
                var result = lengthInMeters * 100 * widthInCentimeters;
                Console.WriteLine($"{result:f2}");
            }
            else
            {
                var percentage = (lengthInMeters / widthInMeters) * 100;
                Console.WriteLine($"{percentage:f2}%");
            }
        }
         
    }
}
