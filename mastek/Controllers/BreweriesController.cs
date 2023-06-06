using mastek.DBContext;
using mastek.Model;
using mastek.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace mastek.Controllers
{
    [Route("brewery")]
    [ApiController]
    public class BreweryController : ControllerBase
    {
        private readonly IBreweryService _breweryService;

        public BreweryController(IBreweryService breweryService)
        {
            _breweryService = breweryService;
        }

        [HttpPost]
        public IActionResult AddBrewery([FromBody] Brewery brewery)
        {
            try
            {
                var createdBrewery = _breweryService.CreateBrewery(brewery);
                return Ok(createdBrewery);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBrewery(int id, [FromBody] Brewery brewery)
        {
            try
            {
                var updatedBrewery = _breweryService.UpdateBrewery(id, brewery);
                if (updatedBrewery == null)
                    return NotFound();

                return Ok(updatedBrewery);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public IActionResult GetBreweries()
        {
            try
            {
                var breweries = _breweryService.GetBreweries();
                return Ok(breweries);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
          
        }

        [HttpGet("{id}")]
        public IActionResult GetBrewery(int id)
        {
            try
            {
                var brewery = _breweryService.GetBrewery(id);
                if (brewery == null)
                    return NotFound();

                return Ok(brewery);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
          
        }
    }
}
