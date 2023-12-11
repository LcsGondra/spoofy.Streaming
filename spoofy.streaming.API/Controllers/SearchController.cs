using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using spoofy.streaming.application;
using Streaming.domain.Aggregates;

namespace spoofy.streaming.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private BandaService _service = new BandaService();

        [HttpGet()]
        public IActionResult Search([FromQuery] String query)
        {
            var results = _service.SearchQuery(query);

            return Ok(results);
        }
    }
}
