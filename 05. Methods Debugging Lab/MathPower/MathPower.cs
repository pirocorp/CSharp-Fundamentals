using System;

namespace MathPower
{
    class MathPower
    {
        static void Main()
        {
            double number = double.Parse(Console.ReadLine());
            int power = int.Parse(Console.ReadLine());

            var result = RaiseToPower(number, power);
            Console.WriteLine(result);
        }

        static double RaiseToPower(double number, int power)
        {
            double result = 1;
            for (int i = 0; i < power; i++)
                result *= number;
            return result;
        }
    }
}
