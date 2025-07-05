using System.ComponentModel.DataAnnotations;

namespace projeto_itegrador_2semestre_fatec.Models
{
    public class Curso
    {
        [Required]
        public int id { get; set; }

        [Required]
        public  string nome { get; set; }   

        [Required]
        public int quantSemestre { get; set; }
         
        [Required]
        public string periodo { get; set; }



    }
}
