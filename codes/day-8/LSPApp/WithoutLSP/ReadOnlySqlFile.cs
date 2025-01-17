namespace LSPApp.WithoutLSP;

public class ReadOnlySqlFile
{
    string filePath = string.Empty;
    string fileText = string.Empty;

    public ReadOnlySqlFile()
    {

    }
    public ReadOnlySqlFile(string filePath, string fileText)
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
}
