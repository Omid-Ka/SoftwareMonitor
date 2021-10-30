using Core.DTO;
using Core.Interfaces;
using Core.ViewModels;
using Domain.Interfaces;
using Domain.Models.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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
                IsActive = x.IsActive,
                LocalTel = x.LocalTel,
                MobileNo = x.MobileNo,
                Post = x.PostId.HasValue ? _lookupRepository.GetByPk(x.PostId.Value).Description : ""
            });
        }

        public Users GetUserForLogin(string Username, string Password)
        {
            return _usersRepository.GetUserForLogin(Username, Password);
        }

        public bool HasUserWithUserName(string userName)
        {
            return _usersRepository.HasUserWithUserName(userName);
        }
        public bool HasUserWithNationalcode(string nationalCode)
        {
            return _usersRepository.HasUserWithNationalcode(nationalCode);
        }

        public bool HasUserWithPersonnelCode(int? personnelCode)
        {
            return _usersRepository.HasUserWithPersonnelCode(personnelCode);
        }

        public void AddUser(Users model,ClaimsPrincipal user)
        {
            _usersRepository.AddUser(model,user);
        }

        public void DeleteUser(int userId, ClaimsPrincipal user)
        {
            _usersRepository.DeleteUser(userId, user);
        }

        public Users GetUserById(int userId)
        {
            return  _usersRepository.GetUserById(userId);
        }

        public void EditUser(Users model, ClaimsPrincipal user)
        {
            _usersRepository.EditUser(model, user);
        }
    }
}
