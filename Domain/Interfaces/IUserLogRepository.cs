using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Domain.Models.BaseInformation;
using Domain.Models.Log;
using Domain.Models.Enum;
using System.Security.Claims;

namespace Domain.Interfaces
{
    public interface IUserLogRepository
    {
        UserLog GetByPk(int id);
        string GetLastLoginUserId(int userId);
        void AddUserLog(ClaimsPrincipal user, UserLogType type);
        void AddEnterUserLog(int userid, string ipAddress, UserLogType type);
    }
}
