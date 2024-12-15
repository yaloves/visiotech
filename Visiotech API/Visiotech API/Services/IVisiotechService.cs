using Microsoft.AspNetCore.Mvc;

namespace Visiotech_API.Services
{
    public interface IVisiotechService
    {
        Task<IEnumerable<string>?> GetManagerIds();
        Task<Dictionary<string, List<string>>?> GetManagersByVineyard();
        Task<IEnumerable<string>?> GetManagersTaxNumbersSorted([FromQuery] bool sorted = false);
        Task<Dictionary<string, double>?> GetTotalAreaByGrape();
        Task<Dictionary<string, double>?> GetTotalAreaByManager();
    }
}