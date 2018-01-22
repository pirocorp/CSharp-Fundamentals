using System;

namespace _08.Advertisement_Message
{
    class Program
    {
        static void Main()
        {
            var phrases = new []
            {
                "Excellent product.",
                "Such a great product.",
                "I always use that product.",
                "Best product of its category.",
                "Exceptional product.",
                "I can’t live without this product."
            };

            var events = new[]
            {
                "Now I feel good.",
                "I have succeeded with this product.",
                "Makes miracles. I am happy of the results!",
                "I cannot believe but now I feel awesome.",
                "Try it yourself, I am very satisfied.",
                "I feel great!"
            };

            var autors = new[]
            {
                "Diana", "Petya", "Stella", "Elena", "Katya", "Iva", "Annie", "Eva"
            };

            var cities = new[]
            {
                "Burgas", "Sofia", "Plovdiv", "Varna", "Ruse"
            };

            var n = int.Parse(Console.ReadLine());
            var randomGenerator = new Random();


            for (int i = 0; i < n; i++)
            {
                var p = randomGenerator.Next(0, phrases.Length);
                var e = randomGenerator.Next(0, events.Length);
                var a = randomGenerator.Next(0, autors.Length);
                var c = randomGenerator.Next(0, cities.Length);
                Console.WriteLine($"{phrases[p]} {events[e]} {autors[a]} – {cities[c]}.");
            }

        }
    }
}
