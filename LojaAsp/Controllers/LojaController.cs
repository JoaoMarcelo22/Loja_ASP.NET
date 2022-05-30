using LojaAsp.Models;
using Microsoft.AspNetCore.Mvc;

namespace LojaAsp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LojaController : ControllerBase
    {
        private static List<Produto> produtos = new List<Produto>();
        private static int id = 1; 

        [HttpPost]
        public IActionResult AdicionarProduto([FromBody]Produto produto)
        {
            produto.Id = id++;
            produtos.Add(produto);
            return CreatedAtAction(nameof(BuscarProdutoId), new { Id = produto.Id}, produto);
        }

        [HttpGet]
        public IActionResult BuscarProduto()
        {
            return Ok(produtos);
        }

        [HttpGet("{id}")]
        public IActionResult BuscarProdutoId(int id)
        {
            Produto produto = produtos.FirstOrDefault(produto => produto.Id == id);
            if(produto != null)
            {
                return Ok(produto);
            }
            return NotFound();
        }
    }
}