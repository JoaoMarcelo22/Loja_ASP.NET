using Microsoft.EntityFrameworkCore;

namespace LojaAsp.Data
{
    public class ProdutoContext : DbContext
    {
        public ProdutoContext(DbContextOptions<ProdutoContext> opt) : base(opt)
        {
        }
        public DbSet<ProdutoContext>Produtos{get;set;}
    }
}