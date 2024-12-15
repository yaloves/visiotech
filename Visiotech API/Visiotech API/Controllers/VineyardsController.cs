using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Visiotech_API.Data;

namespace Visiotech_API.Controllers
{
    [Route("api")]
    [ApiController]
    public class VineyardsController(PostgresDbContext context, ILogger<VineyardsController> logger) : ControllerBase
    {
        private readonly PostgresDbContext _context = context;
        private readonly ILogger<VineyardsController> _logger = logger;

        [HttpPost("vineyards/managers")]
        public async Task<ActionResult<Dictionary<string, int>>> GetManagersByVineyard()
        {
            try
            {
                var result = await _context.Vineyards
                    .Include(v => v.Parcels)
                        .ThenInclude(p => p.Manager)
                    .Select(v => new 
                    { 
                        VineyardName = v.Name, 
                        ManagerNames = v.Parcels.Select(p => p.Manager.Name).Distinct().OrderBy(n => n).ToList() 
                    }).ToDictionaryAsync(v => v.VineyardName, v => v.ManagerNames); 
                
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "GetManagersByVineyard error");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
