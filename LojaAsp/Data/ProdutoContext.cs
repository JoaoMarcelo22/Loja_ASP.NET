using LojaAsp.Models;
using Microsoft.EntityFrameworkCore;

namespace LojaAsp.Data
{
    public class ProdutoContext : DbContext
    {
        public ProdutoContext(DbContextOptions<ProdutoContext> options) : base(options)
        {
        }
        public DbSet<Produto>Produtos{get;set;}
    }
}