namespace Challenges.Entities
{
    public class Product
    {
        public string Name { get; set; }
        public Category Category { get; set; }
        public decimal BasePrice { get; set; }
    }

    public enum Category
    {
        Tablets,
        SmartPhones,
        Adapters
    }
}
