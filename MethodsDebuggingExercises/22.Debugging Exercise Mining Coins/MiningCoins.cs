using System;

namespace _22.Debugging_Exercise_Mining_Coins
{
    class MiningCoins
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            string decrypted = string.Empty;
            float totalValue = 0;

            for (int i = 1; i <= n; i++)
            {
                int number = int.Parse(Console.ReadLine());

                int digit1 = number / 100;
                int digit2 = (number % 100) / 10;
                int digit3 = number % 10;

                totalValue += (digit1 + digit2 + digit3) / (float)n;
                int aSCIIcode;

                if (i % 2 == 0)
                {
                    aSCIIcode = ((digit1 * 10) + digit3) + digit2;
                }
                else
                {
                    aSCIIcode = ((digit1 * 10) + digit3) - digit2;
                }

                if ((aSCIIcode >= 65 && aSCIIcode <= 90)
                    || (aSCIIcode >= 97 && aSCIIcode <= 122))
                {
                    decrypted += (char)aSCIIcode;
                }
            }

            Console.WriteLine("Message: {0}", decrypted);
            Console.WriteLine("Value: {0:F7}", totalValue);
        }
    }
}
