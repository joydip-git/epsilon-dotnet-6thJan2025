namespace AbstractDemoApp
{
    abstract class DataSource
    {
        string sourcePath = string.Empty;

        public DataSource()
        {

        }

        public DataSource(string sourcePath)
        {
            this.sourcePath = sourcePath;
        }

        public string SourcePath { set => sourcePath = value; get => sourcePath; }

        //implementation of GetData depends on the child classes
        public abstract string GetData();
    }
}
