using AutoMapper;
using LojaAsp.Data;
using Microsoft.AspNetCore.Mvc;

namespace LojaAsp
{
    [ApiController]
    [Route("[controller]")]
    public class GerenteController : ControllerBase
    {
        private ProdutoContext _context;
        private IMapper _mapper;

        public GerenteController(ProdutoContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public IActionResult AdicionaGerente(CreateGerenteDto dto)
        {
            Gerente gerente = _mapper.Map<Gerente>(dto);
            _context.Gerentes.Add(gerente);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperaGerentesId),new { Id = gerente.Id},gerente);
        }

        public IActionResult RecuperaGerentesId(int id)
        {
            Gerente gerente = _context.Gerentes.FirstOrDefault(gerente => gerente.Id == id);
            if(gerente != null)
            {
                ReadGerenteDto gerenteDto = _mapper.Map<ReadGerenteDto>(gerente);
                return Ok(gerenteDto);
            }
            return NotFound();
        }
    }
}