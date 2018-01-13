using System;

namespace NumberChecker
{
    class NumberChecker
    {
        static void Main()
        {
            var stringLine = Console.ReadLine();

            try
            {
                long intNum = long.Parse(stringLine);
                Console.WriteLine("integer");
            }
            catch
            {
                double floatNum = double.Parse(stringLine);
                Console.WriteLine("floating-point");
            }
        }
    }
}
