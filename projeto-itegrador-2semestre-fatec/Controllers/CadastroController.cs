using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using projeto_itegrador_2semestre_fatec.Data;
using projeto_itegrador_2semestre_fatec.Models;

namespace projeto_itegrador_2semestre_fatec.Controllers
{
    public class CadastroController : Controller
    {
        private readonly AppDbContext _context;


        public CadastroController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var curso = _context.Curso.ToList();

            CadastroCursoDTO cadastroDTO = new CadastroCursoDTO();
            cadastroDTO.curso = curso;
            return View(cadastroDTO);
        }

        [HttpPost]
        public async Task<IActionResult> Index(CadastroCursoDTO model)
        {
            if (model.cadastroAluno.senha != model.cadastroAluno.confirmeSenha)
            {
                ViewBag.Erro = "As senhas não coincidem.";
                model.curso = _context.Curso.ToList();
                return View(model);
            }

            try
            {
                Aluno novoAluno = new Aluno();
                novoAluno = model.cadastroAluno;
                Console.WriteLine($"id do curso: {model.ToString()}");
                Console.WriteLine($"id do curso: {model.cadastroAluno.idCurso}");
                Console.WriteLine($"id do curso: {novoAluno.idCurso}");

                _context.Aluno.Add(novoAluno);
                await _context.SaveChangesAsync();
                return View("Created");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao cadastrar aluno: {ex.Message}");
                Console.WriteLine($"Erro ao cadastrar aluno: {ex.InnerException}");
                ViewBag.Erro = "Erro ao cadastrar aluno.";
                model.curso = _context.Curso.ToList();
                return View(model);
            }
        }
    }
}