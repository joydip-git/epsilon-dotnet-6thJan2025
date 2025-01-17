namespace FurtherNewFeaturesInCSharp
{
    class Product
    {
        public required int Id { get; set; }
        public required string Name { get; set; }

        //auto-roperty initializer (6.0)
        //public string Description { get; set; } = string.Empty;

        public string? Description { get; set; }
        public decimal? Price { get; set; }

        public Product()
        {

        }

        //public Product(int id, string name, string description, decimal? price)
        public Product(int id, string name, string? description = null, decimal? price = 0)
        {
            Id = id;
            Name = name;
            Description = description;
            Price = price;
        }
    }
}
