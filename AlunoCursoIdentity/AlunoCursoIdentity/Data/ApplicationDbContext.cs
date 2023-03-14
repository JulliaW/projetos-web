using AlunoCursoIdentity.Models;
using Microsoft.EntityFrameworkCore;

namespace AlunoCursoIdentity.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        { 
        }

        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Curso> Curso { get; set; }
    }
}
