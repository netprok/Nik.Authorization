﻿namespace NiC.Authorization.Abstractions;

public interface IAuthorizer
{
    Task<bool> AuthorizeAsync(AuthorizeModel authorizeModel);
}