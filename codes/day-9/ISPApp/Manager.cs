namespace ISPApp;

public class Manager : ILead
{
    public void AssignTask()
    {
        Console.WriteLine("task assigned to team lead");
    }

    public void CreateSubTask()
    {
        Console.WriteLine("sub task created for team lead");
    }
}
