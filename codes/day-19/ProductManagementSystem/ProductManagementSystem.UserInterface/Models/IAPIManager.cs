
namespace ProductManagementSystem.UserInterface.Models
{
    public interface IAPIManager
    {
        Task<bool> SendRequestToAddProduct(ProductCommandViewModel product);
        Task<bool> SendRequestToDeleteProduct(int id);
        Task<ProductQueryViewModel?> SendRequestToFetchProductById(int id);
        Task<IEnumerable<ProductQueryViewModel>?> SendRequestToFetchProducts();
        Task<bool> SendRequestToUpdateProduct(int id, ProductCommandViewModel product);
    }
}