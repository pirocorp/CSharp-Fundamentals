using System;

namespace HouseBuilder
{
    class HouseBuilder
    {
        static void Main()
        {
            var countSbyte = 4;
            var countInt = 10;

            long numberOne = long.Parse(Console.ReadLine());
            long numberTwo = long.Parse(Console.ReadLine());

            long total;
            if (numberOne < numberTwo) total = numberOne * countSbyte + numberTwo * countInt;
            else total = numberTwo * countSbyte + numberOne * countInt;

            Console.WriteLine(total);
        }
    }
}
