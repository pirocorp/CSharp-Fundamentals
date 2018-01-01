using System;

namespace TrainingHallEquipment
{
    class TrainingHallEquipment
    {
        static void Main(string[] args)
        {
            decimal budget = decimal.Parse(Console.ReadLine());
            int items = int.Parse(Console.ReadLine());

            var sum = 0.0m;

            for (int i = 0; i < items; i++)
            {
                var name = Console.ReadLine();
                var price = decimal.Parse(Console.ReadLine());
                var itemCounts = int.Parse(Console.ReadLine());

                if (itemCounts != 1) name += "s";
                sum += price * itemCounts;

                Console.WriteLine($"Adding {itemCounts} {name} to cart.");
            }

            Console.WriteLine($"Subtotal: ${sum:f2}");

            if (sum > budget)
            {
                var moneyNeeded = sum - budget;
                Console.WriteLine($"Not enough. We need ${moneyNeeded:f2} more.");
            }
            else
            {
                var moneyLeft = budget - sum;
                Console.WriteLine($"Money left: ${moneyLeft:f2}");
            }
        }
    }
}
