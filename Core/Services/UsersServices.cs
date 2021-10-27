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
        private ILookupRepository _lookupRepository;

        public UsersServices(IUsersRepository usersRepository, ILookupRepository lookupRepository)
        {
            _usersRepository = usersRepository;
            _lookupRepository = lookupRepository;
        }
        public IEnumerable<UserVM> GetAllUsers()
        {
            return _usersRepository.GetAllUsers().Select(x => new UserVM()
            {
                Id = x.Id,
                Email = x.Email,
                Family = x.Family,
                Gender = _lookupRepository.GetByPk(x.GenderId).Description,
                Name = x.Name,
                NationalCode = x.NationalCode,
                Password = x.Password,
                PersonnelCode = x.PersonnelCode,
                UserName = x.UserName,
                IsActive = x.IsActive
            });
        }

        public Users GetUserForLogin(string Username, string Password)
        {
            return _usersRepository.GetUserForLogin(Username, Password);
        }
    }
}
