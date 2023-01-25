using APICatalogo.Models;
using Microsoft.EntityFrameworkCore;

namespace APICatalogo.Context
{
    //representa sessão com o banco de dados sendo a ponte entre as entidades de domínio
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Categoria>? Categorias { get; set; }
        public DbSet<Produto>? Produtos { get; set; }

    }
}
