using Core.DTO;
using Core.Interfaces;
using Domain.Interfaces;
using Domain.Models.Account;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Services
{
    public class UsersServices : IUsersService
    {
        private IUsersRepository _usersRepository;

        public UsersServices(IUsersRepository usersRepository)
        {
            this._usersRepository = usersRepository;
        }

        public Users GetUserForLogin(string Username, string Password)
        {
            return _usersRepository.GetUserForLogin(Username, Password);
        }
    }
}
