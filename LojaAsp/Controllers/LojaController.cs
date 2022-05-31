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
        public IActionResult AdicionarLoja([FromBody]CreateLojaDto lojaDto)
        {
            Loja loja = _mapper.Map<Loja>(lojaDto);
            
            _context.Lojas.Add(loja);
            _context.SaveChanges();   
            return CreatedAtAction(nameof(BuscarLojasId), new { Id = loja.Id}, loja);
        }

        [HttpGet]
        public IEnumerable<Loja> BuscarLoja()
        {
            return _context.Lojas;
        }

        [HttpGet("{id}")]
        public IActionResult BuscarLojasId(int id)
        {
            Loja loja = _context.Lojas.FirstOrDefault(loja => loja.Id == id);
            if(loja != null)
            {
                ReadLojaDto lojaDto = _mapper.Map<ReadLojaDto>(loja);
                return Ok(lojaDto);
            }
            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult EditarLoja(int id, [FromBody]UpdateLojaDto lojaDto)
        {
            Loja loja = _context.Lojas.FirstOrDefault(loja => loja.Id == id);
            if(loja == null)
            {
                NotFound();
            }
            _mapper.Map(lojaDto,loja); // está sobrescrevendo o produco com o produto dto
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletarLoja(int id)
        {
            Loja loja = _context.Lojas.FirstOrDefault(loja => loja.Id == id);
            if(loja == null )
            {
                NoContent();
            }
            _context.Remove(loja);
            _context.SaveChanges();
            return NoContent();
        }
    }
}