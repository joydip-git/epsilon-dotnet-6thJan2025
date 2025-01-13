namespace AbstractDemoApp
{
    internal class SqlDataSource : DataSource
    {
        public SqlDataSource() { }
        public SqlDataSource(string sqlConnection) : base(sqlConnection)
        {
        }
        public override string GetData()
        {
            return $"sql database table data";
        }
    }
}
