using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Visiotech_API.Controllers;
using Visiotech_API.Data;

namespace Visiotech_API.Services
{
    public class VisiotechService(PostgresDbContext context, ILogger<VisiotechService> logger) : IVisiotechService
    {
        private readonly PostgresDbContext _context = context;
        private readonly ILogger<VisiotechService> _logger = logger;

        public async Task<Dictionary<string, List<string>>?> GetManagersByVineyard()
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

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "GetManagersByVineyard error");
                return null;
            }
        }

        public async Task<IEnumerable<string>?> GetManagerIds()
        {
            try
            {
                var ids = await _context.Managers.Select(m => m.TaxNumber).ToListAsync();
                return ids;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "GetManagerIds error");
                return null;
            }
        }

        public async Task<IEnumerable<string>?> GetManagersTaxNumbersSorted([FromQuery] bool sorted = false)
        {
            try
            {
                var managers = _context.Managers.AsQueryable();
                if (sorted)
                    managers = managers.OrderBy(m => m.Name);
                var taxNumbers = await managers.Select(m => m.TaxNumber).ToListAsync();
                return taxNumbers;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "GetManagersTaxNumbersSorted error");
                return null;
            }
        }

        public async Task<Dictionary<string, double>?> GetTotalAreaByManager()
        {
            try
            {
                var result = await _context.Managers
                    .Include(m => m.Parcels)
                    .Select(m => new { ManagerName = m.Name, TotalArea = m.Parcels.Sum(p => p.Area) })
                    .ToDictionaryAsync(m => m.ManagerName, m => m.TotalArea);

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "GetTotalAreaByManager error");
                return null;
            }
        }

        public async Task<Dictionary<string, double>?> GetTotalAreaByGrape()
        {
            try
            {
                var result = await _context.Grapes
                    .Include(g => g.Parcels)
                    .Select(g => new { GrapeName = g.Name, TotalArea = g.Parcels.Sum(p => p.Area) })
                    .ToDictionaryAsync(g => g.GrapeName, g => g.TotalArea);

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "GetTotalAreaByGrape error");
                return null;
            }
        }
    }
}
