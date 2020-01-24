namespace _01._Binary_Digits_Count
{
    using System;

    public class BinaryDigitsCount
    {
        public static void Main()
        {
            const int n = 23;
            const int b = 1;
            var count = CountDigits(n, b);
            Console.WriteLine(count);
        }

        private static int CountDigits(int n, int b)
        {
            var binary = Convert.ToString(n, 2);
            var bit = b.ToString()[0];
            var count = 0;

            for (var i = 0; i < binary.Length; i++)
            {
                if (binary[i] == bit)
                {
                    count++;
                }
            }

            return count;
        }
    }
}