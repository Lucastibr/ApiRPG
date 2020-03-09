using System.Collections.Generic;
using Test.Models;
using System.Threading.Tasks;
using Test.DTO;

namespace Test.Services
{
    public interface IPersonagemService
    {
        Task<ServiceResponse<List<GetPersonagemDTO>>> PegarTodosPersonagens();
        Task<ServiceResponse<GetPersonagemDTO>> BuscarPersonagemPorId(int id);
        Task<ServiceResponse<List<GetPersonagemDTO>>> AdicionarPersonagem(AdicionarPersonagemDTO novoPersonagem);
        Task<ServiceResponse<GetPersonagemDTO>> AtualizarPersonagem(AtualizarPersonagemDTO atualizarPersonagem);
        Task<ServiceResponse<List<GetPersonagemDTO>>> DeletarPersonagem(int id);

    }
}