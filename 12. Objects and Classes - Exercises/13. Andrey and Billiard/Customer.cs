using System.Collections.Generic;

namespace _13.Andrey_and_Billiard
{
    class Customer
    {
        public string Name { get; set; }
        public Dictionary<string, int> BoughtProducts { get; set; }

        public decimal Bill(Dictionary<string, decimal> priceList)
        {
            var result = 0m;

            foreach (var product in BoughtProducts)
            {
                var productName = product.Key;
                var productQuantaty = product.Value;
                var productPrice = priceList[productName];

                result += productPrice * productQuantaty;
            }

            return result;
        }
    }
}
