namespace NiC.Authorization.Models.Entities;

public sealed class Role
{
    public string Id { get; set; } = Guid.NewGuid().ToString("N");

    public string RoleName { get; set; } = string.Empty;

    public List<string> PermissionNames { get; set; } = [];
}