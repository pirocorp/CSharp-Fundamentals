using System;

namespace NumbersInReversedOrder
{
    class NumbersInReversedOrder
    {
        static void Main()
        {
            string number = Console.ReadLine();

            string reverseNumber = NumbersInReverse(number);
            Console.WriteLine(reverseNumber);
        }

        static string NumbersInReverse(string number)
        {
            string result = string.Empty;
            for (int i = number.Length-1; i >= 0; i--)
            {
                result += number[i];
            }

            return result;
        }
    }
}
