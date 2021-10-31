using Domain.Interfaces;
using Domain.Models;
using Domain.Models.BaseInformation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Domain.Models.Enum;
using Domain.Models.Log;
using Core.Helper;

namespace Data.Repository
{
    public class UserLogRepository : IUserLogRepository
    {
        private SoftwareMonitoringDBContext _SMContext;
        public UserLogRepository(SoftwareMonitoringDBContext SMContext)
        {
            this._SMContext = SMContext;
        }
        public UserLog GetByPk(int id)
        {
            return _SMContext.UserLogs.Find(id);
        }

        public string GetLastLoginUserId(int userId)
        {
            var data = _SMContext.UserLogs.Where(x =>
                x.IsActive && x.EntityId == userId && x.Type == UserLogType.Enter);
                

            return data.Any() ? data.OrderByDescending(x=>x.Id).Select(x=>x.DateInserted).FirstOrDefault().GetPrsianDate() : "";
        }

        public void AddUserLog(ClaimsPrincipal user, UserLogType type)
        {
            var userId = Convert.ToInt32(user.Claims.Where(x => x.Type == ClaimTypes.NameIdentifier).Select(x => x.Value)
                .FirstOrDefault());

            var model = new UserLog();
            model.IsActive = true;
            model.CreatorID = userId;
            model.DateInserted = DateTime.Now;
            model.IpAddress = user.Claims.Where(x => x.Type == "IpAddress").Select(x => x.Value)
                .FirstOrDefault();
            model.EntityType = "User";
            model.Type = type;
            model.EntityId = userId;


            _SMContext.Add(model);
            _SMContext.SaveChanges();
        }

        public void AddEnterUserLog(int userid, string ipAddress, UserLogType type)
        {

            var model = new UserLog();
            model.IsActive = true;
            model.CreatorID = userid;
            model.DateInserted = DateTime.Now;
            model.IpAddress = ipAddress;
            model.EntityType = "User";
            model.Type = type;
            model.EntityId = userid;


            _SMContext.Add(model);
            _SMContext.SaveChanges();
        }
    }
}
