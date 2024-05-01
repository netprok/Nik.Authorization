namespace Nik.Authorization.Abstractions;

public interface IUserLoader
{
    Task<User> LoadByNameAsync(string username);

    Task<bool> UserExistsAsync(string username);
}