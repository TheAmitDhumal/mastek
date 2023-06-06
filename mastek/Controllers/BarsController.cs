using mastek.DBContext;
using mastek.Model;
using mastek.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace mastek.Controllers
{
    [Route("bar")]
    [ApiController]
    public class BarController : ControllerBase
    {
        private readonly IBarService _barService;

        public BarController(IBarService barService)
        {
            _barService = barService;
        }

        [HttpPost]
        public IActionResult AddBar([FromBody] Bar bar)
        {
            try
            {
                var createdBar = _barService.CreateBar(bar);
                return Ok(createdBar);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBar(int id, [FromBody] Bar bar)
        {
            try
            {
                var updatedBar = _barService.UpdateBar(id, bar);
                if (updatedBar == null)
                    return NotFound();

                return Ok(updatedBar);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public IActionResult GetBars()
        {
            try
            {
                var bars = _barService.GetBars();
                return Ok(bars);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
           
        }

        [HttpGet("{id}")]
        public IActionResult GetBar(int id)
        {
            try
            {
                var bar = _barService.GetBar(id);
                if (bar == null)
                    return NotFound();

                return Ok(bar);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }
    }
}
