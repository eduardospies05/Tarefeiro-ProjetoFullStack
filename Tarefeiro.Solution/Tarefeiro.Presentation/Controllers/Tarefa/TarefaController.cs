using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tarefeiro.Application.DTOs.Tarefa;
using Tarefeiro.Application.UseCaseInterface.Tarefa;

namespace Tarefeiro.Presentation.Controllers.Tarefa
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarefaController(ITarefaUseCase useCase) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetTarefasAsync()
        {
            var response = await useCase.GetTarefasAsync();

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTarefaByIdAsync(int id)
        {
            var response = await useCase.GetTarefaByIdAsync(id);

            if(!response.Status)
                return BadRequest(response);

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTarefaAsync(CreateTarefaDto create)
        {
            var response = await useCase.CreateTarefaAsync(create);

            if(!response.Status)
                return BadRequest(response);

            return StatusCode(StatusCodes.Status201Created, response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTarefaAsync(UpdateTarefaDto update)
        {
            var response = await useCase.UpdateTarefaAsync(update);

            if(!response.Status)
                return BadRequest(response);

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTarefaByIdAsync(int id)
        {
            var response = await useCase.DeleteTarefaByIdAsync(id);

            if(!response.Status)
                return BadRequest(response);

            return Ok(response);
        }
    }
}
