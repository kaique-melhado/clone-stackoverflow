using CloneStackOverflow.Data;
using CloneStackOverflow.Filters;
using CloneStackOverflow.Models;
using Microsoft.AspNetCore.Mvc;
namespace CloneStackOverflow.Controllers
{
    public class UserController : Controller
    {
        private readonly CloneStackOverflowContext _context;
        private readonly Helper.ISession _session;

        public UserController(CloneStackOverflowContext context, Helper.ISession session)
        {
            _context = context;
            _session = session;
        }

        [AcesssAdmin]
        public IActionResult Index()
        {
            var users = _context.Users.ToList();
            return View(users);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(User model)
        {
            try
            {
                _context.Users.Add(model);
                _context.SaveChanges();

                TempData["MensagemSucesso"] = "Cadastro realizado com sucesso!";
                return RedirectToAction(nameof(Index), "Login");
            }
            catch
            {
                TempData["MensagemErro"] = "Falha ao tentar cadastrar o usuário, tente novamente mais tarde!";
                return RedirectToAction(nameof(Create));
            }            
        }

        [UserLogged]
        public IActionResult Edit(int id)
        {
            try
            {
                var currentUser = _session.GetSession();
                if (currentUser.Id != id)
                    return RedirectToAction("Restrict", "Home");

                var user = _context.Users.FirstOrDefault(x => x.Id == id);
                return View(user);
            }
            catch
            {
                TempData["MensagemErro"] = "Falha ao tentar carregar a tela, tente novamente mais tarde!";
                return RedirectToAction(nameof(Edit), id);
            }
        }

        [HttpPost]
        public IActionResult Edit(User model)
        {
            try
            {
                var user = _context.Users.FirstOrDefault(x => x.Id == model.Id);

                if (user != null)
                {
                    user.Name = model.Name;
                    user.Email = model.Email;
                    user.Password = model.Password;
                    user.Profile = model.Profile;
                    _context.SaveChanges();
                    TempData["MensagemSucesso"] = "Dados atualizados com sucesso!";
                }

                return RedirectToAction(nameof(Edit), model);
            }
            catch
            {
                TempData["MensagemErro"] = "Falha ao tentar atualizar os dados, tente novamente mais tarde!";
                return RedirectToAction(nameof(Edit), model);
            }            
        }

        [UserLogged]
        public IActionResult Delete(int id)
        {
            try
            {
                var user = _context.Users.FirstOrDefault(x => x.Id == id);
                if (user != null)
                {
                    _context.Users.Remove(user);
                    _context.SaveChanges();
                    TempData["MensagemSucesso"] = "Usuário removido com sucesso!";
                }

                var users = _context.Users.ToList();                
                return RedirectToAction(nameof(Index), users);
            }
            catch
            {
                var users = _context.Users.ToList();
                TempData["MensagemErro"] = "Falha ao tentar remover o usuário, tente novamente mais tarde!";
                return RedirectToAction(nameof(Index), users);
            }
        }
    }
}
