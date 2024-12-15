using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Visiotech_API.Data;
using Visiotech_API.Services;

namespace Visiotech_API.Controllers
{
    [Route("api")]
    [ApiController]
    public class GrapesController(VisiotechService service, ILogger<GrapesController> logger) : ControllerBase
    {
        private readonly VisiotechService _service = service;
        private readonly ILogger<GrapesController> _logger = logger;

        [HttpPost("grapes/area")]
        public async Task<ActionResult<Dictionary<string, int>>> GetTotalAreaByGrape()
        {
            try 
            {
                var result = await _service.GetManagersByVineyard();
                return result != null ?
                    Ok(result) :
                    NoContent();
            } 
            catch (Exception ex) 
            { 
                _logger.LogError(ex, "GetTotalAreaByGrape error"); 
                return StatusCode(StatusCodes.Status500InternalServerError); 
            }
        }
    }
}
