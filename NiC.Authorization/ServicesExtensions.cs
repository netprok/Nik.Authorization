[assembly: InternalsVisibleTo("NiC.Authorization.Seeder")]
[assembly: InternalsVisibleTo("NiC.Authorization.Api")]
[assembly: InternalsVisibleTo("NiC.Authorization.UnitTests")]

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