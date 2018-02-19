namespace _08.Charity_Marathon
{
    using System;

    class Program
    {
        static void Main()
        {
            var days = int.Parse(Console.ReadLine());
            var participants = long.Parse(Console.ReadLine());
            var laps = int.Parse(Console.ReadLine());
            var lenghtOfTrack = long.Parse(Console.ReadLine());
            var capacity = int.Parse(Console.ReadLine());
            var donatedMoneyPerKm = decimal.Parse(Console.ReadLine());

            var maxCapacity = days * capacity;
            var currentCapacity = Math.Min(participants, maxCapacity);
            var totalKm = laps * (decimal) lenghtOfTrack * currentCapacity / 1000;
            var totalMoney = totalKm * donatedMoneyPerKm;
            Console.WriteLine($"Money raised: {totalMoney:F2}");

        }
    }
}
