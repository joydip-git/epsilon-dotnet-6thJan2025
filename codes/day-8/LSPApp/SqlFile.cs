namespace LSPApp;

/*
public class SqlFile : ReadOnlySqlFile, IWritableSqlFile
{
    public SqlFile()
    {

    }
    public SqlFile(string filePath, string fileText) : base(filePath, fileText)
    {

    }
    public string SaveText()
    {
        //code to save text into an sql file
        return "query saved in file in the current app directory";
    }
}
*/
public class SqlFile : IReadableSqlFile, IWritableSqlFile
{
    string filePath = string.Empty;
    string fileText = string.Empty;

    public SqlFile()
    {

    }
    public SqlFile(string filePath, string fileText)
    {
        this.filePath = filePath;
        this.fileText = fileText;
    }

    public string FilePath { get => filePath; set => filePath = value; }
    public string FileText { get => fileText; set => fileText = value; }

    public string LoadText()
    {
        return "query from file loaded";
    }


    public string SaveText()
    {
        //code to save text into an sql file
        return "query saved in file in the current app directory";
    }
}
