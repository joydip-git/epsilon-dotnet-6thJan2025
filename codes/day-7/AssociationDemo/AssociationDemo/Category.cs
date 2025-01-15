namespace AssociationDemo
{
    class Category
    {
        private readonly int id;
        private string name = string.Empty;

        //navigation property
        //one to many relationship
        private Product[]? products;

        public Category()
        {

        }

        //products -> optional argument with default value
        public Category(int id, string name, Product[]? products = null)
        {
            this.id = id;
            this.name = name;
            this.products = products;
        }

        public int Id => id;
        public string Name { get => name; set => name = value; }
        public Product[]? Products { get => products; set => products = value; }
    }
}
