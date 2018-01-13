using System;

namespace IntervalNumbers
{
    class IntervalNumbers
    {
        static void Main()
        {
            var numberOne = int.Parse(Console.ReadLine());
            var numberTwo = int.Parse(Console.ReadLine());

            for (int i = Math.Min(numberOne, numberTwo); i <= Math.Max(numberOne, numberTwo); i++)
            {
                Console.WriteLine(i);
            }
        }
    }
}
