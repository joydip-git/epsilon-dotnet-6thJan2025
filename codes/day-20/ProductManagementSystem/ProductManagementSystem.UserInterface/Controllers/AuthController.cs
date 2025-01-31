using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using ProductManagementSystem.UserInterface.Models;

namespace ProductManagementSystem.UserInterface.Controllers
{
    public class AuthController(IUserApiManager userApiManager) : Controller
    {
        [HttpGet]
        public IActionResult Login([FromQuery] string? redirectUrl)
        {
            ViewData["redirectUrl"] = redirectUrl;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromQuery] string? redirectUrl, [FromForm] UserViewModel user)
        {
            try
            {
                var token = await userApiManager.SendRequestToAuthenticateUser(user);
                if (token != null && token != string.Empty)
                {
                    AuthToken.Token = token;
                    //if (string.IsNullOrEmpty(redirectUrl))
                    //    return RedirectToAction("Index", "Product");
                    //else
                    //    return RedirectToRoute(redirectUrl);
                    return RedirectToAction("Index", "Product");
                }
                else
                {
                    ViewData["message"] = "Invalid User";
                    return View(user);
                }
            }
            catch (Exception ex)
            {
                ViewData["message"] = ex.Message;
                return View(user);
            }
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromForm] UserViewModel user)
        {
            try
            {
                var status = await userApiManager.SendRequestToRegisterUser(user);
                if (status)
                    return RedirectToAction("Login");
                else
                {
                    ViewData["message"] = "could not register or the user already exists";
                    return View(user);
                };
            }
            catch (Exception ex)
            {
                ViewData["message"] = ex.ToString();
                return View(user);
            }
        }

        [HttpGet]
        public ActionResult Logout()
        {
            AuthToken.Token = string.Empty;
            return RedirectToAction("Login");
        }
    }
}
