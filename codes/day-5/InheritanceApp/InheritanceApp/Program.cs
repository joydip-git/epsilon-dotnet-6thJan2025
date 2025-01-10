namespace InheritanceApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Trainee venkateshTrainee = new Trainee("venkatesh", ["Java", "C#"], ["CITA"]);
            Trainer joydipTrainer = new Trainer("joydip", ["Java", "C#", "JavaScript"], ["Epsilon", "Siemens"]);
        }
    }
}
