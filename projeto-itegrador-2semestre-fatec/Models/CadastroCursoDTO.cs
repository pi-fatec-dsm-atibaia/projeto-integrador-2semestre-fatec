using System.ComponentModel.DataAnnotations;

namespace projeto_itegrador_2semestre_fatec.Models
{
    public class CadastroCursoDTO
    {
        public List<Curso> curso { get; set; }
        public CadastroAluno cadastroAluno { get; set; }
        public override string ToString()
        {
            return $"nome:{cadastroAluno.nome} email:{cadastroAluno.email} idCurso:{cadastroAluno.idCurso}";
        }
    }
}
