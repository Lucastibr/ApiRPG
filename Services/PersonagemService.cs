using System.Collections.Generic;
using System.Linq;
using Test.Models;
using Test.DTO;
using System.Threading.Tasks;
using AutoMapper;
using System;

namespace Test.Services
{
    public class PersonagemService : IPersonagemService
    {
        private readonly IMapper _mapper;
        public PersonagemService(IMapper mapper)
        {
            _mapper = mapper;
        }
        
        public async Task<ServiceResponse<List<GetPersonagemDTO>>> AdicionarPersonagem(AdicionarPersonagemDTO NovoPersonagem)
        {
            ServiceResponse<List<GetPersonagemDTO>> ServiceResponse = new ServiceResponse<List<GetPersonagemDTO>>();
            Personagem personagem = _mapper.Map<Personagem>(NovoPersonagem);
            personagem.Id = personagens.Max(c => c.Id) + 1;
            personagens.Add(personagem);
            ServiceResponse.Data = (personagens.Select(c => _mapper.Map<GetPersonagemDTO>(c))).ToList();
            return ServiceResponse;
        }

        public async Task<ServiceResponse<GetPersonagemDTO>> BuscarPersonagemPorId(int id)
        {
        
           ServiceResponse<GetPersonagemDTO> serviceResponse = new ServiceResponse<GetPersonagemDTO>();
           serviceResponse.Data = _mapper.Map<GetPersonagemDTO>(personagens.FirstOrDefault(p => p.Id == id));
           return serviceResponse;
        }
        public async Task<ServiceResponse<List<GetPersonagemDTO>>> PegarTodosPersonagens()
        {
            ServiceResponse<List<GetPersonagemDTO>> serviceResponse = new ServiceResponse<List<GetPersonagemDTO>>();
            serviceResponse.Data = (personagens.Select(c => _mapper.Map<GetPersonagemDTO>(c))).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetPersonagemDTO>> AtualizarPersonagem(AtualizarPersonagemDTO atualizarPersonagem)
        {
            ServiceResponse<GetPersonagemDTO> serviceResponse = new ServiceResponse<GetPersonagemDTO>();
            try
            {
            Personagem personagem = personagens.FirstOrDefault(p => p.Id == atualizarPersonagem.Id);
            personagem.Nome = atualizarPersonagem.Nome;
            personagem.Classe =  atualizarPersonagem.Classe;
            personagem.Forca = atualizarPersonagem.Forca;
            personagem.Defesa = atualizarPersonagem.Defesa;
            personagem.Inteligencia = atualizarPersonagem.Inteligencia;
            personagem.PontosDeDano = atualizarPersonagem.PontosDeDano;
            
            serviceResponse.Data = _mapper.Map<GetPersonagemDTO>(personagem);
            }
            catch(Exception ex)
            {
                serviceResponse.Sucesso = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetPersonagemDTO>>> DeletarPersonagem(int id)
        {
            ServiceResponse<List<GetPersonagemDTO>> serviceResponse = new ServiceResponse<List<GetPersonagemDTO>>();
            try
            {
                Personagem personagem = personagens.First(p => p.Id == id);
                personagens.Remove(personagem);

                serviceResponse.Data = (personagens.Select(p => _mapper.Map<GetPersonagemDTO>(p)).ToList());
            }
            catch(Exception ex)
            {
                serviceResponse.Sucesso = false;
                serviceResponse.Message= ex.Message;
            }

            return serviceResponse;
        }

        private static List<Personagem> personagens = new List<Personagem>
        {
            new Personagem(),
            new Personagem { Id = 1, Nome = "Barbarovisky"}
        };
    }
}