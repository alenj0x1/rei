using Rei.Infrastructure.Context;

namespace Rei.Presentation.Extensions;

public static class ServiceExtension
{
    public static void AddServiceExtension(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddNpgsql<ReiDbContext>(configuration.GetConnectionString("Database"));
    }    
}