using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13.Andrey_and_Billiard
{
    class Program
    {
        static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var priceList = new Dictionary<string, decimal>();
            var inputData = string.Empty;
            var clientList = new List<Customer>();
            GeneratePriceList(n, priceList);
            inputData = Console.ReadLine();
            GenerateClientList(inputData, priceList, clientList);

            foreach (var client in clientList.OrderBy(x => x.Name))
            {
                var clientName = client.Name;
                var productsBought = client.BoughtProducts;
                var bill = client.Bill(priceList);
                Console.WriteLine($"{clientName}");
                productsBought.ToList().ForEach(x => Console.WriteLine($"-- {x.Key} - {x.Value}"));
                Console.WriteLine($"Bill: {bill:f2}");
            }

            Console.WriteLine($"Total bill: {clientList.Sum(x => x.Bill(priceList)):f2}");
        }

        private static void GenerateClientList(string inputData, Dictionary<string, decimal> priceList, List<Customer> clientList)
        {
            while (inputData != "end of clients")
            {
                var tokens = inputData.Split(new[] {'-', ','}, StringSplitOptions.RemoveEmptyEntries);
                var clientName = tokens[0];
                var productName = tokens[1];
                var quantaty = int.Parse(tokens[2]);

                if (priceList.ContainsKey(productName))
                {
                    if (!clientList.Any(x => x.Name == clientName))
                    {
                        var currentClient = new Customer()
                        {
                            Name = clientName,
                            BoughtProducts = new Dictionary<string, int>()
                        };

                        clientList.Add(currentClient);
                    }

                    if (clientList.Count > 0)
                    {
                        var currentClient = clientList.Where(x => x.Name == clientName).First();

                        if (!currentClient.BoughtProducts.ContainsKey(productName))
                        {
                            currentClient.BoughtProducts[productName] = 0;
                        }

                        currentClient.BoughtProducts[productName] += quantaty;
                    }
                }

                inputData = Console.ReadLine();
            }
        }

        private static void GeneratePriceList(int n, Dictionary<string, decimal> priceList)
        {
            string inputData;
            for (int i = 0; i < n; i++)
            {
                inputData = Console.ReadLine();
                var tokens = inputData.Split(new[] {'-'}, StringSplitOptions.RemoveEmptyEntries);
                var productName = tokens[0];
                var price = decimal.Parse(tokens[1]);

                if (!priceList.ContainsKey(productName))
                {
                    priceList[productName] = price;
                }

                priceList[productName] = price;
            }
        }
    }

}
