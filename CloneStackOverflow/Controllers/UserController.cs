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
        public IActionResult Create(User user)
        {
            //bancoDados.Users.Add(user);
            //bancoDados.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {
            //var user = bancoDados.Users.Where(x => x.Id = id);
            User user = new User { Id = 2, Nome = "Lucas", Email = "lucas.melhado@outlook.com" };
            return View(user);
        }

        public IActionResult Delete(int id)
        {
            return RedirectToAction(nameof(Index));
        }
    }
}
