namespace InheritanceApp
{
    internal class Person
    {
        //protected string name = string.Empty;
        //protected string[] subjects;

        private string name = string.Empty;
        private string subject;
        private string company;

        public Person()
        {
            Console.WriteLine("Person class default ctor");
        }

        public Person(string name, string subject, string company)
        {
            Console.WriteLine("Person class parameterized ctor");
            this.name = name;
            this.subject = subject;
            this.company = company;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Subject
        {
            get { return subject; }
            set { subject = value; }
        }
        public string Company
        {
            get { return company; }
            set { company = value; }
        }

        public virtual string GetInformation()
        {
            return $"Name:{this.name}, Company: {this.company}, Subject:{subject}";
        }
    }
}
