using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _16.Sweet_Dessert
{
    class Program
    {
        static void Main()
        {
            var amountOfCash = decimal.Parse(Console.ReadLine());
            var numberOfGuests = int.Parse(Console.ReadLine());
            var priceOfBananas = decimal.Parse(Console.ReadLine());
            var priceOfEggs = decimal.Parse(Console.ReadLine());
            var priceOfBerries = decimal.Parse(Console.ReadLine());
            var numberOfSets = (decimal)Math.Ceiling(numberOfGuests / 6.0);
            var pricePerSet = priceOfBananas * 2 + 4 * priceOfEggs + 0.2m * priceOfBerries;
            var costOfProducts = pricePerSet * numberOfSets;

            var cashleft = costOfProducts - amountOfCash;

            if (amountOfCash >= costOfProducts)
            {
                Console.WriteLine($"Ivancho has enough money - it would cost {costOfProducts:F2}lv.");
            }
            else
            {
                Console.WriteLine($"Ivancho will have to withdraw money - he will need {cashleft:F2}lv more.");
            }
        }
    }
}
