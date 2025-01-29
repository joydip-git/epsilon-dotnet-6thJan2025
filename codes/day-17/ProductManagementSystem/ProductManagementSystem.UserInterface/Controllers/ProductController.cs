using Microsoft.AspNetCore.Mvc;
using ProductManagementSystem.UserInterface.Models;
using System.Security.Principal;

namespace ProductManagementSystem.UserInterface.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly ILogger<ProductController> _logger;

        public ProductController(IProductRepository productRepository, ILogger<ProductController> logger)
        {
            _productRepository = productRepository;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet, ActionName("all")]
        // the name of view file for GetAll action is "GetAll.csthtml". So, when the request hits this endpoint MVC will look for the view with the same name as that of the action name, generally.
        // since you now used ActionName to create alias for GetAll method, MVC will expect the view file name as "all.cshtml". Kindly pass the view name explicitly in the View() method to avoid any confusion
        public IActionResult GetAll([FromRoute(Name = "id")] string message)
        {
            try
            {
                List<Product>? products = _productRepository.FetchAll();
                ViewData["message"] = message;
                //return View(products);
                return View("GetAll", products);
            }
            catch (Exception ex)
            {
                return this.Problem(ex.ToString());
            }
        }

        [HttpGet]
        public IActionResult Get(int id)
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

        [HttpGet]
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
        public IActionResult Add([FromForm] Product product)
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
        public IActionResult Update(int id)
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
        public IActionResult Update(int id, [FromForm] Product product)
        {
            try
            {
                var p = _productRepository.Update(id, product);
                if (p != null)
                {
                    //ViewData["UpdateMessage"] = "Updated Sucessfully";
                    return RedirectToAction("all", new { id = "Updated Successfully" });
                }
                else
                {
                    ViewData["UpdateMessage"] = "could not update";
                    return View("ProductUpdateForm", product);
                }
            }
            catch (Exception ex)
            {
                ViewData["UpdateMessage"] = ex.ToString();
                return View("ProductUpdateForm", product);
            }
            
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            try
            {
                _logger.LogInformation(id.ToString());
                var result = _productRepository.Delete(id);
                if (result > 0)
                {
                    //ViewData["DeleteMessage"] = "deleted successfully";
                    ViewBag.Hi = "Hi...";
                    return RedirectToAction("GetAll", new { id = "deleted successfully" });
                }
                else
                    //ViewData["DeleteMessage"] = "could not delete";
                    return RedirectToAction("GetAll", new { id = "could not delete" });
            }
            catch (Exception ex)
            {
                //ViewData["DeleteMessage"] =ex.ToString() ;
                return RedirectToAction("GetAll", new { id = ex.ToString() });
            }

        }
    }
}
