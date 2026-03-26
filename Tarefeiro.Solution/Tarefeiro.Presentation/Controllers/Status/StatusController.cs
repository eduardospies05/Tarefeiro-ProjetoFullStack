using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tarefeiro.Application.DTOs.Status;
using Tarefeiro.Application.UseCaseInterface.Status;

namespace Tarefeiro.Presentation.Controllers.Status
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusController(IStatusUseCase useCase) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreateStatusAsync(CreateStatusDto create)
        {
            var response = await useCase.CreateStatusAsync(create);

            if(!response.Status)
                return BadRequest(response);

            return StatusCode(StatusCodes.Status201Created, response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateStatusAsync(UpdateStatusDto update)
        {
            var response = await useCase.UpdateStatusAsync(update);

            if(!response.Status)
                return BadRequest(response);

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStatusByIdAsync(int id)
        {
            var response = await useCase.GetStatusByIdAsync(id);

            if(!response.Status)
                return NotFound(response);

            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetStatusAsync()
        {
            var response = await useCase.GetStatusAsync();

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStatusByIdAsync(int id)
        {
            var response = await useCase.DeleteStatusByIdAsync(id);

            if(!response.Status)
                return NotFound(response);

            return Ok(response);
        }
    }
}
