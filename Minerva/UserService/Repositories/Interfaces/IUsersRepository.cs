﻿using Microsoft.AspNetCore.Identity;
using SharedLibrary.Entities;

namespace UserService.Repositories.Interfaces;

public interface IUsersRepository
{
    Task<User> GetUserAsync(string email);

    Task<IdentityResult> AddUserAsync(User user, string password);

    Task CheckRoleAsync(string roleName);

    Task AddUserToRoleAsync(User user, string roleName);

    Task<bool> IsUserInRoleAsync(User user, string roleName);
}