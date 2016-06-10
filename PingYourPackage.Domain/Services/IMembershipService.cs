﻿using PingYourPackage.Domain.Entities;
using System;
using System.Collections.Generic;

namespace PingYourPackage.Domain.Services
{
    public interface IMembershipService
    {
        ValidUserContext ValidateUser(string username, string password);

        OperationResult<UserWithRoles> CreateUser(string username, string email, string password);
        OperationResult<UserWithRoles> CreateUser(string username, string email, string password, string role);
        OperationResult<UserWithRoles> CreateUser(string username, string email, string password, string[] roles);

        UserWithRoles UpdateUser(User user, string username, string email);

        bool ChangePassword(string username, string oldPassword, string newPassword);

        bool AddToRole(Guid key, string role);
        bool AddToRole(string username, string role);
        bool RemoveFromRole(string username, string role);

        IEnumerable<Role> GetRoles();
        Role GetRole(Guid key);
        Role GetRole(string name);

        PaginatedList<UserWithRoles> GetUsers(int pageIndex, int pageSize);
        UserWithRoles GetUser(Guid key);
        UserWithRoles GEtUser(string name);
    }
}
