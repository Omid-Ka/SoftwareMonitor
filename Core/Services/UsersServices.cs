using Core.DTO;
using Core.Interfaces;
using Core.ViewModels;
using Domain.Interfaces;
using Domain.Models.Account;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public IEnumerable<UserVM> GetAllUsers()
        {
            return _usersRepository.GetAllUsers().Select(x => new UserVM()
            {
                Id = x.Id,
                Email = x.Email,
                Family = x.Family,
                //Gender = x.Gender.Description,
                Name = x.Name,
                NationalCode = x.NationalCode,
                Password = x.Password,
                PersonnelCode = x.PersonnelCode,
                UserName = x.UserName
            });
        }

        public Users GetUserForLogin(string Username, string Password)
        {
            return _usersRepository.GetUserForLogin(Username, Password);
        }
    }
}
