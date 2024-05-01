namespace Nik.Authorization.Models.Entities;

public sealed class User
{
    public string Id { get; set; } = Guid.NewGuid().ToString("N");

    public string Username { get; set; } = string.Empty;

    public List<string> RoleNames { get; set; } = [];
}