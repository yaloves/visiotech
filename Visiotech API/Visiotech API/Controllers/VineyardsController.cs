using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Visiotech_API.Data;
using Visiotech_API.Services;

namespace Visiotech_API.Controllers
{
    [Route("api")]
    [ApiController]
    public class VineyardsController(VisiotechService service, ILogger<VineyardsController> logger) : ControllerBase
    {
        private readonly VisiotechService _service = service;
        private readonly ILogger<VineyardsController> _logger = logger;

        [HttpPost("vineyards/managers")]
        public async Task<ActionResult<Dictionary<string, List<string>>>> GetManagersByVineyard()
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
                _logger.LogError(ex, "GetManagersByVineyard error");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
