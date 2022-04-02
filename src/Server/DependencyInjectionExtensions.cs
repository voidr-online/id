using VoidR.ID.Identity.Models;

namespace Microsoft.Extensions.DependencyInjection;

public static class DependencyInjectionExtensions
{
    public static IServiceCollection AddIdentity(this IServiceCollection services)
    {
        services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
            .AddIdentityStores();

        return services;
    } 
}
