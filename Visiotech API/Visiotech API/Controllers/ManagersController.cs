using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Visiotech_API.Data;

namespace Visiotech_API.Controllers
{
    [Route("api")]
    [ApiController]
    public class ManagersController(PostgresDbContext context, ILogger<ManagersController> logger) : ControllerBase
    {
        private readonly PostgresDbContext _context = context;
        private readonly ILogger<ManagersController> _logger = logger;

        [HttpGet("managers/ids")]
        public async Task<ActionResult<IEnumerable<string>>> GetManagerIds()
        {
            try
            {
                var ids = await _context.Managers.Select(m => m.TaxNumber).ToListAsync();
                return Ok(ids);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "GetManagersTaxNumbersSorted error");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

        }

        [HttpGet("managers/taxnumbers")]
        public async Task<ActionResult<IEnumerable<string>>> GetManagersTaxNumbersSorted([FromQuery] bool sorted = false)
        {
            try
            {
                var managers = _context.Managers.AsQueryable();
                if (sorted)
                    managers = managers.OrderBy(m => m.Name);
                var taxNumbers = await managers.Select(m => m.TaxNumber).ToListAsync();
                return Ok(taxNumbers);
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
                var result = await _context.Managers
                    .Include(m => m.Parcels)
                    .Select(m => new { ManagerName = m.Name, TotalArea = m.Parcels.Sum(p => p.Area) })
                    .ToDictionaryAsync(m => m.ManagerName, m => m.TotalArea);

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "GetTotalAreaByManager error");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
