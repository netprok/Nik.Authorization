namespace Nik.Authorization.Models.Db;

public class AuthorizationDbContext : DbContext
{
    private const string PermissionCollectionName = "permissions";
    private const string RegistrationCollectionName = "registrations";
    private const string RoleCollectionName = "roles";
    private const string UserCollectionName = "users";
    private readonly IMongoDatabase _mongoDatabase;

    public AuthorizationDbContext(string connectionString, string databaseName)
    {
        var client = new MongoClient(connectionString);
        _mongoDatabase = client.GetDatabase(databaseName);

        CreateIndices();
    }

    public IMongoCollection<Permission> Permissions => _mongoDatabase.GetCollection<Permission>(PermissionCollectionName);
    public IMongoCollection<Role> Roles => _mongoDatabase.GetCollection<Role>(RoleCollectionName);
    public IMongoCollection<User> Users => _mongoDatabase.GetCollection<User>(UserCollectionName);

    public async Task<bool> UpdateAsync(User user) =>
        (await Users.ReplaceOneAsync(doc => doc.Id == user.Id, user)).IsAcknowledged;

    private void CreateIndices()
    {
        var roleIndexModel = new CreateIndexModel<Role>(Builders<Role>
            .IndexKeys
            .Ascending(role => role.RoleName)
            , new CreateIndexOptions { Unique = true });
        Roles.Indexes.CreateOne(roleIndexModel);

        var permissionIndexModel = new CreateIndexModel<Permission>(Builders<Permission>
            .IndexKeys
            .Ascending(permission => permission.PermissionName)
            , new CreateIndexOptions { Unique = true });
        Permissions.Indexes.CreateOne(permissionIndexModel);

        var userIndexModel = new CreateIndexModel<User>(
            Builders<User>.IndexKeys.Ascending(user => user.Username),
            new CreateIndexOptions { Unique = true });
        Users.Indexes.CreateOne(userIndexModel);
    }
}