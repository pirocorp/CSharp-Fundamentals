using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace _05.Products
{
    class Products
    {
        private static string dataBaseFile = "../../dataBase.txt";

        static void Main()
        {
            var dataBase = new List<Product>();
            InitializeDataBaseFromFile(dataBase);
            var inputData = Console.ReadLine();

            while (inputData != "exit")
            {
                if (inputData == "stock")
                {
                    WriteDataBaseToFile(dataBase);
                }
                else if (inputData == "analyze")
                {
                    PrintAllProductsFromFile();
                }
                else if (inputData == "sales")
                {
                    PrintAllActiveProducts(dataBase);
                }
                else
                {
                    var currentProduct = Product.Parse(inputData);

                    if (dataBase.Any(x => x.Name == currentProduct.Name && x.Type == currentProduct.Type))
                    {
                        var product = dataBase.Find(x =>
                            x.Name == currentProduct.Name && x.Type == currentProduct.Type);
                        product.Price = currentProduct.Price;
                        product.Quantity = currentProduct.Quantity;
                    }
                    else
                    {
                        dataBase.Add(currentProduct);
                    }

                }

                inputData = Console.ReadLine();
            }

        }

        private static void InitializeDataBaseFromFile(List<Product> dataBase)
        {
            try
            {
                var productsFromFile = File.ReadAllLines(dataBaseFile)
                    .Select(Product.Parse)
                    .ToList();

                dataBase = productsFromFile;
            }
            catch (Exception e)
            {
            }
        }

        private static void PrintAllActiveProducts(List<Product> dataBase)
        {
            var typeOfProducts = dataBase.Select(x => x.Type).Distinct().ToArray();
            var sumByType = new Dictionary<string, decimal>();

            for (var i = 0; i < typeOfProducts.Length; i++)
            {
                var currentType = typeOfProducts[i];
                var currentSum = dataBase.Where(x => x.Type == currentType).Sum(x => x.Price * x.Quantity);
                sumByType.Add(currentType, currentSum);
            }

            sumByType = sumByType.OrderBy(x => x.Value).ToDictionary(x => x.Key, x => x.Value);

            foreach (var type in sumByType)
            {
                if (type.Value != 0)
                {
                    Console.WriteLine($"{type.Key}: ${type.Value:F2}");
                }
            }
        }

        private static void PrintAllProductsFromFile()
        {
            try
            {
                var productsFromFile = File.ReadAllLines(dataBaseFile)
                    .Select(Product.Parse)
                    .OrderBy(x => x.Type)
                    .ToList();

                foreach (var product in productsFromFile)
                {
                    Console.WriteLine($"{product.Type}, Product: {product.Name}");
                    Console.WriteLine($"Price: ${product.Price:F2}, Amount Left: {product.Quantity}");
                }
            }
            catch 
            {
                Console.WriteLine($"No products stocked");
            }
        }

        private static void WriteDataBaseToFile(List<Product> dataBase)
        {
            var result = new StringBuilder();

            for (var i = 0; i < dataBase.Count; i++)
            {
                result.AppendLine($"{dataBase[i].Name} {dataBase[i].Type} {dataBase[i].Price} {dataBase[i].Quantity}");
            }

            File.WriteAllText(dataBaseFile, result.ToString().Trim());
        }
    }
}
