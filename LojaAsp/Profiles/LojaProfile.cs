using AutoMapper;
using LojaAsp.Models;

namespace LojaAsp
{
    public class LojaProfile : Profile
    {
        public LojaProfile()
        {
            CreateMap<CreateLojaDto, Produto>();
            CreateMap<Loja, ReadLojaDto>();
            CreateMap<UpdateLojaDto, Loja>();
        }
    }
}