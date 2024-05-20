using Microsoft.AspNetCore.Mvc;

namespace CloneStackOverflow.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Restrict()
        {
            return View();
        }

        public IActionResult Error()
        {

            var errorMessage = HttpContext.Session.GetString("ErrorMessage");
            if (!string.IsNullOrEmpty(errorMessage))
            {
                ViewBag.ErrorMessage = errorMessage;
                HttpContext.Session.Remove("ErrorMessage");
            }

            return View();
        }
    }
}
