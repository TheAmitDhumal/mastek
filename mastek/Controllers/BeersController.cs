using mastek.DBContext;
using mastek.Model;
using mastek.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace mastek.Controllers
{
    [Route("beer")]
    [ApiController]
    public class BeerController : ControllerBase
    {
        private readonly IBeerService _beerService;

        public BeerController(IBeerService beerService)
        {
            _beerService = beerService;
        }

        [HttpPost]
        public IActionResult AddBeer([FromBody] Beer beer)
        {
            try
            {
                var createdBeer = _beerService.CreateBeer(beer);
                return Ok(createdBeer);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBeer([FromBody] Beer beer)
        {
            try
            {
                var updatedBeer = _beerService.UpdateBeer(beer);
                if (updatedBeer == null)
                    return NotFound();

                return Ok(updatedBeer);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public IActionResult GetBeers(decimal? gtAlcoholByVolume, decimal? ltAlcoholByVolume)
        {
            try
            {
                var beers = _beerService.GetBeers(gtAlcoholByVolume, ltAlcoholByVolume);
                return Ok(beers);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetBeer(int id)
        {
            try
            {
                var beer = _beerService.GetBeer(id);
                if (beer == null)
                    return NotFound();

                return Ok(beer);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
