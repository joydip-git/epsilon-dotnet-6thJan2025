namespace DependencyInjectionApp
{
    public class ProductDataAccessComponent : IDataAccessComponent
    {
        public string GetData()
        {
            return "data";
        }
    }
}
