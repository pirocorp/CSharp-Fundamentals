using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Wardrobe
{
    class Wardrobe
    {
        static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var wardrobe = new Dictionary<string, Dictionary<string, int>>();
            // <color <clothing, count>>

            for (int i = 0; i < n; i++)
            {
                var tokens = Console.ReadLine()
                    .Split(new[] {" -> "}, StringSplitOptions.RemoveEmptyEntries);
                var color = tokens[0];
                var clothingItems = tokens[1].Split(',');

                if (!wardrobe.ContainsKey(color))
                {
                    wardrobe[color] = new Dictionary<string, int>();
                }

                for (int j = 0; j < clothingItems.Length; j++)
                {
                    var clothing = clothingItems[j];
                    if (!wardrobe[color].ContainsKey(clothing))
                    {
                        wardrobe[color][clothing] = 0;
                    }

                    wardrobe[color][clothing]++;
                }
            }

            var inputCommand = Console.ReadLine().Split(' ');
            var searchedColor = inputCommand[0];
            var searchedItem = inputCommand[1];

            foreach (var kvp in wardrobe)
            {
                var color = kvp.Key;
                var items = kvp.Value;
                Console.WriteLine($"{color} clothes:");
                foreach (var clothing in items)
                {
                    var item = clothing.Key;
                    var itemNumbers = clothing.Value;
                    Console.Write($"* {item} - {itemNumbers}");
                    if (color == searchedColor && item == searchedItem)
                    {
                        Console.Write(" (found!)");
                    }

                    Console.WriteLine();
                }
            }

        }
    }
}
