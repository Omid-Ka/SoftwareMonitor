using Core.DTO;
using Core.Interfaces;
using Core.ViewModels;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Domain.Models.Log;
using Domain.Models.Enum;
using System.Security.Claims;

namespace Core.Services
{
    public class UserLogServices : IUserLogService
    {
        private IUserLogRepository _userLogRepository;

        public UserLogServices(IUserLogRepository userLogRepository)
        {
            _userLogRepository = userLogRepository;
        }

        public UserLog GetByPk(int id)
        {
            var Model = _userLogRepository.GetByPk(id);

            return Model;
        }

        public string GetLastLoginUserId(int userId)
        {
            return _userLogRepository.GetLastLoginUserId(userId);
        }

        public void AddUserLog(ClaimsPrincipal user, UserLogType Type)
        {
            _userLogRepository.AddUserLog(user , Type);
        }

        public void AddEnterUserLog(int userid, string ipAddress, UserLogType Type)
        {
            _userLogRepository.AddEnterUserLog(userid, ipAddress, Type);
        }
    }
}
