using mastek.DBContext;
using mastek.Model;
using mastek.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace mastek.Controllers
{
    [Route("brewery")]
    [ApiController]
    public class BreweryBeerLinkController : ControllerBase
    {
        private readonly IBreweryBeerLinkService _breweryBeerLinkService;

        public BreweryBeerLinkController(IBreweryBeerLinkService breweryBeerLinkService)
        {
            _breweryBeerLinkService = breweryBeerLinkService;
        }

        [HttpPost("addbeertobrewery")]
        public IActionResult AddBeerToBrewery(BreweryBeerLink breweryBeerLink)
        {
            try
            {
                _breweryBeerLinkService.AddBeerToBrewery(breweryBeerLink.BreweryId, breweryBeerLink.BeerId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{breweryId}/beer")]
        public IActionResult GetBreweryWithBeers(int breweryId)
        {
            try
            {
                var brewery = _breweryBeerLinkService.GetBreweryWithBeers(breweryId);
                if (brewery == null)
                    return NotFound();

                return Ok(brewery);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
           
        }

        [HttpGet]
        [Route("beer")]
        public IActionResult GetBreweriesWithBeers()
        {
            try
            {
                var breweries = _breweryBeerLinkService.GetBreweriesWithBeers();
                return Ok(breweries);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }
    }
}
