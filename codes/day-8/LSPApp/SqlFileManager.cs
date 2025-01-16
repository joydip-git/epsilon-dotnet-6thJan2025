using System.Text;

namespace LSPApp;

public class SqlFileManager
{
    // SqlFile[] sqlFiles;

    // public SqlFileManager()
    // {

    // }
    // public SqlFileManager(SqlFile[] sqlFiles)
    // {
    //     this.sqlFiles = sqlFiles;
    // }

    //public SqlFile[] SqlFiles { get => sqlFiles; set => sqlFiles = value; }

    public string GetQueriesFromFiles(IReadableSqlFile[] readableSqlFiles)
    // public string GetQueriesFromFiles(ReadOnlySqlFile[] readableSqlFiles)
    {
        StringBuilder stringBuilder = new StringBuilder();
        foreach (var item in readableSqlFiles)
        {
            stringBuilder.Append(item.LoadText() + Environment.NewLine);
        }
        return stringBuilder.ToString();
    }

    public void SaveQueryInFiles(IWritableSqlFile[] writableSqlFiles)
    {
        foreach (var item in writableSqlFiles)
        {
            item.SaveText();
        }
    }
}
