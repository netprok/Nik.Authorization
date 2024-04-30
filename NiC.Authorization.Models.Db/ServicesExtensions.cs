namespace NiC.Authorization.Models.Db;

public static class ServicesExtensions
{
    private const string AuthorizationConnectionSettingsName = "AuthorizationMongoDB";
    private const string AuthorizationDbSettingsName = "DatabaseSettings:DatabaseName";

    public static IServiceCollection ConfigureAuthorizationMongoDb(this IServiceCollection services)
    {
        var mongoConnectionString = Context.Configuration.GetConnectionString(AuthorizationConnectionSettingsName);
        var databaseName = Context.Configuration[AuthorizationDbSettingsName];

        services.AddSingleton(new AuthorizationDbContext(mongoConnectionString!, databaseName!));

        return services;
    }
}