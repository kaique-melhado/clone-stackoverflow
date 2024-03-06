using CloneStackOverflow.Models;
using Microsoft.AspNetCore.Mvc;

namespace CloneStackOverflow.Controllers
{
    public class UserController : Controller
    {
        public UserController()
        {
                
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(User userModel)
        {
            return RedirectToAction(nameof(Index));
        }
    }
}
