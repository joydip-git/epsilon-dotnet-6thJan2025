namespace ISPApp;

public class TeamLead : ILead, IProgrammer
{
    public void AssignTask()
    {
        Console.WriteLine("task assigned to programmer");
    }

    public void CreateSubTask()
    {
        Console.WriteLine("sub task created for programmers");
    }

    public void WorkOnTask()
    {
        Console.WriteLine("working on a task");
    }
}
