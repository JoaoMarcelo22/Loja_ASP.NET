using AutoMapper;
using LojaAsp.Data;
using LojaAsp.Models;
using Microsoft.AspNetCore.Mvc;

namespace LojaAsp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EnderecoController : ControllerBase
    {
        private ProdutoContext _context;
        private IMapper _mapper;

        public EnderecoController(ProdutoContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }   

        [HttpPost]
        public IActionResult AdicionarEndereco([FromBody]CreateEnderecoDto enderecoDto)
        {
            Endereco endereco = _mapper.Map<Endereco>(enderecoDto);
            
            _context.Enderecos.Add(endereco);
            _context.SaveChanges();   
            return CreatedAtAction(nameof(BuscarEnderecoId), new { Id = endereco.Id}, endereco);
        }

        [HttpGet]
        public IEnumerable<Endereco> BuscarEnderecos()
        {
            return _context.Enderecos;
        }

        [HttpGet("{id}")]
        public IActionResult BuscarEnderecoId(int id)
        {
            Endereco endereco = _context.Enderecos.FirstOrDefault(endereco => endereco.Id == id);
            if(endereco != null)
            {
                ReadEnderecoDto enderecoDto = _mapper.Map<ReadEnderecoDto>(endereco);
                return Ok(enderecoDto);
            }
            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult EditarEndereco(int id, [FromBody]UpdateEnderecoDto enderecoDto)
        {
            Endereco endereco = _context.Enderecos.FirstOrDefault(endereco => endereco.Id == id);
            if(endereco == null)
            {
                NotFound();
            }
            _mapper.Map(enderecoDto,endereco); // está sobrescrevendo o produco com o produto dto
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletarProduto(int id)
        {
            Endereco endereco = _context.Enderecos.FirstOrDefault(endereco => endereco.Id == id);
            if(endereco == null )
            {
                NoContent();
            }
            _context.Remove(endereco);
            _context.SaveChanges();
            return NoContent();
        }
    }
}