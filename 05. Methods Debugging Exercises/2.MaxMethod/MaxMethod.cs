using System;

namespace MaxMethod
{
    class MaxMethod
    {
        static void Main()
        {
            double number1 = double.Parse(Console.ReadLine());
            double number2 = double.Parse(Console.ReadLine());
            double number3 = double.Parse(Console.ReadLine());

            double result = GetMax(GetMax(number1, number2), number3);
            Console.WriteLine(result);
        }

        static double GetMax(double number1, double number2)
        {
            if (number1 > number2)
            {
                return number1;
            }
            else
            {
                return number2;
            }
        }
    }
}
