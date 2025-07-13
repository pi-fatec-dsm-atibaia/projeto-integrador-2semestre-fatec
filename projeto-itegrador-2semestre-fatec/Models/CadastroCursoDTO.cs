using System.ComponentModel.DataAnnotations;

namespace projeto_itegrador_2semestre_fatec.Models
{
    public class CadastroCursoDTO
    {
        public List<Curso> curso { get; set; }
        public CadastroAluno cadastroAluno { get; set; }
    }
}
