using AutoMapper;
using Test.DTO;
using Test.Models;

namespace Test
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Personagem, GetPersonagemDTO>();
            CreateMap<AdicionarPersonagemDTO, Personagem>();
        }
    }
}