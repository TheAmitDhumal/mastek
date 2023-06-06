using mastek.DBContext;
using mastek.Model;
using mastek.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace mastek.Controllers
{
    [Route("bar")]
    [ApiController]
    public class BarBeerLinkController : ControllerBase
    {
        private readonly IBarBeerLinkService _barBeerLinkService;

        public BarBeerLinkController(IBarBeerLinkService barBeerLinkService)
        {
            _barBeerLinkService = barBeerLinkService;
        }

        [HttpPost("addbeertobar")]
        public IActionResult AddBeerToBar(BarBeerLink barBeerLink)
        {
            try
            {
                _barBeerLinkService.AddBeerToBar(barBeerLink.BarId, barBeerLink.BeerId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{barId}/beer")]
        public IActionResult GetBarWithBeers(int barId)
        {
            try
            {
                var bar = _barBeerLinkService.GetBarWithBeers(barId);
                if (bar == null)
                    return NotFound();

                return Ok(bar);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        [HttpGet]
        [Route("beer")]
        public IActionResult GetBarsWithBeers()
        {
            try
            {
                var bars = _barBeerLinkService.GetBarsWithBeers();
                return Ok(bars);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }
    }
}
