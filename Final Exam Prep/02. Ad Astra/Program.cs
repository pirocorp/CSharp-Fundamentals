namespace _02._Ad_Astra
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    public static class Program
    {
        public static void Main()
        {
            const string pattern = "([#|])(?<item>[A-Za-z\\s]+)\\1(?<date>\\d{2}\\/\\d{2}\\/\\d{2})\\1(?<calories>\\d{1,5})\\1";

            var foods = new List<Food>();

            var text = Console.ReadLine();

            var matches = Regex.Matches(text, pattern);

            foreach (Match match in matches)
            {
                var food = new Food()
                {
                    Name = match.Groups["item"].Value,
                    Date = match.Groups["date"].Value,
                    Calories = int.Parse(match.Groups["calories"].Value),
                };

                foods.Add(food);
            }

            var days = foods.Sum(f => f.Calories) / 2000;
            Console.WriteLine($"You have food to last you for: {days} days!");

            foreach (var food in foods)
            {
                Console.WriteLine($"Item: {food.Name}, Best before: {food.Date}, Nutrition: {food.Calories}");
            }
        }

        private class Food
        {
            public string Name { get; set; }

            public string Date { get; set; }

            public int Calories { get; set; }
        }
    }
}
