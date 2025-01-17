using System.Text;

namespace LSPApp.WithoutLSP;

public class SqlFileManager
{

    public string GetQueriesFromFiles(SqlFile[] readableSqlFiles)
    {
        StringBuilder stringBuilder = new StringBuilder();
        foreach (var item in readableSqlFiles)
        {
            stringBuilder.Append(item.LoadText() + Environment.NewLine);
        }
        return stringBuilder.ToString();
    }

    public void SaveQueryInFiles(SqlFile[] writableSqlFiles)
    {
        foreach (var item in writableSqlFiles)
        {
            if (!(item is ReadOnlySqlFile))
            {
                item.SaveText();
            }
        }
    }
}
