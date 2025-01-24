using Microsoft.AspNetCore.Identity.Data;

namespace FirstCoreWebApp.Infrastructure
{
    public class RequestLogger : IRequestLogger
    {
        public void Log(string data)
        {
            StreamWriter writer = new("log.txt", true);
            writer.WriteLine(data);
            writer.Flush();
            writer.Close();
        }
    }
}
