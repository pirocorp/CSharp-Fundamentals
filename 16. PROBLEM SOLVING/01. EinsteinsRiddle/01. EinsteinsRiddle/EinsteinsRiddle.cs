namespace _01._EinsteinsRiddle
{
    using System;
    using System.Runtime.InteropServices;

    public class EinsteinsRiddle
    {
        static string[] houses = { "Red", "Green", "Yellow", "White", "Blue" };
        static string[] pets = { "Dog", "Cat", "Bird", "Horse", "Fish" };
        static string[] nationalities = { "Brit", "Swede", "Dane", "Norwegian", "German" };
        static string[] cigarettes = { "Blend", "Prince", "Dunhill", "BlueMaster", "PullMall" };
        static string[] drinks = { "Tea", "Coffee", "Milk", "Beer", "Water" };
        static string[] hints = new string[15];

        public static void Main()
        {
            var rand = new Random();
            Shuffle(rand);
            GenerateHints();
            Console.WriteLine("Einstein's riddle");
            Console.WriteLine("The situation:");
            Console.WriteLine("     1. There are 5 houses of five different colors.");
            Console.WriteLine("     2. In each house lives a person with a different nationality.");
            Console.WriteLine("     3. These five owners drink a certain type of beverage, smoke a certain brand of cigar and keep a certain pet.");
            Console.WriteLine("     4. No owners have the same pet, smoke the same brand of cigar or drink same beverage.");
            Console.WriteLine($"The question is: Who owns the {pets[3]}?");
            Console.WriteLine("HINTS:");

            for (var i = 0; i < hints.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {hints[i]}");
            }

            Console.WriteLine("Einstein wrote this riddle this century. He said that 98% of the world could not solve it.");
            Console.WriteLine("To see the solution type solution.");
            var solution = Console.ReadLine();

            while (solution.ToLower() != "solution")
            {
                Console.WriteLine("Wrong Command! Try Again!");
                solution = Console.ReadLine();
            }

            PrintSolution();
        }

        private static void PrintSolution()
        {
            for (var i = 0; i < 5; i++)
            {
                Console.WriteLine($"In the {houses[i]} lives the {nationalities[i]}. He drinks {drinks[i]}, smokes {cigarettes[i]} and has {pets[i]} as a pet.");
            }
        }

        private static void GenerateHints()
        {
            hints[0] = $"the {nationalities[2]} lives in the {houses[2]} house.";
            hints[1] = $"the {nationalities[4]} keeps {pets[4]} as pet.";
            hints[2] = $"the {nationalities[1]} drinks {drinks[1]}.";
            hints[3] = $"the {houses[3]} house is on the left of the {houses[4]} house.";
            hints[4] = $"the {houses[2]} house's owner keeps {pets[2]}";
            hints[5] = $"the person who smokes {cigarettes[1]} keeps {pets[1]}";
            hints[6] = $"the owner of the {pets[0]} smokes {cigarettes[0]}";
            hints[7] = $"the man living in the center house drinks {drinks[2]}";
            hints[8] = $"the {nationalities[0]} lives in the first house";
            hints[9] = $"the man who smokes {cigarettes[2]} lives next to the one who keeps {pets[3]}";
            hints[10] = $"the man who drinks {drinks[0]} smokes {cigarettes[0]}";
            hints[11] = $"the owner who smokes {cigarettes[4]} drinks {drinks[4]}";
            hints[12] = $"the {nationalities[3]} smokes {cigarettes[3]}";
            hints[13] = $"the {nationalities[0]} lives next to the {houses[1]} house";
            hints[14] = $"the man who smokes {cigarettes[2]} has a neighbor who drinks {drinks[3]}";
        }

        private static void Shuffle(Random rand)
        {
            for (var i = 0; i < 5; i++)
            {
                //Shuffling houses
                var randomHouse = i + rand.Next(0, houses.Length - i);
                Swap(i, randomHouse, houses);

                //Shuffling pets
                var randomPet = i + rand.Next(0, pets.Length - i);
                Swap(i, randomPet, pets);

                //Shuffling nationalities
                var randomNationality = i + rand.Next(0, nationalities.Length - i);
                Swap(i, randomNationality, nationalities);

                //Shuffling cigarettes 
                var randomCigarette = i + rand.Next(0, cigarettes.Length - i);
                Swap(i, randomCigarette, cigarettes);

                //Shuffling drinks
                var randomDrink = i + rand.Next(0, drinks.Length - i);
                Swap(i, randomDrink, drinks);
            }
        }

        private static void Swap(int i, int random, string[] array)
        {
            var temp = array[i];
            array[i] = array[random];
            array[random] = temp;
        }
    }
}
