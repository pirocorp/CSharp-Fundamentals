using System;

namespace CaloriesCounter
{
    class CaloriesCounter
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            var totalCalories = 0;
            var cheese = 500;
            var tomatoSauce = 150;
            var salami = 600;
            var pepper = 50;

            for (int i = 0; i < n; i++)
            {
                var ingredient = Console.ReadLine().ToLower();

                if (ingredient == "cheese") totalCalories += cheese;
                else if (ingredient == "tomato sauce") totalCalories += tomatoSauce;
                else if (ingredient == "salami") totalCalories += salami;
                else if (ingredient == "pepper") totalCalories += pepper;
            }

            Console.WriteLine($"Total calories: {totalCalories}");
        }
    }
}
