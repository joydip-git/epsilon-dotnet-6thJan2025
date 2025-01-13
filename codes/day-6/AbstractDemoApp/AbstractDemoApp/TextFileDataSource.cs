namespace AbstractDemoApp
{
    internal class TextFileDataSource : DataSource
    {
        public TextFileDataSource() { }
        public TextFileDataSource(string filePath) : base(filePath) { }

        public override string GetData()
        {
            return "text file data";
        }
    }
}
