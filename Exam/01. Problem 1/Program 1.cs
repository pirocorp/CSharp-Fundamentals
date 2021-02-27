namespace _01._Problem_1
{
    using System;

    public static class Program
    {
        public static void Main()
        {
            var amountNeeded = double.Parse(Console.ReadLine());
            var count = int.Parse(Console.ReadLine());
            var gained = 0D;

            var battles = 0;

            for (var i = 1; i <= count; i++)
            {
                var exp = double.Parse(Console.ReadLine());

                if (i % 15 == 0)
                {
                    exp *= 1.05;
                }
                else if (i % 5 == 0)
                {
                    exp *= 0.9;
                }
                else if (i % 3 == 0)
                {
                    exp *= 1.15;
                }

                gained += exp;
                battles++;

                if (gained >= amountNeeded)
                {
                    break;
                }
            }

            if (gained >= amountNeeded)
            {
                Console.WriteLine($"Player successfully collected his needed experience for {battles} battles.");
            }
            else
            {
                var needed = amountNeeded - gained;
                Console.WriteLine($"Player was not able to collect the needed experience, {needed:F2} more needed.");
            }
        }
    }
}
