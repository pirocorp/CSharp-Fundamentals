using System;

namespace ComparingFloats
{
    class ComparingFloats
    {
        static void Main()
        {
            decimal numberA = decimal.Parse(Console.ReadLine());
            decimal numberB = decimal.Parse(Console.ReadLine());

            decimal difrence = numberA - numberB;

            if (difrence < 0.000001m && difrence > -0.000001m)
            {
                Console.WriteLine("True");
            }
            else
            {
                Console.WriteLine("False");
            }
        }
    }
}
