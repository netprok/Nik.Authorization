namespace NiC.Authorization.Models.Entities;

public sealed class Permission
{
    public string Id { get; set; } = Guid.NewGuid().ToString("N");
  
    public string PermissionName { get; set; } = string.Empty;
}