using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

using VoidR.ID.Infrastructure;

namespace Microsoft.Extensions.DependencyInjection;

public static class DependencyInjectionExtensions
{
    public static void AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddApplicationDbContext(configuration);
        
        // Is this the right place for this?
        services.AddDatabaseDeveloperPageExceptionFilter();
    }
    
    private static void AddApplicationDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
            // options.UseNpgsql(configuration[configuration["PostgreSQL:ConnectionStringPath"]]));
            options.UseNpgsql(configuration.GetValue<string>(configuration.GetSection("PostgreSQL")["ConnectionStringPath"])));
    }
    
    public static IdentityBuilder AddIdentityStores(this IdentityBuilder builder)
    {
        builder.AddEntityFrameworkStores<ApplicationDbContext>();
        return builder;
    } 
}
