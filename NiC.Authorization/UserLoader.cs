namespace NiC.Authorization;

public sealed class UserLoader(AuthorizationDbContext dbContext) : IUserLoader
{
    public Task<User> LoadByNameAsync(string username)
    {
        var filter = Builders<User>.Filter.Eq(s => s.Username, username);
        return dbContext.Users.Find(filter).FirstOrDefaultAsync();
    }

    public async Task<bool> UserExistsAsync(string username)
    {
        var filter = Builders<User>.Filter.Or(
            Builders<User>.Filter.Eq(user => user.Username, username)
        );

        var users = await dbContext.Users.Find(filter).ToListAsync();
        return users.Count > 0;
    }
}