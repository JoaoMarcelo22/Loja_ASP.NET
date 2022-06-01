using LojaAsp.Models;
using Microsoft.EntityFrameworkCore;

namespace LojaAsp.Data
{
    public class ProdutoContext : DbContext
    {
        public ProdutoContext(DbContextOptions<ProdutoContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Endereco>()               //RELAÇÃO DE 1 - 1
                .HasOne(endereco => endereco.Loja)
                .WithOne(loja=> loja.Endereco)
                .HasForeignKey<Loja>(loja => loja.EnderecoID); // definição da foreignKey
        }
        public DbSet<Produto>Produtos{get;set;}
        public DbSet<Loja> Lojas{get;set;}
        public DbSet<Endereco> Enderecos{get;set;}
        public DbSet<Gerente> Gerentes{get;set;}
    }
}