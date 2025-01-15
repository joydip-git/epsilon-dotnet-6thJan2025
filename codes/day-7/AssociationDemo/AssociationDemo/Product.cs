namespace AssociationDemo
{
    class Product
    {
        private readonly int id;
        private string name = string.Empty;
        private decimal price;
        private int? categoryId;

        //navigation (Association) property
        //One to one relationship
        private Category? category;

        public Product()
        {

        }

        //categoryId: optional argument with default value
        public Product(int id, string name, decimal price, Category? category = null, Nullable<int> categoryId = null)
        {
            this.id = id;
            this.name = name;
            this.price = price;
            this.categoryId = categoryId;
            this.category = category;
        }

        public int Id => id;

        public string Name { get => name; set => name = value; }
        public decimal Price { get => price; set => price = value; }
        public int? CategoryId { get => categoryId; set => categoryId = value; }
        public Category? Category { get => category; set => category = value; }

    }
}
