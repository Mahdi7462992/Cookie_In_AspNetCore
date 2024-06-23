using Cookie_In_AspNetCore.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Cookie_In_AspNetCore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            Response.Cookies.Append("Message", "Welcome", new CookieOptions
            {
                HttpOnly = true,
                Secure = Request.IsHttps,
                Path = Request.PathBase.HasValue ? Request.PathBase.Value : "/",
                Expires=DateTime.Now.AddMonths(5)
            });
            return View();
        }

        public IActionResult Read()
        {
            string cookieValue;
            if(Request.Cookies.TryGetValue("Message12347",out cookieValue))
            {

            }
            else
            {
                cookieValue = "کوکی یافت نشد";
            }
            return Ok(cookieValue);
        }

        public IActionResult Remove()
        {
            Response.Cookies.Delete("Message");
            return Ok("Remove cookie");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}