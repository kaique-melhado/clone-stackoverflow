using CloneStackOverflow.Data;
using CloneStackOverflow.Helper;
using CloneStackOverflow.Models;
using Microsoft.AspNetCore.Mvc;

namespace CloneStackOverflow.Controllers
{
    public class LoginController : Controller
    {
        private readonly CloneStackOverflowContext _context;
        private readonly Helper.ISession _session;

        public LoginController(CloneStackOverflowContext context, Helper.ISession session)
        {
            _context = context;
            _session = session;
        }

        public IActionResult Index()
        {
            if (_session.GetSession() != null)
                return RedirectToAction("Index", "Home");

            return View();
        }

        [HttpPost]
        public IActionResult Login(User loginDTO)
        {
            try
            {
                var user = _context.Users.FirstOrDefault(x => x.Email == loginDTO.Email && x.Password == loginDTO.Password);
                if (user != null)
                {
                    _session.CreateSession(user);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    TempData["MensagemErro"] = "Usuário e/ou senha invalido(s). Tente novamente!"; 
                    return View(nameof(Index));
                }

            }
            catch
            {
                TempData["MensagemErro"] = "Falha ao tentar efetuar login, tente novamente mais tarde!";
                return RedirectToAction(nameof(Index));
            }
        }

        public IActionResult Logout()
        {
            try
            {
                _session.RemoveSession();
                return RedirectToAction("Index", "Home");
            }
            catch
            {
                TempData["MensagemErro"] = "Falha ao tentar efetuar logout, tente novamente mais tarde!";
                return RedirectToAction(nameof(Index));
            }
        }
    }
}
