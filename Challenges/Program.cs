using Challenges.Models;
using Challenges.Services;

namespace Challenges
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var filePath = Path.GetFullPath("Utility/product.csv");
            var parser = new CSVParser();
            var products = parser.ReadCsv<Product>(filePath, new CSVParsingOptions()).ToList();

            products.Add(new Product()
            {
                Id = 3,
                Name = "Banana",
                Price = 2.69m
            });

            parser.SaveCsv(products, filePath, new CSVParsingOptions());

            foreach(var product in products)
                Console.WriteLine(product);
        }
    }
}
