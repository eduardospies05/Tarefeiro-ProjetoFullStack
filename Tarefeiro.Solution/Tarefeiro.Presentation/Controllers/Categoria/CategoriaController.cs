using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tarefeiro.Application.DTOs.Categoria;
using Tarefeiro.Application.UseCaseInterface.Categoria;

namespace Tarefeiro.Presentation.Controllers.Categoria
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController(ICategoriaUseCase useCase) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreateCategoriaAsync(CreateCategoriaDto create)
        {
            var response = await useCase.CreateCategoriaAsync(create);

            if(!response.Status)
                return BadRequest(response);

            return StatusCode(StatusCodes.Status201Created, response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCategoriaAsync(UpdateCategoriaDto update)
        {
            var response = await useCase.UpdateCategoriaAsync(update);

            if(!response.Status)
                return BadRequest(response);

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoriaByIdAsync(int id)
        {
            var response = await useCase.GetCategoriaByIdAsync(id);

            if(!response.Status)
                return NotFound(response);

            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetCategoriasAsync()
        {
            var response = await useCase.GetCategoriasAsync();

            return Ok(response);
        }
    }
}
