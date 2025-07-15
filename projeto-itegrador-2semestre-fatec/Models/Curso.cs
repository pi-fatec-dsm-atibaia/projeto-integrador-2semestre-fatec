using System.ComponentModel.DataAnnotations;

namespace projeto_itegrador_2semestre_fatec.Models
{
    public class Curso
    {
        
        public int id { get; set; }

        
        public  string nome { get; set; }   

        
        public int quantSemestre { get; set; }
         
        
        public string periodo { get; set; }

        public static implicit operator Curso(List<Curso> v)
        {
            throw new NotImplementedException();
        }

        public static implicit operator List<object>(Curso? v)
        {
            throw new NotImplementedException();
        }
    }
}
