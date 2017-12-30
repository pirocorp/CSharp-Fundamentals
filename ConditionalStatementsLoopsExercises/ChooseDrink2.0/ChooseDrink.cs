using System;

namespace ChooseDrink
{
    class ChooseDrink
    {
        static void Main()
        {
            var profession = Console.ReadLine();
            var quantities = int.Parse(Console.ReadLine());
            var professionResult = profession;
            profession = profession.ToLower();

            //Prices
            var water = 0.70m;
            var coffee = 1.00m;
            var beer = 1.70m;
            var tea = 1.20m;

            var totalCost = 0.0m;
            //string preferedDrink = ""; Version 1.0
            if (profession == "athlete")
            {
                //preferedDrink = "Water"; Version 1.0
                totalCost = water * quantities; 
            }
            else if (profession == "businessman" || profession == "businesswoman")
            {
                //preferedDrink = "Coffee"; Version 1.0
                totalCost = coffee * quantities;
            }
            else if (profession == "softuni student")
            {
                //preferedDrink = "Beer"; Version 1.0
                totalCost = beer * quantities;
            }
            else
            {
                //preferedDrink = "Tea"; Version 1.0
                totalCost = tea * quantities;
            }
            //Console.WriteLine(result); Version 1.0
            Console.WriteLine($"The {professionResult} has to pay {totalCost}.");
        }
    }
}
