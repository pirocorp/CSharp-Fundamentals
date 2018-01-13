using System;


namespace RefactorSpecialNumbers
{
    class RefactorSpecialNumbers
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            for (int num = 1; num <= n; num++)
            {
                int currentNum = num;
                int sum = 0;

                while (currentNum > 0)
                {
                    sum += currentNum % 10;
                    currentNum = currentNum / 10;
                }
                bool specialNum = (sum == 5) || (sum == 7) || (sum == 11);
                Console.WriteLine($"{num} -> {specialNum}");
            }
        }
    }
}
