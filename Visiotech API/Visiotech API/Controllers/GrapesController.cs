using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Visiotech_API.Data;

namespace Visiotech_API.Controllers
{
    [Route("api")]
    [ApiController]
    public class GrapesController(PostgresDbContext context, ILogger<GrapesController> logger) : ControllerBase
    {
        private readonly PostgresDbContext _context = context;
        private readonly ILogger<GrapesController> _logger = logger;

        [HttpPost("grapes/area")]
        public async Task<ActionResult<Dictionary<string, int>>> GetTotalAreaByGrape()
        {
            try 
            { 
                var result = await _context.Grapes
                    .Include(g => g.Parcels)
                    .Select(g => new { GrapeName = g.Name, TotalArea = g.Parcels.Sum(p => p.Area) })
                    .ToDictionaryAsync(g => g.GrapeName, g => g.TotalArea); 
                
                return Ok(result); 
            } 
            catch (Exception ex) 
            { 
                _logger.LogError(ex, "GetTotalAreaByGrape error"); 
                return StatusCode(StatusCodes.Status500InternalServerError); 
            }
        }
    }
}
