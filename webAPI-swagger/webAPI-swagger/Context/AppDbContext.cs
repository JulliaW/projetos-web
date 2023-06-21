using Microsoft.EntityFrameworkCore;
using webAPI_swagger.Model;

namespace webAPI_swagger.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Produto> Produtos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Produto>()
                .Property(p => p.Nome)
                .HasMaxLength(80);

            modelBuilder.Entity<Produto>()
                .Property(p => p.Preco)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Produto>()
                .HasData(
                new Produto { Id = 1, Nome = "Caderno", Preco = 7.99M, Estoque = 50 },
                new Produto { Id = 2, Nome = "Lapis", Preco = 1.99M, Estoque = 100 },
                new Produto { Id = 3, Nome = "Borracha", Preco = 0.75M, Estoque = 20 }
                );
        }
    }
}
