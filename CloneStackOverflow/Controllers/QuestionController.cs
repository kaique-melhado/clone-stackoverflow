using CloneStackOverflow.Data;
using CloneStackOverflow.Filters;
using CloneStackOverflow.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace CloneStackOverflow.Controllers
{
    public class QuestionController : Controller
    {
        private readonly CloneStackOverflowContext _context;

        public QuestionController(CloneStackOverflowContext context)
        {
            _context = context;
        }

        [UserLogged]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult RegisterQuestion(Question model)
        {
            try
            {
                _context.Questions.Add(model);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                TempData["MensagemErro"] = "Falha ao tentar cadastrar a pergunta, tente novamente mais tarde!";
                return RedirectToAction(nameof(Index));
            }
        }
    }
}