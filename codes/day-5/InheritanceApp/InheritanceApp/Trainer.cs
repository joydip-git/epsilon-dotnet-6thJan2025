namespace InheritanceApp
{
    internal class Trainer : Person
    {
        private string[] clients;

        public Trainer() : base()
        {
            Console.WriteLine("Trainer class default ctor");
        }
        public Trainer(string name, string[] subjects, string[] clients)
            : base(name, subjects)
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
            this.clients = clients;
        }

        private string[] Clients
        {
            get { return clients; }
            set { clients = value; }
        }
    }
}
