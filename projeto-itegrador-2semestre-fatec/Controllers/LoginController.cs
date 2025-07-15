using Microsoft.AspNetCore.Mvc;
using projeto_itegrador_2semestre_fatec.Data;

namespace projeto_itegrador_2semestre_fatec.Controllers
{
    public class LoginController : Controller
    {
        private readonly AppDbContext _context;

        public LoginController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string email, string senha)
        {
            var aluno = _context.Aluno.FirstOrDefault(
                actualStudent => actualStudent.email == email && actualStudent.senha == senha);
            if (aluno == null)
            {
                ViewBag.Erro = "Usuário ou senha inválidos";
                return View();
            }
            
            return RedirectToAction("Index", "Perfil", new { id = aluno.id });
        }
    }
}