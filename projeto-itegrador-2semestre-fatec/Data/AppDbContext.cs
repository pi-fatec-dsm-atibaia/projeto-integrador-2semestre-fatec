using Microsoft.EntityFrameworkCore;
using projeto_itegrador_2semestre_fatec.Models;

namespace projeto_itegrador_2semestre_fatec.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Aluno> Aluno { get; set; }

        public DbSet<Curso> Curso { get; set; }
    }
}
