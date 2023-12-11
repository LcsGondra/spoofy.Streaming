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

            _service.Criar(dto);

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

        [HttpGet("Musica/{id}")]
        public IActionResult ObterMusica(Guid id)
        {
            var result = this._service.ObterMusica(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpGet("Album/{id}")]
        public IActionResult ObterAlbum(Guid id)
        {
            var result = this._service.ObterAlbum(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }


        [HttpPut("{id}/Atualizar")]
        public IActionResult UpdateBanda(Guid id, BandaDto dto)
        {
            _service.AtualizarBanda(id, dto);

            return Created($"/banda/{id}", dto);
        }

    }
}
