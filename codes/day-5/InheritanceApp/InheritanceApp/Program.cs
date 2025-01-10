namespace InheritanceApp
{
    internal class Program
    {
        static void Main(string[] args)
        {


            //up-casting
            //Person venkateshTrainee = new Trainee("venkatesh", "C#", "Epsilon", "CITA");

            //can access ONLY inherited members of base class from child class object
            //Console.WriteLine(
            //   venkateshTrainee.Name
            //   + " "
            //   + venkateshTrainee.Company
            //   + " "
            //   + venkateshTrainee.Subject
            //   );

            Trainee venkateshTrainee = new Trainee("venkatesh", "C#", "Epsilon", "CITA");

            //you can access all members of child class (inherited members of base + explicit members of child)
            //Console.WriteLine(
            //    venkateshTrainee.Name
            //    + " "
            //    + venkateshTrainee.Company
            //    + " "
            //    + venkateshTrainee.Subject
            //    + " "
            //    + venkateshTrainee.Project
            //    );

            PrintInformation(venkateshTrainee);
            //Console.WriteLine(venkateshTrainee.GetInformation());

            Trainer joydipTrainer = new Trainer("joydip", "C#", "Knowledgeworks", "Epsilon");

            //you can access all members of child class (inherited members of base + explicit members of child)
            //Console.WriteLine(
            //    joydipTrainer.Name
            //    + " "
            //    + joydipTrainer.Company
            //    + " "
            //    + joydipTrainer.Subject
            //    + " "
            //    + joydipTrainer.Client
            //    );

            PrintInformation(joydipTrainer);
            //Console.WriteLine(joydipTrainer.GetInformation());
        }
        //public static void PrintInformation(Trainer trainer)
        //{
        //    Console.WriteLine(trainer.GetInformation());
        //}
        //public static void PrintInformation(Trainee trainee)
        //{
        //    Console.WriteLine(trainee.GetInformation());
        //}
        public static void PrintInformation(Person person)
        {
            Console.WriteLine("Type of instance: " + person.GetType().Name);
            Console.WriteLine(person.GetInformation());
        }
    }
}
