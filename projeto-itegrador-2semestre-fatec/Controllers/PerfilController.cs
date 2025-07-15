using Microsoft.AspNetCore.Mvc;
using projeto_itegrador_2semestre_fatec.Data;
using projeto_itegrador_2semestre_fatec.Models;

namespace projeto_itegrador_2semestre_fatec.Controllers
{
    public class PerfilController : Controller
    {
        private readonly AppDbContext _context;
        public PerfilController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index(int id)
        {
            var aluno = _context.Aluno.FirstOrDefault(a => a.id == id);
            var curso = _context.Curso.ToList();
            if (aluno == null)
            {
                return NotFound("Aluno não encontrado.");
            }
            AlunoCursoPerfilDTO dto = new AlunoCursoPerfilDTO();
            dto.aluno = aluno;
            dto.curso = curso;
            return View(dto);
        }

        [HttpPost]
        public IActionResult Index(AlunoCursoPerfilDTO parameters)
        {
            var aluno = _context.Aluno.FirstOrDefault(a => a.id == parameters.aluno.id);
            if (aluno == null)
            {
                return NotFound("Aluno não encontrado.");
            }
            _context.Aluno.Update(aluno);
            _context.SaveChanges();
            return RedirectToAction("Index", new { id = aluno.id });
        }
    }
}