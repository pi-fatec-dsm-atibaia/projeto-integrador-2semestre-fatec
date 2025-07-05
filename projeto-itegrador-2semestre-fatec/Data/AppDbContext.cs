using Microsoft.EntityFrameworkCore;

namespace projeto_itegrador_2semestre_fatec.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public Dbset<Aluno> Aluno { get; set; }

    }
}
