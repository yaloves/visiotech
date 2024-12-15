using System.Data.Common;

namespace Visiotech_API.Models
{
    public class AppConfiguration
    {        
        public string ConnectionString { get; set; }

        public AppConfiguration(IConfiguration config)
        {
            ConnectionString = Environment.GetEnvironmentVariable("DB_CONNECTIONSTRING") ?? config.GetConnectionString("Api") ?? string.Empty;
        }
    }
}
