using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.ProductShop
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            var revisonResult = new SortedDictionary<string, Dictionary<string, double>>();

            while (input != "Revision")
            {
                var shopInfo = input.Split(", ", StringSplitOptions.RemoveEmptyEntries);

                var shop = shopInfo[0];
                var product = shopInfo[1];
                var price = double.Parse(shopInfo[2]);

                if (!revisonResult.ContainsKey(shop))
                {
                    revisonResult.Add(shop, new Dictionary<string, double>());
                }
                revisonResult[shop].Add(product, price);

                input = Console.ReadLine();
            }

            foreach (var shop in revisonResult)
            {
                Console.WriteLine($"{shop.Key}->");

                foreach (var product in shop.Value)
                {
                    Console.WriteLine($"Product: {product.Key}, Price: {product.Value}");
                }
            }

        }
    }
}
