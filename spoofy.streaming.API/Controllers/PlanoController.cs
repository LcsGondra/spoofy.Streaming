using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using spoofy.streaming.application;

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

        [HttpGet("{id}")]
        public IActionResult GetPlano(Guid id) 
        {
            var result = service.ObterPlano(id);

            if (result == null) 
                return NotFound();

            return Ok(result);

        }
    }
}