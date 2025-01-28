namespace ProductManagementSystem.UserInterface.Models
{
    public interface IProductRepository : IEpsilonDbRepository<Product, int>
    {
        List<Product>? FilterProductsByName(string name = "");
    }
}
