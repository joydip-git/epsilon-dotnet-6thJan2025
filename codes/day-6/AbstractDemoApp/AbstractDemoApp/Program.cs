namespace AbstractDemoApp
{
    internal class Program
    {
        static void Main()
        {
            B objB = new B(1, "joydip");
            Console.WriteLine(objB.Name);
            Console.WriteLine(objB.GetInfo());

            //up-casting (NOT creating instance of A, rather objAB is just a reference variable of A class, which stores reference of an object of its child class, B)
            A objAB = objB;
            Console.WriteLine(objAB.Name);
            Console.WriteLine(objAB.GetInfo());

            SqlDataSource sqlDataSource = new SqlDataSource("sql database path");
            //Console.WriteLine(sqlDataSource.GetData());
            PrintData(sqlDataSource);

            TextFileDataSource txtDataSource = new TextFileDataSource("file path");
            //Console.WriteLine(txtDataSource.GetData());
            PrintData(txtDataSource);

            Postman anilPostMan = new("anil");
            Console.WriteLine(anilPostMan.DeliverMessage());

            //up-casting to abstract base class
            Messenger postman = anilPostMan;            
            Console.WriteLine(postman.DeliverMessage());

            //up-casting to interface
            IDeliveryPerson deliveryPerson = postman;
            Console.WriteLine(deliveryPerson.DeliverMessage());
        }

        static void PrintData(DataSource dataSource)
        {
            Console.WriteLine(dataSource.GetData());
        }
    }
}
