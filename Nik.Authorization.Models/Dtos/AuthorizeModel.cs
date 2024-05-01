namespace Nik.Authorization.Models.Dtos;

public sealed class AuthorizeModel
{
    public string Username { get; set; } = string.Empty;

    public string PermissionName { get; set; } = string.Empty;
}