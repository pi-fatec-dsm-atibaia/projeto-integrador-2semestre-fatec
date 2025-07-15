using System.ComponentModel.DataAnnotations;

namespace projeto_itegrador_2semestre_fatec.Models
{
    public class AlunoCursoPerfilDTO
    {
        public List<Curso> curso { get; set; }
        public Aluno aluno { get; set; }
    }
}
