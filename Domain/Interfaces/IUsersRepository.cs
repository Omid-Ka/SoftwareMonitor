using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Domain.Models.Account;

namespace Domain.Interfaces
{
    public interface IUsersRepository
    {
        Users GetUserForLogin(string Username, string Password);
    }
}
