namespace projeto_itegrador_2semestre_fatec.Models
{
    public class CadastroAluno: Aluno
    {
        public int cursoId { get; set; }

        public string semestre { get; set; }
        public string periodo { get; set; }
        public string confirmeSenha { get; set; }
    }
}
