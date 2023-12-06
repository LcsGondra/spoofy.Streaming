using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using spoofy.streaming.application;
using spoofy.streaming.application.Dto;

namespace spoofy.streaming.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BandaController : ControllerBase
    {
        private BandaService _service = new BandaService();
        public BandaController() { }

        [HttpPost]
        public IActionResult Criar(BandaDto dto)
        {
            if (ModelState.IsValid == false)
                return BadRequest(ModelState);

            this._service.Criar(dto);

            return Created($"/banda/{dto.Id}", dto);
        }

        [HttpGet("{id}")]
        public IActionResult ObterBanda(Guid id)
        {
            var result = this._service.ObterBanda(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpGet("musica/{id}")]
        public IActionResult ObterMusica(Guid id)
        {
            var result = this._service.ObterMusica(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }
    }
}
