using Microsoft.AspNetCore.Mvc;
using ProductManagementSystem.UserInterface.Models;

namespace ProductManagementSystem.UserInterface.Controllers
{
    [Route("product")]
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [Route("all")]
        public IActionResult GetAll()
        {
            try
            {
                List<Product>? products = _productRepository.FetchAll();

                return View(products);
            }
            catch (Exception)
            {

                throw;
            }
        }
        [Route("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                Product? product = _productRepository.Fetch(id);

                return View("ProductInfo", product);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
