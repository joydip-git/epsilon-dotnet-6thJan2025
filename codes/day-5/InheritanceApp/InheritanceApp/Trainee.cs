namespace InheritanceApp
{
    internal class Trainee : Person
    {
        private string[] projects;

        public Trainee()
        {
            Console.WriteLine("Trainee class default ctor");
        }
        public Trainee(string name, string[] subjects, string[] projects)
            : base(name, subjects)
        {
            Console.WriteLine("Trainee class parameterized ctor");

            //accessing inherited protected data members directly
            //this.name = name;
            //this.subjects = subjects;

            //accessing inherited private data members indirectly via the inherited public properties
            //this.Name = name;
            //this.Subjects = subjects;

            //explicit data members
            this.projects = projects;
        }

        private string[] Projects
        {
            get { return projects; }
            set { projects = value; }
        }
    }
}
