using Microsoft.AspNetCore.Mvc;
using ProductManagementSystem.UserInterface.Models;

namespace ProductManagementSystem.UserInterface.Controllers
{
    [Route("product")]
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly ILogger<ProductController> _logger;

        public ProductController(IProductRepository productRepository, ILogger<ProductController> logger)
        {
            _productRepository = productRepository;
            _logger = logger;
        }

        //GET request
        [HttpGet]
        [Route("all/{message?}")]
        public IActionResult GetAll(string? message)
        {
            try
            {
                List<Product>? products = _productRepository.FetchAll();
                ViewData["DeleteMessage"] = message;
                return View(products);
            }
            catch (Exception ex)
            {
                return this.Problem(ex.ToString());
            }
        }

        //GET request
        [HttpGet]
        [Route("get/{x}")]
        //the value/data for "id" route parameter will be mapped from string to int automatically
        public IActionResult Get([FromRoute(Name = "x")] int id)
        {
            try
            {
                Product? product = _productRepository.Fetch(id);

                return View("ProductInfo", product);
            }
            catch (Exception ex)
            {
                return this.Problem(ex.ToString());
            }
        }

        //GET request
        [HttpGet]
        [Route("add")]
        public IActionResult Add()
        {
            try
            {
                return View("ProductEntryForm");
            }
            catch (Exception ex)
            {
                return this.Problem(ex.ToString());
            }
        }

        [HttpPost]
        [Route("add")]
        //the value/data for every product related property as received via the request body will be fetched and then model binder witll produce an instance of Product class, by assigning the request data values to the respective properties of Product class object (this is possible because you have used strongly typed view as well as used HTML helper to generate the HTML controls by binding the controls with respective properties of Product class)
        public IActionResult Add(Product product)
        {
            try
            {
                _logger.LogInformation(product.ToString());
                var p = _productRepository.Insert(product);
                if (p != null)
                {
                    this.ViewData["message"] = "Product Added Successfully";
                }
                else
                {
                    this.ViewData["message"] = "Product Could not be added";
                }
            }
            catch (Exception ex)
            {
                this.ViewData["message"] = ex.ToString();
            }
            return View("ProductEntryForm");
        }

        [HttpGet]
        [Route("update/{id}")]
        public IActionResult Update([FromRoute] int id)
        {
            try
            {
                var p = _productRepository.Fetch(id);
                if (p != null)
                {
                    //this.ViewBag.ErrorMessage = "";
                    return View("ProductUpdateForm", p);
                }
                else
                {
                    this.ViewBag.ErrorMessage = "Could nt get the product data";
                    return View("ProductUpdateForm");
                }
            }
            catch (Exception ex)
            {
                this.ViewBag.ErrorMessage = ex.ToString();
                return View("ProductUpdateForm");
            }
        }

        [HttpPost]
        [Route("update/{id}")]
        public IActionResult Update([FromRoute] int id, [FromForm] Product product)
        {
            try
            {
                var p = _productRepository.Update(id, product);
                if (p != null)
                    ViewData["UpdateMessage"] = "Updated Sucessfully";
                else
                    ViewData["UpdateMessage"] = "could nt update";
            }
            catch (Exception ex)
            {
                ViewData["UpdateMessage"] = ex.ToString();
            }
            return View("ProductUpdateForm", product);
        }

        [HttpGet]
        [Route("delete/{productId}")]
        public IActionResult Delete([FromRoute(Name = "productId")] int id)
        {
            try
            {
                _logger.LogInformation(id.ToString());
                var result = _productRepository.Delete(id);
                if (result > 0)
                {
                    return this.RedirectToAction("GetAll", new { message = "deleted successfully" });
                }
                else
                    return RedirectToAction("GetAll", new { message = "could not delete" });
            }
            catch (Exception ex)
            {
                return RedirectToAction("GetAll", new { message = ex.ToString() });
            }

        }
    }
}
