[assembly: InternalsVisibleTo("Nik.Authorization.Seeder")]
[assembly: InternalsVisibleTo("Nik.Authorization.Api")]
[assembly: InternalsVisibleTo("Nik.Authorization.UnitTests")]

namespace Nik.Authorization;

internal static class ServicesExtensions
{
    public static IServiceCollection AddNiCAuthorization(this IServiceCollection services)
    {
        services.AddScoped<IUserLoader, UserLoader>();
        services.AddScoped<IAuthorizer, Authorizer>();

        return services;
    }
}