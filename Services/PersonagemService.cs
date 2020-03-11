using System.Collections.Generic;
using System.Linq;
using Test.Models;
using Test.DTO;
using System.Threading.Tasks;
using AutoMapper;
using Test.Data;
using System;
using Microsoft.EntityFrameworkCore;

namespace Test.Services
{
    public class PersonagemService : IPersonagemService
    {
        //Injeção de dependência
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        public PersonagemService(IMapper mapper, DataContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        
        public async Task<ServiceResponse<List<GetPersonagemDTO>>> AdicionarPersonagem(AdicionarPersonagemDTO NovoPersonagem)
        {
            ServiceResponse<List<GetPersonagemDTO>> ServiceResponse = new ServiceResponse<List<GetPersonagemDTO>>();
            Personagem personagem = _mapper.Map<Personagem>(NovoPersonagem);
            
            await _context.Personagens.AddAsync(personagem);
            await _context.SaveChangesAsync();
            ServiceResponse.Data = (_context.Personagens.Select(p => _mapper.Map<GetPersonagemDTO>(p)).ToList());
            return ServiceResponse;
        }

        public async Task<ServiceResponse<GetPersonagemDTO>> BuscarPersonagemPorId(int id)
        {
        
           ServiceResponse<GetPersonagemDTO> serviceResponse = new ServiceResponse<GetPersonagemDTO>();
           Personagem dbpersonagem = await _context.Personagens.FirstOrDefaultAsync(p => p.Id == id);
           serviceResponse.Data = _mapper.Map<GetPersonagemDTO>(dbpersonagem);
           return serviceResponse;
        }
        public async Task<ServiceResponse<List<GetPersonagemDTO>>> PegarTodosPersonagens()
        {
            ServiceResponse<List<GetPersonagemDTO>> serviceResponse = new ServiceResponse<List<GetPersonagemDTO>>();
            List<Personagem> dbPersonagens = await _context.Personagens.ToListAsync();
            serviceResponse.Data = (dbPersonagens.Select(c => _mapper.Map<GetPersonagemDTO>(c))).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetPersonagemDTO>> AtualizarPersonagem(AtualizarPersonagemDTO atualizarPersonagem)
        {
            ServiceResponse<GetPersonagemDTO> serviceResponse = new ServiceResponse<GetPersonagemDTO>();
            try
            {
            Personagem personagem = await _context.Personagens.FirstOrDefaultAsync(p => p.Id == atualizarPersonagem.Id);
            personagem.Nome = atualizarPersonagem.Nome;
            personagem.Classe =  atualizarPersonagem.Classe;
            personagem.Forca = atualizarPersonagem.Forca;
            personagem.Defesa = atualizarPersonagem.Defesa;
            personagem.Inteligencia = atualizarPersonagem.Inteligencia;
            personagem.PontosDeDano = atualizarPersonagem.PontosDeDano;

            _context.Personagens.Update(personagem);
            await _context.SaveChangesAsync();
            
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
                Personagem personagem = await _context.Personagens.FirstAsync(p => p.Id == id);
                _context.Personagens.Remove(personagem);
                await _context.SaveChangesAsync();

                serviceResponse.Data = (_context.Personagens.Select(p => _mapper.Map<GetPersonagemDTO>(p)).ToList());
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