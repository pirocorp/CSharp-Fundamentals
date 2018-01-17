using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Shopping_Spree
{
    class Program
    {
        static void Main()
        {
            var productPrices = new Dictionary<string, decimal>();
            var budget = decimal.Parse(Console.ReadLine());
            var indputData = Console.ReadLine();

            while (indputData != "end")
            {
                var tokens = indputData.Split(' ').ToArray();
                var key = tokens[0];
                var value = decimal.Parse(tokens[1]);

                if (!productPrices.ContainsKey(key) || (productPrices.ContainsKey(key) && productPrices[key] > value))
                {
                    productPrices[key] = value;
                }

                indputData = Console.ReadLine();
            }

            var sum = productPrices.Sum(x => x.Value);

            if (budget >= sum)
            {
                var result = productPrices.OrderByDescending(x => x.Value).ThenBy(x => x.Key.Length);

                foreach (var item in result)
                {
                    var product = item.Key;
                    var price = item.Value;
                    Console.WriteLine($"{product} costs {price:f2}");
                }
            }
            else
            {
                Console.WriteLine($"Need more money... Just buy banichka");
            }
        }
    }
}
