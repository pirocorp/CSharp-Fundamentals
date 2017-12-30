using System;

namespace ChooseDrink
{
    class ChooseDrink
    {
        static void Main()
        {
            var profession = Console.ReadLine().ToLower();

            string result = "";
            if (profession == "athlete")
            {
                result = "Water";
            }
            else if (profession == "businessman" || profession == "businesswoman")
            {
                result = "Coffee";
            }
            else if (profession == "softuni student")
            {
                result = "Beer";
            }
            else
            {
                result = "Tea";
            }
            Console.WriteLine(result);
        }
    }
}
