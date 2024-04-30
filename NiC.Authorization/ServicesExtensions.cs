[assembly: InternalsVisibleTo("NiC.Authentication.Seeder")]
[assembly: InternalsVisibleTo("NiC.Authentication.Api")]
[assembly: InternalsVisibleTo("NiC.Authentication.UnitTests")]

namespace NiC.Authorization;

internal static class ServicesExtensions
{
    public static IServiceCollection AddAuthorization(this IServiceCollection services)
    {
        services.AddScoped<IUserLoader, UserLoader>();
        services.AddScoped<IAuthorizer, Authorizer>();

        return services;
    }
}