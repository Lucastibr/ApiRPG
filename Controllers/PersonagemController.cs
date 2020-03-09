using Microsoft.AspNetCore.Mvc;
using Test.Services;
using Test.DTO;
using System.Threading.Tasks;
using Test.Models;
using System.Collections.Generic;

namespace Test.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonagemController : ControllerBase
    {
        //Injeção de dependencia
        private readonly IPersonagemService _characterService;

        public PersonagemController(IPersonagemService characterService)
        {
            _characterService = characterService;

        }

        [Route("GetAll")]
        public async Task<IActionResult> Get()
        {
            return Ok(await _characterService.PegarTodosPersonagens());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingle(int id)
        {
            return Ok(await _characterService.BuscarPersonagemPorId(id));
        }

        [HttpPost]
        public async Task<IActionResult> AdicionarPersonagem(AdicionarPersonagemDTO NovoPersonagem)
        {
            return Ok(await _characterService.AdicionarPersonagem(NovoPersonagem));
        }
        
        [HttpPut]
        public async Task<IActionResult> AtualizarPersonagem(AtualizarPersonagemDTO atualizarPersonagem)
        {
            ServiceResponse<GetPersonagemDTO> response = await _characterService.AtualizarPersonagem(atualizarPersonagem);
            if(response.Data == null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletar(int id)
        {
            ServiceResponse<List<GetPersonagemDTO>> response = await _characterService.DeletarPersonagem(id);
            if(response.Data == null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }
        

    }
}