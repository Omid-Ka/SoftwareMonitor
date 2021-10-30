using Core.DTO;
using Core.Interfaces;
using Core.ViewModels;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Domain.Models.Log;

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
    }
}
