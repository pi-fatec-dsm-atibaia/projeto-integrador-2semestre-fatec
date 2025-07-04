using System.ComponentModel.DataAnnotations;

namespace projeto_itegrador_2semestre_fatec.Models
{
    public class Aluno
    {
        [Required]
        public int id { get; set; }

        [Required]
        public Curso curso { get; set; }

        [Required]
        public string ra { get; set; }

        [Required]
        public string rg { get; set; }

        [Required]
        public string telefone { get; set; }

        [Required]
        public string nome { get; set; }

        [Required]
        public string email { get; set; }

        [Required]
        public string cpf { get; set; }

        [Required]
        public string senha { get; set; }

    }
}
