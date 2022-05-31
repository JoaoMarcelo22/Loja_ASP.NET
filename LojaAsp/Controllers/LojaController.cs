using AutoMapper;
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
        private IMapper _mapper;

        public LojaController(ProdutoContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }   

        [HttpPost]
        public IActionResult AdicionarProduto([FromBody]CreateProdutoDto produtoDto)
        {
            Produto produto = _mapper.Map<Produto>(produtoDto);
            
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
                ReadProdutoDto produtoDto = _mapper.Map<ReadProdutoDto>(produto);
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
                NotFound();
            }
            _mapper.Map(produtoDto,produto); // está sobrescrevendo o produco com o produto dto
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