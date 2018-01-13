using System;

namespace RestaurantDiscount
{
    class RestaurantDiscount
    {
        static void Main()
        {
            var nPeople = int.Parse(Console.ReadLine());
            var package = Console.ReadLine().ToLower();

            var smallHall = 2500;
            var terrace = 5000;
            var greatHall = 7500;
            var hallPrice = 0;
            string hallName = "";
            bool no = false;

            if (nPeople > 0 && nPeople <= 50)
            {
                hallPrice = smallHall;
                hallName = "Small Hall";
            }
            else if (nPeople > 50 && nPeople <= 100)
            {
                hallPrice = terrace;
                hallName = "Terrace";
            }
            else if (nPeople > 100 && nPeople <= 120)
            {
                hallPrice = greatHall;
                hallName = "Great Hall";
            }
            else
            {
                Console.WriteLine("We do not have an appropriate hall.");
                no = true;
            }

            var discount = 0.0;
            var packagePrice = 0;

            if (package == "normal")
            {
                discount = 0.95;
                packagePrice = 500;
            }
            else if (package == "gold")
            {
                discount = 0.90;
                packagePrice = 750;
            }
            else if (package == "platinum")
            {
                discount = 0.85;
                packagePrice = 1000;
            }

            var total = (hallPrice + packagePrice) * discount;
            var pricePerPerson = total / nPeople;

            if (!no)
            {
                Console.WriteLine($"We can offer you the {hallName}");
                Console.WriteLine($"The price per person is {pricePerPerson:f2}$");
            }
        }
    }
}
