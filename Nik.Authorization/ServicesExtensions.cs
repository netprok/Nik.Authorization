namespace Nik.Authorization;

public static class ServicesExtensions
{
    public static IServiceCollection AddNiCAuthorization(this IServiceCollection services)
    {
        services.AddScoped<IUserLoader, UserLoader>();
        services.AddScoped<IAuthorizer, Authorizer>();

        return services;
    }
}