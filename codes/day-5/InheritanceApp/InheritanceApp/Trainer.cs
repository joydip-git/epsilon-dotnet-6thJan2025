namespace InheritanceApp
{
    internal class Trainer : Person
    {
        private string client;

        public Trainer() : base()
        {
            Console.WriteLine("Trainer class default ctor");
        }
        public Trainer(string name, string subject, string company, string client)
            : base(name, subject, company)
        {
            Console.WriteLine("Trainer class parameterized ctor");

            //accessing inherited protected data members directly
            //this.name = name;
            //this.subjects = subjects;

            //accessing inherited private data members indirectly via the inherited public properties
            //this.Name = name;
            //this.Subjects = subjects;

            //base.Name = name;
            //base.Subjects = subjects;

            //explicit data members
            this.client = client;
        }

        public string Client
        {
            get { return client; }
            set { client = value; }
        }

        //re-implementation of base class GetInformation()
        public override string GetInformation()
        {
            return $"{base.GetInformation()}, Client:{client}";
        }
    }
}
