using System;

namespace MasterNumber
{
    class MasterNumber
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            //Console.WriteLine(HoldsOneEvenDigit(n));
            //Console.WriteLine(ItsSumOfDigitsIsDividableBySeven(n));
            //Console.WriteLine(IsSymetric(n));
            for (int i = 1; i <= n; i++)
            {
                if (IsSymetric(i))
                {
                    if (ItsSumOfDigitsIsDividableBySeven(i))
                    {
                        if (HoldsOneEvenDigit(i))
                        {
                            Console.WriteLine(i);
                        }
                    }
                }
            }
        }

        static bool HoldsOneEvenDigit(int number)
        {
            while (number != 0)
            {
                if (number % 2 == 0) return true;
                number /= 10;
            }

            return false;
        }

        static bool ItsSumOfDigitsIsDividableBySeven(int number)
        {
            int sum = 0;
            while (number != 0)
            {
                sum += number % 10;
                number /= 10;
            }

            if (sum % 7 == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static bool IsSymetric(int number)
        {
            int currentNumber = number;
            int palendrom = 0;

            while(currentNumber != 0)
            {
                palendrom *= 10;
                palendrom += currentNumber % 10;
                currentNumber /= 10;
            }

            if (palendrom == number) return true;

            return false;
        }
    }
}
