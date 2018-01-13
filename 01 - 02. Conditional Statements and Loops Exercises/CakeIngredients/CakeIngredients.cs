using System;

namespace CakeIngredients
{
    class CakeIngredients
    {
        static void Main(string[] args)
        {
            string ingredients;
            var ingredientsCount = 0;
            
            do
            {
                ingredients = Console.ReadLine();
                if (ingredients == "Bake!") continue;
                ingredientsCount++;
                Console.WriteLine($"Adding ingredient {ingredients}.");
            } while (ingredients != "Bake!");

            Console.WriteLine($"Preparing cake with {ingredientsCount} ingredients.");
        }
    }
}
