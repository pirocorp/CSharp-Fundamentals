using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.Sales_Report
{
    class Program
    {
        class Sale
        {
            public string Town { get; set; }
            public string Product { get; set; }
            public decimal Price { get; set; }
            public decimal Quantity { get; set; }
        }

        static Sale ReadSale()
        {
            string[] items = Console.ReadLine().Split();

            return new Sale()
            {
                Town = items[0],
                Product = items[1],
                Price = decimal.Parse(items[2]),
                Quantity = decimal.Parse(items[3]),
            };
        }

        static void Main()
        {
            var sales = ReadSales();
            var towns = sales.Select(s => s.Town).Distinct();

            foreach (string town in towns)
            {
                var salesByTown = sales.Where(s => s.Town == town)
                    .Select(s => s.Price * s.Quantity).Sum();
                Console.WriteLine("{0} -> {1:f2}", town, salesByTown);
            }

        }

        static List<Sale> ReadSales()
        {
            var n = int.Parse(Console.ReadLine());
            var sales = new List<Sale>();

            for (int i = 0; i < n; i++)
            {
                sales.Add(ReadSale());
            }

            return sales.OrderBy(x => x.Town).ToList();
        }
    }
}
