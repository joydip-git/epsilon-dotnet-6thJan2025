namespace ISPApp;

public class Program
{
    public static void Main(string[] args)
    {
        Manager manager = new Manager();
        manager.AssignTask();
        manager.CreateSubTask();

        TeamLead teamLead = new TeamLead();
        teamLead.AssignTask();
        teamLead.CreateSubTask();
        teamLead.WorkOnTask();

        Programmer programmer = new Programmer();
        programmer.WorkOnTask();
    }
}
