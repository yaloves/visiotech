using Microsoft.EntityFrameworkCore;
using Visiotech_API.Data;

namespace Visiotech_API.Extensions
{
    public static class StartUpExtensions
    {
        public static void UseDatabase(this IApplicationBuilder app)
        {
            try
            {
                using var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();
                using var context = serviceScope.ServiceProvider.GetRequiredService<PostgresDbContext>();
                context.Database.Migrate();
                context.SeedDatabase();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
