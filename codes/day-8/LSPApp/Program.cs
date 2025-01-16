namespace LSPApp;

public class Program
{
    public static void Main(string[] args)
    {
        SqlFileManager manager = new SqlFileManager();
        string allQueries = manager.GetQueriesFromFiles([new SqlFile("", "query1"), new SqlFile("", "query2")]);
        System.Console.WriteLine(allQueries);
    }
}
