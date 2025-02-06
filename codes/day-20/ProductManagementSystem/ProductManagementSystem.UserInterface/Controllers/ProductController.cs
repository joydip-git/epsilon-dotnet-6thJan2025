using Microsoft.AspNetCore.Mvc;
using ProductManagementSystem.UserInterface.Filters;
using ProductManagementSystem.UserInterface.Models;

namespace ProductManagementSystem.UserInterface.Controllers
{
    //primary constructor    
    public class ProductController(IProductApiManager manager) : Controller
    {
        //use primary constructor instead of the following code
        //private readonly IAPIManager manager;
        //public ProductController(IAPIManager manager)
        //{
        // this.manager = manager;
        //}

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [ProtectedRouteFilter]
        public async Task<IActionResult> GetAll([FromRoute(Name = "routedata")] string message)
        {
            try
            {
                var allProducts = await manager.SendRequestToFetchProducts();
                if (allProducts != null)
                {
                    ViewData["message"] = message;
                    return View("GetAll", allProducts);
                }
                else
                {
                    return View("GetAll");
                }
            }
            catch (Exception ex)
            {
                return this.Problem(ex.ToString());
            }
        }

        [HttpGet]
        [ProtectedRouteFilter]
        public async Task<IActionResult> Get([FromQuery(Name = "id")] int id)
        {
            try
            {
                var product = await manager.SendRequestToFetchProductById(id);
                return product != null ? View("ProductInfo", product) : View("ProductInfo");
            }
            catch (Exception ex)
            {
                return this.Problem(ex.ToString());
            }
        }

        [HttpGet]
        [ProtectedRouteFilter]
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
        [ProtectedRouteFilter]
        public async Task<IActionResult> Add([FromForm] ProductCommandViewModel product)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var status = await manager.SendRequestToAddProduct(product);
                    if (status)
                    {
                        return RedirectToAction("GetAll", new { routedata = "Product Added Successfully" });
                    }
                    else
                    {
                        this.ViewData["message"] = "Product Could not be added";
                        return View("ProductEntryForm");
                    }
                }
                else
                {
                    this.ViewData["message"] = "Product Validation failed";
                    return View("ProductEntryForm");
                }
            }
            catch (Exception ex)
            {
                this.ViewData["message"] = ex.ToString();
                return View("ProductEntryForm");
            }

        }

        [HttpGet]
        [ProtectedRouteFilter]
        public async Task<IActionResult> Update([FromQuery] int id)
        {
            try
            {
                var p = await manager.SendRequestToFetchProductById(id);
                if (p != null)
                {
                    return View("ProductUpdateForm", p);
                }
                else
                {
                    return View("ProductUpdateForm");
                }
            }
            catch (Exception ex)
            {
                this.ViewBag.Message = ex.ToString();
                return View("ProductUpdateForm");
            }
        }

        [HttpPost]
        [ProtectedRouteFilter]
        public async Task<IActionResult> Update(int id, [FromForm] ProductQueryViewModel product)
        {
            try
            {
                var status = await manager.SendRequestToUpdateProduct(id, new ProductCommandViewModel { Name = product.Name, Description = product.Description, Price = product.Price });
                if (status)
                {
                    return RedirectToAction("GetAll", new { routedata = "Updated Sucessfully" });
                }
                else
                {
                    ViewBag.Message = "could not update";
                    return View("ProductUpdateForm", product);
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.ToString();
                return View("ProductUpdateForm", product);
            }

        }

        [HttpGet]
        [ProtectedRouteFilter]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var result = await manager.SendRequestToDeleteProduct(id);
                if (result)
                {
                    return RedirectToAction("GetAll", new { routedata = "deleted successfully" });
                }
                else
                    return RedirectToAction("GetAll", new { routedata = "could not delete" });
            }
            catch (Exception ex)
            {
                return RedirectToAction("GetAll", new { routedata = ex.ToString() });
            }
        }
    }
}
