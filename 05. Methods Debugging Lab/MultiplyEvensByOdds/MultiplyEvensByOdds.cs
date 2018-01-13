using System;

namespace MultiplyEvensByOdds
{
    class MultiplyEvensByOdds
    {
        static void Main()
        {
            int number = int.Parse(Console.ReadLine());
            var result = GetMultipleOfEvensAndOdds(number);
            Console.WriteLine(result);

        }

        static int GetMultipleOfEvensAndOdds(int number)
        {
            number = Math.Abs(number);
            var sumOfEven = GetSumOfEvenDigits(number);
            var sumOfOdd = GetSumOfOddDigits(number);
            return sumOfEven * sumOfOdd;
        }

        static int GetSumOfOddDigits(int number)
        {
            var sum = 0;
            while (number > 0)
            {
                int lastDigit = number % 10;

                if (lastDigit % 2 != 0)
                {
                    sum += lastDigit;
                }

                number /= 10;
            }

            return sum;
        }

        static int GetSumOfEvenDigits(int number)
        {
            var sum = 0;
            while (number > 0)
            {
                int lastDigit = number % 10;

                if (lastDigit % 2 == 0)
                {
                    sum += lastDigit;
                }

                number /= 10;
            }

            return sum;

            return sum;
        }
    }
}
