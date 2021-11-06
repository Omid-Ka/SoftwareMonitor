using Domain.Models;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using Domain.Models.Account;

namespace Domain.Interfaces
{
    public interface IUsersRepository
    {
        Users GetUserForLogin(string Username);

        IEnumerable<Users> GetAllUsers();
        bool HasUserWithUserName(string userName);
        bool HasUserWithNationalcode(string nationalCode);
        bool HasUserWithPersonnelCode(int? personnelCode);
        void AddUser(Users model, ClaimsPrincipal user);
        void DeleteUser(int userId, ClaimsPrincipal user);
        Users GetUserById(int userId);
        void EditUser(Users model, ClaimsPrincipal user);
        bool IsDisable(ClaimsPrincipal user);
        string GetFullNameById(int userid);
    }
}
