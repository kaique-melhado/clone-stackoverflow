using Microsoft.AspNetCore.Mvc;

namespace CloneStackOverflow.Controllers
{
    public class UsuarioController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }
    }
}
