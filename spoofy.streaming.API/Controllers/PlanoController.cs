using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using spoofy.streaming.application;
using spoofy.streaming.application.Dto;
using System.Security.Cryptography;

namespace spoofy.streaming.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlanoController : ControllerBase
    {
        private PlanoService service { get; set; }

        public PlanoController()
        {
            this.service = new PlanoService();
        }

        [HttpPost]
        public IActionResult CriarPlano(PlanoDto planoDto)
        {
            if (ModelState.IsValid == false)
                return BadRequest(ModelState);

            service.CriarPlano(planoDto);

            return Created($"/Plano/{planoDto.Id}", planoDto);
        }
        [HttpGet("{id}")]
        public IActionResult GetPlano(Guid id) 
        {
            var result = service.ObterPlano(id);

            if (result == null) 
                return NotFound();

            return Ok(result);

        }

        [HttpGet("All")]
        public IActionResult GetPlanos()
        {
            return Ok(service.PlanoRepository.GetPlanos());
        }

        [HttpPut("{id}/atualizar")]
        public IActionResult AtualizarPlano(Guid id, PlanoDto planoDto)
        {
            service.AtualizarPlano(id, planoDto);

            return Created($"/Plano/{id}", planoDto);
        }
    }
}