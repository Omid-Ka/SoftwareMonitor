using Core.DTO;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using Core.ViewModels;
using Domain.Models.Account;

namespace Core.Interfaces
{
    public interface IUsersService
    {
        Users GetUserForLogin(string Username);

        IEnumerable<UserVM> GetAllUsers();
        bool HasUserWithUserName(string userName);
        bool HasUserWithNationalcode(string nationalCode);
        bool HasUserWithPersonnelCode(int? personnelCode);
        void AddUser(Users model, ClaimsPrincipal user);
        void DeleteUser(int userId, ClaimsPrincipal user);
        Users GetUserById(int userId);
        void EditUser(Users model, ClaimsPrincipal user);
        bool IsDisable(ClaimsPrincipal user);
        bool ExistsEmail(string email);
        Users GetUserByEmail(string email);
        void UpdateUserPassword(Users currentUser);
    }
}
