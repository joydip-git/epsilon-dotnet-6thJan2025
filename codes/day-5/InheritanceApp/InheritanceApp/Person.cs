namespace InheritanceApp
{
    internal class Person
    {
        //protected string name = string.Empty;
        //protected string[] subjects;

        private string name = string.Empty;
        private string[] subjects;

        public Person()
        {
            Console.WriteLine("Person class default ctor");
        }

        public Person(string name, string[] subjects)
        {
            Console.WriteLine("Person class parameterized ctor");
            this.name = name;
            this.subjects = subjects;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string[] Subjects
        {
            get { return subjects; }
            set { subjects = value; }
        }
    }
}
