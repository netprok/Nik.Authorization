namespace Nik.Authorization;

public static class ServicesExtensions
{
    public static IServiceCollection AddNikAuthorization(this IServiceCollection services)
    {
        services.AddScoped<IUserLoader, UserLoader>();
        services.AddScoped<IAuthorizer, Authorizer>();

        return services;
    }
}