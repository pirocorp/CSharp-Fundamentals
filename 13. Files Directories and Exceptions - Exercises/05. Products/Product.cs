using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Products
{
    public class Product
    {
        public Product(string type, string name, decimal price, int quantity)
        {
            Type = type;
            Name = name;
            Price = price;
            Quantity = quantity;
        }

        public string Type { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        public static Product Parse(string inputData)
        {
            var tokens = inputData.Split(new []{' '}, StringSplitOptions.RemoveEmptyEntries);
            var type = tokens[1];
            var name = tokens[0];
            var price = decimal.Parse(tokens[2]);
            var quantity = int.Parse(tokens[3]);
            
            return new Product(type, name, price, quantity);
        }
    }
}
