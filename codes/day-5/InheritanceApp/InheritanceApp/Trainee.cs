namespace InheritanceApp
{
    internal class Trainee : Person
    {
        private string project;

        public Trainee()
        {
            Console.WriteLine("Trainee class default ctor");
        }
        public Trainee(string name, string subject, string company, string project)
            : base(name, subject, company)
        {
            Console.WriteLine("Trainee class parameterized ctor");

            //accessing inherited protected data members directly
            //this.name = name;
            //this.subjects = subjects;

            //accessing inherited private data members indirectly via the inherited public properties
            //this.Name = name;
            //this.Subjects = subjects;

            //explicit data members
            this.project = project;
        }

        public string Project
        {
            get { return project; }
            set { project = value; }
        }

        //re-implementation of base class GetInformation()
        public override string GetInformation()
        {
            return $"{base.GetInformation()}, Project:{project}";
        }
    }
}
