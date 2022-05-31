using LojaAsp.Data;
using LojaAsp.Models;
using Microsoft.AspNetCore.Mvc;

namespace LojaAsp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LojaController : ControllerBase
    {
        private ProdutoContext _context;

        public LojaController(ProdutoContext context)
        {
            _context = context;
        }   

        [HttpPost]
        public IActionResult AdicionarProduto([FromBody]CreateProdutoDto produtoDto)
        {
            Produto produto = new Produto
            {
                Nome = produtoDto.Nome,
                Categoria = produtoDto.Categoria,
                Preco = produtoDto.Preco
            };
            _context.Produtos.Add(produto);
            _context.SaveChanges();   
            return CreatedAtAction(nameof(BuscarProdutoId), new { Id = produto.Id}, produto);
        }

        [HttpGet]
        public IEnumerable<Produto> BuscarProduto()
        {
            return _context.Produtos;
        }

        [HttpGet("{id}")]
        public IActionResult BuscarProdutoId(int id)
        {
            Produto produto = _context.Produtos.FirstOrDefault(produto => produto.Id == id);
            if(produto != null)
            {
                ReadProdutoDto produtoDto = new ReadProdutoDto
                {
                    Nome = produto.Nome,
                    Categoria = produto.Categoria,
                    Preco = produto.Preco,
                    Id = produto.Id,
                    HoraDaConsulta = DateTime.Now
                };
                return Ok(produtoDto);
            }
            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult EditarProduto(int id, [FromBody]UpdateProdutoDto produtoDto)
        {
            Produto produto = _context.Produtos.FirstOrDefault(produto => produto.Id == id);
            if(produto == null)
            {
                NoContent();
            }
            produto.Nome = produtoDto.Nome;
            produto.Categoria = produtoDto.Categoria;
            produto.Preco = produtoDto.Preco;
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletarProduto(int id)
        {
            Produto produto = _context.Produtos.FirstOrDefault(produto => produto.Id == id);
            if(produto == null )
            {
                NoContent();
            }
            _context.Remove(produto);
            _context.SaveChanges();
            return NoContent();
        }
    }
}