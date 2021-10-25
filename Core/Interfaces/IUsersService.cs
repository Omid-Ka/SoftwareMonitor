using Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using Domain.Models.Account;

namespace Core.Interfaces
{
    public interface IUsersService
    {
        Users GetUserForLogin(string Username, string Password);
    }
}
