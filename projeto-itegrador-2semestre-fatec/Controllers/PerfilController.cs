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
        public IActionResult Index(AlunoCursoPerfilDTO parameters, string senhaAtual, string novaSenha, string confirmarSenha)
        {
            if (parameters?.aluno == null)
            {
                return BadRequest("Dados inválidos.");
            }

            var aluno = _context.Aluno.FirstOrDefault(a => a.id == parameters.aluno.id);
            if (aluno == null)
            {
                return NotFound("Aluno não encontrado.");
            }

            aluno.nome = parameters.aluno.nome;
            aluno.email = parameters.aluno.email;
            aluno.cpf = parameters.aluno.cpf;
            aluno.rg = parameters.aluno.rg;
            aluno.ra = parameters.aluno.ra;
            aluno.telefone = parameters.aluno.telefone;
            aluno.idCurso = parameters.aluno.idCurso;

            if (!string.IsNullOrEmpty(senhaAtual) || !string.IsNullOrEmpty(novaSenha) || !string.IsNullOrEmpty(confirmarSenha))
            {
                if (string.IsNullOrEmpty(senhaAtual) || string.IsNullOrEmpty(novaSenha) || string.IsNullOrEmpty(confirmarSenha))
                {
                    TempData["ErrorMessage"] = "Para alterar a senha, todos os campos de senha devem ser preenchidos.";
                    return RedirectToAction("Index", new { id = aluno.id });
                }

                if (aluno.senha != senhaAtual)
                {
                    TempData["ErrorMessage"] = "Senha atual incorreta.";
                    return RedirectToAction("Index", new { id = aluno.id });
                }

                if (novaSenha != confirmarSenha)
                {
                    TempData["ErrorMessage"] = "A nova senha e a confirmação não coincidem.";
                    return RedirectToAction("Index", new { id = aluno.id });
                }

                if (novaSenha.Length < 6)
                {
                    TempData["ErrorMessage"] = "A nova senha deve ter pelo menos 6 caracteres.";
                    return RedirectToAction("Index", new { id = aluno.id });
                }

                aluno.senha = novaSenha;
            }

            try
            {
                _context.Aluno.Update(aluno);
                _context.SaveChanges();
                TempData["SuccessMessage"] = "Dados atualizados com sucesso!";
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "Erro ao atualizar dados: " + ex.Message;
            }

            return RedirectToAction("Index", new { id = aluno.id });
        }

        [HttpPost]
        public IActionResult Deletar(int id)
        {
            try
            {
                var aluno = _context.Aluno.FirstOrDefault(a => a.id == id);
                if (aluno == null)
                {
                    TempData["ErrorMessage"] = "Aluno não encontrado.";
                    return RedirectToAction("Index", new { id = id });
                }

                _context.Aluno.Remove(aluno);
                var result = _context.SaveChanges();

                TempData["SuccessMessage"] = "Conta excluída com sucesso!";
                return RedirectToAction("Index", "Login");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "Erro ao excluir conta: " + ex.Message;
                return RedirectToAction("Index", new { id = id });
            }
        }
    }
}