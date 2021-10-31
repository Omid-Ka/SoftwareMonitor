using Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using Core.ViewModels;
using Domain.Models.Log;
using Domain.Models.Enum;
using System.Security.Claims;

namespace Core.Interfaces
{
    public interface IUserLogService
    {
        UserLog GetByPk(int id);
        string GetLastLoginUserId(int userId);
        void AddUserLog(ClaimsPrincipal user, UserLogType enter);
        void AddEnterUserLog(int id, string ipAddress, UserLogType enter);
    }
}
