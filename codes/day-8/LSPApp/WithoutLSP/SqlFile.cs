namespace LSPApp.WithoutLSP;


public class SqlFile : ReadOnlySqlFile
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
