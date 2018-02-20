namespace _12.Softuni_Coffee_Orders
{
    using System;
    using System.Globalization;

    class Program
    {
        static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var totalSum = 0M;

            for (var i = 0; i < n; i++)
            {
                var pricePerCapsule = decimal.Parse(Console.ReadLine());
                var orderDate = DateTime.ParseExact(Console.ReadLine(), "d/M/yyyy", CultureInfo.InvariantCulture);
                var capsulesCount = int.Parse(Console.ReadLine());
                var daysInMonth = DateTime.DaysInMonth(orderDate.Year, orderDate.Month);
                var currentSum = pricePerCapsule * daysInMonth * capsulesCount;
                totalSum += currentSum;
                Console.WriteLine($"The price for the coffee is: ${currentSum:F2}");
            }

            Console.WriteLine($"Total: ${totalSum:F2}");
        }
    }
}
