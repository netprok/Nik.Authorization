namespace NiC.Authorization;

internal sealed class Authorizer(
    IUserLoader userLoader,
    ILogger<Authorizer> logger,
    AuthorizationDbContext dbContext) : IAuthorizer
{
    public async Task<bool> AuthorizeAsync(AuthorizeModel model)
    {
        var user = await userLoader.LoadByNameAsync(model.Username);
        if (user is null)
        {
            logger.LogWarning($"Unknown user {model.Username} tries to get use permission: {model.PermissionName}");
            return false;
        }

        try
        {
            var roleFilter = Builders<Role>.Filter.In(role => role.RoleName, user.RoleNames);

            var roles = dbContext.Roles.Find(roleFilter).ToList();
            var isAuthorized  =roles.SelectMany(role=>role.PermissionNames).Any(permissionName=>permissionName==model.PermissionName);

            if (!isAuthorized)
            {
                logger.LogWarning($"Unauthorized attempt of user: {model.Username} to permission: {model.PermissionName}");
            }

            return isAuthorized;
        }
        catch (Exception e)
        {
            logger.LogWarning(e, $"Error authorizing of user: {model.Username} to permission: {model.PermissionName}");
            return false;
        }
    }
}