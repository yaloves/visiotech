using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Visiotech_API.Data;
using Visiotech_API.Services;

namespace Visiotech_API.Controllers
{
    [Route("api")]
    [ApiController]
    public class GrapesController(IVisiotechService service, ILogger<GrapesController> logger) : ControllerBase
    {
        private readonly IVisiotechService _service = service;
        private readonly ILogger<GrapesController> _logger = logger;

        [HttpPost("grapes/area")]
        public async Task<ActionResult<Dictionary<string, double>>> GetTotalAreaByGrape()
        {
            try 
            {
                var result = await _service.GetTotalAreaByGrape();
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
