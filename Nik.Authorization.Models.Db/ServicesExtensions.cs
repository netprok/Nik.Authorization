namespace Nik.Authorization.Models.Db;

public static class ServicesExtensions
{
    private const string AuthorizationConnectionSettingsName = "AuthorizationMongoDB";
    private const string AuthorizationDbSettingsName = "DatabaseSettings:AuthorizationDatabaseName";

    public static IServiceCollection ConfigureNikAuthorizationMongoDb(this IServiceCollection services)
    {
        var mongoConnectionString = Context.Configuration.GetConnectionString(AuthorizationConnectionSettingsName);
        var databaseName = Context.Configuration[AuthorizationDbSettingsName];

        services.AddSingleton(new AuthorizationDbContext(mongoConnectionString!, databaseName!));

        return services;
    }
}