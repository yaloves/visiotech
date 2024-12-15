using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using Visiotech_API.Data;
using Visiotech_API.Services;

namespace Visiotech_API.Controllers
{
    [Route("api")]
    [ApiController]
    public class ManagersController(IVisiotechService service, ILogger<ManagersController> logger) : ControllerBase
    {
        private readonly IVisiotechService _service = service;
        private readonly ILogger<ManagersController> _logger = logger;

        [HttpGet("managers/ids")]
        public async Task<ActionResult<IEnumerable<string>>> GetManagerIds()
        {
            try
            {
                var result = await _service.GetManagerIds();
                return result != null ?
                    Ok(result) :
                    NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "GetManagerIds error");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

        }

        [HttpGet("managers/taxnumbers")]
        public async Task<ActionResult<IEnumerable<string>>> GetManagersTaxNumbersSorted([FromQuery] bool sorted = false)
        {
            try
            {
                var result = await _service.GetManagersTaxNumbersSorted(sorted);
                return result != null ?
                    Ok(result) :
                    NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "GetManagersTaxNumbersSorted error");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost("managers/totalarea")]
        public async Task<ActionResult<Dictionary<string, int>>> GetTotalAreaByManager()
        {
            try
            {
                var result = await _service.GetTotalAreaByManager();
                return result != null ?
                    Ok(result) :
                    NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "GetTotalAreaByManager error");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
