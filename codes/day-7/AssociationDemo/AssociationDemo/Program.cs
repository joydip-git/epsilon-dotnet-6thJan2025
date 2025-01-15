namespace AssociationDemo
{
    internal class Program
    {
        static void Main()
        {
            Category mobileCategory = new(1, "mobile", null);
            Category laptopCategory = new(2, "laptop", null);
            Category[] categories = [mobileCategory, laptopCategory];

            Product dellXps = new(1, "dell xps", 140000, categories[1]);
            Product onePlusThirteen = new(2, "One Plus 13", 55000, categories[0]);
            Product lenovoThinkpad = new(3, "Lenovo Thinkpad", 150000, categories[1]);
            Product iPhoneSixteen = new(4, "iPhone 16", 155000, categories[0]);
            Product[] products = [dellXps, onePlusThirteen, lenovoThinkpad, iPhoneSixteen];

            categories[0].Products = [onePlusThirteen, iPhoneSixteen];
            categories[1].Products = [dellXps, lenovoThinkpad];

            //select c.name from categories c join products p on p.cid = c.id
            if (products.Length > 0)
            {
                foreach (var p in products)
                {
                    Console.WriteLine($"{p.Name}->{p.Category.Name}");
                }
            }
            Console.WriteLine("\n");
            foreach (var c in categories)
            {
                Console.WriteLine($"{c.Name}\n______________________");

                Product[]? allProducts = c.Products;
                if (allProducts?.Length > 0)
                {
                    foreach (var product in allProducts)
                    {
                        Console.WriteLine($"{product.Name}");
                    }
                }
                Console.WriteLine("\n");
            }

            //Nullable<int> categoryId = 1;
            int? categoryId = 1;

            //HasValue checks whether null is stored or proper value is stored
            if (categoryId.HasValue)
            {
                //Console.WriteLine(categoryId.Value);
                Console.WriteLine(categoryId);
            }
            else
                Console.WriteLine("no value yet..");

            Console.Write("enter name: ");
            string? name = Console.ReadLine();

            //if (name != null)
            //    name = name.ToUpper());

            //Console.WriteLine(name);

            Console.WriteLine(name?.ToUpper());

            Console.Write("enter name: ");
            string namevalue = Console.ReadLine() ?? string.Empty;
            Console.WriteLine(namevalue != string.Empty ? namevalue.ToUpper() : "empty string");

            string? str;
            if ((str = Console.ReadLine()) != null)
            {
                Console.WriteLine(str);
            }

        }
    }
}
